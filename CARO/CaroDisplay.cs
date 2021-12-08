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
using System.Media;
namespace CARO
{
    public partial class CaroDisplay : Form
    {

        #region Properties
        Chess_control ChessBoard;
        Connection socket;
        #endregion

        private int mode = 0; // = 1: đánh với người, = 0 đánh với máy
        DataTable sv = new DataTable();
        public CaroDisplay()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
            ChessBoard = new Chess_control(chessboard_pnl,player0_name,player1_name,player0_symboy,player1_symboy);
            ChessBoard.EndedGame += ChessBoard_EndedGame;
            ChessBoard.Player_Click += ChessBoard_Player_Click;
            socket = new Connection();

            //database serve
            
            
        }
        private void SoundClick()
        {
            string pat = "D:\\C#\\shiba_C#\\clickbutton.wav";
            SoundPlayer vov = new SoundPlayer();
            vov.SoundLocation = pat;
            vov.Load();
            vov.Play();
        }
        private void CaroDisplay_Load(object sender, EventArgs e)
        {
            //player0_image.Image = ChessBoard.Player[0].Avata;
            //player0_name.Text = ChessBoard.Player[0].Name;
            //player0_symboy.Text = ChessBoard.Player[0].Symboy;

            //player1_image.Image = ChessBoard.Player[1].Avata;
            //player1_name.Text = ChessBoard.Player[1].Name;
            //player1_symboy.Text = ChessBoard.Player[1].Symboy;

            
           
        }

        
        void NewGame()
        {
            
            
                ChessBoard.draw_banco();
           
            
          
                foreach (Control Button in chessboard_pnl.Controls)
                {
                    Button.BackgroundImage = null;
                    //Button.BackColor = Color.White;
                    Button.Tag = "";
                }
           
            
        }

        void Undo()
        {

        }

