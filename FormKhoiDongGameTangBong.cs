using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace VuongQuocTroChoi
{
    public partial class FormKhoiDongGameTangBong : Form
    {
        public FormKhoiDongGameTangBong()
        {
            InitializeComponent();
        }

        private void FormKhoiDongGameTangBong_Load(object sender, EventArgs e)
        {

        }

        private void FormKhoiDongGameTangBong_Paint(object sender, PaintEventArgs e)
        {
            Rectangle rect = new Rectangle(0, 0, ClientRectangle.Width, ClientRectangle.Height);

            HatchBrush hb = new HatchBrush(HatchStyle.DarkUpwardDiagonal, Color.Pink, Color.White);
            e.Graphics.FillRectangle(hb, ClientRectangle);

            SolidBrush slb = new SolidBrush(Color.Black);
            string str = "Tâng Bóng";
            Font font = new Font("chiller", 38, FontStyle.Bold);
            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Center;
            format.LineAlignment = StringAlignment.Center;
            e.Graphics.DrawString(str, font, slb, rect, format);
            rect.X -= 2;
            rect.Y -= 3;
            e.Graphics.DrawString(str, font, new SolidBrush(Color.BlueViolet), rect, format);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Increment(1);
            if (progressBar1.Value == 100)
            {
                timer1.Stop();
            }
        }
    }
}
