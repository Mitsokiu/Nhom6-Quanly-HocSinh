using System;
using System.Drawing;
using System.Drawing.Drawing2D; // Để vẽ bo tròn
using System.Windows.Forms;

namespace GUI.UserControls
{
    public partial class UC_HocSinh_ThongTin : UserControl
    {
        // --- MÀU SẮC GIAO DIỆN ---
        private Color colorBackground = Color.FromArgb(245, 247, 250); // Xám nhạt nền
        private Color colorCard = Color.White;
        private Color colorTextPrimary = Color.FromArgb(33, 37, 41); // Đen xám
        private Color colorTextSecondary = Color.FromArgb(108, 117, 125); // Xám chữ mờ
        private Color colorReadOnlyBG = Color.FromArgb(241, 243, 245); // Xám nền ô khóa
        private Color colorBorder = Color.FromArgb(222, 226, 230); // Viền nhạt
        private Font fontLabel = new Font("Segoe UI", 9F, FontStyle.Regular);
        private Font fontInput = new Font("Segoe UI", 10F, FontStyle.Regular);

        // --- CÁC CONTROL ĐỂ ĐỔ DỮ LIỆU SAU NÀY ---
        // 1. Cá nhân
        public PictureBox picAvatar;
        public TextBox txtMaHS, txtHoTen, txtNgaySinh, txtGioiTinh, txtLop, txtNienKhoa, txtGVCN, txtSDTGV;

        // 2. Liên hệ
        public TextBox txtDiaChi, txtSDTHS, txtEmailHS;
        public Button btnCapNhatLienHe;

        // 3. Gia đình
        public TextBox txtChaTen, txtChaSDT, txtChaNghe, txtChaEmail;
        public TextBox txtMeTen, txtMeSDT, txtMeNghe, txtMeEmail;

        public UC_HocSinh_ThongTin(int userId = 0)
        {
            InitializeComponent();
            SetupUI();
        }

