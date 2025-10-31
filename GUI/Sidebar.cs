using System;
using System.Linq;
using System.Windows.Forms;

namespace GUI
{
    public partial class Sidebar : UserControl
    {
        // ============================
        // KHAI BÁO SỰ KIỆN (ĐÃ ĐỔI TÊN)
        // ============================
        public event EventHandler TaiKhoanClicked;
        public event EventHandler NhapDiemClicked;
        public event EventHandler XemDiemClicked;
        public event EventHandler HocPhiClicked;
        public event EventHandler XemTKBClicked;
        public event EventHandler XemLichDayClicked;
        public event EventHandler HocSinhClicked;
        public event EventHandler TinhHinhClicked;
        public event EventHandler QlyLopClicked;
        public event EventHandler CauHinhClicked;
        public event EventHandler HomeClicked;

        public Sidebar()
        {
            InitializeComponent();

            // Thiết lập FlowLayoutPanel
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.WrapContents = false;
            flowLayoutPanel1.AutoScroll = true;
        }

        // ============================
        // ẨN/HIỆN NÚT THEO VAI TRÒ
        // ============================
        public void SetRole(string role)
        {
            foreach (Button btn in flowLayoutPanel1.Controls.OfType<Button>())
                btn.Visible = false;

            switch (role)
            {
                case "admin":
                    ShowButtons(btnTaiKhoan, btnQlyLop, btnCauHinh);
                    break;
                case "GVBM":
                    ShowButtons(btnNhapDiem, btnXemLichDay);
                    break;
                case "GVCN":
                    ShowButtons(btnHocSinh, btnNhapDiem, btnXemLichDay);
                    break;
                case "PH":
                    ShowButtons(btnHocPhi, btnTinhHinh,btnXemDiem,btnXemTKB);
                    break;
                case "HS":
                    ShowButtons(btnXemDiem,btnXemTKB);
                    break;
            }
        }

        private void ShowButtons(params Button[] buttons)
        {
            foreach (var btn in buttons)
                btn.Visible = true;
        }

        // ============================
        // XỬ LÝ CLICK NÚT
        // ============================
        private void btnTaiKhoan_Click(object sender, EventArgs e) => TaiKhoanClicked?.Invoke(this, EventArgs.Empty);
        private void btnNhapDiem_Click(object sender, EventArgs e) => NhapDiemClicked?.Invoke(this, EventArgs.Empty);
        private void btnXemDiem_Click(object sender, EventArgs e) => XemDiemClicked?.Invoke(this, EventArgs.Empty);
        private void btnHocPhi_Click(object sender, EventArgs e) => HocPhiClicked?.Invoke(this, EventArgs.Empty);
        private void btnXemTKB_Click(object sender, EventArgs e) => XemTKBClicked?.Invoke(this, EventArgs.Empty);
        private void btnXemLichDay_Click(object sender, EventArgs e) => XemLichDayClicked?.Invoke(this, EventArgs.Empty);
        private void btnHocSinh_Click(object sender, EventArgs e) => HocSinhClicked?.Invoke(this, EventArgs.Empty);
        private void btnTinhHinh_Click(object sender, EventArgs e) => TinhHinhClicked?.Invoke(this, EventArgs.Empty);
        private void btnQlyLop_Click(object sender, EventArgs e) => QlyLopClicked?.Invoke(this, EventArgs.Empty);
        private void btnCauHinh_Click(object sender, EventArgs e) => CauHinhClicked?.Invoke(this, EventArgs.Empty);
        private void btnHome_Click(object sender, EventArgs e) => HomeClicked?.Invoke(this, EventArgs.Empty);

        // ============================
        // XỬ LÝ ĐĂNG XUẤT
        // ============================
        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Bạn có chắc muốn đăng xuất?", "Xác nhận", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                new Login().Show();
                this.FindForm()?.Close();
            }
        }

        private void lbInfo_Click(object sender, EventArgs e)
        {

        }
    }
}
