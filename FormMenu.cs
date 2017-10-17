using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VuongQuocTroChoi
{
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();
        }

        private void FormMenu_Load(object sender, EventArgs e)
        {

        }

        private void btnbaucua_Click(object sender, EventArgs e)
        {
            FormGameBauCua fr = new FormGameBauCua();
            this.Hide();
            fr.Show();

        }

        private void btntangbong_Click(object sender, EventArgs e)
        {
            FormGameTangBong fr = new FormGameTangBong();
            this.Close();
            fr.Show();
        }

        private void btncaro_Click(object sender, EventArgs e)
        {
            GameCaro fr = new GameCaro();
            this.Close();
            fr.Show();
        }

        private void btntritue_Click(object sender, EventArgs e)
        {
            FormGameTinhToan fr = new FormGameTinhToan();
            this.Close();
            fr.Show();
        }

        private void btnsigout_Click(object sender, EventArgs e)
        {
            this.Close();
            DangNhap fr = new DangNhap();
            fr.Show();
        }

        private void btnthongkekqchoi_Click(object sender, EventArgs e)
        {
            this.Hide();
            ThongKeKetQua f = new ThongKeKetQua();
            f.Show();
        }
    }
}
