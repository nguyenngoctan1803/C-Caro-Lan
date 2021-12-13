using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CARO
{
    public class Connection
    {
        #region Client
        public Socket client;
        public bool ConnectServe()
        {
            IPEndPoint iep = new IPEndPoint(IPAddress.Parse(IP), PORT);
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                client.Connect(iep);
                return true;
            }
            catch
            {
                return false;
            }
            
        }
        #endregion
        #region serve

        public Socket serve;
        public void CrateServe()
        {
            try
            {
                IPEndPoint iep = new IPEndPoint(IPAddress.Parse(IP), PORT);
                serve = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                serve.Bind(iep);
                serve.Listen(10);

                Thread acceptClient = new Thread(() =>
                {
                    client = serve.Accept();
                });
                acceptClient.IsBackground = true;
                acceptClient.Start();
            }
            catch { }
            
        }
        #endregion
        #region Both
        public string IP = "127.0.0.1";
        public int PORT = 8000;
        public bool isServe = true;
        public const int countData = 1024;
        public bool Send(object data)
        {
            byte[] datasend = SeriaLizeData(data);

            return SendData(client, datasend);
        }
        public object Receive()
        {
            byte[] datareceive = new byte[countData];
            bool ok = ReceiveData(client, datareceive);
            return DeseriaLizeData(datareceive);
        }
        public bool SendData(Socket target, byte[] data)
        {
            return target.Send(data) == 1 ? true : false;
        }
        public bool ReceiveData(Socket target, byte[] data)
        {
            return target.Receive(data) == 1 ? true : false;
        }
        // Chuyển byte[] thành dữ liệu
        public byte[] SeriaLizeData(object o)
        {
            MemoryStream ms = new MemoryStream();
            BinaryFormatter bf1 = new BinaryFormatter();
            bf1.Serialize(ms, o);
            return ms.ToArray();
        }
        // Chuyển dữ liệu thành byte[]
        public object DeseriaLizeData(byte[] theByteAray)
        {
            MemoryStream ms = new MemoryStream(theByteAray);
            BinaryFormatter bf1 = new BinaryFormatter();
            ms.Position = 0;
            return bf1.Deserialize(ms);
        }
        // Lấy ra ip của máy đang dùng
        public string GetLocalIPv4(NetworkInterfaceType _type)
        {
            string output = "";
            foreach (NetworkInterface item in NetworkInterface.GetAllNetworkInterfaces())
            {
                if(item.NetworkInterfaceType == _type && item.OperationalStatus == OperationalStatus.Up)
                {
                    foreach(UnicastIPAddressInformation ip in item.GetIPProperties().UnicastAddresses)
                    {
                        if(ip.Address.AddressFamily == AddressFamily.InterNetwork)
                        {
                            output = ip.Address.ToString();
                        }
                    }
                }
            }
            return output;
        }

        #endregion
    }
}
