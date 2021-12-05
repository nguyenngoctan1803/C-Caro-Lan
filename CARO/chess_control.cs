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
        private List<List<Button>> matrix;
        private event EventHandler<ChessClickEvent> player_Click;
        private event EventHandler endedGame;

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


        #endregion

        ////////////////////////////
        #region Initialize
        public Chess_control(Panel chessBoard)
        {
           
            this.ChessBoard = chessBoard;
            this.Matrix = new List<List<Button>>();
            this.Player = new List<Player>()
            {
                new Player("Shiba","X", global::CARO.Properties.Resources.z2769681691345_3cb985cd26c2c89e09e4dcb0c09b4acb),
                new Player("Husky","O", global::CARO.Properties.Resources.gia_cho_shiba_2)
            };
            
            ChangePlayer = 0;
        }
        #endregion

        
        /////////////////////////////
        #region Methods
        public void draw_banco()      //vẻ bàn cờ
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
                        Font = new Font("Forte", 16, FontStyle.Bold),
                        BackColor = Color.White,
                        Width = Cons.chess_width,
                        Height = Cons.chess_height,
                        FlatStyle = FlatStyle.Flat,
                        BackgroundImageLayout = ImageLayout.Stretch,
                        Location = new Point(old_btn.Location.X + old_btn.Width, old_btn.Location.Y),
                        Tag = i.ToString()
                        
                    };
                    btn.FlatAppearance.BorderColor = Color.Gray;
                    btn.Click += danhco;
                    ChessBoard.Controls.Add(btn);
                    Matrix[i].Add(btn);
                    old_btn = btn;
                }

                old_btn.Location = new Point(5, old_btn.Location.Y + Cons.chess_height);
                old_btn.Width = 0;
                old_btn.Height = 0;

            }
        }


        void danhco(object sender, EventArgs e)   //đánh cờ
        {
            Button btn = sender as Button;
            if (btn.Text != "")
            {
                return;
            }

            btn.Text = Player[ChangePlayer].Symboy;          

            if (Player[ChangePlayer].Symboy == "X")
            {
                btn.ForeColor = Color.Red;
            }
            else
            {
                btn.ForeColor = Color.Blue;
            }
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
            Button btn = Matrix[point.Y][point.X];  
            if (btn.Text != "")
            {
                return;
            }

            btn.Text = Player[ChangePlayer].Symboy;
           
            if (Player[ChangePlayer].Symboy == "X")
            {
                btn.ForeColor = Color.Red;
            }
            else
            {
                btn.ForeColor = Color.Blue;
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
            int indY = Convert.ToInt32(btn.Tag);
            int indX = Matrix[indY].IndexOf(btn);

            Point point = new Point(indX,indY);
            return point;
        }
        private bool isEndGame(Button btn)
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
            // check hàng ngang
            for(int i = point.X; i >= 0; i--)        //check hàng ngang bên trái
            {
                if(Matrix[point.Y][i].Text == btn.Text)
                {
                    countLeft++;                
                }
                else
                {                  
                    break;
                }

            }

            for (int i = point.X + 1; i < Cons.chess_num_width - point.X; i++)     //check hàng ngang bên phải
            {
                if (Matrix[point.Y][i].Text == btn.Text)
                {
                    countRight++;                 
                }
                else
                {                  
                    break;
                }
            }


            // check hàng dọc
            for (int i = point.Y; i >= 0; i--)        //check hàng dọc bên trên
            {
                if (Matrix[i][point.X].Text == btn.Text)
                {
                    countTop++;
                }
                else
                {
                    break;
                }

            }

            for (int i = point.Y + 1; i < Cons.chess_num_height - point.Y; i++)     //check hàng dọc bên dưới
            {
                if (Matrix[i][point.X].Text == btn.Text)
                {
                    countButtom++;
                }
                else
                {
                    break;
                }
            }

            //check đường chéo xuống
            for (int i = 0; i <= point.X; i++)        //check hàng ngang bên trái
            {
                if(point.X - i < 0 || point.Y - i < 0)
                {
                    break;
                }
                if (Matrix[point.Y - i][point.X - i].Text == btn.Text)
                {
                    countTopLeft++;
                }
                else
                {
                    break;
                }

            }

            for (int i = 1; i < Cons.chess_num_width - point.X ; i++)     //check hàng ngang bên phải
            {
                if (point.X + i >= Cons.chess_num_width  || point.Y + i >= Cons.chess_num_height)
                {
                    break;
                }
                if (Matrix[point.Y + i][point.X + i].Text == btn.Text)
                {
                    countButtomRight++;
                }
                else
                {
                    break;
                }
            }

            //check đường chéo lên
            for (int i = 0; i <= point.X; i++)        //check hàng ngang bên trái
            {
                if (point.X + i >= Cons.chess_num_width || point.Y - i < 0)
                {
                    break;
                }
                if (Matrix[point.Y - i][point.X + i].Text == btn.Text)
                {
                    countTopRight++;
                }
                else
                {
                    break;
                }

            }

            for (int i = 1; i < Cons.chess_num_width - point.X; i++)     //check hàng ngang bên phải
            {
                if (point.X - i < 0 || point.Y + i >= Cons.chess_num_height)
                {
                    break;
                }
                if (Matrix[point.Y + i][point.X - i].Text == btn.Text)
                {
                    countButtomLeft++;
                }
                else
                {
                    break;
                }
            }


            return countLeft + countRight == 5 || countTop + countButtom == 5 || countTopLeft + countButtomRight ==5 || countTopRight + countButtomLeft ==5;
        }





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
