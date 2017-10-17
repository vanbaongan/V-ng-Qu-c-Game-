
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
    public partial class GameCaro : Form
    {

        Cocaro cocaro;
        Graphics gs;
        public GameCaro()
        {
  
            InitializeComponent();

            cocaro = new Cocaro();
            cocaro.mangoco();

            btnChoivoinguoi.Click += playerVsPlayerToolStripMenuItem_Click;
            btnChoivoimay.Click += playerVsPCToolStripMenuItem_Click;
            gs = panel.CreateGraphics();
        }

   

        private void playerVsPlayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gs.Clear(panel.BackColor);
            cocaro.StartPvsP(gs);
            btnchoilai.Enabled = true;
        }



        private void playerVsPCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gs.Clear(panel.BackColor);
            cocaro.StartCom(gs);
            btnchoilai.Enabled = true;
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GameCaro_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn đóng ứng dụng ?", "Thông báo!",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                FormMenu fr = new FormMenu();
                fr.Show();
            }
        }

        private void btnchoilai_Click(object sender, EventArgs e)
        {
            if (cocaro.Chedochoi == 1)
            {
                gs.Clear(panel.BackColor);
                cocaro.StartPvsP(gs);
            }
            if (cocaro.Chedochoi == 2)
            {
                gs.Clear(panel.BackColor);
                cocaro.StartCom(gs);
            }
            btnchoilai.Enabled = false;
        }

        private void panel_Paint(object sender, PaintEventArgs e)
        {
            cocaro.vebanco(gs);
            cocaro.Velaiquanco(gs);
        }

        private void panel_MouseClick(object sender, MouseEventArgs e)
        {
            if (!cocaro.SanSang)
                return;
            cocaro.danhco(e.X, e.Y, gs);
            if (cocaro.kiemtra_thangthua())
            {
                cocaro.ketthuctrochoi();
            }
            else
            {
                if (cocaro.Chedochoi == 2)
                {
                    cocaro.KhoidongPC(gs);
                    if (cocaro.kiemtra_thangthua())
                    {
                        cocaro.ketthuctrochoi();
                    }
                }
            }
        }

        private void GameCaro_Load(object sender, EventArgs e)
        {
            btnchoilai.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblthoigian.Text = lblthoigian.Text.Substring(1)
               + lblthoigian.Text.Substring(0, 1);
        }

    }
    // LỚP Ô CỜ

    class oCo
    {
        public const int chieurong = 25;
        public const int chieucao = 25;
        private int dong;
        private int cot;
        private Point vitri;
        public int Dong
        {
            get { return dong; }
            set { dong = value; }
        }
        public int Cot
        {
            get { return cot; }
            set { cot = value; }
        }

        public Point Vitri
        {
            get { return vitri; }
            set { vitri = value; }
        }
        private int sohuu;
        public int Sohuu
        {
            get { return sohuu; }
            set { sohuu = value; }
        }
        public oCo() {}
        public oCo(int dong, int cot, Point vitri, int sohuu)
        {
            this.dong = dong;
            this.cot = cot;
            this.vitri = vitri;
            this.sohuu = sohuu;
        }
    }

    // LỚP CỜ CARO

    class Cocaro
    {
        public enum Ketthuc{Hoa,Ps1, Ps2, Com}
        private Ketthuc ketthuc;
        public static Pen pen;
        public static SolidBrush sbred;
        public static SolidBrush sbblue;
        public static SolidBrush sbYellow;
        oCo [,] Mangoco;
        private Banco Banco;
        private Stack<oCo> stackCacnuocdadi;
        private Stack<oCo> stacknuocundo;
        private int Luocdi;
        private bool sansang;
        private int chedochoi;
        public int Chedochoi
        { get { return chedochoi; } }
        public bool SanSang
        { get { return sansang; } }
        public Cocaro()
        {
            pen = new Pen(Color.Black);
            sbred = new SolidBrush(Color.Red);
            sbblue = new SolidBrush(Color.Blue);
            sbYellow = new SolidBrush(Color.Yellow);
            Banco = new Banco(20, 20);
            Mangoco = new oCo[Banco.Sodong, Banco.Socot];
            stackCacnuocdadi = new Stack<oCo>();
            stacknuocundo = new Stack<oCo>();
            Luocdi = 1;
        }
        public void vebanco(Graphics g)
        {
            Banco.vebanco(g);
        }
        public void mangoco()
        {
            for (int i = 0; i < Banco.Sodong; i++)
            {
                for (int j = 0; j < Banco.Socot; j++)
                {
                    Mangoco[i, j] = new oCo(i, j, new Point(j * oCo.chieurong, i * oCo.chieucao), 0);
                }
            }
        }
        public bool danhco(int MouseX, int MouseY, Graphics g)
        {
            if (MouseX % oCo.chieurong == 0 || MouseY % oCo.chieucao == 0)
                return false;
            int Cot = MouseX / oCo.chieurong;
            int Dong = MouseY / oCo.chieucao;
            //kiểm soát không cho vẽ đè lên
            if (Mangoco[Dong, Cot].Sohuu != 0)
                return false;
            //thay phiên với nhau đánh
            switch (Luocdi)
            {
                case 1:
                    Mangoco[Dong, Cot].Sohuu = 1;
                    Banco.vequanco(g, Mangoco[Dong, Cot].Vitri, sbblue);
                    Luocdi = 2;
                    break;
                case 2:
                    Mangoco[Dong, Cot].Sohuu = 2;
                    Banco.vequanco(g, Mangoco[Dong, Cot].Vitri, sbred);
                    Luocdi = 1;
                    break;
                default:
                    MessageBox.Show("Đi Lỗi");
                    break;
            }
            stacknuocundo = new Stack<oCo>();
            oCo oco = new oCo(Mangoco[Dong, Cot].Dong, Mangoco[Dong, Cot].Cot, Mangoco[Dong, Cot].Vitri, Mangoco[Dong, Cot].Sohuu);
            stackCacnuocdadi.Push(oco);
            return true;
        }
        public void Velaiquanco(Graphics g)
        {
            //dùng danh sách liên kết vẽ lại 
            //minimize sẽ không mất
            foreach (oCo oco in stackCacnuocdadi)
            {
                if (oco.Sohuu == 1)
                    Banco.vequanco(g, oco.Vitri, sbblue);
                else if (oco.Sohuu == 2)
                    Banco.vequanco(g, oco.Vitri, sbred);
            }
        }
        public void StartPvsP(Graphics g)
        {
            sansang = true;
            stackCacnuocdadi = new Stack<oCo>();
            stacknuocundo = new Stack<oCo>();
            chedochoi = 1;
            mangoco();
            vebanco(g);
        }
        public void StartCom(Graphics g)
        {
            sansang = true;
            stackCacnuocdadi = new Stack<oCo>();
            stacknuocundo = new Stack<oCo>();
            chedochoi = 2;
            mangoco();
            vebanco(g);
            KhoidongPC(g);
        }
        public void undo(Graphics g)
        {
            if (stackCacnuocdadi.Count != 0)
            {
                oCo oco = stackCacnuocdadi.Pop();
                //stack chua cac nuoc da undo
                stacknuocundo.Push(new oCo(oco.Dong, oco.Cot, oco.Vitri, oco.Sohuu));
                Mangoco[oco.Dong, oco.Cot].Sohuu = 0;
                Banco.xoaquanco(g, oco.Vitri, sbYellow);
                oCo oco2 = stackCacnuocdadi.Pop();
                //stack chua cac nuoc da undo
                stacknuocundo.Push(new oCo(oco2.Dong, oco2.Cot, oco2.Vitri, oco2.Sohuu));
                Mangoco[oco.Dong, oco.Cot].Sohuu = 0;
                Banco.xoaquanco(g, oco.Vitri, sbYellow);
            }
            if (Luocdi == 1)
                Luocdi = 2;
            else
                Luocdi = 1;
            
        }

        public void Redo(Graphics g)
        {
            if (stacknuocundo.Count != 0)
            {
                oCo oco = stacknuocundo.Pop();
                //stack chua cac nuoc da di
                stackCacnuocdadi.Push(new oCo(oco.Dong, oco.Cot, oco.Vitri, oco.Sohuu));
                Mangoco[oco.Dong, oco.Cot].Sohuu = oco.Sohuu;
                Banco.vequanco(g, oco.Vitri, oco.Sohuu == 1 ? sbblue : sbred);
            }
            if (Luocdi == 1)
                Luocdi = 2;
            else
                Luocdi = 1;
  
        }
        #region Duyệt chiến thắng

        private SqlConnection cnn = null;
        private string cnstr = "Server = DESKTOP-0KSPLP6\\SQLEXPRESS; Database = VuongQuocTroChoi; Integrated security = true; ";
        public void ketthuctrochoi()
        {
            switch (ketthuc)
            {
                case Ketthuc.Hoa:
                    {
                        MessageBox.Show("Ngang tài ngang sức !", "Thông báo");

                        // lưu kết quả khi kết thúc trò chơi.
                        cnn = new SqlConnection(cnstr);
                        cnn.Open();
                        string sql = "select * from ThongKeKetQua";
                        SqlDataAdapter ad = new SqlDataAdapter(sql, cnn);
                        DataSet ds = new DataSet();
                        ad.Fill(ds);
                        DataRow dr = ds.Tables[0].NewRow();
                        dr["TenDangNhap"] = DangNhap.id;
                        dr["TenTroChoi"] = "Game Caro";
                        dr["KetQua"] = "Hòa nhau";
                        ds.Tables[0].Rows.Add(dr);
                        SqlCommandBuilder cm = new SqlCommandBuilder(ad);
                        ad.Update(ds);
                        break;
                    }
                case Ketthuc.Ps1:
                    {
                        if (chedochoi == 2 && Luocdi == 2)
                        {
                            MessageBox.Show("Máy thắng !", "Thông báo");
                            // lưu kết quả khi kết thúc trò chơi.
                            cnn = new SqlConnection(cnstr);
                            cnn.Open();
                            string sql = "select * from ThongKeKetQua";
                            SqlDataAdapter ad = new SqlDataAdapter(sql, cnn);
                            DataSet ds = new DataSet();
                            ad.Fill(ds);
                            DataRow dr = ds.Tables[0].NewRow();
                            dr["TenDangNhap"] = DangNhap.id;
                            dr["TenTroChoi"] = "Game Caro";
                            dr["KetQua"] = "Máy thắng";
                            ds.Tables[0].Rows.Add(dr);
                            SqlCommandBuilder cm = new SqlCommandBuilder(ad);
                            ad.Update(ds);
                        }
                        else
                        {
                            MessageBox.Show("Người chơi 1 đã giành chiến thắng !", "Thông báo");
                            // lưu kết quả khi kết thúc trò chơi.
                            cnn = new SqlConnection(cnstr);
                            cnn.Open();
                            string sql = "select * from ThongKeKetQua";
                            SqlDataAdapter ad = new SqlDataAdapter(sql, cnn);
                            DataSet ds = new DataSet();
                            ad.Fill(ds);
                            DataRow dr = ds.Tables[0].NewRow();
                            dr["TenDangNhap"] = DangNhap.id;
                            dr["TenTroChoi"] = "Game Caro";
                            dr["KetQua"] = "Người chơi 1 thắng";
                            ds.Tables[0].Rows.Add(dr);
                            SqlCommandBuilder cm = new SqlCommandBuilder(ad);
                            ad.Update(ds);
                        }
                        Luocdi = 2;
                        break;
                    }
                case Ketthuc.Ps2:
                    {
                        if (chedochoi == 2 && Luocdi == 2)
                        {
                            MessageBox.Show("Máy đã giành chiến thắng !", "Thông báo");
                            // lưu kết quả khi kết thúc trò chơi.
                            cnn = new SqlConnection(cnstr);
                            cnn.Open();
                            string sql = "select * from ThongKeKetQua";
                            SqlDataAdapter ad = new SqlDataAdapter(sql, cnn);
                            DataSet ds = new DataSet();
                            ad.Fill(ds);
                            DataRow dr = ds.Tables[0].NewRow();
                            dr["TenDangNhap"] = DangNhap.id;
                            dr["TenTroChoi"] = "Game Caro";
                            dr["KetQua"] = "Máy thắng";
                            ds.Tables[0].Rows.Add(dr);
                            SqlCommandBuilder cm = new SqlCommandBuilder(ad);
                            ad.Update(ds);
                        }
                        else
                        {
                            MessageBox.Show("Người chơi 2 đã giành chiến thắng !", "Thông báo");
                            // lưu kết quả khi kết thúc trò chơi.
                            cnn = new SqlConnection(cnstr);
                            cnn.Open();
                            string sql = "select * from ThongKeKetQua";
                            SqlDataAdapter ad = new SqlDataAdapter(sql, cnn);
                            DataSet ds = new DataSet();
                            ad.Fill(ds);
                            DataRow dr = ds.Tables[0].NewRow();
                            dr["TenDangNhap"] = DangNhap.id;
                            dr["TenTroChoi"] = "Game Caro";
                            dr["KetQua"] = "Người chơi 2 thắng";
                            ds.Tables[0].Rows.Add(dr);
                            SqlCommandBuilder cm = new SqlCommandBuilder(ad);
                            ad.Update(ds);
                        }
                        Luocdi = 1;
                        break;

                    }
                case Ketthuc.Com:
                    {
                        MessageBox.Show("Máy giành chiến thắng !", "Thông báo");
                        // lưu kết quả khi kết thúc trò chơi.
                        cnn = new SqlConnection(cnstr);
                        cnn.Open();
                        string sql = "select * from ThongKeKetQua";
                        SqlDataAdapter ad = new SqlDataAdapter(sql, cnn);
                        DataSet ds = new DataSet();
                        ad.Fill(ds);
                        DataRow dr = ds.Tables[0].NewRow();
                        dr["TenDangNhap"] = DangNhap.id;
                        dr["TenTroChoi"] = "Game Caro";
                        dr["KetQua"] = "Máy thắng";
                        ds.Tables[0].Rows.Add(dr);
                        SqlCommandBuilder cm = new SqlCommandBuilder(ad);
                        ad.Update(ds);
                        break;
                    }
            }
            sansang = false;
        }
        public bool kiemtra_thangthua()
        {
            if (stackCacnuocdadi.Count == Banco.Socot * Banco.Sodong)
            {
                ketthuc = Ketthuc.Hoa;

                return true;
            }
            foreach (oCo oco in stackCacnuocdadi)
            {
                if (duyetdoc(oco.Dong, oco.Cot, oco.Sohuu) || duyetngang(oco.Dong, oco.Cot, oco.Sohuu) || duyetcheoxuoi(oco.Dong, oco.Cot, oco.Sohuu) || duyetcheonguoc(oco.Dong, oco.Cot, oco.Sohuu))
                {
                    ketthuc = oco.Sohuu == 1 ? Ketthuc.Ps1 : Ketthuc.Ps2;
                    return true;
                }
            }
            return false;
        }
        private bool duyetdoc(int crrdong, int currcot, int currsohuu)
        {
            int dem;
            //nếu 4 ô cờ nằm ở biên thì ko thắng
            if (crrdong > Banco.Sodong - 5)
                return false;
            //lập 
            for (dem = 0; dem < 5; dem++)
            {
                if (Mangoco[crrdong + dem, currcot].Sohuu != currsohuu)
                    return false;
            }
            //ở biên nếu đủ 5 con sẽ thắng cho dù bị chặn 1 đầu
            if (crrdong == 0 || crrdong + dem == Banco.Sodong)
                return true;
            //nếu bị chặn 2 đầu sẽ không thắng
            if (Mangoco[crrdong - 1, currcot].Sohuu == 0 || Mangoco[crrdong + dem, currcot].Sohuu == 0)
                return true;
            return false;
        }
        private bool duyetngang(int crrdong, int currcot, int currsohuu)
        {
            int dem;
            //nếu 4 ô cờ nằm ở biên thì ko thắng
            if (currcot > Banco.Socot - 5)
                return false;
            //lập đếm số quân cờ
            for (dem = 0; dem < 5; dem++)
            {
                //nếu có quân khác màu sẽ trả false
                if (Mangoco[crrdong, currcot + dem].Sohuu != currsohuu)
                    return false;
            }
            //ở biên nếu đủ 5 con sẽ thắng cho dù bị chặn 1 đầu
            if (currcot == 0 || currcot + dem == Banco.Socot)
                return true;
            //nếu bị chặn 2 đầu sẽ không thắng
            if (Mangoco[crrdong, currcot - 1].Sohuu == 0 || Mangoco[crrdong, currcot + dem].Sohuu == 0)
                return true;
            return false;
        }
        private bool duyetcheoxuoi(int crrdong, int currcot, int currsohuu)
        {
            int dem;
            //nếu 4 ô cờ nằm ở biên thì ko thắng
            if (crrdong > Banco.Sodong - 5 || currcot > Banco.Socot - 5)
                return false;
            //lập đếm số quân cờ
            for (dem = 0; dem < 5; dem++)
            {
                //nếu có quân khác màu sẽ trả false
                if (Mangoco[crrdong + dem, currcot + dem].Sohuu != currsohuu)
                    return false;
            }
            //ở biên nếu đủ 5 con sẽ thắng cho dù bị chặn 1 đầu
            if (crrdong == 0 || crrdong + dem == Banco.Sodong || currcot == 0 || currcot + dem == Banco.Socot)
                return true;
            //nếu bị chặn 2 đầu sẽ không thắng
            if (Mangoco[crrdong - 1, currcot - 1].Sohuu == 0 || Mangoco[crrdong + dem, currcot + dem].Sohuu == 0)
                return true;
            return false;
        }
        private bool duyetcheonguoc(int crrdong, int currcot, int currsohuu)
        {
            int dem;
            //nếu 4 ô cờ nằm ở biên thì ko thắng
            if (crrdong < 4 || currcot > Banco.Socot - 5)
                return false;
            //lập đếm số quân cờ
            for (dem = 0; dem < 5; dem++)
            {
                //nếu có quân khác màu sẽ trả false
                if (Mangoco[crrdong - dem, currcot + dem].Sohuu != currsohuu)
                    return false;
            }
            //ở biên nếu đủ 5 con sẽ thắng cho dù bị chặn 1 đầu
            if (crrdong == 4 || crrdong == Banco.Sodong - 1 || currcot == 0 || currcot + dem == Banco.Socot)
                return true;
            //nếu bị chặn 2 đầu sẽ không thắng
            if (Mangoco[crrdong + 1, currcot - 1].Sohuu == 0 || Mangoco[crrdong - dem, currcot + dem].Sohuu == 0)
                return true;
            return false;
        }

        #endregion
        #region chế độ AI
        // tạo mảng đếm giá trị tấn công
        private long[] _mangdiemtanchong = new long[7] { 0, 1, 9, 81, 729, 6561, 59049 };
        //tạo mảng giá trị phòng ngự
        private long[] _mangdiemphongngu = new long[7] { 0, 2, 18, 162, 1458, 8000, 70000 };
        public void KhoidongPC(Graphics g)
        {
            if (Luocdi == 1)
            {
                //đánh giữa bàn cờ

                if (stackCacnuocdadi.Count == 0)
                    danhco(Banco.Sodong / 2 * oCo.chieucao + 1, Banco.Socot / 2 * oCo.chieurong + 1, g);
                else
                {
                    oCo oco = _timnuocdi();
                    danhco(oco.Vitri.X + 1, oco.Vitri.Y + 1, g);
                }
            }
        }
        //tạo hàm AI cho máy
        private oCo _timnuocdi()
        {
            oCo ocoresult = new oCo();
            long diemmax = 0;
            for (int i = 0; i < Banco.Sodong; i++)
            {
                for (int j = 0; j < Banco.Socot; j++)
                {
                    if (Mangoco[i, j].Sohuu == 0)
                    {
                        long diemtancong = DTC_DuyetDoc(i, j) + DTC_DuyetNgang(i, j) + DTC_DuyetCheoXuoi(i, j) + DTC_DuyetCheoNguoc(i, j);
                        long diemphongngu = DPN_DuyetDoc(i, j) + DPN_DuyetNgang(i, j) + DPN_DuyetCheoXuoi(i, j) + DPN_DuyetCheoNguoc(i, j);
                        long diemtam = diemtancong > diemphongngu ? diemtancong : diemphongngu;
                        if (diemmax < diemtam)
                        {
                            diemmax = diemtam;
                            ocoresult = new oCo(Mangoco[i, j].Dong, Mangoco[i, j].Cot, Mangoco[i, j].Vitri, Mangoco[i, j].Sohuu);
                        }
                    }
                }
            }
            return ocoresult;
        }
        #region Tấn công
        private long DTC_DuyetDoc(int crrdong, int crrcot)
        {
            long diemtong = 0;
            int soquanta = 0;
            int soquandich = 0;
            for (int dem = 1; dem < 6 && crrdong + dem < Banco.Sodong; dem++)
            {
                if (Mangoco[crrdong + dem, crrcot].Sohuu == 1)
                {
                    soquanta++;
                }
                else if (Mangoco[crrdong + dem, crrcot].Sohuu == 2)
                {
                    soquandich++;
                    break;
                }
                else
                    break;
            }
            for (int dem = 1; dem < 6 && crrdong - dem >= 0; dem++)
            {
                if (Mangoco[crrdong - dem, crrcot].Sohuu == 1)
                {
                    soquanta++;
                }
                else if (Mangoco[crrdong - dem, crrcot].Sohuu == 2)
                {
                    soquandich++;
                    break;
                }
                else
                    break;

            }
            if (soquandich == 2)
                return 0;
            //diemtong -= _mangdiemphongngu[soquandich];
            diemtong += _mangdiemtanchong[soquanta];
            return diemtong;
        }
        private long DTC_DuyetNgang(int crrdong, int crrcot)
        {
            long diemtong = 0;
            int soquanta = 0;
            int soquandich = 0;
            for (int dem = 1; dem < 6 && crrcot + dem < Banco.Socot; dem++)
            {
                if (Mangoco[crrdong, crrcot + dem].Sohuu == 1)
                {
                    soquanta++;
                }
                else if (Mangoco[crrdong, crrcot + dem].Sohuu == 2)
                {
                    soquandich++;
                    break;
                }
                else
                    break;

            }
            for (int dem = 1; dem < 6 && crrcot - dem >= 0; dem++)
            {
                if (Mangoco[crrdong, crrcot - dem].Sohuu == 1)
                {
                    soquanta++;
                }
                else if (Mangoco[crrdong, crrcot - dem].Sohuu == 2)
                {
                    soquandich++;
                    break;
                }
                else
                    break;

            }
            if (soquandich == 2)
                return 0;
            //diemtong -= _mangdiemphongngu[soquandich];
            diemtong += _mangdiemtanchong[soquanta];
            return diemtong;
        }
        private long DTC_DuyetCheoXuoi(int crrdong, int crrcot)
        {
            long diemtong = 0;
            int soquanta = 0;
            int soquandich = 0;
            for (int dem = 1; dem < 6 && crrcot + dem < Banco.Socot && crrdong + dem < Banco.Sodong; dem++)
            {
                if (Mangoco[crrdong + dem, crrcot + dem].Sohuu == 1)
                {
                    soquanta++;
                }
                else if (Mangoco[crrdong + dem, crrcot + dem].Sohuu == 2)
                {
                    soquandich++;
                    break;
                }
                else
                    break;

            }
            for (int dem = 1; dem < 6 && crrcot - dem >= 0 && crrdong - dem >= 0; dem++)
            {
                if (Mangoco[crrdong - dem, crrcot - dem].Sohuu == 1)
                {
                    soquanta++;
                }
                else if (Mangoco[crrdong - dem, crrcot - dem].Sohuu == 2)
                {
                    soquandich++;
                    break;
                }
                else
                    break;

            }
            if (soquandich == 2)
                return 0;
            //diemtong -= _mangdiemphongngu[soquandich];
            diemtong += _mangdiemtanchong[soquanta];
            return diemtong;
        }
        private long DTC_DuyetCheoNguoc(int crrdong, int crrcot)
        {
            long diemtong = 0;
            int soquanta = 0;
            int soquandich = 0;
            for (int dem = 1; dem < 6 && crrcot + dem < Banco.Socot && crrdong - dem >= 0; dem++)
            {
                if (Mangoco[crrdong - dem, crrcot + dem].Sohuu == 1)
                {
                    soquanta++;
                }
                else if (Mangoco[crrdong - dem, crrcot + dem].Sohuu == 2)
                {
                    soquandich++;
                    break;
                }
                else
                    break;

            }
            for (int dem = 1; dem < 6 && crrcot - dem >= 0 && crrdong + dem < Banco.Sodong; dem++)
            {
                if (Mangoco[crrdong + dem, crrcot - dem].Sohuu == 1)
                {
                    soquanta++;
                }
                else if (Mangoco[crrdong + dem, crrcot - dem].Sohuu == 2)
                {
                    soquandich++;
                    break;
                }
                else
                    break;

            }
            if (soquandich == 2)
                return 0;
            //diemtong -= _mangdiemphongngu[soquandich];
            diemtong += _mangdiemtanchong[soquanta];
            return diemtong;
        }
        #endregion
        #region Phòng ngự
        private long DPN_DuyetDoc(int crrdong, int crrcot)
        {
            long diemtong = 0;
            int soquanta = 0;
            int soquandich = 0;
            for (int dem = 1; dem < 6 && crrdong + dem < Banco.Sodong; dem++)
            {
                if (Mangoco[crrdong + dem, crrcot].Sohuu == 1)
                {
                    soquanta++; break;
                }
                else if (Mangoco[crrdong + dem, crrcot].Sohuu == 2)
                {
                    soquandich++;

                }
                else
                    break;
            }
            for (int dem = 1; dem < 6 && crrdong - dem >= 0; dem++)
            {
                if (Mangoco[crrdong - dem, crrcot].Sohuu == 1)
                {
                    soquanta++; break;
                }
                else if (Mangoco[crrdong - dem, crrcot].Sohuu == 2)
                {
                    soquandich++;
                }
                else
                    break;

            }
            if (soquanta == 2)
                return 0;

            diemtong += _mangdiemphongngu[soquandich];
            return diemtong;
        }
        private long DPN_DuyetNgang(int crrdong, int crrcot)
        {
            long diemtong = 0;
            int soquanta = 0;
            int soquandich = 0;
            for (int dem = 1; dem < 6 && crrcot + dem < Banco.Socot; dem++)
            {
                if (Mangoco[crrdong, crrcot + dem].Sohuu == 1)
                {
                    soquanta++; break;
                }
                else if (Mangoco[crrdong, crrcot + dem].Sohuu == 2)
                {
                    soquandich++;
                }
                else
                    break;

            }
            for (int dem = 1; dem < 6 && crrcot - dem >= 0; dem++)
            {
                if (Mangoco[crrdong, crrcot - dem].Sohuu == 1)
                {
                    soquanta++;
                    break;
                }
                else if (Mangoco[crrdong, crrcot - dem].Sohuu == 2)
                {
                    soquandich++;

                }
                else
                    break;

            }
            if (soquanta == 2)
                return 0;

            diemtong += _mangdiemphongngu[soquandich];
            return diemtong;
        }
        private long DPN_DuyetCheoXuoi(int crrdong, int crrcot)
        {
            long diemtong = 0;
            int soquanta = 0;
            int soquandich = 0;
            for (int dem = 1; dem < 6 && crrcot + dem < Banco.Socot && crrdong + dem < Banco.Sodong; dem++)
            {
                if (Mangoco[crrdong + dem, crrcot + dem].Sohuu == 1)
                {
                    soquanta++; break;
                }
                else if (Mangoco[crrdong + dem, crrcot + dem].Sohuu == 2)
                {
                    soquandich++;

                }
                else
                    break;

            }
            for (int dem = 1; dem < 6 && crrcot - dem >= 0 && crrdong - dem >= 0; dem++)
            {
                if (Mangoco[crrdong - dem, crrcot - dem].Sohuu == 1)
                {
                    soquanta++; break;
                }
                else if (Mangoco[crrdong - dem, crrcot - dem].Sohuu == 2)
                {
                    soquandich++;

                }
                else
                    break;

            }
            if (soquanta == 2)
                return 0;
            diemtong += _mangdiemphongngu[soquandich];
            return diemtong;
        }
        private long DPN_DuyetCheoNguoc(int crrdong, int crrcot)
        {
            long diemtong = 0;
            int soquanta = 0;
            int soquandich = 0;
            for (int dem = 1; dem < 6 && crrcot + dem < Banco.Socot && crrdong - dem >= 0; dem++)
            {
                if (Mangoco[crrdong - dem, crrcot + dem].Sohuu == 1)
                {
                    soquanta++; break;
                }
                else if (Mangoco[crrdong - dem, crrcot + dem].Sohuu == 2)
                {
                    soquandich++;

                }
                else
                    break;

            }
            for (int dem = 1; dem < 6 && crrcot - dem >= 0 && crrdong + dem < Banco.Sodong; dem++)
            {
                if (Mangoco[crrdong + dem, crrcot - dem].Sohuu == 1)
                {
                    soquanta++; break;
                }
                else if (Mangoco[crrdong + dem, crrcot - dem].Sohuu == 2)
                {
                    soquandich++;

                }
                else
                    break;

            }
            if (soquanta == 2)
                return 0;
            diemtong += _mangdiemphongngu[soquandich];
            return diemtong;
        }
        #endregion
        #endregion
    }

    // LỚP BÀN CỜ.
    class Banco
    {
        private int dong;
        private int cot;
        public int Sodong
        {
            get { return dong; }

        }
        public int Socot
        {
            get { return cot; }
        }
        public Banco()
        {
            dong = cot = 0;
        }
        public Banco(int sd, int sc)
        {
            dong = sd;
            cot = sc;
        }
        public void vebanco(Graphics g)
        {
            for (int i = 0; i <= dong; i++)
            {
                g.DrawLine(Cocaro.pen, i * oCo.chieurong, 0, i * oCo.chieurong, dong * oCo.chieucao);
            }
            //vẽ chiều ngang
            for (int j = 0; j <= cot; j++)
            {
                g.DrawLine(Cocaro.pen, 0, j * oCo.chieucao, cot * oCo.chieurong, j * oCo.chieucao);
            }
        }
        public void vequanco(Graphics g, Point point, SolidBrush sb)
        {
            //vẽ hình tròn nằm trong ô cờ
            g.FillEllipse(sb, point.X + 1, point.Y + 1, oCo.chieurong - 2, oCo.chieucao - 2);

        }
        public void xoaquanco(Graphics g, Point point, SolidBrush sb)
        {
            g.FillRectangle(sb, point.X + 1, point.Y + 1, oCo.chieurong - 2, oCo.chieucao - 2);
        }
    }
}
