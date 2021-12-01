 using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARO
{
    public class Player
    {
        private string name;
        private string symboy;
        private Image avata;
        public string Name { get => name; set => name = value; }
        public string Symboy { get => symboy; set => symboy = value; }
        public Image Avata { get => avata; set => avata = value; }

        public Player(string name, string symboy, Image avata)
        {
            this.Name = name;
            this.Symboy = symboy;
            this.Avata = avata;        }
    }
}
