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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (pic1.Right >= pic2.Left)
                timer1.Stop();
            int dx = 6;
            pic1.Left += dx;
            pic2.Left -= dx;
            
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Rectangle rect = new Rectangle(0, 0, ClientRectangle.Width, ClientRectangle.Height);

            HatchBrush hb = new HatchBrush(HatchStyle.DashedHorizontal, Color.White, Color.Pink);
            e.Graphics.FillRectangle(hb, ClientRectangle);

            SolidBrush slb = new SolidBrush(Color.Black);
            string str = "Game Bầu Cua";
            Font font = new Font("Arial", 38, FontStyle.Bold);
            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Center;
            format.LineAlignment = StringAlignment.Center;
            e.Graphics.DrawString(str, font, slb, rect, format);
            rect.X -= 2;
            rect.Y -=3;
            e.Graphics.DrawString(str, font, new SolidBrush(Color.Blue), rect, format);
        }
    }
}
