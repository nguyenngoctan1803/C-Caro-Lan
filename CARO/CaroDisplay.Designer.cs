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
            this.addRoom_btn = new System.Windows.Forms.Button();
            this.search_btn = new System.Windows.Forms.Button();
            this.search_roomid = new System.Windows.Forms.TextBox();
            this.save_option_btn = new System.Windows.Forms.Button();
            this.computer = new System.Windows.Forms.Button();
            this.person = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.player0_image = new System.Windows.Forms.PictureBox();
            this.player0_symboy = new System.Windows.Forms.Label();
            this.player1_symboy = new System.Windows.Forms.Label();
            this.player0_name = new System.Windows.Forms.Label();
            this.player1_name = new System.Windows.Forms.Label();
            this.progressBar_left = new System.Windows.Forms.ProgressBar();
            this.progressBar_right = new System.Windows.Forms.ProgressBar();
            this.timer_play = new System.Windows.Forms.Timer(this.components);
            this.out_room_btn = new System.Windows.Forms.Button();
            this.label_maphong = new System.Windows.Forms.Label();
            this.maphong = new System.Windows.Forms.Label();
            this.player1_image = new System.Windows.Forms.PictureBox();
            this.control_pnl = new System.Windows.Forms.Panel();
            this.rule_btn = new System.Windows.Forms.Button();
            this.undo_btn = new System.Windows.Forms.Button();
            this.option_btn = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ruleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rank_btn = new System.Windows.Forms.Button();
            this.chessboard_pnl.SuspendLayout();
            this.Option_pnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.player0_image)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.player1_image)).BeginInit();
            this.control_pnl.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chessboard_pnl
            // 
            this.chessboard_pnl.BackColor = System.Drawing.Color.Black;
            this.chessboard_pnl.Controls.Add(this.Option_pnl);
            this.chessboard_pnl.Location = new System.Drawing.Point(304, 12);
            this.chessboard_pnl.Name = "chessboard_pnl";
            this.chessboard_pnl.Size = new System.Drawing.Size(812, 749);
            this.chessboard_pnl.TabIndex = 0;
            // 
            // Option_pnl
            // 
            this.Option_pnl.BackColor = System.Drawing.Color.DarkOrange;
            this.Option_pnl.Controls.Add(this.addRoom_btn);
            this.Option_pnl.Controls.Add(this.search_btn);
            this.Option_pnl.Controls.Add(this.search_roomid);
            this.Option_pnl.Controls.Add(this.save_option_btn);
            this.Option_pnl.Controls.Add(this.computer);
            this.Option_pnl.Controls.Add(this.person);
            this.Option_pnl.Controls.Add(this.label8);
            this.Option_pnl.Location = new System.Drawing.Point(121, 202);
            this.Option_pnl.Name = "Option_pnl";
            this.Option_pnl.Size = new System.Drawing.Size(576, 300);
            this.Option_pnl.TabIndex = 1;
            this.Option_pnl.Visible = false;
            // 
            // addRoom_btn
            // 
            this.addRoom_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addRoom_btn.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.addRoom_btn.Location = new System.Drawing.Point(215, 220);
            this.addRoom_btn.Name = "addRoom_btn";
            this.addRoom_btn.Size = new System.Drawing.Size(149, 39);
            this.addRoom_btn.TabIndex = 7;
            this.addRoom_btn.Text = "Tạo Phòng";
            this.addRoom_btn.UseVisualStyleBackColor = true;
            this.addRoom_btn.Visible = false;
            this.addRoom_btn.Click += new System.EventHandler(this.addRoom_btn_Click);
            // 
            // search_btn
            // 
            this.search_btn.BackgroundImage = global::CARO.Properties.Resources.search;
            this.search_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.search_btn.FlatAppearance.BorderSize = 0;
            this.search_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.search_btn.Location = new System.Drawing.Point(152, 169);
            this.search_btn.Name = "search_btn";
            this.search_btn.Size = new System.Drawing.Size(46, 38);
            this.search_btn.TabIndex = 6;
            this.search_btn.UseVisualStyleBackColor = true;
            this.search_btn.Visible = false;
            this.search_btn.Click += new System.EventHandler(this.search_button_Click);
            // 
            // search_roomid
            // 
            this.search_roomid.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.search_roomid.Location = new System.Drawing.Point(204, 172);
            this.search_roomid.Multiline = true;
            this.search_roomid.Name = "search_roomid";
            this.search_roomid.Size = new System.Drawing.Size(169, 27);
            this.search_roomid.TabIndex = 5;
            this.search_roomid.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.search_roomid.Visible = false;
            this.search_roomid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.search_roomid_KeyDown);
            // 
            // save_option_btn
            // 
            this.save_option_btn.BackColor = System.Drawing.Color.White;
            this.save_option_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.save_option_btn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.save_option_btn.Location = new System.Drawing.Point(215, 221);
            this.save_option_btn.Name = "save_option_btn";
            this.save_option_btn.Size = new System.Drawing.Size(149, 38);
            this.save_option_btn.TabIndex = 3;
            this.save_option_btn.Text = "OK";
            this.save_option_btn.UseVisualStyleBackColor = false;
            this.save_option_btn.Click += new System.EventHandler(this.save_option_btn_Click);
            // 
            // computer
            // 
            this.computer.BackColor = System.Drawing.Color.LimeGreen;
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
            this.person.BackColor = System.Drawing.Color.Red;
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
            // out_room_btn
            // 
            this.out_room_btn.BackColor = System.Drawing.Color.Transparent;
            this.out_room_btn.BackgroundImage = global::CARO.Properties.Resources.log_out;
            this.out_room_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.out_room_btn.FlatAppearance.BorderSize = 0;
            this.out_room_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.out_room_btn.Location = new System.Drawing.Point(1340, 777);
            this.out_room_btn.Name = "out_room_btn";
            this.out_room_btn.Size = new System.Drawing.Size(67, 64);
            this.out_room_btn.TabIndex = 8;
            this.out_room_btn.UseVisualStyleBackColor = false;
            this.out_room_btn.Visible = false;
            this.out_room_btn.VisibleChanged += new System.EventHandler(this.out_room_btn_VisibleChanged);
            this.out_room_btn.Click += new System.EventHandler(this.exit_game);
            // 
            // label_maphong
            // 
            this.label_maphong.AutoSize = true;
            this.label_maphong.BackColor = System.Drawing.Color.Transparent;
            this.label_maphong.Font = new System.Drawing.Font("Segoe UI", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label_maphong.Location = new System.Drawing.Point(1035, 793);
            this.label_maphong.Name = "label_maphong";
            this.label_maphong.Size = new System.Drawing.Size(135, 32);
            this.label_maphong.TabIndex = 10;
            this.label_maphong.Text = "Mã Phòng:";
            this.label_maphong.Visible = false;
            // 
            // maphong
            // 
            this.maphong.AutoSize = true;
            this.maphong.BackColor = System.Drawing.Color.Transparent;
            this.maphong.Font = new System.Drawing.Font("Segoe UI", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.maphong.Location = new System.Drawing.Point(1180, 793);
            this.maphong.Name = "maphong";
            this.maphong.Size = new System.Drawing.Size(127, 32);
            this.maphong.TabIndex = 10;
            this.maphong.Tag = "ipv4";
            this.maphong.Text = "19522174";
            this.maphong.Visible = false;
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
            // control_pnl
            // 
            this.control_pnl.BackColor = System.Drawing.Color.Transparent;
            this.control_pnl.Controls.Add(this.rule_btn);
            this.control_pnl.Controls.Add(this.undo_btn);
            this.control_pnl.Controls.Add(this.option_btn);
            this.control_pnl.Location = new System.Drawing.Point(530, 768);
            this.control_pnl.Name = "control_pnl";
            this.control_pnl.Size = new System.Drawing.Size(366, 73);
            this.control_pnl.TabIndex = 11;
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
            this.rule_btn.Location = new System.Drawing.Point(277, 16);
            this.rule_btn.Name = "rule_btn";
            this.rule_btn.Size = new System.Drawing.Size(63, 50);
            this.rule_btn.TabIndex = 2;
            this.rule_btn.UseVisualStyleBackColor = false;
            // 
            // undo_btn
            // 
            this.undo_btn.BackColor = System.Drawing.Color.Transparent;
            this.undo_btn.BackgroundImage = global::CARO.Properties.Resources.undo;
            this.undo_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.undo_btn.FlatAppearance.BorderSize = 0;
            this.undo_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.undo_btn.Location = new System.Drawing.Point(23, 16);
            this.undo_btn.Name = "undo_btn";
            this.undo_btn.Size = new System.Drawing.Size(64, 50);
            this.undo_btn.TabIndex = 3;
            this.undo_btn.UseVisualStyleBackColor = false;
            // 
            // option_btn
            // 
            this.option_btn.BackColor = System.Drawing.Color.Transparent;
            this.option_btn.BackgroundImage = global::CARO.Properties.Resources.option;
            this.option_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.option_btn.FlatAppearance.BorderSize = 0;
            this.option_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.option_btn.Location = new System.Drawing.Point(150, 16);
            this.option_btn.Name = "option_btn";
            this.option_btn.Size = new System.Drawing.Size(64, 50);
            this.option_btn.TabIndex = 4;
            this.option_btn.UseVisualStyleBackColor = false;
            this.option_btn.Click += new System.EventHandler(this.option_btn_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1419, 31);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.openToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(50, 27);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(198, 28);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(198, 28);
            this.openToolStripMenuItem.Text = "Open";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(198, 28);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem1,
            this.ruleToolStripMenuItem});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(60, 27);
            this.aboutToolStripMenuItem.Text = "Help";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem1
            // 
            this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            this.aboutToolStripMenuItem1.Size = new System.Drawing.Size(141, 28);
            this.aboutToolStripMenuItem1.Text = "About";
            // 
            // ruleToolStripMenuItem
            // 
            this.ruleToolStripMenuItem.Name = "ruleToolStripMenuItem";
            this.ruleToolStripMenuItem.Size = new System.Drawing.Size(141, 28);
            this.ruleToolStripMenuItem.Text = "Rule";
            // 
            // rank_btn
            // 
            this.rank_btn.BackColor = System.Drawing.Color.Transparent;
            this.rank_btn.BackgroundImage = global::CARO.Properties.Resources.star;
            this.rank_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.rank_btn.FlatAppearance.BorderSize = 0;
            this.rank_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rank_btn.Location = new System.Drawing.Point(95, 82);
            this.rank_btn.Name = "rank_btn";
            this.rank_btn.Size = new System.Drawing.Size(116, 84);
            this.rank_btn.TabIndex = 13;
            this.rank_btn.UseVisualStyleBackColor = false;
            // 
            // CaroDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::CARO.Properties.Resources._3;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1419, 853);
            this.Controls.Add(this.rank_btn);
            this.Controls.Add(this.control_pnl);
            this.Controls.Add(this.maphong);
            this.Controls.Add(this.label_maphong);
            this.Controls.Add(this.out_room_btn);
            this.Controls.Add(this.progressBar_right);
            this.Controls.Add(this.progressBar_left);
            this.Controls.Add(this.player1_name);
            this.Controls.Add(this.player0_name);
            this.Controls.Add(this.player1_symboy);
            this.Controls.Add(this.player0_symboy);
            this.Controls.Add(this.player1_image);
            this.Controls.Add(this.player0_image);
            this.Controls.Add(this.chessboard_pnl);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(1437, 900);
            this.Name = "CaroDisplay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Caro";
            this.TransparencyKey = System.Drawing.Color.DarkRed;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.close_game);
            this.Load += new System.EventHandler(this.CaroDisplay_Load);
            this.Shown += new System.EventHandler(this.CaroDisplay_Shown);
            this.chessboard_pnl.ResumeLayout(false);
            this.Option_pnl.ResumeLayout(false);
            this.Option_pnl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.player0_image)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.player1_image)).EndInit();
            this.control_pnl.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel chessboard_pnl;
        private System.Windows.Forms.PictureBox player0_image;
        private System.Windows.Forms.Label player0_symboy;
        private System.Windows.Forms.Label player1_symboy;
        private System.Windows.Forms.Label player0_name;
        private System.Windows.Forms.Label player1_name;
        private System.Windows.Forms.ProgressBar progressBar_left;
        private System.Windows.Forms.ProgressBar progressBar_right;
        private System.Windows.Forms.Timer timer_play;
        private System.Windows.Forms.Button out_room_btn;
        private System.Windows.Forms.Panel Option_pnl;
        private System.Windows.Forms.Button computer;
        private System.Windows.Forms.Button person;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button save_option_btn;
        private System.Windows.Forms.Label label_maphong;
        private System.Windows.Forms.Label maphong;
        private System.Windows.Forms.PictureBox player1_image;
        private System.Windows.Forms.Button search_btn;
        private System.Windows.Forms.TextBox search_roomid;
        private System.Windows.Forms.Button addRoom_btn;
        private System.Windows.Forms.Panel control_pnl;
        private System.Windows.Forms.Button rule_btn;
        private System.Windows.Forms.Button undo_btn;
        private System.Windows.Forms.Button option_btn;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem ruleToolStripMenuItem;
        private System.Windows.Forms.Button rank_btn;
    }
}

