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
    public partial class FormGameBauCua : Form
    {
        public FormGameBauCua()
        {
            Thread t = new Thread(new ThreadStart(VuongQuocTroChoi));
            t.Start();
            Thread.Sleep(5000);
            InitializeComponent();
            t.Abort();
        }

        private void VuongQuocTroChoi()
        {
            Application.Run(new Form1());
        }

        Random rd = new Random();
        string duongdan = Application.StartupPath + @"\Hinh\";
        int dem = 0;
        int tienconlai = 1000; // lưu số tiền còn lại của người chơi
        int trangthai = 0; // xác định xem kết quả đã save hay chưa.

        private SqlConnection cnn = null;
        private string cnstr = "Server = DESKTOP-0KSPLP6\\SQLEXPRESS; Database = VuongQuocTroChoi; Integrated security = true; ";
        private void btnquay_Click(object sender, EventArgs e)
        {
            int tien = Convert.ToInt16(txttiencuoc.Text);
            if( tienconlai == 0)
            {
                if (MessageBox.Show("Tiền cược của bạn đã hết!\n Bạn có muốn chơi lại?", "Thông báo!",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    tienconlai = 1000;
                    txttiencuoc.Text = "0";
                    cbchon.SelectedIndex = 0;
                    pic1.Image = pic2.Image = pic3.Image = Image.FromFile(duongdan + "0.jpg");

                    // Lưu kết quả khi kết thúc trò chơi.
                    cnn = new SqlConnection(cnstr);
                    cnn.Open();
                    string sql = "select * from ThongKeKetQua";
                    SqlDataAdapter ad = new SqlDataAdapter(sql, cnn);
                    DataSet ds = new DataSet();
                    ad.Fill(ds);
                    DataRow dr = ds.Tables[0].NewRow();
                    dr["TenDangNhap"] = DangNhap.id;
                    dr["TenTroChoi"] = "Game Bầu Cua";
                    dr["KetQua"] = tienconlai.ToString();
                    ds.Tables[0].Rows.Add(dr);
                    SqlCommandBuilder cm = new SqlCommandBuilder(ad);
                    ad.Update(ds);
                    trangthai = 1;
                }
                else
                    txttiencuoc.Text = "0";
            }
            else if( tien == 0)
            {
                MessageBox.Show("Bạn chưa nhập tiền cược", "Thông báo!", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            else if (tien > tienconlai)
            {
                MessageBox.Show("Tiền cược không thể lớn hơn tiền còn lại", "Thông báo!", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            else
            {
                int a = rd.Next(0, 6);
                int b = rd.Next(0, 6);
                int c = rd.Next(0, 6);
                pic1.Image = Image.FromFile(duongdan + a.ToString() + ".jpg");
                pic2.Image = Image.FromFile(duongdan + b.ToString() + ".jpg");
                pic3.Image = Image.FromFile(duongdan + c.ToString() + ".jpg");
                if (cbchon.SelectedIndex == a)
                    dem++;
                if (cbchon.SelectedIndex == b)
                    dem++;
                if (cbchon.SelectedIndex == c)
                    dem++;
                if (dem == 0)
                {
                    tienconlai -= int.Parse(txttiencuoc.Text);
                    lbltienconlai.Text = tienconlai.ToString();
                    dem = 0;
                }
                if (dem != 0)
                {
                    tienconlai += (dem * int.Parse(txttiencuoc.Text));
                    lbltienconlai.Text = tienconlai.ToString();
                    dem = 0;
                }
            }
        }
 
        private void FormGameBauCua_Load(object sender, EventArgs e)
        {
            cbchon.SelectedIndex = 0;
            lbltienconlai.Text = tienconlai.ToString();
            txttiencuoc.Text = "0";
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormGameBauCua_FormClosing(object sender, FormClosingEventArgs e)
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
                    dr["TenTroChoi"] = "Game Bầu Cua";
                    dr["KetQua"] = tienconlai.ToString();
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
