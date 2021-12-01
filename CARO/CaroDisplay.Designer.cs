namespace CARO
{
    partial class CaroDisplay
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.chessboard_pnl = new System.Windows.Forms.Panel();
            this.Option_pnl = new System.Windows.Forms.Panel();
            this.nhac = new System.Windows.Forms.CheckBox();
            this.amthanh = new System.Windows.Forms.CheckBox();
            this.save_option_btn = new System.Windows.Forms.Button();
            this.computer = new System.Windows.Forms.Button();
            this.person = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.undo_btn = new System.Windows.Forms.Button();
            this.rule_btn = new System.Windows.Forms.Button();
            this.option_btn = new System.Windows.Forms.Button();
            this.player0_image = new System.Windows.Forms.PictureBox();
            this.player0_symboy = new System.Windows.Forms.Label();
            this.player1_symboy = new System.Windows.Forms.Label();
            this.player0_name = new System.Windows.Forms.Label();
            this.player1_name = new System.Windows.Forms.Label();
            this.progressBar_left = new System.Windows.Forms.ProgressBar();
            this.progressBar_right = new System.Windows.Forms.ProgressBar();
            this.timer_play = new System.Windows.Forms.Timer(this.components);
            this.gg_btn = new System.Windows.Forms.Button();
            this.out_room_btn = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label_maphong = new System.Windows.Forms.Label();
            this.maphong = new System.Windows.Forms.Label();
            this.player1_image = new System.Windows.Forms.PictureBox();
            this.chessboard_pnl.SuspendLayout();
            this.Option_pnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.player0_image)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.player1_image)).BeginInit();
            this.SuspendLayout();
            // 
            // chessboard_pnl
            // 
            this.chessboard_pnl.BackColor = System.Drawing.Color.Black;
            this.chessboard_pnl.Controls.Add(this.Option_pnl);
            this.chessboard_pnl.Location = new System.Drawing.Point(302, 12);
            this.chessboard_pnl.Name = "chessboard_pnl";
            this.chessboard_pnl.Size = new System.Drawing.Size(812, 749);
            this.chessboard_pnl.TabIndex = 0;
            // 
            // Option_pnl
            // 
            this.Option_pnl.BackColor = System.Drawing.Color.DarkOrange;
            this.Option_pnl.Controls.Add(this.nhac);
            this.Option_pnl.Controls.Add(this.amthanh);
            this.Option_pnl.Controls.Add(this.save_option_btn);
            this.Option_pnl.Controls.Add(this.computer);
            this.Option_pnl.Controls.Add(this.person);
            this.Option_pnl.Controls.Add(this.label8);
            this.Option_pnl.Location = new System.Drawing.Point(121, 202);
            this.Option_pnl.Name = "Option_pnl";
            this.Option_pnl.Size = new System.Drawing.Size(576, 417);
            this.Option_pnl.TabIndex = 1;
            this.Option_pnl.Visible = false;
            // 
            // nhac
            // 
            this.nhac.AutoSize = true;
            this.nhac.Checked = true;
            this.nhac.CheckState = System.Windows.Forms.CheckState.Checked;
            this.nhac.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nhac.Location = new System.Drawing.Point(343, 232);
            this.nhac.Name = "nhac";
            this.nhac.Size = new System.Drawing.Size(80, 32);
            this.nhac.TabIndex = 4;
            this.nhac.Text = "Nhạc";
            this.nhac.UseVisualStyleBackColor = true;
            // 
            // amthanh
            // 
            this.amthanh.AutoSize = true;
            this.amthanh.Checked = true;
            this.amthanh.CheckState = System.Windows.Forms.CheckState.Checked;
            this.amthanh.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.amthanh.Location = new System.Drawing.Point(151, 232);
            this.amthanh.Name = "amthanh";
            this.amthanh.Size = new System.Drawing.Size(124, 32);
            this.amthanh.TabIndex = 4;
            this.amthanh.Text = "Âm thanh";
            this.amthanh.UseVisualStyleBackColor = true;
            // 
            // save_option_btn
            // 
            this.save_option_btn.BackColor = System.Drawing.Color.White;
            this.save_option_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.save_option_btn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.save_option_btn.Location = new System.Drawing.Point(221, 340);
            this.save_option_btn.Name = "save_option_btn";
            this.save_option_btn.Size = new System.Drawing.Size(144, 38);
            this.save_option_btn.TabIndex = 3;
            this.save_option_btn.Text = "OK";
            this.save_option_btn.UseVisualStyleBackColor = false;
            this.save_option_btn.Click += new System.EventHandler(this.save_option_btn_Click);
            // 
            // computer
            // 
            this.computer.BackColor = System.Drawing.Color.Red;
            this.computer.FlatAppearance.BorderSize = 2;
            this.computer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.computer.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.computer.Location = new System.Drawing.Point(306, 88);
            this.computer.Name = "computer";
            this.computer.Size = new System.Drawing.Size(199, 43);
            this.computer.TabIndex = 1;
            this.computer.Text = "Đánh với máy";
            this.computer.UseVisualStyleBackColor = false;
            this.computer.Click += new System.EventHandler(this.regime_chose);
            // 
            // person
            // 
            this.person.BackColor = System.Drawing.Color.LimeGreen;
            this.person.FlatAppearance.BorderSize = 2;
            this.person.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.person.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.person.Location = new System.Drawing.Point(71, 88);
            this.person.Name = "person";
            this.person.Size = new System.Drawing.Size(199, 43);
            this.person.TabIndex = 1;
            this.person.Text = "Đánh với người";
            this.person.UseVisualStyleBackColor = false;
            this.person.Click += new System.EventHandler(this.regime_chose);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label8.Location = new System.Drawing.Point(230, 5);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(119, 41);
            this.label8.TabIndex = 0;
            this.label8.Text = "Chế Độ";
            // 
            // undo_btn
            // 
            this.undo_btn.BackColor = System.Drawing.Color.Transparent;
            this.undo_btn.BackgroundImage = global::CARO.Properties.Resources.undo;
            this.undo_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.undo_btn.FlatAppearance.BorderSize = 0;
            this.undo_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.undo_btn.Location = new System.Drawing.Point(545, 778);
            this.undo_btn.Name = "undo_btn";
            this.undo_btn.Size = new System.Drawing.Size(88, 64);
            this.undo_btn.TabIndex = 1;
            this.undo_btn.UseVisualStyleBackColor = false;
            // 
            // rule_btn
            // 
            this.rule_btn.BackColor = System.Drawing.Color.Transparent;
            this.rule_btn.BackgroundImage = global::CARO.Properties.Resources.question;
            this.rule_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.rule_btn.FlatAppearance.BorderSize = 0;
            this.rule_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rule_btn.Font = new System.Drawing.Font("Forte", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rule_btn.ForeColor = System.Drawing.Color.Black;
            this.rule_btn.Location = new System.Drawing.Point(799, 778);
            this.rule_btn.Name = "rule_btn";
            this.rule_btn.Size = new System.Drawing.Size(87, 64);
            this.rule_btn.TabIndex = 1;
            this.rule_btn.UseVisualStyleBackColor = false;
            // 
            // option_btn
            // 
            this.option_btn.BackColor = System.Drawing.Color.Transparent;
            this.option_btn.BackgroundImage = global::CARO.Properties.Resources.option;
            this.option_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.option_btn.FlatAppearance.BorderSize = 0;
            this.option_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.option_btn.Location = new System.Drawing.Point(672, 778);
            this.option_btn.Name = "option_btn";
            this.option_btn.Size = new System.Drawing.Size(88, 64);
            this.option_btn.TabIndex = 1;
            this.option_btn.UseVisualStyleBackColor = false;
            this.option_btn.Click += new System.EventHandler(this.option_btn_Click);
            // 
            // player0_image
            // 
            this.player0_image.Image = global::CARO.Properties.Resources.z2769681691345_3cb985cd26c2c89e09e4dcb0c09b4acb;
            this.player0_image.Location = new System.Drawing.Point(82, 181);
            this.player0_image.Name = "player0_image";
            this.player0_image.Size = new System.Drawing.Size(139, 127);
            this.player0_image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.player0_image.TabIndex = 2;
            this.player0_image.TabStop = false;
            // 
            // player0_symboy
            // 
            this.player0_symboy.AutoSize = true;
            this.player0_symboy.BackColor = System.Drawing.Color.Transparent;
            this.player0_symboy.Font = new System.Drawing.Font("Forte", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.player0_symboy.ForeColor = System.Drawing.Color.Red;
            this.player0_symboy.Location = new System.Drawing.Point(97, 363);
            this.player0_symboy.Name = "player0_symboy";
            this.player0_symboy.Size = new System.Drawing.Size(96, 87);
            this.player0_symboy.TabIndex = 3;
            this.player0_symboy.Text = "X";
            // 
            // player1_symboy
            // 
            this.player1_symboy.AutoSize = true;
            this.player1_symboy.BackColor = System.Drawing.Color.Transparent;
            this.player1_symboy.Font = new System.Drawing.Font("Forte", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.player1_symboy.ForeColor = System.Drawing.Color.Blue;
            this.player1_symboy.Location = new System.Drawing.Point(1226, 363);
            this.player1_symboy.Name = "player1_symboy";
            this.player1_symboy.Size = new System.Drawing.Size(89, 87);
            this.player1_symboy.TabIndex = 3;
            this.player1_symboy.Text = "O";
            // 
            // player0_name
            // 
            this.player0_name.AutoSize = true;
            this.player0_name.BackColor = System.Drawing.Color.Transparent;
            this.player0_name.Font = new System.Drawing.Font("Sitka Heading", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.player0_name.Location = new System.Drawing.Point(105, 324);
            this.player0_name.Name = "player0_name";
            this.player0_name.Size = new System.Drawing.Size(84, 40);
            this.player0_name.TabIndex = 5;
            this.player0_name.Text = "shiba";
            // 
            // player1_name
            // 
            this.player1_name.AutoSize = true;
            this.player1_name.BackColor = System.Drawing.Color.Transparent;
            this.player1_name.Font = new System.Drawing.Font("Sitka Heading", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.player1_name.Location = new System.Drawing.Point(1227, 324);
            this.player1_name.Name = "player1_name";
            this.player1_name.Size = new System.Drawing.Size(91, 40);
            this.player1_name.TabIndex = 5;
            this.player1_name.Text = "husky";
            // 
            // progressBar_left
            // 
            this.progressBar_left.Location = new System.Drawing.Point(42, 479);
            this.progressBar_left.Maximum = 10000;
            this.progressBar_left.Name = "progressBar_left";
            this.progressBar_left.Size = new System.Drawing.Size(216, 35);
            this.progressBar_left.Step = 100;
            this.progressBar_left.TabIndex = 6;
            // 
            // progressBar_right
            // 
            this.progressBar_right.Location = new System.Drawing.Point(1162, 479);
            this.progressBar_right.Maximum = 10000;
            this.progressBar_right.Name = "progressBar_right";
            this.progressBar_right.Size = new System.Drawing.Size(216, 35);
            this.progressBar_right.Step = 100;
            this.progressBar_right.TabIndex = 6;
            // 
            // timer_play
            // 
            this.timer_play.Tick += new System.EventHandler(this.timer_play_Tick);
            // 
            // gg_btn
            // 
            this.gg_btn.BackColor = System.Drawing.Color.Transparent;
            this.gg_btn.BackgroundImage = global::CARO.Properties.Resources.white_flag;
            this.gg_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.gg_btn.FlatAppearance.BorderSize = 0;
            this.gg_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gg_btn.Location = new System.Drawing.Point(100, 541);
            this.gg_btn.Name = "gg_btn";
            this.gg_btn.Size = new System.Drawing.Size(105, 120);
            this.gg_btn.TabIndex = 7;
            this.gg_btn.UseVisualStyleBackColor = false;
            this.gg_btn.Click += new System.EventHandler(this.gg_btn_Click);
            // 
            // out_room_btn
            // 
            this.out_room_btn.BackColor = System.Drawing.Color.White;
            this.out_room_btn.BackgroundImage = global::CARO.Properties.Resources.log_out;
            this.out_room_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.out_room_btn.Location = new System.Drawing.Point(1340, 787);
            this.out_room_btn.Name = "out_room_btn";
            this.out_room_btn.Size = new System.Drawing.Size(67, 55);
            this.out_room_btn.TabIndex = 8;
            this.out_room_btn.UseVisualStyleBackColor = false;
            this.out_room_btn.Click += new System.EventHandler(this.exit_game);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(1346, 764);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 23);
            this.label7.TabIndex = 9;
            this.label7.Text = "Thoát";
            // 
            // label_maphong
            // 
            this.label_maphong.AutoSize = true;
            this.label_maphong.BackColor = System.Drawing.Color.Transparent;
            this.label_maphong.Font = new System.Drawing.Font("Segoe UI", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label_maphong.Location = new System.Drawing.Point(1035, 794);
            this.label_maphong.Name = "label_maphong";
            this.label_maphong.Size = new System.Drawing.Size(135, 32);
            this.label_maphong.TabIndex = 10;
            this.label_maphong.Text = "Mã Phòng:";
            // 
            // maphong
            // 
            this.maphong.AutoSize = true;
            this.maphong.BackColor = System.Drawing.Color.Transparent;
            this.maphong.Font = new System.Drawing.Font("Segoe UI", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.maphong.Location = new System.Drawing.Point(1180, 794);
            this.maphong.Name = "maphong";
            this.maphong.Size = new System.Drawing.Size(127, 32);
            this.maphong.TabIndex = 10;
            this.maphong.Tag = "ipv4";
            this.maphong.Text = "19522174";
            // 
            // player1_image
            // 
            this.player1_image.Image = global::CARO.Properties.Resources.gia_cho_shiba_2;
            this.player1_image.Location = new System.Drawing.Point(1198, 181);
            this.player1_image.Name = "player1_image";
            this.player1_image.Size = new System.Drawing.Size(138, 127);
            this.player1_image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.player1_image.TabIndex = 2;
            this.player1_image.TabStop = false;
            // 
            // CaroDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::CARO.Properties.Resources._3;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1419, 853);
            this.Controls.Add(this.maphong);
            this.Controls.Add(this.label_maphong);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.out_room_btn);
            this.Controls.Add(this.gg_btn);
            this.Controls.Add(this.progressBar_right);
            this.Controls.Add(this.progressBar_left);
            this.Controls.Add(this.player1_name);
            this.Controls.Add(this.player0_name);
            this.Controls.Add(this.player1_symboy);
            this.Controls.Add(this.player0_symboy);
            this.Controls.Add(this.player1_image);
            this.Controls.Add(this.player0_image);
            this.Controls.Add(this.rule_btn);
            this.Controls.Add(this.undo_btn);
            this.Controls.Add(this.option_btn);
            this.Controls.Add(this.chessboard_pnl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximumSize = new System.Drawing.Size(1437, 900);
            this.MinimumSize = new System.Drawing.Size(1437, 900);
            this.Name = "CaroDisplay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.TransparencyKey = System.Drawing.Color.DarkRed;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.close_game);
            this.Load += new System.EventHandler(this.CaroDisplay_Load);
            this.Shown += new System.EventHandler(this.CaroDisplay_Shown);
            this.chessboard_pnl.ResumeLayout(false);
            this.Option_pnl.ResumeLayout(false);
            this.Option_pnl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.player0_image)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.player1_image)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel chessboard_pnl;
        private System.Windows.Forms.Button option_btn;
        private System.Windows.Forms.Button undo_btn;
        private System.Windows.Forms.Button rule_btn;
        private System.Windows.Forms.PictureBox player0_image;
        private System.Windows.Forms.Label player0_symboy;
        private System.Windows.Forms.Label player1_symboy;
        private System.Windows.Forms.Label player0_name;
        private System.Windows.Forms.Label player1_name;
        private System.Windows.Forms.ProgressBar progressBar_left;
        private System.Windows.Forms.ProgressBar progressBar_right;
        private System.Windows.Forms.Timer timer_play;
        private System.Windows.Forms.Button gg_btn;
        private System.Windows.Forms.Button out_room_btn;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel Option_pnl;
        private System.Windows.Forms.Button computer;
        private System.Windows.Forms.Button person;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button save_option_btn;
        private System.Windows.Forms.CheckBox nhac;
        private System.Windows.Forms.CheckBox amthanh;
        private System.Windows.Forms.Label label_maphong;
        private System.Windows.Forms.Label maphong;
        private System.Windows.Forms.PictureBox player1_image;
    }
}

