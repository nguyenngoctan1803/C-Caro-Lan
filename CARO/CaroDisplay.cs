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
using System.IO;

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
        
        private void CaroDisplay_Load(object sender, EventArgs e)
        {
            sound_music();
        }

        
        void NewGame()
        {
            ChessBoard.draw_banco();
            //ChessBoard.ChangePlayer = 0;

            foreach (Control Button in chessboard_pnl.Controls)
            {
                Button.BackgroundImage = null;
                Button.BackColor = Color.Transparent;
                Button.Tag = "";
            }
        }

        void Undo()
        {
            ChessBoard.Undo();
        }

        void EndGame()
        {
            this.Invoke((MethodInvoker)(() =>
            {
                timer_play.Stop();
                progressBar_left.Value = 0;
                progressBar_right.Value = 0;
                progressBar_left.Visible = false;
                progressBar_right.Visible = false;
            }));
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
                if (e.ClickedPoint == new Point(20, 20))
                {

                }
                else
                {
                    sound_click();
                    progressBar_left.Value = 0;
                    progressBar_right.Value = 0;
                    timer_play.Start();
                    check_symboy();
                    if (mode == 1)
                    {
                        //người đánh
                        foreach (Control x in chessboard_pnl.Controls)
                        {
                            if (Convert.ToString(x.Tag) != "X" && Convert.ToString(x.Tag) != "O")
                            {
                                x.Click -= ChessBoard.danhco;
                            }
                        }
                        
                    }
                    else if (mode == 0)
                    {
                        // máy đánh
                        foreach (Control x in chessboard_pnl.Controls)
                        {
                            if (Convert.ToString(x.Tag) != "X" && Convert.ToString(x.Tag) != "O")
                            {
                                x.Click -= ChessBoard.danhco;
                            }
                        }

                        ChessBoard.computer_play();
                        sound_clickk();
                    }
                }
                try
                {
                    socket.Send(new DataTrans((int)SocketCommand.POINT_TRANS, "", ChessBoard.Player[0].Sb, e.ClickedPoint));
                    Listen();
                }
                catch
                {

                }
            }));

            
            
        }

        //thắng thua 5 chess
        private void ChessBoard_EndedGame(object sender, EventArgs e)
        {          
            timer_play.Stop();
            progressBar_left.Value = 0;
            progressBar_right.Value = 0;
            progressBar_left.Visible = false;
            progressBar_right.Visible = false;
            if (mode == 0)
            {                           
                update_status.Text = "Máy đã sẵn sàng...";
                update_status.ForeColor = Color.Green;
                ready.Text = "Bắt Đầu";
                ready.Enabled = true;   
                if(ChessBoard.ChangePlayer == 1)
                {
                    sound_win();
                    MessageBox.Show(player0_name.Text + " Đã Thắng!", "Thông Báo", MessageBoxButtons.OK);
                    
                }
                else
                {
                    sound_lose();
                    MessageBox.Show(player1_name.Text + " Đã Thắng!", "Thông Báo", MessageBoxButtons.OK);
                }
                ChessBoard.ChangePlayer = 0;
            }
            else if(mode == 1)
            {
                
                update_status.Text = "Đang chờ đối thủ...";
                update_status.ForeColor = Color.Red;
                ready.BackColor = Color.Transparent;
                if(ready.Text == "Sẵn Sàng")
                {                  
                    ready.Enabled = true;
                    update_status.Text = player0_name.Text + " đang chờ bạn sẵn sàng...";
                }
                else if(ready.Text == "Bắt Đầu")
                {
                    ready.Enabled = false;
                    update_status.Text ="Đang chờ " + player1_name.Text + " sẵn sàng...";
                }
                if (ChessBoard.ChangePlayer == 1)
                {
                    if(player0_name.Text == ChessBoard.Player[0].Name)
                    {
                        sound_win();
                        Rank rk = new Rank();
                        rk.Update_Score(player0_name.Text);
                    }
                    else
                    {
                        sound_lose();
                    }
                    MessageBox.Show(player0_name.Text + " Đã Thắng!\n.........................", "Thông Báo", MessageBoxButtons.OK);
                    socket.Send(new DataTrans((int)SocketCommand.END_GAME, player1_name + " Đã Thua!\nGà.......................", ChessBoard.Player[0].Sb, new Point()));
                }
                else
                {
                    if (player1_name.Text == ChessBoard.Player[0].Name)
                    {
                        sound_win();
                        Rank rk = new Rank();
                        rk.Update_Score(player1_name.Text);
                    }
                    else
                    {
                        sound_lose();
                    }
                    MessageBox.Show(player1_name.Text + " Đã Thắng!\n.........................", "Thông Báo", MessageBoxButtons.OK);
                    socket.Send(new DataTrans((int)SocketCommand.END_GAME, player0_name + " Đã Thua!\nGà.......................", ChessBoard.Player[0].Sb, new Point()));
                }

            }
            Status_pnl.Visible = true;
           
            Listen();
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
                    timer_play.Stop();
                    progressBar_left.Value = 0;
                    progressBar_right.Value = 0;
                    progressBar_left.Visible = false;
                    progressBar_right.Visible = false;
                    if (mode == 0)
                    {
                        sound_lose();
                        update_status.Text = "Máy đã sẵn sàng...";
                        update_status.ForeColor = Color.Green;
                        ready.Text = "Bắt Đầu";
                        ready.Enabled = true;
                        MessageBox.Show(player0_name.Text + " hết thời gian\n" + player1_name.Text + " đã thắng!", "Thông báo", MessageBoxButtons.OK);
                    }
                    else if (mode == 1)
                    {
                        update_status.Text = "Đang chờ đối thủ...";
                        update_status.ForeColor = Color.Red;
                        ready.BackColor = Color.Transparent;
                        if (ready.Text == "Sẵn Sàng")
                        {
                            ready.Enabled = true;
                            update_status.Text = player0_name.Text + " đang chờ bạn sẵn sàng...";
                        }
                        else if (ready.Text == "Bắt Đầu")
                        {
                            ready.Enabled = false;
                            update_status.Text = "Đang chờ " + player1_name.Text + " sẵn sàng...";
                        }
                        
                        if(ChessBoard.ChangePlayer == 0)
                        {
                            if (player1_name.Text == ChessBoard.Player[0].Name)
                            {
                                
                                Rank rk = new Rank();
                                rk.Update_Score(player1_name.Text);
                                sound_win();
                            }
                            else
                            {
                                sound_lose();
                            }

                            socket.Send(new DataTrans((int)SocketCommand.END_GAME, player0_name + " Đã Thua!\nGà.......................", ChessBoard.Player[0].Sb, new Point()));
                        }
                        MessageBox.Show(player0_name.Text + " hết thời gian\n" + player1_name.Text + " đã thắng!", "Thông báo", MessageBoxButtons.OK);
                        
                    }
                    Status_pnl.Visible = true;

                }
                else if (progressBar_right.Value >= progressBar_right.Maximum)
                {
                    timer_play.Stop();
                    progressBar_left.Value = 0;
                    progressBar_right.Value = 0;
                    progressBar_left.Visible = false;
                    progressBar_right.Visible = false;
                    if (mode == 0)
                    {
                        sound_win();
                        update_status.Text = "Máy đã sẵn sàng...";
                        update_status.ForeColor = Color.Green;
                        ready.Text = "Bắt Đầu";
                        ready.Enabled = true;
                        MessageBox.Show(player1_name.Text + " hết thời gian\n" + player0_name.Text + " đã thắng!", "Thông báo", MessageBoxButtons.OK);
                    }
                    else if (mode == 1)
                    {

                        update_status.Text = "Đang chờ đối thủ...";
                        update_status.ForeColor = Color.Red;
                        ready.BackColor = Color.Transparent;
                        if (ready.Text == "Sẵn Sàng")
                        {
                            ready.Enabled = true;
                            update_status.Text = player0_name.Text + " đang chờ bạn sẵn sàng...";
                        }
                        else if (ready.Text == "Bắt Đầu")
                        {
                            ready.Enabled = false;
                            update_status.Text = "Đang chờ " + player1_name.Text + " sẵn sàng...";
                        }
                        if (ChessBoard.ChangePlayer == 1)
                        {
                            if (player0_name.Text == ChessBoard.Player[0].Name)
                            {
                                
                                Rank rk = new Rank();
                                rk.Update_Score(player0_name.Text);
                                sound_win();
                            }
                            else
                            {
                                sound_lose();
                            }

                            socket.Send(new DataTrans((int)SocketCommand.END_GAME, player1_name + " Đã Thua!\nGà.......................", ChessBoard.Player[0].Sb, new Point()));
                        }
                        
                        MessageBox.Show(player1_name.Text + " hết thời gian\n" + player0_name.Text + " đã thắng!", "Thông báo", MessageBoxButtons.OK);                      

                    }
                    
                    Status_pnl.Visible = true;
                }
                
            }));
            

        }
       

        private void close_game(object sender, FormClosingEventArgs e)
        {
            this.Invoke((MethodInvoker)(() =>
            {
                sound_click();
                DialogResult dlg = MessageBox.Show("Bạn có chắc chắn muốn thoát", "Thông báo", MessageBoxButtons.OKCancel);
                if (dlg != DialogResult.OK)
                {
                    e.Cancel = true;
                }
                else
                {
                    timer_sever.Stop();
                    try
                    {
                        socket.Send(new DataTrans((int)SocketCommand.OUT_ROOM, "Đối phương đã mất kết nối!", ChessBoard.Player[0].Sb, new Point()));                     
                        Listen();
                    }
                    catch
                    {
                      
                    }
                    NewGame();

                }

            }));


        }
        private void exit_game(object sender, EventArgs e)
        {
            this.Invoke((MethodInvoker)(() =>
            {
                sound_click();
                DialogResult dlg = MessageBox.Show("Rời khỏi phòng!", "Thông báo", MessageBoxButtons.OKCancel);
                if (dlg == DialogResult.OK)
                {
                    timer_play.Stop();
                    //timer_sever.Stop();   //ngừng fix bug

                    progressBar_left.Value = 0;
                    progressBar_right.Value = 0;
                    progressBar_left.Visible = false;
                    progressBar_right.Visible = false;

                    out_room_btn.Visible = false;
                    maphong.Visible = false;
                    label_maphong.Visible = false;
                    Status_pnl.Visible = true;
                    Option_pnl.Visible = true;

                    ChessBoard.Player[0].Name = ChessBoard.Player[2].Name;
                    ChessBoard.Player[0].Symboy = ChessBoard.Player[2].Symboy;
                    ChessBoard.Player[0].Sb = ChessBoard.Player[2].Sb;
                    ChessBoard.Player[1].Name = ChessBoard.Player[3].Name;
                    ChessBoard.Player[1].Symboy = ChessBoard.Player[3].Symboy;
                    ChessBoard.Player[1].Sb = ChessBoard.Player[3].Sb;

                    player0_name.Text = ChessBoard.Player[0].Name;
                    player0_symboy.Image = ChessBoard.Player[0].Symboy;

                    player0_image.Visible = true;
                    player0_name.Visible = true;
                    player0_symboy.Visible = true;
                    player1_image.Visible = false;
                    player1_name.Visible = false;
                    player1_symboy.Visible = true;
                    player1_name.Text = ChessBoard.Player[3].Name;
                    player1_symboy.Image = ChessBoard.Player[3].Symboy;
                   
                    try
                    {
                        socket.Send(new DataTrans((int)SocketCommand.OUT_ROOM, "Đối phương đã rời khỏi phòng!", ChessBoard.Player[0].Sb, new Point()));
                        NewGame();
                        
                    }
                    catch
                    {
                        NewGame();
                    }

                }

                Listen();
                socket.IP = "";
            }));

            
        }

        private void option_btn_Click(object sender, EventArgs e)
        {
            sound_click();
            Status_pnl.Visible = true;
            Option_pnl.Visible = Option_pnl.Visible == true ? false : true;
            if (progressBar_left.Value==0 && progressBar_right.Value == 0)
            {
                save_option_btn.Text = "OK";
            }
            else
            {
                save_option_btn.Text = "Continue";
            }
            
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
            sound_click();
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

                saveToolStripMenuItem.Enabled = false;
                openToolStripMenuItem.Enabled = false;
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
            sound_clickk();
            if (save_option_btn.Text == "OK")
            {
                Status_pnl.Visible = true;          
            }
            else
            {
                Status_pnl.Visible = false;
            }
            player1_name.Visible = true;
            player1_symboy.Visible = true;
            player1_image.Visible = true;
            Option_pnl.Visible = false;
        }

        private void addRoom_btn_Click(object sender, EventArgs e)
        {
            this.Invoke((MethodInvoker)(() =>
            {
                sound_clickk();
                timer_play.Stop();
                progressBar_right.Value = 0;
                progressBar_left.Value = 0;
                player0_name.Visible = true;
                player0_symboy.Visible = true;
                player0_image.Visible = true;
                player1_name.Visible = false;
                player1_symboy.Visible = true;
                player1_image.Visible = false;
                progressBar_left.Visible = false;
                progressBar_right.Visible = false;
                //socket.serve.Accept();
                if (addRoom_btn.Text == "Tạo Phòng")
                {
                    socket.IP = maphong.Tag.ToString();

                    if (!socket.ConnectServe())
                    {
                        socket.CrateServe();
                    }
                    timer_sever.Start();
                    ready.Text = "Bắt Đầu";
                    ready.Enabled = false;
                    chat_left.Visible = true;
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
                    chat_right.Visible = true;
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
            ChessBoard_Player_Click(new object(), new ChessClickEvent(new Point(20, 20)));
        }
      
        private void search_button_Click(object sender, EventArgs e)
        {
            
            this.Invoke((MethodInvoker)(() =>
            {

                sound_clickk();
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
                        player1_symboy.Image = player0_symboy.Image;
                        
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
                            MessageBox.Show("close");
                            socket.Send(new DataTrans((int)SocketCommand.NOTIFY, ChessBoard.Player[0].Name, ChessBoard.Player[0].Sb, new Point()));                          
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

                Listen();

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
                if (x.BackgroundImage != ChessBoard.Player[0].Symboy && x.BackgroundImage != ChessBoard.Player[1].Symboy && x.BackgroundImage != null)
                {
                    x.BackgroundImage = ChessBoard.Player[0].Symboy;
                }
            }
        }
        void SendName()
        {
            try
            {
                socket.Send(new DataTrans((int)SocketCommand.NAME, ChessBoard.Player[0].Name, ChessBoard.Player[0].Sb, new Point()));  
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
                        sound_welcome();
                        player1_name.Text = data.Message;
                        ChessBoard.Player[1].Name = data.Message;
                        update_status.Text = "Đang chờ " + data.Message + " sẵn sàng...";
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
                        ChessBoard.Player[1].Name = data.Message;
                        update_status.Text = data.Message + " đang chờ bạn sẵn sàng...";
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
                            sound_clickk();
                            foreach (Control x in chessboard_pnl.Controls)
                            {
                                if (Convert.ToString(x.Tag) != "X" && Convert.ToString(x.Tag) != "O")
                                {
                                    x.Click -= ChessBoard.danhco;
                                }
                                if (Convert.ToString(x.Tag) != "X" && Convert.ToString(x.Tag) != "O")
                                {
                                    x.Click += ChessBoard.danhco;
                                }
                            }
                            timer_play.Start();
                            ChessBoard.SendChess(data.Point);
                            
                        }
                              
                    }));                   
                    break;
                case (int)SocketCommand.READY:
                    this.Invoke((MethodInvoker)(() =>
                    {
                        sound_clickk();
                        update_status.Text = data.Message + " đã sẵn sàng...";
                        update_status.ForeColor = Color.LimeGreen;
                    }));
                    
                    break;
                case (int)SocketCommand.NEW_GAME:
                    this.Invoke((MethodInvoker)(() =>
                    {
                        sound_clickk();
                        Status_pnl.Visible = false;
                        NewGame();
                        if(ChessBoard.ChangePlayer == 0)
                        {
                            foreach (Control x in chessboard_pnl.Controls)
                            {

                                if (Convert.ToString(x.Tag) != "X" && Convert.ToString(x.Tag) != "O")
                                {
                                    x.Click -= ChessBoard.danhco;
                                }
                            }
                            MessageBox.Show("Bạn đánh sau nhé! :>", "Thông báo", MessageBoxButtons.OK);
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
                            MessageBox.Show("Bạn đánh trước nhé! :>", "Thông báo", MessageBoxButtons.OK);
                        }
                        
                    }));
                    
                    break;
                case (int)SocketCommand.END_GAME:
                    EndGame();              
                    break;
                case (int)SocketCommand.TIME_OUT:
                    MessageBox.Show(data.Message,"Thông báo", MessageBoxButtons.OK);
                    break;
                case (int)SocketCommand.OUT_ROOM:
                    sound_clickk();
                    timer_play.Stop();
                    ready.Enabled = false;
                    ready.Text = "Bắt Đầu";
                    Status_pnl.Visible = true;
                    out_room_btn.Visible = true;
                    maphong.Visible = true;
                    label_maphong.Visible = true;
                    update_status.Text = "Đang chờ đối thủ...";
                    update_status.ForeColor = Color.Red;
                    Option_pnl.Visible = false;
                    progressBar_right.Value = 0;
                    progressBar_left.Value = 0;
                    player0_name.Visible = true;
                    player0_symboy.Visible = true;
                    player0_image.Visible = true;
                    player0_name.Text = ChessBoard.Player[0].Name;
                    player0_symboy.Image = ChessBoard.Player[0].Symboy;
                    player1_name.Visible = false;
                    player1_symboy.Visible = true;
                    player1_image.Visible = false;
                    progressBar_left.Visible = false;
                    progressBar_right.Visible = false;
                    player1_name.Text = ChessBoard.Player[3].Name;
                    player1_symboy.Image = ChessBoard.Player[3].Symboy;
                    foreach (Control x in chessboard_pnl.Controls)
                    {
                        if (Convert.ToString(x.Tag) != "X" && Convert.ToString(x.Tag) != "O")
                        {
                            x.Click -= ChessBoard.danhco;
                        }
                    }

                    MessageBox.Show(data.Message, "Thông báo", MessageBoxButtons.OK);
                    NewGame();
                    break;
                case (int)SocketCommand.CHAT:
                    this.Invoke((MethodInvoker)(() =>
                    {
                        if (chat_left.Visible == true)
                        {
                            show_chatright.Text = data.Message;
                            show_chatright.Visible = true;
                            timerright.Start();
                        }
                        else if (chat_right.Visible == true)
                        {
                            show_chatleft.Text = data.Message;
                            show_chatleft.Visible = true;
                            timerleft.Start();
                        }
                    }));
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
            //thông tin
            sound_click();
            About ab = new About();
            ab.Show();
        }

        private void ruleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //luật chơi
            sound_click();
            Rule ru = new Rule();
            ru.Show();

        }
        ListGameSave sg = new ListGameSave();
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sound_click();         
            sg.UIParent = this;
            sg.control_savegame.Visible = true;
            sg.Show();

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sound_click();
            sg.UIParent = this;
            sg.control_savegame.Visible = false;
            sg.Show();
        }
        public void SaveGame(string str)
        {
            //lưu txt với tên được đặt
            string thumuc = "D://C#savegame";
            if (!Directory.Exists(thumuc))
            {
                System.IO.Directory.CreateDirectory(thumuc);
            }
            string filePath = thumuc + "//" + str + ".txt";
            string chess = "";
            //chuyển bàn cờ thành file .txt
            foreach (Control x in chessboard_pnl.Controls)
            {
                if (x.Tag.ToString() == "")
                {                   
                    chess += "a";
                }
                else if (x.Tag.ToString() == "X")
                {
                    chess += "X";
                }
                else if (x.Tag.ToString() == "O")
                {
                    chess += "O";
                }
                chess += " ";
            }

            File.WriteAllText(filePath, chess);
        }
        public void OpenGame(Button btn)
        {
            //chuyển .txt thành bán cờ
            timer_play.Stop();
            progressBar_left.Value = 0;
            progressBar_right.Value = 0;
            progressBar_left.Visible = false;
            progressBar_right.Visible = false;
            string thumuc = "D://C#savegame";           
            string filePath = thumuc + "//" + btn.Text + ".txt";
            string chess = File.ReadAllText(filePath);
            string[] ches = chess.Split(' ');
            int i = 0;
            foreach(Control x in chessboard_pnl.Controls)
            {
                if(ches[i].ToString()=="a")
                {
                    x.Tag = "";
                }
                else if(ches[i].ToString()=="X")
                {
                    x.Tag = "X";
                    x.BackgroundImage = ChessBoard.Player[0].Symboy;
                }
                else if (ches[i].ToString() == "O")
                {
                    x.Tag = "O";
                    x.BackgroundImage = ChessBoard.Player[1].Symboy;
                }
                i += 1;
            }

            sg.Hide();
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Chose_symboy(object sender, EventArgs e)
        {
            sound_clickk();
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
            sound_clickk();
            ChessBoard.Player[0].Name = ingame.Text;
            player0_name.Text = ChessBoard.Player[0].Name;
            player0_symboy.Image = ChessBoard.Player[0].Symboy;

            //lưu lại vào Player[2]
            ChessBoard.Player[2].Name = ChessBoard.Player[0].Name;
            ChessBoard.Player[2].Symboy = ChessBoard.Player[0].Symboy;
            ChessBoard.Player[2].Sb = ChessBoard.Player[0].Sb;
            //máy
            ChessBoard.Player[3].Symboy = ChessBoard.Player[1].Symboy;
            ChessBoard.Player[3].Sb = ChessBoard.Player[1].Sb;
            //
            player1_name.Text = ChessBoard.Player[1].Name;
            player1_symboy.Image = ChessBoard.Player[1].Symboy;

            player0_image.Visible = true;
            player0_name.Visible = true;
            player0_symboy.Visible = true;
            player1_symboy.Visible = true;

            Option_pnl.Visible = true;
            start_pnl.Visible = false;

            Rank rk = new Rank();
            rk.add_Player(ingame.Text);

        }

       
        private void ready_Click(object sender, EventArgs e)
        {
            this.Invoke((MethodInvoker)(() =>
            {
                sound_clickk();
                timer_play.Stop();
                progressBar_left.Value = 0;
                progressBar_right.Value = 0;
                if(mode==1)
                {
                    if (ready.Text == "Sẵn Sàng")
                    {
                        update_status.Text = "Đã Sẵn Sàng!...";
                        update_status.ForeColor = Color.LimeGreen;
                        socket.Send(new DataTrans((int)SocketCommand.READY, ChessBoard.Player[0].Name, ChessBoard.Player[0].Sb, new Point()));
                    }
                    else if (ready.Text == "Bắt Đầu")
                    {
                        //ready.BackColor = Color.Green;
                        NewGame();
                        socket.Send(new DataTrans((int)SocketCommand.NEW_GAME, ChessBoard.Player[0].Name, ChessBoard.Player[0].Sb, new Point()));
                        Status_pnl.Visible = false;
                        if (ChessBoard.ChangePlayer == 0)
                        {
                            MessageBox.Show("Bạn đánh trước nhé!:>", "Thông báo", MessageBoxButtons.OK);
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
                            MessageBox.Show("Bạn đánh sau nhé!:>", "Thông báo", MessageBoxButtons.OK);
                        }
                    }
                    
                }
                else if(mode == 0)
                {
                    //ready.BackColor = Color.Green;
                    NewGame();
                    Status_pnl.Visible = false;
                    saveToolStripMenuItem.Enabled = true;
                    openToolStripMenuItem.Enabled = true;
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
            Undo();
            Undo();
            progressBar_left.Value = 0;
        }

        private void rule_btn_Click(object sender, EventArgs e)
        {
            sound_click();
            Rule ru = new Rule();
            ru.Show();
        }

        private void Status_pnl_VisibleChanged(object sender, EventArgs e)
        {
            if(Status_pnl.Visible == true)
            {
                chessboard_pnl.Visible = false;
            }
            else
            {
                chessboard_pnl.Visible = true;
            }
        }

        // Âm thanh
        public void sound_welcome()
        {
            if (wav == 1)
            {
                SoundPlayer vov = new SoundPlayer(Properties.Resources.welcome);
                vov.Play();
            }
        }
        public void sound_click()
        {         
            if(wav ==1)
            {
                SoundPlayer vov = new SoundPlayer(Properties.Resources.click);
                vov.Play();
            }        
        }
        public void sound_music()
        {
            if (wav == 1)
            {
                SoundPlayer vov = new SoundPlayer(Properties.Resources.music);
                vov.PlayLooping();
            }
        }
        public void sound_clickk()
        {
            if (wav == 1)
            {
                SoundPlayer vov = new SoundPlayer(Properties.Resources.clickk);
                vov.Play();
            }
        }
        public void sound_lose()
        {
            if (wav == 1)
            {
                SoundPlayer vov = new SoundPlayer(Properties.Resources.lose);
                vov.Play();
            }
        }
        public void sound_win()
        {
            if (wav == 1)
            {
                SoundPlayer vov = new SoundPlayer(Properties.Resources.win);
                vov.Play();
            }
        }
        int wav = 1;
        public void Sound_Click(object sender, EventArgs e)
        {
            if(wav == 1)
            {
                SoundPlayer vov = new SoundPlayer(Properties.Resources.win);
                vov.Stop();
                wav = 0;
                Sound.BackgroundImage = CARO.Properties.Resources.audio_speaker1;
            }
            else
            {             
                wav = 1;
                Sound.BackgroundImage = CARO.Properties.Resources.audio_speaker;
            }
            
        }


        //hình ảnh

        int pic = 0;
        private void picture_Click(object sender, EventArgs e)
        {
            if(pic ==0)
            {
                chessboard_pnl.BackgroundImage = CARO.Properties.Resources.anh2;
                pic = 1;
            }
            else if(pic == 1)
            {
                chessboard_pnl.BackgroundImage = CARO.Properties.Resources.anh4;
                pic = 2;
            }
            else if (pic == 2)
            {
                chessboard_pnl.BackgroundImage = CARO.Properties.Resources.anh5;
                pic = 3;
            }
            else if (pic == 3)
            {
                chessboard_pnl.BackgroundImage = CARO.Properties.Resources.anh0;
                pic = 0;
            }
        }

        private void control_pnl_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Rank_Click(object sender, EventArgs e)
        {
            Rank rk = new Rank();
            rk.Show();
        }

        private void chat_left_Click(object sender, EventArgs e)
        {
            text_left.Visible = true;

        }

        private void chat_right_Click(object sender, EventArgs e)
        {
            text_right.Visible = true;
        }

        private void text_left_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                text_left.Visible = false;
                show_chatleft.Text = text_left.Text;
                text_left.Text = "";
                show_chatleft.Visible = true;
                timerleft.Start();
                socket.Send(new DataTrans((int)SocketCommand.CHAT, show_chatleft.Text, ChessBoard.Player[0].Sb, new Point()));
                Listen();
            }
        }

        private void text_right_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                text_right.Visible = false;
                show_chatright.Text = text_right.Text;
                text_right.Text = "";
                show_chatright.Visible = true;
                timerright.Start();
                socket.Send(new DataTrans((int)SocketCommand.CHAT, show_chatright.Text, ChessBoard.Player[0].Sb, new Point()));
                Listen();
            }
        }
        int time = 0;
        private void timerleft_Tick(object sender, EventArgs e)
        {
            time += 1;
            if(time == 3)
            {
                show_chatleft.Visible = false;
                time = 0;
                timerleft.Stop();
            }
        }

        private void timerright_Tick(object sender, EventArgs e)
        {
            time += 1;
            if (time == 3)
            {
                show_chatright.Visible = false;
                time = 0;
                timerright.Stop();
            }
        }
    }
}