        private void SetupUI()
        {
            // 1. Cấu hình Form chính
            this.BackColor = colorBackground;
            this.Size = new Size(1100, 900);
            this.AutoScroll = true; // Cho phép cuộn nếu màn hình nhỏ

            // 2. Container chính (để căn lề giữa cho đẹp)
            Panel mainPanel = new Panel();
            mainPanel.Location = new Point(20, 20);
            mainPanel.Size = new Size(1040, 1200); // Chiều cao ảo để chứa hết nội dung
            mainPanel.AutoSize = true;
            this.Controls.Add(mainPanel);

            // --- HEADER ---
            Label lblHeader = new Label();
            lblHeader.Text = "Thông tin học sinh";
            lblHeader.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblHeader.ForeColor = colorTextPrimary;
            lblHeader.AutoSize = true;
            lblHeader.Location = new Point(0, 0);
            mainPanel.Controls.Add(lblHeader);

            Label lblSubHeader = new Label();
            lblSubHeader.Text = "Xem và cập nhật thông tin cá nhân của bạn.";
            lblSubHeader.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            lblSubHeader.ForeColor = colorTextSecondary;
            lblSubHeader.AutoSize = true;
            lblSubHeader.Location = new Point(5, 40);
            mainPanel.Controls.Add(lblSubHeader);

            // --- KHỐI 1: THÔNG TIN CÁ NHÂN ---
            Panel cardCaNhan = CreateCard("Thông tin cá nhân", 80);
            mainPanel.Controls.Add(cardCaNhan);

            // Avatar bên trái
            picAvatar = new PictureBox();
            picAvatar.Size = new Size(120, 120);
            picAvatar.Location = new Point(30, 60);
            picAvatar.BackColor = Color.LightGray; // Màu tạm
            picAvatar.SizeMode = PictureBoxSizeMode.StretchImage;
            // Bo tròn Avatar
            GraphicsPath gp = new GraphicsPath();
            gp.AddEllipse(0, 0, picAvatar.Width, picAvatar.Height);
            picAvatar.Region = new Region(gp);
            cardCaNhan.Controls.Add(picAvatar);

            Label lblAvatar = new Label();
            lblAvatar.Text = "Ảnh đại diện";
            lblAvatar.AutoSize = true;
            lblAvatar.ForeColor = colorTextSecondary;
            lblAvatar.Location = new Point(45, 190);
            cardCaNhan.Controls.Add(lblAvatar);

            // Grid bên phải (TableLayout)
            TableLayoutPanel gridCaNhan = CreateGrid(4); // 4 dòng
            gridCaNhan.Location = new Point(180, 50);
            gridCaNhan.Size = new Size(cardCaNhan.Width - 210, 260);
            cardCaNhan.Controls.Add(gridCaNhan);

            // Thêm các cặp ô nhập liệu (Label + TextBox)
            // Dòng 1
            AddFieldToGrid(gridCaNhan, "Mã học sinh", out txtMaHS, true);
            AddFieldToGrid(gridCaNhan, "Họ và tên", out txtHoTen, true);
            // Dòng 2
            AddFieldToGrid(gridCaNhan, "Ngày sinh", out txtNgaySinh, true);
            AddFieldToGrid(gridCaNhan, "Giới tính", out txtGioiTinh, true);
            // Dòng 3
            AddFieldToGrid(gridCaNhan, "Lớp hiện tại", out txtLop, true);
            AddFieldToGrid(gridCaNhan, "Niên khóa", out txtNienKhoa, true);
            // Dòng 4
            AddFieldToGrid(gridCaNhan, "Giáo viên chủ nhiệm", out txtGVCN, true);
            AddFieldToGrid(gridCaNhan, "SĐT GVCN", out txtSDTGV, true);


            // --- KHỐI 2: THÔNG TIN LIÊN HỆ ---
            Panel cardLienHe = CreateCard("Thông tin liên hệ", 420); // Vị trí Y tiếp theo
            cardLienHe.Height = 220; // Chỉnh chiều cao cho vừa
            mainPanel.Controls.Add(cardLienHe);

            // Địa chỉ (Full width)
            Panel pnlDiaChi = CreateFieldFullWidth("Địa chỉ", out txtDiaChi, true);
            pnlDiaChi.Location = new Point(30, 60);
            pnlDiaChi.Width = cardLienHe.Width - 60;
            cardLienHe.Controls.Add(pnlDiaChi);

            // Grid SĐT & Email (Cho phép sửa)
            TableLayoutPanel gridLienHe = CreateGrid(1);
            gridLienHe.Location = new Point(30, 130);
            gridLienHe.Size = new Size(cardLienHe.Width - 60, 70);
            cardLienHe.Controls.Add(gridLienHe);

            AddFieldToGrid(gridLienHe, "Số điện thoại học sinh", out txtSDTHS, false); // False = Cho sửa
            AddFieldToGrid(gridLienHe, "Email", out txtEmailHS, false);

            // Nút cập nhật (nhỏ gọn góc phải)
            btnCapNhatLienHe = new Button();
            btnCapNhatLienHe.Text = "Cập nhật";
            btnCapNhatLienHe.Size = new Size(100, 35);
            btnCapNhatLienHe.BackColor = Color.FromArgb(13, 110, 253); // Xanh dương
            btnCapNhatLienHe.ForeColor = Color.White;
            btnCapNhatLienHe.FlatStyle = FlatStyle.Flat;
            btnCapNhatLienHe.FlatAppearance.BorderSize = 0;
            btnCapNhatLienHe.Location = new Point(cardLienHe.Width - 130, 15); // Góc phải trên
            btnCapNhatLienHe.Cursor = Cursors.Hand;
            cardLienHe.Controls.Add(btnCapNhatLienHe);


            // --- KHỐI 3: THÔNG TIN GIA ĐÌNH ---
            Panel cardGiaDinh = CreateCard("Thông tin gia đình", 660);
            cardGiaDinh.Height = 350; // Cao hơn để chứa Cha và Mẹ
            mainPanel.Controls.Add(cardGiaDinh);

            TableLayoutPanel gridGiaDinh = CreateGrid(4);
            gridGiaDinh.Location = new Point(30, 60);
            gridGiaDinh.Size = new Size(cardGiaDinh.Width - 60, 270);
            cardGiaDinh.Controls.Add(gridGiaDinh);

            // Cha
            AddFieldToGrid(gridGiaDinh, "Họ tên Cha", out txtChaTen, true);
            AddFieldToGrid(gridGiaDinh, "SĐT Cha", out txtChaSDT, true);
            AddFieldToGrid(gridGiaDinh, "Nghề nghiệp Cha", out txtChaNghe, true);
            AddFieldToGrid(gridGiaDinh, "Email Cha", out txtChaEmail, true);

            // --- KẺ NGĂN CÁCH GIỮA CHA VÀ MẸ (Vẽ thủ công) ---
            Panel line = new Panel();
            line.Height = 1;
            line.BackColor = Color.LightGray;
            // Tính toán vị trí dòng kẻ: Sau 2 dòng grid (mỗi dòng ~65px)
            line.Location = new Point(30, 60 + (65 * 2) + 10);
            line.Width = cardGiaDinh.Width - 60;
            cardGiaDinh.Controls.Add(line);
            line.BringToFront(); // Đè lên trên grid

            // Mẹ (Tiếp tục add vào Grid, nó sẽ tự xuống dòng 3, 4)
            AddFieldToGrid(gridGiaDinh, "Họ tên Mẹ", out txtMeTen, true);
            AddFieldToGrid(gridGiaDinh, "SĐT Mẹ", out txtMeSDT, true);
            AddFieldToGrid(gridGiaDinh, "Nghề nghiệp Mẹ", out txtMeNghe, true);
            AddFieldToGrid(gridGiaDinh, "Email Mẹ", out txtMeEmail, true);


            // 4. Kích hoạt khoảng trống cuối cùng để scroll đẹp
            Panel spacer = new Panel();
            spacer.Location = new Point(0, 1050);
            spacer.Size = new Size(10, 50);
            mainPanel.Controls.Add(spacer);
        }

