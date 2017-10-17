namespace VuongQuocTroChoi
{
    partial class GameCaro
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
            this.panel = new System.Windows.Forms.Panel();
            this.btnthoat = new System.Windows.Forms.Button();
            this.btnChoivoimay = new System.Windows.Forms.Button();
            this.btnChoivoinguoi = new System.Windows.Forms.Button();
            this.btnchoilai = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pichuongdan = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.lblthoigian = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pichuongdan)).BeginInit();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panel.Location = new System.Drawing.Point(162, 51);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(440, 365);
            this.panel.TabIndex = 9;
            this.panel.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_Paint);
            this.panel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panel_MouseClick);
            // 
            // btnthoat
            // 
            this.btnthoat.Location = new System.Drawing.Point(26, 293);
            this.btnthoat.Name = "btnthoat";
            this.btnthoat.Size = new System.Drawing.Size(100, 23);
            this.btnthoat.TabIndex = 6;
            this.btnthoat.Text = "Thoát";
            this.btnthoat.UseVisualStyleBackColor = true;
            this.btnthoat.Click += new System.EventHandler(this.btnthoat_Click);
            // 
            // btnChoivoimay
            // 
            this.btnChoivoimay.Location = new System.Drawing.Point(14, 89);
            this.btnChoivoimay.Name = "btnChoivoimay";
            this.btnChoivoimay.Size = new System.Drawing.Size(110, 36);
            this.btnChoivoimay.TabIndex = 7;
            this.btnChoivoimay.Text = "Người với Máy";
            this.btnChoivoimay.UseVisualStyleBackColor = true;
            // 
            // btnChoivoinguoi
            // 
            this.btnChoivoinguoi.Location = new System.Drawing.Point(14, 39);
            this.btnChoivoinguoi.Name = "btnChoivoinguoi";
            this.btnChoivoinguoi.Size = new System.Drawing.Size(110, 33);
            this.btnChoivoinguoi.TabIndex = 8;
            this.btnChoivoinguoi.Text = "Người với Người";
            this.btnChoivoinguoi.UseVisualStyleBackColor = true;
            // 
            // btnchoilai
            // 
            this.btnchoilai.Location = new System.Drawing.Point(26, 264);
            this.btnchoilai.Name = "btnchoilai";
            this.btnchoilai.Size = new System.Drawing.Size(100, 23);
            this.btnchoilai.TabIndex = 10;
            this.btnchoilai.Text = "Chơi lại";
            this.btnchoilai.UseVisualStyleBackColor = true;
            this.btnchoilai.Click += new System.EventHandler(this.btnchoilai_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.groupBox1.Controls.Add(this.btnChoivoimay);
            this.groupBox1.Controls.Add(this.btnChoivoinguoi);
            this.groupBox1.Location = new System.Drawing.Point(12, 65);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(135, 148);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chế độ chơi";
            // 
            // pichuongdan
            // 
            this.pichuongdan.BackgroundImage = global::VuongQuocTroChoi.Properties.Resources.tải_xuống;
            this.pichuongdan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pichuongdan.Location = new System.Drawing.Point(59, 345);
            this.pichuongdan.Name = "pichuongdan";
            this.pichuongdan.Size = new System.Drawing.Size(28, 29);
            this.pichuongdan.TabIndex = 15;
            this.pichuongdan.TabStop = false;
            this.toolTip1.SetToolTip(this.pichuongdan, "\r\nChọn chế độ chơi với người hay với máy.\r\nNếu bên nào có được 1 hàng 5 chấm liên" +
        " tiếp nhau\r\ntrước là bên đó thắng.\r\nChúc bạn may mắn!");
            // 
            // lblthoigian
            // 
            this.lblthoigian.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.lblthoigian.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblthoigian.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblthoigian.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblthoigian.ForeColor = System.Drawing.Color.Black;
            this.lblthoigian.Location = new System.Drawing.Point(0, 0);
            this.lblthoigian.Name = "lblthoigian";
            this.lblthoigian.Size = new System.Drawing.Size(614, 38);
            this.lblthoigian.TabIndex = 16;
            this.lblthoigian.Text = "                              GAME CARO                           ";
            this.lblthoigian.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // GameCaro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(614, 428);
            this.Controls.Add(this.lblthoigian);
            this.Controls.Add(this.pichuongdan);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnchoilai);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.btnthoat);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "GameCaro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GameCaro";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GameCaro_FormClosing);
            this.Load += new System.EventHandler(this.GameCaro_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pichuongdan)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Button btnthoat;
        private System.Windows.Forms.Button btnChoivoimay;
        private System.Windows.Forms.Button btnChoivoinguoi;
        private System.Windows.Forms.Button btnchoilai;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pichuongdan;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label lblthoigian;
        private System.Windows.Forms.Timer timer1;
    }
}