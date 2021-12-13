namespace CARO
{
    partial class ListGameSave
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
            this.Panel_Savegame = new System.Windows.Forms.TableLayoutPanel();
            this.control_savegame = new System.Windows.Forms.Panel();
            this.save_btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.name_save = new System.Windows.Forms.TextBox();
            this.control_savegame.SuspendLayout();
            this.SuspendLayout();
            // 
            // Panel_Savegame
            // 
            this.Panel_Savegame.BackColor = System.Drawing.Color.Transparent;
            this.Panel_Savegame.ColumnCount = 3;
            this.Panel_Savegame.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.Panel_Savegame.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.Panel_Savegame.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.Panel_Savegame.Location = new System.Drawing.Point(86, 35);
            this.Panel_Savegame.Name = "Panel_Savegame";
            this.Panel_Savegame.RowCount = 2;
            this.Panel_Savegame.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.Panel_Savegame.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.Panel_Savegame.Size = new System.Drawing.Size(618, 302);
            this.Panel_Savegame.TabIndex = 0;
            // 
            // control_savegame
            // 
            this.control_savegame.BackColor = System.Drawing.Color.Transparent;
            this.control_savegame.Controls.Add(this.save_btn);
            this.control_savegame.Controls.Add(this.label1);
            this.control_savegame.Controls.Add(this.name_save);
            this.control_savegame.Location = new System.Drawing.Point(162, 359);
            this.control_savegame.Name = "control_savegame";
            this.control_savegame.Size = new System.Drawing.Size(458, 121);
            this.control_savegame.TabIndex = 1;
            // 
            // save_btn
            // 
            this.save_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.save_btn.FlatAppearance.BorderSize = 0;
            this.save_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.save_btn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.save_btn.Location = new System.Drawing.Point(175, 76);
            this.save_btn.Name = "save_btn";
            this.save_btn.Size = new System.Drawing.Size(120, 45);
            this.save_btn.TabIndex = 2;
            this.save_btn.Text = "OK";
            this.save_btn.UseVisualStyleBackColor = false;
            this.save_btn.Click += new System.EventHandler(this.save_btn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(25, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Lưu với tên:";
            // 
            // name_save
            // 
            this.name_save.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.name_save.Location = new System.Drawing.Point(145, 33);
            this.name_save.Name = "name_save";
            this.name_save.Size = new System.Drawing.Size(255, 31);
            this.name_save.TabIndex = 0;
            // 
            // ListGameSave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::CARO.Properties.Resources._31;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(791, 492);
            this.Controls.Add(this.control_savegame);
            this.Controls.Add(this.Panel_Savegame);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ListGameSave";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ListGameSave";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ListGameSave_FormClosing);
            this.Load += new System.EventHandler(this.ListGameSave_Load);
            this.control_savegame.ResumeLayout(false);
            this.control_savegame.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel Panel_Savegame;
        private System.Windows.Forms.Button save_btn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox name_save;
        public System.Windows.Forms.Panel control_savegame;
    }
}