        // --- CÁC HÀM HỖ TRỢ VẼ (HELPER METHODS) ---

        private Panel CreateCard(string title, int yPos)
        {
            Panel pnl = new Panel();
            pnl.Location = new Point(0, yPos);
            pnl.Size = new Size(1000, 320); // Kích thước mặc định
            pnl.BackColor = colorCard;
            // Shadow giả (Border nhạt)
            pnl.Padding = new Padding(1);

            // Tiêu đề Card
            Label lblTitle = new Label();
            lblTitle.Text = title;
            lblTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTitle.ForeColor = colorTextPrimary;
            lblTitle.Location = new Point(20, 15);
            lblTitle.AutoSize = true;
            pnl.Controls.Add(lblTitle);

            // Đường kẻ dưới tiêu đề
            Panel line = new Panel();
            line.BackColor = Color.FromArgb(240, 240, 240);
            line.Size = new Size(1000, 1);
            line.Location = new Point(0, 50);
            pnl.Controls.Add(line);

            return pnl;
        }

        private TableLayoutPanel CreateGrid(int rows)
        {
            TableLayoutPanel tlp = new TableLayoutPanel();
            tlp.ColumnCount = 2;
            tlp.RowCount = rows;
            // Chia cột 50% - 50%
            tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));

            // Khoảng cách giữa các ô
            tlp.Padding = new Padding(0);
            tlp.Margin = new Padding(0);
            // Tự động giãn dòng
            for (int i = 0; i < rows; i++)
            {
                tlp.RowStyles.Add(new RowStyle(SizeType.Absolute, 65F)); // Mỗi dòng cao 65px
            }
            return tlp;
        }

        // Hàm quan trọng: Tạo Label và TextBox, nhét vào Grid
        private void AddFieldToGrid(TableLayoutPanel grid, string labelText, out TextBox txtBox, bool isReadOnly)
        {
            Panel wrapper = new Panel();
            wrapper.Dock = DockStyle.Fill;
            wrapper.Padding = new Padding(0, 0, 20, 10); // Margin phải 20px

            // Label
            Label lbl = new Label();
            lbl.Text = labelText;
            lbl.Font = fontLabel;
            lbl.ForeColor = colorTextSecondary;
            lbl.AutoSize = true;
            lbl.Location = new Point(0, 0);

            // TextBox
            txtBox = new TextBox();
            txtBox.Font = fontInput;
            txtBox.Location = new Point(0, 25);
            txtBox.Width = 350; // Chiều rộng tương đối (sẽ chỉnh dock fill nếu cần)
            txtBox.Height = 35;
            txtBox.BorderStyle = BorderStyle.None; // Flat style

            // Nếu ReadOnly -> Thêm icon khóa (giả lập bằng text hoặc màu nền)
            if (isReadOnly)
            {
                txtBox.ReadOnly = true;
                txtBox.BackColor = colorReadOnlyBG;
                txtBox.Text = "🔒 ..."; // Placeholder
                txtBox.ForeColor = Color.DimGray;
            }
            else
            {
                txtBox.BackColor = Color.White;
                txtBox.BorderStyle = BorderStyle.FixedSingle; // Viền cho ô nhập được
                txtBox.ForeColor = colorTextPrimary;
            }

            // Hack: Để TextBox đẹp hơn, ta đặt nó vào 1 panel con có bo góc (hoặc chỉ đổi màu nền)
            // Ở đây làm đơn giản: TextBox có Padding (không hỗ trợ chuẩn), nên ta dùng Panel giả TextBox
            Panel pnlBox = new Panel();
            pnlBox.Location = new Point(0, 22);
            pnlBox.Size = new Size(450, 35); // Dài ra
            pnlBox.BackColor = isReadOnly ? colorReadOnlyBG : Color.White;
            pnlBox.Paint += (s, e) => {
                // Vẽ viền bo tròn nhẹ nếu muốn (Code vẽ GDI+ ở đây)
            };

            // Đặt TextBox vào vị trí
            txtBox.Parent = pnlBox;
            txtBox.Dock = DockStyle.Fill;
            // Fix lỗi TextBox bị che border
            if (!isReadOnly)
            {
                Panel borderPnl = new Panel();
                borderPnl.Location = new Point(0, 22);
                borderPnl.Size = new Size(450, 32);
                borderPnl.BackColor = Color.White;
                borderPnl.Padding = new Padding(5, 5, 5, 5); // Padding text
                txtBox.BorderStyle = BorderStyle.None;
                txtBox.Parent = borderPnl;
                txtBox.Dock = DockStyle.Fill;
                pnlBox = borderPnl; // Swap
                                    // Vẽ viền tay cho borderPnl nếu cần
            }

            // Phiên bản đơn giản nhất để chạy ngay:
            txtBox.Parent = wrapper;
            txtBox.Width = 450;
            txtBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            wrapper.Controls.Add(lbl);
            wrapper.Controls.Add(txtBox);

            grid.Controls.Add(wrapper);
        }

        // Tạo ô full chiều rộng (cho Địa chỉ)
        private Panel CreateFieldFullWidth(string labelText, out TextBox txtBox, bool isReadOnly)
        {
            Panel wrapper = new Panel();
            wrapper.Height = 65;

            Label lbl = new Label();
            lbl.Text = labelText;
            lbl.Font = fontLabel;
            lbl.ForeColor = colorTextSecondary;
            lbl.AutoSize = true;
            lbl.Location = new Point(0, 0);

            txtBox = new TextBox();
            txtBox.Font = fontInput;
            txtBox.Location = new Point(0, 22);
            txtBox.Height = 35;
            txtBox.Width = 900; // Full
            txtBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            if (isReadOnly)
            {
                txtBox.ReadOnly = true;
                txtBox.BackColor = colorReadOnlyBG;
                txtBox.BorderStyle = BorderStyle.None;
                txtBox.Text = "🔒 ...";
            }
            else
            {
                txtBox.BackColor = Color.White;
                txtBox.BorderStyle = BorderStyle.FixedSingle;
            }

            wrapper.Controls.Add(lbl);
            wrapper.Controls.Add(txtBox);
            return wrapper;
        }
    }
}