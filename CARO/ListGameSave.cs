using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CARO
{
    public partial class ListGameSave : Form
    {
        public ListGameSave()
        {
            InitializeComponent();
        }
        public object UIParent
        {
            set;
            get;
        }
        private void save_btn_Click(object sender, EventArgs e)
        {
            Button btn = new Button();
            btn.Width = 1000;
            btn.Height = 1000;
            btn.FlatStyle = FlatStyle.Flat;
            btn.TextAlign = ContentAlignment.BottomCenter;
            btn.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            btn.ForeColor = Color.Black;
            btn.BackgroundImageLayout = ImageLayout.Stretch;
            btn.Text = name_save.Text;
            btn.Click += opengame;         
            if (UIParent is CaroDisplay)
            {
                CaroDisplay cr = UIParent as CaroDisplay;
                cr.sound_click();
                cr.SaveGame(btn.Text);
                if (cr.chessboard_pnl.BackgroundImage == null)
                {
                    btn.BackgroundImage = CARO.Properties.Resources.hinhnen2;
                }
                else
                {
                    btn.BackgroundImage = cr.chessboard_pnl.BackgroundImage;
                }
            }          
            Panel_Savegame.Controls.Add(btn);
        }

        public void opengame(object sender,EventArgs e)
        {
            Button btn = (Button)sender;
            if (UIParent is CaroDisplay)
            {
                CaroDisplay cr = UIParent as CaroDisplay;
                cr.sound_clickk();
                cr.OpenGame(btn);
            }
        }

        private void ListGameSave_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void ListGameSave_Load(object sender, EventArgs e)
        {
            string thumuc = "D://C#savegame";
            string[] filegame = Directory.GetFiles(thumuc);
            foreach( var file in filegame)
            {
                Button btn = new Button();
                btn.Width = 1000;
                btn.Height = 1000;
                btn.FlatStyle = FlatStyle.Flat;
                btn.TextAlign = ContentAlignment.BottomCenter;
                btn.Font = new Font("Segoe UI", 18, FontStyle.Bold);
                btn.ForeColor = Color.Black;
                btn.BackgroundImageLayout = ImageLayout.Stretch;
                btn.BackgroundImage = CARO.Properties.Resources.hinhnencaro;
                btn.Text = Path.GetFileNameWithoutExtension(file);
                btn.Click += opengame;              
                Panel_Savegame.Controls.Add(btn);
            }
        }
    }
}
