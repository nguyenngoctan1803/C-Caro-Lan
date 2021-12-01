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
        private int nOTIFY;
        private string v;

        public int Command { get => command; set => command = value; }
        public Point Point { get => point; set => point = value; }
        public string Message { get => message; set => message = value; }

        public DataTrans(int command,string message, Point point)
        {
            this.Command = command;
            this.Message = message;
            this.Point = point;
        }
      
    }
    public enum SocketCommand
    {
        POINT_TRANS,
        NOTIFY,
        NEW_GAME,
        END_GAME,
        TIME_OUT,
        QUIT
    }
}
