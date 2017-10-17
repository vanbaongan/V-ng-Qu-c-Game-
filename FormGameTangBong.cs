using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Data.SqlClient;



namespace VuongQuocTroChoi
{
    public partial class FormGameTangBong : Form
    {
        public FormGameTangBong()
        {
            Thread t = new Thread(new ThreadStart(VuongQuocTroChoi));
            t.Start();
            Thread.Sleep(5000);
            InitializeComponent();
            t.Abort();
        }

        private void VuongQuocTroChoi()
        {
            Application.Run(new FormKhoiDongGameTangBong());
        }

        int ketqua = 0;
        int dx = 7, dy = 10;
        string duongdan = Application.StartupPath + @"\nhanvat\";
        int trangthai = 0;

        private SqlConnection cnn = null;
        private string cnstr = "Server = DESKTOP-0KSPLP6\\SQLEXPRESS; Database = VuongQuocTroChoi; Integrated security = true; ";
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (picbanh.Left < 0 || picbanh.Right > ClientRectangle.Width)
                dx = -dx;
            if (picbanh.Top < 75) // !!!!!!!!!!
                dy = -dy;
            if ((picbanh.Bottom > picdobanh.Top) && ((picbanh.Right > picdobanh.Left) && (picbanh.Left < picdobanh.Right)))
            {
                ketqua++;
                dy = -dy;
                lbldiem.Text = ketqua.ToString();
            }
            if ((picbanh.Bottom > picdobanh.Top) && ((picbanh.Right < picdobanh.Left) || (picbanh.Left > picdobanh.Right)))
            {
                timer1.Stop();
                MessageBox.Show("Bạn ghi được " + ketqua.ToString() + " điểm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                btntieptuc.Enabled = false;
                btntamdung.Enabled = false;
                /////// Luu ket qua choi
               // DangNhap dn = new DangNhap();
                cnn = new SqlConnection(cnstr);
                cnn.Open();
                string sql = "select * from ThongKeKetQua";
                SqlDataAdapter ad = new SqlDataAdapter(sql, cnn);
                DataSet ds = new DataSet();
                ad.Fill(ds);
                DataRow dr = ds.Tables[0].NewRow();
                dr["TenDangNhap"] = DangNhap.id;
                dr["TenTroChoi"] = "Game Tâng Bóng";
                dr["KetQua"] = ketqua.ToString();
                ds.Tables[0].Rows.Add(dr);
                SqlCommandBuilder cm = new SqlCommandBuilder(ad);
                ad.Update(ds);
                trangthai = 1;
                ///////////////////

            }
            picbanh.Left += dx;
            picbanh.Top += dy;
            btnchoilai.Enabled = true;
            btnbatdau.Enabled = false;
        }

        private void picdobanh_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {

                if (picdobanh.Left < ClientRectangle.Left)
                    picdobanh.Left = 0;
                if (picdobanh.Right > ClientRectangle.Right)
                    picdobanh.Left = ClientRectangle.Right - (picdobanh.Right - picdobanh.Left);
                picdobanh.Left += e.X;
            }
        }

        private void btnbatdau_Click(object sender, EventArgs e)
        {
            if (cbdokho.SelectedIndex == 0)
            {
                dx = 7;
                dy = 10;
            }
            else if (cbdokho.SelectedIndex == 1)
            {
                dx = 12;
                dy = 15;
            }
            else if (cbdokho.SelectedIndex == 2)
            {
                dx = 22;
                dy = 25;
            }
            if (cbnhanvat.SelectedIndex == 1)
                picdobanh.Image = Image.FromFile(duongdan + "sasuke.jpg");
            if (cbnhanvat.SelectedIndex == 2)
                picdobanh.Image = Image.FromFile(duongdan + "sakura.png");
            if (cbnhanvat.SelectedIndex == 0)
                picdobanh.Image = Image.FromFile(duongdan + "naruto.jpg");
            timer1.Start();
            cbdokho.Enabled = false;
            cbnhanvat.Enabled = false;
            btntamdung.Enabled = true;
            btntieptuc.Enabled = true;
        }

        private void FormGameTangBong_Load(object sender, EventArgs e)
        {
            timer1.Stop();
            cbdokho.SelectedIndex = 0;
            cbnhanvat.SelectedIndex = 0;
            btnbatdau.Enabled = true;
            btnchoilai.Enabled = true;
            btntamdung.Enabled = false;
            btntieptuc.Enabled = false;
            btnchoilai.Enabled = false;
        }

        private void btntamdung_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            btnbatdau.Enabled = false;
            btntamdung.Enabled = false;
            cbdokho.Enabled = true;
            cbnhanvat.Enabled = true;
        }

        private void btntieptuc_Click(object sender, EventArgs e)
        {
            if (cbdokho.SelectedIndex == 0)
            {
                dx = 7;
                dy = 10;
            }
            else if (cbdokho.SelectedIndex == 1)
            {
                dx = 12;
                dy = 15;
            }
            else if (cbdokho.SelectedIndex == 2)
            {
                dx = 22;
                dy = 25;
            }
            if (cbnhanvat.SelectedIndex == 1)
                picdobanh.Image = Image.FromFile(duongdan + "sasuke.jpg");
            if (cbnhanvat.SelectedIndex == 2)
                picdobanh.Image = Image.FromFile(duongdan + "sakura.png");
            if (cbnhanvat.SelectedIndex == 0)
                picdobanh.Image = Image.FromFile(duongdan + "naruto.jpg");
            timer1.Start();
            btntamdung.Enabled = true;
            cbdokho.Enabled = false;
            cbnhanvat.Enabled = false;
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void FormGameTangBong_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop();
            if (MessageBox.Show("Bạn có muốn đóng ứng dụng ?", "Thông báo!",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                //Lưu KQ
                if (trangthai == 0)
                {
                    cnn = new SqlConnection(cnstr);
                    cnn.Open();
                    string sql = "select * from ThongKeKetQua";
                    SqlDataAdapter ad = new SqlDataAdapter(sql, cnn);
                    DataSet ds = new DataSet();
                    ad.Fill(ds);
                    DataRow dr = ds.Tables[0].NewRow();
                    dr["TenDangNhap"] = DangNhap.id;
                    dr["TenTroChoi"] = "Game Tâng Bóng";
                    dr["KetQua"] = ketqua.ToString();
                    ds.Tables[0].Rows.Add(dr);
                    SqlCommandBuilder cm = new SqlCommandBuilder(ad);
                    ad.Update(ds);
                    ////////////////

                }
                FormMenu fr = new FormMenu();
                fr.Show();
            }

        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Left:
                    {
                        if (picdobanh.Left < ClientRectangle.Width) picdobanh.Left -= 20;
                        break;
                    }
                case Keys.Right:
                    {
                        if (picdobanh.Right > 0) picdobanh.Left += 20;
                        break;
                    }
            }
            return true;
        }

        private void btnchoilai_Click(object sender, EventArgs e)
        {
            ketqua = 0;
            cbdokho.SelectedIndex = 0;
            cbnhanvat.SelectedIndex = 0;
            btnbatdau.Enabled = true;
            btnchoilai.Enabled = false;
            btntamdung.Enabled = false;
            btntieptuc.Enabled = false;
            picbanh.Left = 175;
            picbanh.Top = 100;
        }
 
    }
}
