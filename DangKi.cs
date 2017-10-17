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

namespace VuongQuocTroChoi
{
    public partial class DangKi : Form
    {
        public DangKi()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblthoigian.Text = lblthoigian.Text.Substring(1)
               + lblthoigian.Text.Substring(0, 1);
        }
        SqlConnection cnn = null;
        string cnstr = "Server = DESKTOP-0KSPLP6\\SQLEXPRESS; Database = VuongQuocTroChoi; Integrated security = true; ";

        private void btndangki_Click(object sender, EventArgs e)
        {
            cnn = new SqlConnection(cnstr);
            cnn.Open();
            string sql = "select * from DangKiTaiKhoan";
            SqlDataAdapter ad = new SqlDataAdapter(sql,cnn);
            DataSet ds = new DataSet();
            ad.Fill(ds);

            int trangthai = 0; // tai khoan chua duoc dang ki
            foreach (DataRow d in ds.Tables[0].Rows)
            {
                if (d["TenDangNhap"].ToString() == txttendangki.Text)
                {
                    trangthai = 1;
                }
            }
            if(trangthai == 0)
            {
                DataRow dr = ds.Tables[0].NewRow();
                dr["TenDangNhap"] = txttendangki.Text;
                dr["Password"] = txtpassdangki.Text;
                dr["Ho"] = txtho.Text;
                dr["Ten"] = txtten.Text;
                dr["SoDienThoai"] = txtsdt.Text;
                dr["DiaChi"] = txtdiachi.Text;

                ds.Tables[0].Rows.Add(dr);

                SqlCommandBuilder cm = new SqlCommandBuilder(ad);
                ad.Update(ds);

                if (MessageBox.Show("Đăng kí thành công!\nQuay lai đăng nhập!", "Thông báo", MessageBoxButtons.OK,
           MessageBoxIcon.Information) == DialogResult.OK)
                {
                    DangNhap dn = new DangNhap();
                    this.Hide();
                    dn.Show();
                }
            }
            else if( trangthai == 1)
            {
                MessageBox.Show("Tài khoản đã được đăng kí !", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void DangKi_Load(object sender, EventArgs e)
        {

        }
    }
}
