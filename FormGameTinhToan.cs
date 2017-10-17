using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VuongQuocTroChoi
{
    public partial class FormGameTinhToan : Form
    {
        public FormGameTinhToan()
        {
            InitializeComponent();
        }

        Random rd = new Random();
        double so1;
        double so2;
        int dau;
        int diem = 0;
        double kqTamThoi ;
        int laydungsai;
        private void FormGameTinhToan_Load(object sender, EventArgs e)
        {
            lbldiem.Text = "0";
            so1 = rd.Next(1, 999);
            so2 = rd.Next(1, 999);
            dau = rd.Next(4);
            lblso1.Text = so1.ToString();
            lblso2.Text = so2.ToString();
            string layDau = Dau(dau);
            lbldau.Text = layDau;
            lblketqua.Text = ketQuaDung().ToString();
            kqTamThoi = ketQuaDung();
        }

        private string Dau(int d)
        {
            switch (d)
            {
                case 0: return lbldau.Text = "+";
                case 1: return lbldau.Text = "-";
                case 2: return lbldau.Text = "x";
                case 3: return lbldau.Text = "/";
            }
            return " ";
        }

        private double ketQuaDung()
        {
            if (dau == 0)
                return so1 + so2;
            if (dau == 1)
                return so1 - so2;
            if (dau == 2)
                return so1 * so2;
            if (dau == 3)
                return so1 / so2;
            return 0;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblthoigian.Text = lblthoigian.Text.Substring(1)
                + lblthoigian.Text.Substring(0, 1);
        }

        private SqlConnection cnn = null;
        private string cnstr = "Server = DESKTOP-0KSPLP6\\SQLEXPRESS; Database = VuongQuocTroChoi; Integrated security = true; ";
        int trangthai = 0; // kiểm tra xem đã lưu kết quả chưa.
        private void btnsai_Click(object sender, EventArgs e)
        {
            double a = ketQuaDung();
            if (a == kqTamThoi)
            {
                MessageBox.Show("Chọn sai rồi nhé! \n Số câu trả lời đúng của bạn là: "+diem, "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btndung.Enabled = btnsai.Enabled = false;

                //Lưu kết quả khi kết thúc game
                cnn = new SqlConnection(cnstr);
                cnn.Open();
                string sql = "select * from ThongKeKetQua";
                SqlDataAdapter ad = new SqlDataAdapter(sql, cnn);
                DataSet ds = new DataSet();
                ad.Fill(ds);
                DataRow dr = ds.Tables[0].NewRow();
                dr["TenDangNhap"] = DangNhap.id;
                dr["TenTroChoi"] = "Thiên Tài Toán Học";
                dr["KetQua"] = diem.ToString();
                ds.Tables[0].Rows.Add(dr);
                SqlCommandBuilder cm = new SqlCommandBuilder(ad);
                ad.Update(ds);
                trangthai = 1;
            }
            else
            {
                diem++;
                lbldiem.Text = diem.ToString();
                so1 = rd.Next(1, 999);
                so2 = rd.Next(1, 999);
                dau = rd.Next(4);
                lblso1.Text = so1.ToString();
                lblso2.Text = so2.ToString();
                string layDau = Dau(dau);
                lbldau.Text = layDau;
                laydungsai = rd.Next(1, 100);
                double b = 0;
                if (laydungsai % 2 == 0)
                {
                    b = ketQuaDung();
                    lblketqua.Text = b.ToString();
                }
                else
                {
                    b = rd.Next(0, 99999);
                    lblketqua.Text = b.ToString();
                }


            }

        }

        private void btndung_Click(object sender, EventArgs e)
        {
            double a = ketQuaDung();
            if( a == kqTamThoi)
            {
                diem++;
                lbldiem.Text = diem.ToString();

                so1 = rd.Next(1, 999);
                so2 = rd.Next(1, 999);
                dau = rd.Next(4);
                lblso1.Text = so1.ToString();
                lblso2.Text = so2.ToString();
                string layDau = Dau(dau);
                lbldau.Text = layDau;

                laydungsai = rd.Next(1,100);
                if(laydungsai % 2 == 0)
                {
                    kqTamThoi = ketQuaDung();
                    lblketqua.Text = kqTamThoi.ToString();
                }
                else
                {
                    kqTamThoi = rd.Next(0,99999);
                    lblketqua.Text = kqTamThoi.ToString();
                }
                    
                
            }
            else
            {
                 MessageBox.Show("Chọn sai rồi nhé! ","Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btndung.Enabled = btnsai.Enabled = false;

                //Lưu kết quả khi kết thúc game
                cnn = new SqlConnection(cnstr);
                cnn.Open();
                string sql = "select * from ThongKeKetQua";
                SqlDataAdapter ad = new SqlDataAdapter(sql, cnn);
                DataSet ds = new DataSet();
                ad.Fill(ds);
                DataRow dr = ds.Tables[0].NewRow();
                dr["TenDangNhap"] = DangNhap.id;
                dr["TenTroChoi"] = "Thiên Tài Toán Học";
                dr["KetQua"] = diem.ToString();
                ds.Tables[0].Rows.Add(dr);
                SqlCommandBuilder cm = new SqlCommandBuilder(ad);
                ad.Update(ds);
                trangthai = 1;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
            btndung.Enabled = btnsai.Enabled = true;
            lbldiem.Text = "0";
            so1 = rd.Next(1, 999);
            so2 = rd.Next(1, 999);
            dau = rd.Next(4);
            lblso1.Text = so1.ToString();
            lblso2.Text = so2.ToString();
            string layDau = Dau(dau);
            lbldau.Text = layDau;
            lblketqua.Text = ketQuaDung().ToString();
            kqTamThoi = ketQuaDung();
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void FormGameTinhToan_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn đóng ứng dụng ?", "Thông báo!",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                if(trangthai == 0)
                {
                    cnn = new SqlConnection(cnstr);
                    cnn.Open();
                    string sql = "select * from ThongKeKetQua";
                    SqlDataAdapter ad = new SqlDataAdapter(sql, cnn);
                    DataSet ds = new DataSet();
                    ad.Fill(ds);
                    DataRow dr = ds.Tables[0].NewRow();
                    dr["TenDangNhap"] = DangNhap.id;
                    dr["TenTroChoi"] = "Thiên Tài Toán Học";
                    dr["KetQua"] = diem.ToString();
                    ds.Tables[0].Rows.Add(dr);
                    SqlCommandBuilder cm = new SqlCommandBuilder(ad);
                    ad.Update(ds);
                }
                FormMenu fr = new FormMenu();
                fr.Show();
            }
        }
    }
}
