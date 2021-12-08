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
        private Image symboy;
        private string sb;
        public string Name { get => name; set => name = value; }
        public Image Symboy { get => symboy; set => symboy = value; }
        public string Sb { get => sb; set => sb = value; }

        public Player(string name, Image symboy, string sb)
        {
            this.Name = name;
            this.Symboy = symboy;
            this.Sb = sb;        
        }
    }
}
