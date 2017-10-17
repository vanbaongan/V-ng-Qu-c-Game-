namespace VuongQuocTroChoi
{
    partial class DangNhap
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
            this.lblthoigian = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.txttendangnhap = new System.Windows.Forms.TextBox();
            this.txtpass = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnsigin = new System.Windows.Forms.Button();
            this.btnsigup = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblthoigian
            // 
            this.lblthoigian.BackColor = System.Drawing.Color.Blue;
            this.lblthoigian.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblthoigian.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblthoigian.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblthoigian.ForeColor = System.Drawing.Color.Transparent;
            this.lblthoigian.Location = new System.Drawing.Point(0, 0);
            this.lblthoigian.Name = "lblthoigian";
            this.lblthoigian.Size = new System.Drawing.Size(464, 61);
            this.lblthoigian.TabIndex = 17;
            this.lblthoigian.Text = "ĐĂNG NHẬP        ";
            this.lblthoigian.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // txttendangnhap
            // 
            this.txttendangnhap.Location = new System.Drawing.Point(310, 105);
            this.txttendangnhap.Name = "txttendangnhap";
            this.txttendangnhap.Size = new System.Drawing.Size(142, 20);
            this.txttendangnhap.TabIndex = 18;
            // 
            // txtpass
            // 
            this.txtpass.Location = new System.Drawing.Point(310, 163);
            this.txtpass.Name = "txtpass";
            this.txtpass.Size = new System.Drawing.Size(142, 20);
            this.txtpass.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(188, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 24);
            this.label1.TabIndex = 20;
            this.label1.Text = "Username";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(188, 158);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 24);
            this.label2.TabIndex = 21;
            this.label2.Text = "Password";
            // 
            // btnsigin
            // 
            this.btnsigin.Location = new System.Drawing.Point(248, 227);
            this.btnsigin.Name = "btnsigin";
            this.btnsigin.Size = new System.Drawing.Size(75, 23);
            this.btnsigin.TabIndex = 22;
            this.btnsigin.Text = "Sig in";
            this.btnsigin.UseVisualStyleBackColor = true;
            this.btnsigin.Click += new System.EventHandler(this.btnsigin_Click);
            // 
            // btnsigup
            // 
            this.btnsigup.Location = new System.Drawing.Point(358, 227);
            this.btnsigup.Name = "btnsigup";
            this.btnsigup.Size = new System.Drawing.Size(75, 23);
            this.btnsigup.TabIndex = 23;
            this.btnsigup.Text = "Sig up";
            this.btnsigup.UseVisualStyleBackColor = true;
            this.btnsigup.Click += new System.EventHandler(this.btnsigup_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Image = global::VuongQuocTroChoi.Properties.Resources.system_users;
            this.pictureBox1.Location = new System.Drawing.Point(12, 86);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(161, 149);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 24;
            this.pictureBox1.TabStop = false;
            // 
            // DangNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(464, 335);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnsigup);
            this.Controls.Add(this.btnsigin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtpass);
            this.Controls.Add(this.txttendangnhap);
            this.Controls.Add(this.lblthoigian);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "DangNhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DangNhap";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblthoigian;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox txttendangnhap;
        private System.Windows.Forms.TextBox txtpass;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnsigin;
        private System.Windows.Forms.Button btnsigup;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}