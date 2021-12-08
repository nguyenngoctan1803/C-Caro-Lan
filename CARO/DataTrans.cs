using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARO
{
    [Serializable]
    public class DataTrans
    {
        private int command;
        private Point point;
        private string message;
        private string img;
        //private int nOTIFY;
        //private string v;

        public int Command { get => command; set => command = value; }
        public Point Point { get => point; set => point = value; }
        public string Message { get => message; set => message = value; }
        public String Img { get => img; set => img = value; }

        public DataTrans(int command,string message,string img, Point point)
        {
            this.Command = command;
            this.Message = message;
            this.Point = point;
            this.Img = img;
        }
      
    }
    public enum SocketCommand
    {
        POINT_TRANS,
        NOTIFY,
        NAME,
        READY,
        NEW_GAME,
        END_GAME,
        TIME_OUT,
        QUIT
    }
}
