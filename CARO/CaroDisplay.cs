using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CARO
{
    public partial class CaroDisplay : Form
    {

        #region Properties
        Chess_control ChessBoard;
        Connection socket;
        #endregion

        DataTable sv = new DataTable();
        public CaroDisplay()
        {
            InitializeComponent();
            ChessBoard = new Chess_control(chessboard_pnl);
            ChessBoard.EndedGame += ChessBoard_EndedGame;
            ChessBoard.Player_Click += ChessBoard_Player_Click;
            socket = new Connection();

            ChessBoard.draw_banco();

            //database serve
            
            sv.Columns.Add("MaPhong", typeof(string));
            sv.Columns.Add("Address", typeof(string));
            
        }

        private void CaroDisplay_Load(object sender, EventArgs e)
        {
            player0_image.Image = ChessBoard.Player[0].Avata;
            player0_name.Text = ChessBoard.Player[0].Name;
            player0_symboy.Text = ChessBoard.Player[0].Symboy;

            player1_image.Image = ChessBoard.Player[1].Avata;
            player1_name.Text = ChessBoard.Player[1].Name;
            player1_symboy.Text = ChessBoard.Player[1].Symboy;

            ListServe();
           
        }

        void ListServe()
        {
            sv.Rows.Add("19522174", "195.168.1.5");
            sv.Rows.Add("12345678", "192.168.1.6");

        }
        void NewGame()
        {
            foreach (Control Button in chessboard_pnl.Controls)
            {
                Button.Text = "";
            }
        }

        void Undo()
        {

        }

        void EndGame()
        {
            timer_play.Stop();
            //chessboard_pnl.Enabled = false;
            if (ChessBoard.changePlayer == 1)
            {
                //alert_wl.Text = "Bên trái win";
            }
            else
            {
                //alert_wl.Text = "Bên trái thua";
            }
            
        }

        void TimeOut()
        {
            timer_play.Stop();
           
            if (ChessBoard.changePlayer == 1)
            {              
                MessageBox.Show("Đối phương hết thời gian\nBạn Đã Thắng!", "Thông Báo", MessageBoxButtons.OK);
            }
            else
            {               
                MessageBox.Show("Hết thời gian\nBạn Đã Thua!", "Thông Báo", MessageBoxButtons.OK);
            }
       
        }
        void Quit()
        {
            
        }

        private void ChessBoard_Player_Click(object sender, ChessClickEvent e)
        {
            this.Invoke((MethodInvoker)(() =>
            {
                //chessboard_pnl.Enabled = false;
                progressBar_left.Value = 0;
                progressBar_right.Value = 0;
                timer_play.Start();
            }));

            if(person.BackColor==Color.LimeGreen)
            {
                try
                {
                    socket.Send(new DataTrans((int)SocketCommand.POINT_TRANS, "", e.ClickedPoint));
                    Listen();
                }
                catch
                {

                }
                
            }
            
        }

        private void ChessBoard_EndedGame(object sender, EventArgs e)
        {
            
            try
            {
                socket.Send(new DataTrans((int)SocketCommand.END_GAME, "", new Point()));
            }
            catch
            {
                EndGame();
            }
            
        }
      

        private void timer_play_Tick(object sender, EventArgs e)
        {
            this.Invoke((MethodInvoker)(() =>
            {
                if (ChessBoard.ChangePlayer == 0)
                {
                    progressBar_left.PerformStep();
                    progressBar_right.Value = 0;
                }
                else if (ChessBoard.ChangePlayer == 1)
                {
                    progressBar_right.PerformStep();
                    progressBar_left.Value = 0;
                }
                if (progressBar_left.Value >= progressBar_left.Maximum)
                {
                    TimeOut();

                    try
                    {
                        socket.Send(new DataTrans((int)SocketCommand.TIME_OUT, "Đối phương hết thời gian\nBạn Đã Thắng!", new Point()));
                        Listen();
                    }
                    catch
                    {
                        
                    }
                    
                }
                else if (progressBar_right.Value >= progressBar_right.Maximum)
                {
                    TimeOut();
                   
                    try
                    {
                        socket.Send(new DataTrans((int)SocketCommand.TIME_OUT, "Hết thời gian\nBạn Đã Thua", new Point()));
                        Listen();
                    }
                    catch
                    {
                       
                    }
                }
            }));
            

        }

        //private void fight_btn_Click(object sender, EventArgs e)
        //{
        //    foreach (Control Button in chessboard_pnl.Controls)
        //    {
        //        Button.Text = "";
        //    }

        //    progressBar_left.Value = 0;
        //    progressBar_right.Value = 0;
   
        //}

       

        private void gg_btn_Click(object sender, EventArgs e)
        {
            //alert_wl.Text = ChessBoard.Player[ChessBoard.ChangePlayer].Name.ToString() + " GG";
            //WinLose_pnl.Visible = true;
        }

        private void close_game(object sender, FormClosingEventArgs e)
        {
            DialogResult dlg = MessageBox.Show("Bạn có chắc chắn muốn thoát", "Thông báo", MessageBoxButtons.OKCancel);
            if (dlg != DialogResult.OK)
            {
                e.Cancel = true;
            }
            else
            {
                try
                {
                    socket.Send(new DataTrans((int)SocketCommand.QUIT, "Đối phương đã rời khỏi phòng!", new Point()));
                    Listen();
                }
                catch
                {
                    NewGame();
                }
                
            }
            
        }
        private void exit_game(object sender, EventArgs e)
        {
            DialogResult dlg = MessageBox.Show("Rời khỏi phòng!", "Thông báo", MessageBoxButtons.OKCancel);
            if(dlg == DialogResult.OK)
            {               
                try
                {
                    socket.Send(new DataTrans((int)SocketCommand.QUIT, "Đối phương đã mất kết nối!", new Point()));
                    Listen();
                }
                catch
                {
                    NewGame();
                }
            }
            
            
    

            timer_play.Stop();
            foreach (Control Button in chessboard_pnl.Controls)
            {
                Button.Text = "";
            }

            progressBar_left.Value = 0;
            progressBar_right.Value = 0;
           
        }

        private void option_btn_Click(object sender, EventArgs e)
        {
            Option_pnl.Visible = true;
        }

        private void regime_chose(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if(btn.Text == person.Text)
            {
                person.BackColor = Color.LimeGreen;
                computer.BackColor = Color.Red;

                maphong.Visible = true;
                label_maphong.Visible = true;
            }
            else
            {
                person.BackColor = Color.Red;
                computer.BackColor = Color.LimeGreen;

                maphong.Visible = false;
                label_maphong.Visible = false;              
            }
        }
        private void CaroDisplay_Shown(object sender, EventArgs e)
        {
            maphong.Tag = socket.GetLocalIPv4(NetworkInterfaceType.Wireless80211).ToString();
            if (string.IsNullOrEmpty(maphong.Tag.ToString()))
            {
                maphong.Tag = socket.GetLocalIPv4(NetworkInterfaceType.Ethernet);

            }
            //DataRow[] dt = sv.Select("MaPhong= '" + maphong.Text + "'");
            //maphong.Tag = dt[0]["Address"].ToString();
        }
        private void save_option_btn_Click(object sender, EventArgs e)
        {
            Option_pnl.Visible = false;
            if (person.BackColor == Color.LimeGreen) 
            {
                socket.IP = maphong.Tag.ToString();

                if (!socket.ConnectServe())
                {
                    socket.CrateServe();
                }
                else
                {
                    MessageBox.Show("đã vào phòng");
                    try
                    {                      
                        socket.Send(new DataTrans((int)SocketCommand.NOTIFY, "kêt noi thanh công", new Point()));
                        Listen();
                    }
                    catch
                    {

                    }
                    
                    //đợi người chơi vào phòng 19522174
                }
            }
            else
            {
               
            }
            

        }
        void Listen()  
        {
            Thread listenThread = new Thread(() =>
            {
                try
                {
                    DataTrans data = (DataTrans)socket.Receive();
                    ProcessData(data);
                }
                catch
                {
                    
                }
            });
            listenThread.IsBackground = true;
            listenThread.Start();
        }

        private void ProcessData(DataTrans data)
        {
            switch(data.Command)
            {
                case (int)SocketCommand.NOTIFY:
                    MessageBox.Show("ket noi");
                    break;
                case (int)SocketCommand.POINT_TRANS:
                    this.Invoke((MethodInvoker)(() =>
                    {
                        ChessBoard.SendChess(data.Point);
                        timer_play.Start();
                        chessboard_pnl.Enabled = true;
                    }));                   
                    break;
                case (int)SocketCommand.NEW_GAME:

                    break;
                case (int)SocketCommand.END_GAME:
                    EndGame();
                    MessageBox.Show(data.Message);
                    break;
                case (int)SocketCommand.TIME_OUT:
                    MessageBox.Show(data.Message,"Thông báo", MessageBoxButtons.OK);
                    break;
                case (int)SocketCommand.QUIT:
                    timer_play.Stop();
                    MessageBox.Show(data.Message, "Thông báo", MessageBoxButtons.OK);
                    NewGame();
                    break;
                default:
                    break;
            }

            Listen();
        }

        
    }
}
