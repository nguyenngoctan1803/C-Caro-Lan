using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CARO
{
    public class Chess_control
    {

        #region Properties
        private Panel chessBoard;
        private List<Player> player;
        public int changePlayer;
        private int isBanco;
        private List<List<Button>> matrix;
        private event EventHandler<ChessClickEvent> player_Click;
        private event EventHandler endedGame;
        private Stack<Point> playTime;
        private Point p;
        private PictureBox player0;
        private PictureBox player1;
        private Label player0_name;
        private Label player1_name;
        private Image xx;
        private Image oo;
        public event EventHandler<ChessClickEvent> Player_Click
        {
            add
            {
                player_Click += value;
            }
            remove
            {
                player_Click -= value;
            }
        }
        public event EventHandler EndedGame
        {
            add
            {
                endedGame += value;
            }
            remove
            {
                endedGame -= value;
            }
        }
        public Panel ChessBoard { get => chessBoard; set => chessBoard = value; }
        public List<Player> Player { get => player; set => player = value; }
        public int ChangePlayer { get => changePlayer; set => changePlayer = value; }
        public List<List<Button>> Matrix { get => matrix; set => matrix = value; }
        public Point P { get => p; set => p = value; }
        public Image XX { get => xx; set => xx = value; }
        public Image OO { get => oo; set => oo = value; }
        public PictureBox Player0 { get => player0; set => player0 = value; }
        public PictureBox Player1 { get => player1; set => player1 = value; }
        public Label Player0_name { get => player0_name; set => player0_name = value; }
        public Label Player1_name { get => player1_name; set => player1_name = value; }
        public int IsBanco { get => isBanco; set => isBanco = value; }
        public Stack<Point> PlayTime { get => playTime; set => playTime = value; }


        #endregion

        ////////////////////////////
        #region Initialize
        public Chess_control(Panel chessBoard,Label player0_name,Label player1_name, PictureBox player0,PictureBox player1)
        {
            XX = global::CARO.Properties.Resources.x1;
            OO = global::CARO.Properties.Resources.letter_o;
            this.ChessBoard = chessBoard;
            this.Player0 = player0;
            this.Player1 = player1;
            this.Player0_name = player0_name;
            this.Player1_name = player1_name;
            this.Matrix = new List<List<Button>>();
            this.Player = new List<Player>()

            {
                new Player("Shiba", XX, "x"),
                new Player("Computer", OO, "o"),
                new Player("Temp", XX,"t"),
                new Player("Computer", OO, "o")
            };
            this.PlayTime = new Stack<Point>();
            IsBanco = 0;
            ChangePlayer = 0;
        }
        #endregion

        
        /////////////////////////////
        
        #region Methods
        public void draw_banco()      //vẻ bàn cờ
        {
            
            if(IsBanco == 0)
            {
                Button old_btn = new Button()
                {
                    Width = 0,
                    Height = 0,
                    Location = new Point(5, 5)
                };

                for (int i = 0; i < Cons.chess_num_height; i++)
                {
                    Matrix.Add(new List<Button>());
                    for (int j = 0; j <= Cons.chess_num_width; j++)
                    {
                        Button btn = new Button()
                        {
                            Font = new Font("Forte", 1),
                            TextAlign = ContentAlignment.BottomLeft,
                            ForeColor = Color.White,
                            BackColor = Color.Transparent,
                            Width = Cons.chess_width,
                            Height = Cons.chess_height,
                            FlatStyle = FlatStyle.Flat,
                            BackgroundImageLayout = ImageLayout.Stretch,
                            Location = new Point(old_btn.Location.X + old_btn.Width, old_btn.Location.Y),
                            Text = i.ToString()

                        };
                        btn.FlatAppearance.BorderColor = Color.White;
                        btn.Click += danhco;
                        ChessBoard.Controls.Add(btn);
                        Matrix[i].Add(btn);
                        old_btn = btn;
                    }

                    old_btn.Location = new Point(5, old_btn.Location.Y + Cons.chess_height);
                    old_btn.Width = 0;
                    old_btn.Height = 0;

                }

                IsBanco = 1;
            }
            else
            {
                foreach (Control x in ChessBoard.Controls)
                {
                    //x.Click += danhco;
                    x.BackgroundImage = null;
                    x.BackColor = Color.Transparent;
                    x.Tag = "";
                }
            }
            
        }


        public void computer_play()
        {
            int flag = 0;
            int alert_ngang = 0;
            int alert_doc = 0;
            int alert_huyen = 0;
            int alert_sac = 0;

            int count1 = 0;
            int count2 = 0;
           
            List<Point> ngang = new List<Point>();
            List<Point> doc = new List<Point>();
            List<Point> huyen = new List<Point>();
            List<Point> sac = new List<Point>();

            //check hàng ngang
            for (int i = P.X; i >= 0; i--)        //check hàng ngang bên trái
            {
                if (Matrix[P.Y][i].Tag == Matrix[P.Y][P.X].Tag)
                {
                    count1++;                  
                }
                else
                {
                    if (Convert.ToString(Matrix[P.Y][i].Tag) != "")
                    {
                        flag += 1;
                        break;
                    }
                    else
                    {
                        Point p = new Point(P.Y, i);
                        ngang.Add(p);
                        break;
                    }
                    
                }

            }

            for (int i = P.X + 1; i < Cons.chess_num_width; i++)     //check hàng ngang bên phải
            {
                if (Matrix[P.Y][i].Tag == Matrix[P.Y][P.X].Tag)
                {
                    count2++;                  
                }
                else
                {
                    if (Convert.ToString(Matrix[P.Y][i].Tag) != "")
                    {
                        flag += 1;
                        break;
                    }
                    else
                    {
                        Point p = new Point(P.Y, i);
                        ngang.Add(p);
                        break;
                    }
                }
            }
            if (count1 + count2 == 4 && (flag == 1 || flag == 0))
            {
                alert_ngang = 5;
            }
            else if(count1 + count2 == 3 && flag == 0)
            {
                alert_ngang = 4;
            }
            else if(count1 + count2 == 5)
            {
                alert_ngang = 10;
            }

            count1 = 0;
            count2 = 0;
            flag = 0;

            // check hàng dọc
            for (int i = P.Y; i >= 0; i--)        //check hàng dọc bên trên
            {
                if (Matrix[i][P.X].Tag == Matrix[P.Y][P.X].Tag)
                {
                    count1++;                  
                }
                else
                {
                    if (Convert.ToString(Matrix[i][P.X].Tag) != "")
                    {
                        flag += 1;
                        break;
                    }
                    else
                    {
                        Point p = new Point(i, P.X);
                        doc.Add(p);
                        break;
                    }
                    
                }

            }

            for (int i = P.Y + 1; i < Cons.chess_num_height; i++)     //check hàng dọc bên dưới
            {
                if (Matrix[i][P.X].Tag == Matrix[P.Y][P.X].Tag)
                {
                    count2++;                  
                }
                else
                {
                    if (Convert.ToString(Matrix[i][P.X].Tag) != "")
                    {
                        flag += 1;
                        break;
                    }
                    else
                    {
                        Point p = new Point(i, P.X);
                        doc.Add(p);
                        break;
                    }

                }
            }
            if (count1 + count2 == 4 && (flag == 1 || flag == 0))
            {
                alert_doc = 5;
            }
            else if (count1 + count2 == 3 && flag == 0)
            {
                alert_doc = 4;
            }
            else if (count1 + count2 == 5)
            {
                alert_doc = 10;
            }

            count1 = 0;
            count2 = 0;
            flag = 0;


            //check đường chéo xuống
            for (int i = 0; i <= P.X; i++)        //check đường chéo xuống bên trên
            {
                if (P.X - i < 0 || P.Y - i < 0)
                {
                    break;
                }
                if (Matrix[P.Y - i][P.X - i].Tag == Matrix[P.Y][P.X].Tag)
                {
                    count1++;                 
                }
                else
                {
                    if(Convert.ToString(Matrix[P.Y - i][P.X - i].Tag) != "")
                    {
                        flag += 1;
                        break;
                    }
                    else
                    {
                        Point p = new Point(P.Y - i, P.X - i);
                        huyen.Add(p);
                        break;
                    }
                   
                }

            }

            for (int i = 1; i < Cons.chess_num_width; i++)     //check đường chéo xuống bên dưới
            {
                if (P.X + i >= Cons.chess_num_width || P.Y + i >= Cons.chess_num_height)
                {
                    break;
                }
                if (Matrix[P.Y + i][P.X + i].Tag == Matrix[P.Y][P.X].Tag)
                {
                    count2++;                
                }
                else
                {
                    if (Convert.ToString(Matrix[P.Y + i][P.X + i].Tag) != "")
                    {
                        flag += 1;
                        break;
                    }
                    else
                    {
                        Point p = new Point(P.Y + i, P.X + i);
                        huyen.Add(p);
                        break;
                    }
                }
            }
            if (count1 + count2 == 4 && (flag == 1 || flag == 0))
            {
                alert_huyen = 5;
            }
            else if (count1 + count2 == 3 && flag == 0)
            {
                alert_huyen = 4;
            }
            else if (count1 + count2 == 5)
            {
                alert_huyen = 10;
            }

            count1 = 0;
            count2 = 0;
            flag = 0;

            ////check đường chéo lên
            for (int i = 0; i <= P.X; i++)        //check đường chéo lên bên trên
            {
                if (P.X + i >= Cons.chess_num_width || P.Y - i < 0)
                {
                    break;
                }
                if (Matrix[P.Y - i][P.X + i].Tag == Matrix[P.Y][P.X].Tag) 
                {
                    count1++;
                }
                else
                {
                    if (Convert.ToString(Matrix[P.Y - i][P.X + i].Tag) != "")
                    {
                        flag += 1;
                        break;
                    }
                    else
                    {
                        Point p = new Point(P.Y - i, P.X + i);
                        sac.Add(p);
                        break;
                    }

                }

            }

            for (int i = 1; i < Cons.chess_num_width; i++)     //check đường chéo lên bên dưới
            {
                if (P.X - i < 0 || P.Y + i >= Cons.chess_num_height)
                {
                    break;
                }
                if (Matrix[P.Y + i][P.X - i].Tag == Matrix[P.Y][P.X].Tag) 
                {
                    count2++;                   
                }
                else
                {
                    if(Convert.ToString(Matrix[P.Y + i][P.X - i].Tag) != "")
                    {
                        flag += 1;
                        break;
                    }
                    else
                    {
                        Point p = new Point(P.Y + i, P.X - i);
                        sac.Add(p);
                        break;
                    }
                   
                }
            }

            if (count1 + count2 == 4 && (flag == 1 || flag == 0))
            {
                alert_sac = 5;
            }
            else if (count1 + count2 == 3 && flag == 0)
            {
                alert_sac = 4;
            }
            else if (count1 + count2 == 5)
            {
                alert_sac = 10;
            }

            count1 = 0;
            count2 = 0;
            flag = 0;
            if(alert_ngang == 10 || alert_doc == 10 || alert_huyen == 10 || alert_sac == 10)
            {
                // máy thua

            }
            else if(alert_ngang >=4 || alert_doc >=4 || alert_huyen >=4 || alert_sac >=4)
            {
                if (alert_ngang >= alert_doc && alert_ngang >= alert_huyen && alert_ngang >= alert_sac)
                {
                    for (int i = 0; i <= ngang.Count; i++)
                    {
                        try
                        {
                            if (Convert.ToString(Matrix[ngang[i].X][ngang[i].Y].Tag) == "")
                            {
                                Matrix[ngang[i].X][ngang[i].Y].Tag = "O";
                                Matrix[ngang[i].X][ngang[i].Y].BackgroundImage = Player[ChangePlayer].Symboy;
                                Button btn = Matrix[ngang[i].X][ngang[i].Y];
                                PlayTime.Push(chess_point(btn));
                                ChangePlayer = ChangePlayer == 1 ? 0 : 1;
                                if (isEndGame(Matrix[ngang[i].X][ngang[i].Y]))
                                {
                                    EndGame();
                                }
                                break;
                            }
                        }
                        catch
                        {
                            MessageBox.Show("Máy Mệt Quá Không Chơi Nữa\nBạn Thắng Đó, Bạn Là Nhất!", "Dừng Lại Dùm", MessageBoxButtons.OK);
                            EndGame();
                        }
                        
                    }
                }
                else if (alert_doc >= alert_ngang && alert_doc >= alert_huyen && alert_doc >= alert_sac)
                {
                    for (int i = 0; i <= doc.Count; i++)
                    {
                        try
                        {
                            if (Convert.ToString(Matrix[doc[i].X][doc[i].Y].Tag) == "")
                            {
                                Matrix[doc[i].X][doc[i].Y].Tag = "O";
                                Matrix[doc[i].X][doc[i].Y].BackgroundImage = Player[ChangePlayer].Symboy;
                                Button btn = Matrix[doc[i].X][doc[i].Y];
                                PlayTime.Push(chess_point(btn));
                                ChangePlayer = ChangePlayer == 1 ? 0 : 1;
                                if (isEndGame(Matrix[doc[i].X][doc[i].Y]))
                                {
                                    EndGame();
                                }
                                break;
                            }
                        }
                        catch
                        {
                            MessageBox.Show("Máy Mệt Quá Không Chơi Nữa\nBạn Thắng Đó, Bạn Là Nhất!", "Dừng Lại Dùm", MessageBoxButtons.OK);
                            EndGame();
                        }
                        

                    }
                }
                else if (alert_huyen >= alert_ngang && alert_huyen >= alert_doc && alert_huyen >= alert_sac)
                {
                    for (int i = 0; i <= huyen.Count; i++)
                    {
                        try
                        {
                            if (Convert.ToString(Matrix[huyen[i].X][huyen[i].Y].Tag) == "")
                            {
                                Matrix[huyen[i].X][huyen[i].Y].Tag = "O";
                                Matrix[huyen[i].X][huyen[i].Y].BackgroundImage = Player[ChangePlayer].Symboy;
                                Button btn = Matrix[huyen[i].X][huyen[i].Y];
                                PlayTime.Push(chess_point(btn));
                                ChangePlayer = ChangePlayer == 1 ? 0 : 1;
                                if (isEndGame(Matrix[huyen[i].X][huyen[i].Y]))
                                {
                                    EndGame();
                                }
                                break;
                            }
                        }
                        catch
                        {
                            MessageBox.Show("Máy Mệt Quá Không Chơi Nữa\nBạn Thắng Đó, Bạn Là Nhất!", "Dừng Lại Dùm", MessageBoxButtons.OK);
                            EndGame();
                        }
                        

                    }
                }
                else if (alert_sac >= alert_ngang && alert_sac >= alert_doc && alert_sac >= alert_huyen)
                {
                    for (int i = 0; i <= sac.Count; i++)
                    {
                        try
                        {
                            if (Convert.ToString(Matrix[sac[i].X][sac[i].Y].Tag) == "")
                            {
                                Matrix[sac[i].X][sac[i].Y].Tag = "O";
                                Matrix[sac[i].X][sac[i].Y].BackgroundImage = Player[ChangePlayer].Symboy;
                                Button btn = Matrix[sac[i].X][sac[i].Y];
                                PlayTime.Push(chess_point(btn));
                                ChangePlayer = ChangePlayer == 1 ? 0 : 1;
                                if (isEndGame(Matrix[sac[i].X][sac[i].Y]))
                                {
                                    EndGame();
                                }
                                break;
                            }
                        }
                        catch
                        {
                            MessageBox.Show("Máy Mệt Quá Không Chơi Nữa\nBạn Thắng Đó, Bạn Là Nhất!", "Dừng Lại Dùm", MessageBoxButtons.OK);
                            EndGame();
                        }
                        

                    }
                }
            }
            else
            {
                for (int i = 0; i <= sac.Count; i++)
                {
                    try
                    {
                        if (Convert.ToString(Matrix[sac[i].X][sac[i].Y].Tag) == "")
                        {
                            Matrix[sac[i].X][sac[i].Y].Tag = "O";
                            Matrix[sac[i].X][sac[i].Y].BackgroundImage = Player[ChangePlayer].Symboy;
                            Button btn = Matrix[sac[i].X][sac[i].Y];
                            PlayTime.Push(chess_point(btn));
                            ChangePlayer = ChangePlayer == 1 ? 0 : 1;

                            if (isEndGame(Matrix[sac[i].X][sac[i].Y]))
                            {
                                EndGame();
                            }

                            break;
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Máy Mệt Quá Không Chơi Nữa\nBạn Thắng Đó, Bạn Là Nhất!", "Dừng Lại Dùm", MessageBoxButtons.OK);
                        EndGame();
                    }                   
                }
            }

            foreach (Control x in ChessBoard.Controls)
            {
                if (Convert.ToString(x.Tag) != "X" && Convert.ToString(x.Tag) != "O")
                {
                    x.Click += danhco;
                }
            }

        } ///Máy đánh
        public void danhco(object sender, EventArgs e)   //Người đánh
        {
            Button btn = sender as Button;
            P = chess_point(btn);
            if (Convert.ToString(btn.Tag) != "")
            {
                return;
            }

            btn.BackgroundImage = Player[ChangePlayer].Symboy;          

            if (ChangePlayer == 0)
            {
                btn.Tag = "X";
            }
            else
            {
                btn.Tag = "O";
            }

            PlayTime.Push(chess_point(btn));

            ChangePlayer = ChangePlayer == 0 ? 1 : 0;

           

            if (player_Click != null)
            {
                player_Click(this, new ChessClickEvent(chess_point(btn)));
            }

          
            if (isEndGame(btn))
            {
                EndGame(); 
            }

            
        }
        
        public void SendChess(Point point)
        {
            if (point.X == 20)
            {
                MessageBox.Show("20 20");
            }
            Button btn = Matrix[point.Y][point.X];  
            if (Convert.ToString(btn.Tag) != "")
            {
                return;
            }

            btn.BackgroundImage = Player[ChangePlayer].Symboy;

            if (ChangePlayer == 0)
            {
                btn.Tag = "X";
            }
            else
            {
                btn.Tag = "O";
            }

            ChangePlayer = ChangePlayer == 0 ? 1 : 0;
            
            if (isEndGame(btn))
            {
                EndGame();
            }
        }
        

        public void EndGame()
        {
            if(endedGame != null)
            {
                endedGame(this, new EventArgs());
            }
        }

        private Point chess_point(Button btn)
        {         
            int indY = Convert.ToInt32(btn.Text);
            int indX = Matrix[indY].IndexOf(btn);

            Point point = new Point(indX,indY);
            return point;
        }

        public void Undo()
        {
            if(PlayTime.Count<=0)
            {

            }
            else
            {
                Point p = PlayTime.Pop();
                Button btn = Matrix[p.Y][p.X];
                btn.BackgroundImage = null;
                btn.Tag = "";
            }
            
            
        }
        public bool isEndGame(Button btn)
        {
            Point point = chess_point(btn);
            int countLeft = 0;
            int countRight = 0;
            int countTop = 0;
            int countButtom = 0;
            int countTopLeft = 0;
            int countButtomRight = 0;
            int countTopRight = 0;
            int countButtomLeft = 0;
            List<Point> five = new List<Point>();
            // check hàng ngang
            for(int i = point.X; i >= 0; i--)        //check hàng ngang bên trái
            {
                if(Matrix[point.Y][i].Tag == btn.Tag)
                {
                    countLeft++;
                    Point p = new Point(point.Y, i);
                    five.Add(p);
                }
                else
                {                  
                    break;
                }

            }

            for (int i = point.X + 1; i < Cons.chess_num_width; i++)     //check hàng ngang bên phải
            {
                if (Matrix[point.Y][i].Tag == btn.Tag)
                {
                    countRight++;
                    Point p = new Point(point.Y, i);
                    five.Add(p);
                }
                else
                {                  
                    break;
                }
            }

            if(countLeft + countRight == 5)
            {
                for(int i = 0; i < 5; i++)
                {
                    Matrix[five[i].X][five[i].Y].BackColor = Color.Yellow;
                }
          
            }
            else
            {
                five.Clear();
            }
            // check hàng dọc
            for (int i = point.Y; i >= 0; i--)        //check hàng dọc bên trên
            {
                if (Matrix[i][point.X].Tag == btn.Tag)
                {
                    countTop++;
                    Point p = new Point(i, point.X);
                    five.Add(p);
                }
                else
                {
                    break;
                }

            }

            for (int i = point.Y + 1; i < Cons.chess_num_height; i++)     //check hàng dọc bên dưới
            {
                if (Matrix[i][point.X].Tag == btn.Tag)
                {
                    countButtom++;
                    Point p = new Point(i, point.X);
                    five.Add(p);
                }
                else
                {
                    break;
                }
            }

            if (countTop + countButtom == 5)
            {
                for (int i = 0; i < 5; i++)
                {
                    Matrix[five[i].X][five[i].Y].BackColor = Color.Yellow;
                }

            }
            else
            {
                five.Clear();
            }

            //check đường chéo xuống
            for (int i = 0; i <= point.X; i++)        //check đường chéo xuống bên trên
            {
                if(point.X - i < 0 || point.Y - i < 0)
                {
                    break;
                }
                if (Matrix[point.Y - i][point.X - i].Tag == btn.Tag)
                {
                    countTopLeft++;
                    Point p = new Point(point.Y - i, point.X - i);
                    five.Add(p);
                }
                else
                {
                    break;
                }

            }

            for (int i = 1; i < Cons.chess_num_width ; i++)     //check đường chéo xuống bên dưới
            {
                if (point.X + i >= Cons.chess_num_width  || point.Y + i >= Cons.chess_num_height)
                {
                    break;
                }
                if (Matrix[point.Y + i][point.X + i].Tag == btn.Tag)
                {
                    countButtomRight++;
                    Point p = new Point(point.Y + i, point.X + i);
                    five.Add(p);
                }
                else
                {
                    break;
                }
            }
            if (countTopLeft + countButtomRight == 5)
            {
                for (int i = 0; i < 5; i++)
                {
                    Matrix[five[i].X][five[i].Y].BackColor = Color.Yellow;
                }

            }
            else
            {
                five.Clear();
            }
            //check đường chéo lên
            for (int i = 0; i <= point.X; i++)        //check đường chéo lên bên trên
            {
                if (point.X + i >= Cons.chess_num_width || point.Y - i < 0)
                {
                    break;
                }
                if (Matrix[point.Y - i][point.X + i].Tag == btn.Tag)
                {
                    countTopRight++;
                    Point p = new Point(point.Y - i, point.X + i);
                    five.Add(p);
                }
                else
                {
                    break;
                }

            }

            for (int i = 1; i < Cons.chess_num_width; i++)     //check đường chéo lên bên dưới
            {
                if (point.X - i < 0 || point.Y + i >= Cons.chess_num_height)
                {
                    break;
                }
                if (Matrix[point.Y + i][point.X - i].Tag == btn.Tag)
                {
                    countButtomLeft++;
                    Point p = new Point(point.Y + i, point.X - i);
                    five.Add(p);
                }
                else
                {
                    break;
                }
            }
            if (countTopRight + countButtomLeft == 5)
            {
                for (int i = 0; i < 5; i++)
                {
                    Matrix[five[i].X][five[i].Y].BackColor = Color.Yellow;
                }

            }
            else
            {
                five.Clear();
            }


            return countLeft + countRight == 5 || countTop + countButtom == 5 || countTopLeft + countButtomRight ==5 || countTopRight + countButtomLeft ==5;
        }  //kiểm tra thắng thua





        #endregion

    }
    public class ChessClickEvent : EventArgs
    {
        private Point clickedPoint;

        public Point ClickedPoint { get => clickedPoint; set => clickedPoint = value; }

        public ChessClickEvent(Point point)
        {
            this.ClickedPoint = point;
        }
    }
}
