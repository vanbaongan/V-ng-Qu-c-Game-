using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Threading;

namespace VuongQuocTroChoi
{
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            Thread t = new Thread(new ThreadStart(VuongQuocTroChoi));
            t.Start();
            Thread.Sleep(5000);
            InitializeComponent();
            t.Abort();
        }

        private void VuongQuocTroChoi()
        {
            Application.Run(new FormKhoiDongHeThong());
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            lblthoigian.Text = lblthoigian.Text.Substring(1)
               + lblthoigian.Text.Substring(0, 1);
        }

        SqlConnection cnn = null;
        string cnstr= "Server = DESKTOP-0KSPLP6\\SQLEXPRESS; Database = VuongQuocTroChoi; Integrated security = true; ";
        private void btnsigup_Click(object sender, EventArgs e)
        {
            DangKi dk = new DangKi();
            this.Hide();
            dk.Show();
        }

        public static string id="";
        private void btnsigin_Click(object sender, EventArgs e)
        {
            cnn = new SqlConnection(cnstr);
            string sql = "select TenDangNhap, Password from DangKiTaiKhoan";

            SqlDataAdapter ad = new SqlDataAdapter(sql,cnn);

            DataSet ds = new DataSet();
            ad.Fill(ds);
            int trangthai = 0;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                if((dr["TenDangNhap"].ToString() == txttendangnhap.Text) && (dr["Password"].ToString() == txtpass.Text))
                {
                    id = txttendangnhap.Text;
                    MessageBox.Show("Đăng nhập thành công!", "Thông báo!");
                    this.Hide();
                    FormMenu fm = new FormMenu();
                    fm.Show();
                    trangthai = 1;
                }
            }
            if( trangthai == 0)
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!", "Thông báo!",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
