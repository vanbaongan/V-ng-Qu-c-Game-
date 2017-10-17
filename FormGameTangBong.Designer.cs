namespace VuongQuocTroChoi
{
    partial class FormGameTangBong
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.cbdokho = new System.Windows.Forms.ComboBox();
            this.btnbatdau = new System.Windows.Forms.Button();
            this.btntamdung = new System.Windows.Forms.Button();
            this.cbnhanvat = new System.Windows.Forms.ComboBox();
            this.btntieptuc = new System.Windows.Forms.Button();
            this.lbldiem = new System.Windows.Forms.Label();
            this.btnthoat = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnchoilai = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pichuongdan = new System.Windows.Forms.PictureBox();
            this.picbanh = new System.Windows.Forms.PictureBox();
            this.picdobanh = new System.Windows.Forms.PictureBox();
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pichuongdan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbanh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picdobanh)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // cbdokho
            // 
            this.cbdokho.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.cbdokho.FormattingEnabled = true;
            this.cbdokho.Items.AddRange(new object[] {
            "Dễ",
            "Trung Bình",
            "Khó"});
            this.cbdokho.Location = new System.Drawing.Point(6, 39);
            this.cbdokho.Name = "cbdokho";
            this.cbdokho.Size = new System.Drawing.Size(90, 27);
            this.cbdokho.TabIndex = 2;
            // 
            // btnbatdau
            // 
            this.btnbatdau.Location = new System.Drawing.Point(320, 15);
            this.btnbatdau.Name = "btnbatdau";
            this.btnbatdau.Size = new System.Drawing.Size(65, 23);
            this.btnbatdau.TabIndex = 3;
            this.btnbatdau.Text = "Bắt đầu";
            this.btnbatdau.UseVisualStyleBackColor = true;
            this.btnbatdau.Click += new System.EventHandler(this.btnbatdau_Click);
            // 
            // btntamdung
            // 
            this.btntamdung.Location = new System.Drawing.Point(401, 15);
            this.btntamdung.Name = "btntamdung";
            this.btntamdung.Size = new System.Drawing.Size(75, 23);
            this.btntamdung.TabIndex = 4;
            this.btntamdung.Text = "Tạm dừng";
            this.btntamdung.UseVisualStyleBackColor = true;
            this.btntamdung.Click += new System.EventHandler(this.btntamdung_Click);
            // 
            // cbnhanvat
            // 
            this.cbnhanvat.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.cbnhanvat.FormattingEnabled = true;
            this.cbnhanvat.Items.AddRange(new object[] {
            "Naruto",
            "Sasuke",
            "Sakura"});
            this.cbnhanvat.Location = new System.Drawing.Point(102, 39);
            this.cbnhanvat.Name = "cbnhanvat";
            this.cbnhanvat.Size = new System.Drawing.Size(90, 27);
            this.cbnhanvat.TabIndex = 5;
            // 
            // btntieptuc
            // 
            this.btntieptuc.Location = new System.Drawing.Point(485, 15);
            this.btntieptuc.Name = "btntieptuc";
            this.btntieptuc.Size = new System.Drawing.Size(75, 23);
            this.btntieptuc.TabIndex = 6;
            this.btntieptuc.Text = "Tiếp tục";
            this.btntieptuc.UseVisualStyleBackColor = true;
            this.btntieptuc.Click += new System.EventHandler(this.btntieptuc_Click);
            // 
            // lbldiem
            // 
            this.lbldiem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lbldiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbldiem.ForeColor = System.Drawing.Color.Red;
            this.lbldiem.Location = new System.Drawing.Point(222, 31);
            this.lbldiem.Name = "lbldiem";
            this.lbldiem.Size = new System.Drawing.Size(70, 37);
            this.lbldiem.TabIndex = 7;
            this.lbldiem.Text = "0";
            this.lbldiem.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnthoat
            // 
            this.btnthoat.Location = new System.Drawing.Point(355, 45);
            this.btnthoat.Name = "btnthoat";
            this.btnthoat.Size = new System.Drawing.Size(65, 23);
            this.btnthoat.TabIndex = 8;
            this.btnthoat.Text = "Thoát";
            this.btnthoat.UseVisualStyleBackColor = true;
            this.btnthoat.Click += new System.EventHandler(this.btnthoat_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(11, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "Độ khó";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.Location = new System.Drawing.Point(111, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 16);
            this.label2.TabIndex = 10;
            this.label2.Text = "Nhân vật";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.Location = new System.Drawing.Point(226, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 16);
            this.label3.TabIndex = 11;
            this.label3.Text = "Điểm số";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.PaleGreen;
            this.groupBox1.Controls.Add(this.btnchoilai);
            this.groupBox1.Controls.Add(this.cbdokho);
            this.groupBox1.Controls.Add(this.btntieptuc);
            this.groupBox1.Controls.Add(this.btnthoat);
            this.groupBox1.Controls.Add(this.btntamdung);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnbatdau);
            this.groupBox1.Controls.Add(this.lbldiem);
            this.groupBox1.Controls.Add(this.cbnhanvat);
            this.groupBox1.Location = new System.Drawing.Point(1, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(560, 74);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            // 
            // btnchoilai
            // 
            this.btnchoilai.Location = new System.Drawing.Point(440, 45);
            this.btnchoilai.Name = "btnchoilai";
            this.btnchoilai.Size = new System.Drawing.Size(75, 23);
            this.btnchoilai.TabIndex = 12;
            this.btnchoilai.Text = "Chơi lại";
            this.btnchoilai.UseVisualStyleBackColor = true;
            this.btnchoilai.Click += new System.EventHandler(this.btnchoilai_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.ToolTipTitle = "Hướng dẫn!";
            // 
            // pichuongdan
            // 
            this.pichuongdan.BackgroundImage = global::VuongQuocTroChoi.Properties.Resources.tải_xuống;
            this.pichuongdan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pichuongdan.Location = new System.Drawing.Point(522, 80);
            this.pichuongdan.Name = "pichuongdan";
            this.pichuongdan.Size = new System.Drawing.Size(28, 29);
            this.pichuongdan.TabIndex = 13;
            this.pichuongdan.TabStop = false;
            this.toolTip1.SetToolTip(this.pichuongdan, "- Có thể chọn nhân vật và độ khó.\r\n- Di chuyển nhân vật bằng chuột hoặc phím trái" +
        ", phải để đỡ\r\nbóng không để bóng rơi.");
            // 
            // picbanh
            // 
            this.picbanh.Image = global::VuongQuocTroChoi.Properties.Resources.icon170x170;
            this.picbanh.Location = new System.Drawing.Point(177, 100);
            this.picbanh.Name = "picbanh";
            this.picbanh.Size = new System.Drawing.Size(61, 55);
            this.picbanh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picbanh.TabIndex = 1;
            this.picbanh.TabStop = false;
            // 
            // picdobanh
            // 
            this.picdobanh.Image = global::VuongQuocTroChoi.Properties.Resources.naruto_sasuke_chibi__2_;
            this.picdobanh.Location = new System.Drawing.Point(167, 332);
            this.picdobanh.Name = "picdobanh";
            this.picdobanh.Size = new System.Drawing.Size(92, 142);
            this.picdobanh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picdobanh.TabIndex = 0;
            this.picdobanh.TabStop = false;
            this.picdobanh.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picdobanh_MouseMove);
            // 
            // FormGameTangBong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(562, 475);
            this.Controls.Add(this.pichuongdan);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.picbanh);
            this.Controls.Add(this.picdobanh);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FormGameTangBong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormGameTangBong";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormGameTangBong_FormClosing);
            this.Load += new System.EventHandler(this.FormGameTangBong_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pichuongdan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbanh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picdobanh)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picdobanh;
        private System.Windows.Forms.PictureBox picbanh;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ComboBox cbdokho;
        private System.Windows.Forms.Button btnbatdau;
        private System.Windows.Forms.Button btntamdung;
        private System.Windows.Forms.ComboBox cbnhanvat;
        private System.Windows.Forms.Button btntieptuc;
        private System.Windows.Forms.Label lbldiem;
        private System.Windows.Forms.Button btnthoat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnchoilai;
        private System.Windows.Forms.PictureBox pichuongdan;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolTip toolTip2;
    }
}