        void EndGame()
        {
            timer_play.Stop();
            foreach (Control x in chessboard_pnl.Controls)
            {
                if (Convert.ToString(x.Tag) != "X" && Convert.ToString(x.Tag) != "O")
                {
                    x.Click -= ChessBoard.danhco;
                }
            }
            if (ChessBoard.changePlayer == 1)
            {
                MessageBox.Show("Hảo Hán\nBạn Đã Thắng!", "Thông Báo", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Gà\nBạn Đã Thua!", "Thông Báo", MessageBoxButtons.OK);
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
                MessageBox.Show("Hết thời gian\nBạn Đã Thua! Gà", "Thông Báo", MessageBoxButtons.OK);
            }
       
        }
       
        private void ChessBoard_Player_Click(object sender, ChessClickEvent e)
        {
            
            this.Invoke((MethodInvoker)(() =>
            {
                if(e.ClickedPoint == new Point(20,20))
                {

                }
                else
                {
                    foreach (Control x in chessboard_pnl.Controls)
                    {
                        if (Convert.ToString(x.Tag) != "X" && Convert.ToString(x.Tag) != "O")
                        {
                            x.Click -= ChessBoard.danhco;
                        }
                    }
                    progressBar_left.Value = 0;
                    progressBar_right.Value = 0;
                    timer_play.Start();

                    
                }
                
            }));

            if (mode == 1)
            {
                try
                {
                    socket.Send(new DataTrans((int)SocketCommand.POINT_TRANS, "", ChessBoard.Player[0].Sb, e.ClickedPoint));
                    Listen();
                }
                catch
                {

                }
                check_symboy();
            }
            else if (mode == 0)
            {
                //máy đánh
                foreach (Control x in chessboard_pnl.Controls)
                {
                    if (Convert.ToString(x.Tag) != "X" && Convert.ToString(x.Tag) != "O")
                    {
                        x.Click -= ChessBoard.danhco;
                    }
                }
                ChessBoard.computer_play();
            }
            
        }

    
        private void ChessBoard_EndedGame(object sender, EventArgs e)
        {
            if(mode == 0)
            {
                update_status.Text = "Máy đã sẵn sàng...";
                update_status.ForeColor = Color.Green;
                ready.Text = "Bắt Đầu";
                ready.Visible = true;
                
            }
            else if(mode == 1)
            {
                update_status.Text = "Đang chờ đối thủ...";
                update_status.ForeColor = Color.Red;
                ready.BackColor = Color.Transparent;
                if(ready.Text == "Sẵn Sàng")
                {                  
                    ready.Visible = true;
                }
                else if(ready.Text == "Bắt Đầu")
                {
                    ready.Visible = false;
                }
               
            }
            Status_pnl.Visible = true;
        }
      

        private void timer_play_Tick(object sender, EventArgs e)
        {
            this.Invoke((MethodInvoker)(() =>
            {                
                if (ChessBoard.ChangePlayer == 0)
                {
                    progressBar_left.PerformStep();
                    progressBar_left.Visible = true;
                    progressBar_right.Visible = false;
                    progressBar_right.Value = 0;
                }
                else if (ChessBoard.ChangePlayer == 1)
                {
                    progressBar_right.PerformStep();
                    progressBar_right.Visible = true;
                    progressBar_left.Visible = false;
                    progressBar_left.Value = 0;
                }
                if (progressBar_left.Value >= progressBar_left.Maximum)
                {

                    MessageBox.Show(player0_name + " hết thời gian/n" + player1_name + " đã thắng!", "Thông báo", MessageBoxButtons.OK);
                    timer_play.Stop();
                }
                else if (progressBar_right.Value >= progressBar_right.Maximum)
                {

                    MessageBox.Show(player1_name + " hết thời gian/n" + player0_name + " đã thắng!", "Thông báo", MessageBoxButtons.OK);
                    timer_play.Stop();
                }
            }));
            

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
                    socket.Send(new DataTrans((int)SocketCommand.QUIT, "Đối phương đã mất kết nối!", ChessBoard.Player[0].Sb, new Point()));
                    NewGame();
                    Listen();
                }
                catch
                {
                    NewGame();
                }
                socket = null;
                
            }
            
        }
        private void exit_game(object sender, EventArgs e)
        {
            DialogResult dlg = MessageBox.Show("Rời khỏi phòng!", "Thông báo", MessageBoxButtons.OKCancel);
            if(dlg == DialogResult.OK)
            {
                timer_play.Stop();

                progressBar_left.Value = 0;
                progressBar_right.Value = 0;

                out_room_btn.Visible = false;
                maphong.Visible = false;
                label_maphong.Visible = false;
                try
                {
                    socket.Send(new DataTrans((int)SocketCommand.QUIT, "Đối phương đã rời khỏi phòng!", ChessBoard.Player[0].Sb, new Point()));
                    NewGame();
                    Listen();
                }
                catch
                {
                    NewGame();
                }
                socket = null;
            }
            
            
    

            

        }

        private void option_btn_Click(object sender, EventArgs e)
        {
            Option_pnl.Visible = Option_pnl.Visible == true ? false : true;
        }
        private void out_room_btn_VisibleChanged(object sender, EventArgs e)
        {
            if (out_room_btn.Visible == false)
            {
                control_pnl.Visible = true;
            }
            else
            {
                control_pnl.Visible = false;
            }
        }
        private void regime_chose(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if(btn.Text == person.Text)
            {
                mode = 1;
                person.BackColor = Color.LimeGreen;
                computer.BackColor = Color.White;

                update_status.Text = "Đang chờ đối thủ...";
                update_status.ForeColor = Color.Red;

                search_btn.Visible = true;
                search_roomid.Visible = true;
                addRoom_btn.Visible = true;
            }
            else
            {
                mode = 0;
                person.BackColor = Color.White;
                computer.BackColor = Color.LimeGreen;

                ready.Text = "Bắt Đầu";
                ready.Visible = true;
                update_status.Text = "Máy đã sẵn sàng...";
                update_status.ForeColor = Color.Green;

                search_btn.Visible = false;
                search_roomid.Visible = false;
                addRoom_btn.Visible = false;
            }
        }
        private void CaroDisplay_Shown(object sender, EventArgs e)
        {
            maphong.Tag = socket.GetLocalIPv4(NetworkInterfaceType.Wireless80211).ToString();
            maphong.Text = IPtoRoomID(maphong.Tag.ToString());
            if (string.IsNullOrEmpty(maphong.Tag.ToString()))
            {
                maphong.Tag = socket.GetLocalIPv4(NetworkInterfaceType.Ethernet);

            }
          
        }
        private void save_option_btn_Click(object sender, EventArgs e)
        {
            Status_pnl.Visible = true;

            player1_name.Visible = true;
            player1_symboy.Visible = true;
            player1_image.Visible = true;
            Option_pnl.Visible = false;     
        }

        private void addRoom_btn_Click(object sender, EventArgs e)
        {
            this.Invoke((MethodInvoker)(() =>
            {            
                if (addRoom_btn.Text == "Tạo Phòng")
                {
                    socket.IP = maphong.Tag.ToString();

                    if (!socket.ConnectServe())
                    {
                        socket.CrateServe();
                        timer_sever.Start();
                    }

                    ready.Text = "Bắt Đầu";
                    ready.Enabled = false;
                    Status_pnl.Visible = true;
                    out_room_btn.Visible = true;
                    maphong.Visible = true;
                    label_maphong.Visible = true;
                    Option_pnl.Visible = false;
                    foreach (Control x in chessboard_pnl.Controls)
                    {
                        if (Convert.ToString(x.Tag) != "X" && Convert.ToString(x.Tag) != "O")
                        {
                            x.Click -= ChessBoard.danhco;
                        }
                    }
                }
                else if (addRoom_btn.Text == "Tìm Phòng")
                {
                    search_button_Click(sender, e);
                }
            }));

            Listen();
      
        }

        private void timer_sever_Tick(object sender, EventArgs e)
        {
            flag();
        }
        private void search_roomid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                search_button_Click(sender, e);
            }
        }
        public void flag()
        {
            SoundClick();
            ChessBoard_Player_Click(new object(), new ChessClickEvent(new Point(20, 20)));
        }
      
        private void search_button_Click(object sender, EventArgs e)
        {
            
            this.Invoke((MethodInvoker)(() =>
            {
                
                
                if (search_roomid.Text.Length == 8)
                {
                    string ip = RoomIDtoIP(search_roomid.Text);

                    socket.IP = ip.ToString();

                    if (!socket.ConnectServe())
                    {
                        MessageBox.Show("Phòng Không Tồn Tại\nCoi Lại Đi Ba!", "Thông Báo", MessageBoxButtons.OK);
                        search_roomid.Focus();
                    }
                    else
                    {                      
                        player1_name.Text = player0_name.Text;
                        player0_symboy.Image = player0_symboy.Image;
                        
                        foreach (Control x in chessboard_pnl.Controls)
                        {
                            if (Convert.ToString(x.Tag) != "X" && Convert.ToString(x.Tag) != "O")
                            {
                                x.Click -= ChessBoard.danhco;
                            }
                        }
                        ready.Text = "Sẵn Sàng";
                        ready.Enabled = true;
                        Status_pnl.Visible = true;
                        out_room_btn.Visible = true;
                        maphong.Visible = true;
                        label_maphong.Visible = true;
                        Option_pnl.Visible = false;

                        player1_image.Visible = true;
                        player1_name.Visible = true;
                        player1_symboy.Visible = true;
                        
                        try
                        {
                            socket.Send(new DataTrans((int)SocketCommand.NOTIFY, ChessBoard.Player[0].Name, ChessBoard.Player[0].Sb, new Point()));
                            Listen();
                        }
                        catch
                        {

                        }
                   

                    }

                }
                else
                {
                    MessageBox.Show("Mã phòng không hợp lệ\nNhập lại dùm cái đi!", "Thông báo", MessageBoxButtons.OK);
                    search_roomid.Focus();
                }
            }));
   
           
            
        }
        public string RoomIDtoIP(string roomid)
        {
            string str1 = roomid.Substring(0, 3);
            string str2 = roomid.Substring(3, 3);
            string str3 = roomid.Substring(6, 1);
            string str4 = roomid.Substring(7, 1);

            string ip = str1 + "." + str2 + "." + str3 + "." + str4;
            return ip;
        }
        public string IPtoRoomID(string ip)
        {
            string roomid = ip.Replace(".", "");
            return roomid;
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
       
        void check_symboy()
        {
            foreach (Control x in chessboard_pnl.Controls)
            {
                if (x.BackgroundImage != ChessBoard.Player[0].Symboy && x.BackgroundImage != ChessBoard.Player[1].Symboy&& x.BackgroundImage != null)
                {
                    x.BackgroundImage = ChessBoard.Player[0].Symboy;
                }
            }
        }
        void SendName()
        {
            SoundClick();
            try
            {
                socket.Send(new DataTrans((int)SocketCommand.NAME, ChessBoard.Player[0].Name, ChessBoard.Player[0].Sb, new Point()));
                //Listen();
            }
            catch
            {

            }
        }
        private void ProcessData(DataTrans data)
        {
            switch(data.Command)
            {
                case (int)SocketCommand.NOTIFY:
                    this.Invoke((MethodInvoker)(() =>
                    {
                        player1_name.Text = data.Message;
                        player1_image.Visible = true;
                        player1_name.Visible = true;
                        player1_symboy.Visible = true;
                        SendName();                      
                    }));                   
                    break;
                case (int)SocketCommand.NAME:
                    this.Invoke((MethodInvoker)(() =>
                    {
                        player0_name.Text = data.Message;
                        if (data.Img == Convert.ToString(x_symboy.Tag))
                        {
                           
                            ChessBoard.Player[0].Symboy = x_symboy.BackgroundImage;
                            ChessBoard.Player[1].Symboy = o_symboy.BackgroundImage;                         
                        }
                        else if (data.Img == Convert.ToString(o_symboy.Tag))
                        {
                            
                            ChessBoard.Player[0].Symboy = o_symboy.BackgroundImage;
                            ChessBoard.Player[1].Symboy = x_symboy.BackgroundImage;
                        }
                        else if (data.Img == Convert.ToString(play_symboy.Tag))
                        {
                            
                            ChessBoard.Player[0].Symboy = play_symboy.BackgroundImage;
                            ChessBoard.Player[1].Symboy = pause_symboy.BackgroundImage;
                        }
                        else if (data.Img == Convert.ToString(pause_symboy.Tag))
                        {
                           
                            ChessBoard.Player[0].Symboy = pause_symboy.BackgroundImage;
                            ChessBoard.Player[1].Symboy = play_symboy.BackgroundImage;
                        }
                        else if (data.Img == Convert.ToString(sword_symboy.Tag))
                        {
                            ChessBoard.Player[0].Symboy = sword_symboy.BackgroundImage;
                            ChessBoard.Player[1].Symboy = shield_symboy.BackgroundImage;
                        }
                        else if (data.Img == Convert.ToString(shield_symboy.Tag))
                        {
                            ChessBoard.Player[0].Symboy = shield_symboy.BackgroundImage;
                            ChessBoard.Player[1].Symboy = sword_symboy.BackgroundImage;
                        }
                        player0_symboy.Image = ChessBoard.Player[0].Symboy;
                        player1_symboy.Image = ChessBoard.Player[1].Symboy;

                    }));
                    
                    break;
                case (int)SocketCommand.POINT_TRANS:
                    this.Invoke((MethodInvoker)(() =>
                    {
                        if(data.Point == new Point(20,20))
                        {
                            //mới vào phòng //fix bug không cập nhật được tên
                        }
                        else
                        {
                            foreach (Control x in chessboard_pnl.Controls)
                            {
                                if (Convert.ToString(x.Tag) != "X" && Convert.ToString(x.Tag) != "O")
                                {
                                    x.Click += ChessBoard.danhco;
                                }
                            }

                            ChessBoard.SendChess(data.Point);
                            timer_play.Start();
                        }
                              
                    }));                   
                    break;
                case (int)SocketCommand.READY:
                    this.Invoke((MethodInvoker)(() =>
                    {
                        update_status.Text = data.Message + " đã sẵn sàng...";
                        update_status.ForeColor = Color.LimeGreen;
                    }));
                    
                    break;
                case (int)SocketCommand.NEW_GAME:
                    this.Invoke((MethodInvoker)(() =>
                    {
                        Status_pnl.Visible = false;
                        NewGame();
                        foreach(Control x in chessboard_pnl.Controls)
                        {
                            if (Convert.ToString(x.Tag) != "X" && Convert.ToString(x.Tag) != "O")
                            {
                                x.Click -= ChessBoard.danhco;
                            }
                        }
                        MessageBox.Show("Bạn đánh sau nhé! Người ta là chủ phòng mà :>", "Thông báo", MessageBoxButtons.OK);
                    }));
                    
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
                    socket = null;
                    NewGame();
                    break;
                default:
                    break;
            }

            Listen();
        }

        

        private void search_roomid_TextChanged(object sender, EventArgs e)
        {
            if(search_roomid.Text!="")
            {
                addRoom_btn.Text = "Tìm Phòng";
            }
            else
            {
                addRoom_btn.Text = "Tạo Phòng";
            }
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            About ab = new About();
            ab.Show();
        }

        private void ruleToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Chose_symboy(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            x_symboy.BackColor = Color.Transparent;
            o_symboy.BackColor = Color.Transparent;
            play_symboy.BackColor = Color.Transparent;
            pause_symboy.BackColor = Color.Transparent;
            sword_symboy.BackColor = Color.Transparent;
            shield_symboy.BackColor = Color.Transparent;
            btn.BackColor = Color.White;
            ChessBoard.Player[0].Symboy = btn.BackgroundImage;
            ChessBoard.Player[0].Sb = btn.Tag.ToString();
            if (x_symboy.BackColor == Color.White)
            {
                ChessBoard.Player[1].Symboy = o_symboy.BackgroundImage;
                ChessBoard.Player[1].Sb = o_symboy.Tag.ToString();
            }
            else if(o_symboy.BackColor == Color.White)
            {
                ChessBoard.Player[1].Symboy = x_symboy.BackgroundImage;
                ChessBoard.Player[1].Sb = x_symboy.Tag.ToString();
            }
            else if (play_symboy.BackColor == Color.White)
            {
                ChessBoard.Player[1].Symboy = pause_symboy.BackgroundImage;
                ChessBoard.Player[1].Sb = pause_symboy.Tag.ToString();
            }
            else if (pause_symboy.BackColor == Color.White)
            {
                ChessBoard.Player[1].Symboy = play_symboy.BackgroundImage;
                ChessBoard.Player[1].Sb = play_symboy.Tag.ToString();
            }
            else if (sword_symboy.BackColor == Color.White)
            {
                ChessBoard.Player[1].Symboy = shield_symboy.BackgroundImage;
                ChessBoard.Player[1].Sb = shield_symboy.Tag.ToString();
            }
            else if (shield_symboy.BackColor == Color.White)
            {
                ChessBoard.Player[1].Symboy = sword_symboy.BackgroundImage;
                ChessBoard.Player[1].Sb = sword_symboy.Tag.ToString();
            }
            
        }

        private void start_game(object sender, EventArgs e)
        {
            ChessBoard.Player[0].Name = ingame.Text;
            player0_name.Text = ChessBoard.Player[0].Name;
            player0_symboy.Image = ChessBoard.Player[0].Symboy;
            player1_name.Text = ChessBoard.Player[1].Name;
            player1_symboy.Image = ChessBoard.Player[1].Symboy;

            player0_image.Visible = true;
            player0_name.Visible = true;
            player0_symboy.Visible = true;
            player1_symboy.Visible = true;

            start_pnl.Visible = false;

        }

       
        private void ready_Click(object sender, EventArgs e)
        {
            this.Invoke((MethodInvoker)(() =>
            {
                if(mode==1)
                {
                    if (ready.Text == "Sẵn Sàng")
                    {
                        ready.BackColor = Color.Green;
                        socket.Send(new DataTrans((int)SocketCommand.READY, ChessBoard.Player[0].Name, ChessBoard.Player[0].Sb, new Point()));

                    }
                    else if (ready.Text == "Bắt Đầu")
                    {
                        ready.BackColor = Color.Green;
                        NewGame();
                        socket.Send(new DataTrans((int)SocketCommand.NEW_GAME, ChessBoard.Player[0].Name, ChessBoard.Player[0].Sb, new Point()));
                        Status_pnl.Visible = false;
                        MessageBox.Show("Bạn đánh trước!:>", "Thông báo", MessageBoxButtons.OK);
                    }
                }
                else if(mode == 0)
                {
                    ready.BackColor = Color.Green;
                    NewGame();
                    Status_pnl.Visible = false;
                    MessageBox.Show("Bạn đánh trước!:>", "Thông báo", MessageBoxButtons.OK);
                }
                
            }));
            

            Listen();
            
        }

        private void update_status_TextChanged(object sender, EventArgs e)
        {
            this.Invoke((MethodInvoker)(() =>
            {
                if (update_status.Text.Contains("đã"))
                {
                    ready.Enabled = true;
                }
            }));
            
        }

        private void undo_btn_Click(object sender, EventArgs e)
        {
            NewGame();
        }
    }
}
