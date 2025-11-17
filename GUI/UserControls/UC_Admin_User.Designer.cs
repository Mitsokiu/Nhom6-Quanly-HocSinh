using System;
using System.Drawing;
using System.Windows.Forms;
namespace GUI.UserControls
{
    partial class UC_Admin_User
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_add = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_xoa = new System.Windows.Forms.Button();
            this.btn_sua = new System.Windows.Forms.Button();
            this.Text_mail = new System.Windows.Forms.TextBox();
            this.Text_sdt = new System.Windows.Forms.TextBox();
            this.Text_ht = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Text_mk = new System.Windows.Forms.TextBox();
            this.Text_tk = new System.Windows.Forms.TextBox();
            this.combo_role = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btn_search = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.Taikhoan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MatKhau = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SDT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Role = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayTao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_add
            // 
            this.btn_add.BackColor = System.Drawing.Color.Silver;
            this.btn_add.Location = new System.Drawing.Point(1131, 28);
            this.btn_add.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(101, 27);
            this.btn_add.TabIndex = 10;
            this.btn_add.Text = "Them";
            this.btn_add.UseVisualStyleBackColor = false;
            this.btn_add.Click += new System.EventHandler(this.Add_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 20);
            this.label1.TabIndex = 15;
            this.label1.Text = "Thong Tin";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btn_xoa);
            this.panel2.Controls.Add(this.btn_sua);
            this.panel2.Controls.Add(this.Text_mail);
            this.panel2.Controls.Add(this.Text_sdt);
            this.panel2.Controls.Add(this.Text_ht);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.Text_mk);
            this.panel2.Controls.Add(this.Text_tk);
            this.panel2.Controls.Add(this.combo_role);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(30, 71);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(338, 465);
            this.panel2.TabIndex = 14;
            // 
            // btn_xoa
            // 
            this.btn_xoa.BackColor = System.Drawing.Color.Silver;
            this.btn_xoa.Location = new System.Drawing.Point(211, 422);
            this.btn_xoa.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_xoa.Name = "btn_xoa";
            this.btn_xoa.Size = new System.Drawing.Size(101, 27);
            this.btn_xoa.TabIndex = 5;
            this.btn_xoa.Text = "Xoa";
            this.btn_xoa.UseVisualStyleBackColor = false;
            this.btn_xoa.Click += new System.EventHandler(this.btn_xoa_Click);
            // 
            // btn_sua
            // 
            this.btn_sua.BackColor = System.Drawing.Color.Silver;
            this.btn_sua.Location = new System.Drawing.Point(12, 422);
            this.btn_sua.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_sua.Name = "btn_sua";
            this.btn_sua.Size = new System.Drawing.Size(101, 27);
            this.btn_sua.TabIndex = 4;
            this.btn_sua.Text = "Sua";
            this.btn_sua.UseVisualStyleBackColor = false;
            this.btn_sua.Click += new System.EventHandler(this.btn_sua_Click);
            // 
            // Text_mail
            // 
            this.Text_mail.Location = new System.Drawing.Point(105, 148);
            this.Text_mail.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Text_mail.Name = "Text_mail";
            this.Text_mail.Size = new System.Drawing.Size(207, 26);
            this.Text_mail.TabIndex = 11;
            // 
            // Text_sdt
            // 
            this.Text_sdt.Location = new System.Drawing.Point(105, 190);
            this.Text_sdt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Text_sdt.Name = "Text_sdt";
            this.Text_sdt.Size = new System.Drawing.Size(207, 26);
            this.Text_sdt.TabIndex = 10;
            // 
            // Text_ht
            // 
            this.Text_ht.Location = new System.Drawing.Point(105, 116);
            this.Text_ht.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Text_ht.Name = "Text_ht";
            this.Text_ht.Size = new System.Drawing.Size(207, 26);
            this.Text_ht.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 120);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 20);
            this.label6.TabIndex = 7;
            this.label6.Text = "Ho Ten";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 193);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 20);
            this.label5.TabIndex = 6;
            this.label5.Text = "SDT";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 154);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "Email";
            // 
            // Text_mk
            // 
            this.Text_mk.Location = new System.Drawing.Point(105, 86);
            this.Text_mk.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Text_mk.Name = "Text_mk";
            this.Text_mk.Size = new System.Drawing.Size(207, 26);
            this.Text_mk.TabIndex = 4;
            // 
            // Text_tk
            // 
            this.Text_tk.Location = new System.Drawing.Point(105, 56);
            this.Text_tk.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Text_tk.Name = "Text_tk";
            this.Text_tk.Size = new System.Drawing.Size(207, 26);
            this.Text_tk.TabIndex = 3;
            // 
            // combo_role
            // 
            this.combo_role.FormattingEnabled = true;
            this.combo_role.Items.AddRange(new object[] {
            "admin",
            "student",
            "gvcn",
            "gvbm",
            "parent"});
            this.combo_role.Location = new System.Drawing.Point(117, 235);
            this.combo_role.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.combo_role.Name = "combo_role";
            this.combo_role.Size = new System.Drawing.Size(164, 28);
            this.combo_role.TabIndex = 2;
            this.combo_role.Text = "Role";
            this.combo_role.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Mat Khau";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tai Khoan";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Taikhoan,
            this.MatKhau,
            this.HoTen,
            this.Email,
            this.SDT,
            this.Role,
            this.NgayTao});
            this.dataGridView1.Location = new System.Drawing.Point(374, 71);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.Size = new System.Drawing.Size(1117, 465);
            this.dataGridView1.TabIndex = 13;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // btn_search
            // 
            this.btn_search.Location = new System.Drawing.Point(543, 14);
            this.btn_search.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(101, 27);
            this.btn_search.TabIndex = 12;
            this.btn_search.Text = "Seach";
            this.btn_search.UseVisualStyleBackColor = true;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(202, 14);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(336, 26);
            this.txtSearch.TabIndex = 11;
            this.txtSearch.Text = "Search";
            // 
            // Taikhoan
            // 
            this.Taikhoan.HeaderText = "Tai Khoan";
            this.Taikhoan.MinimumWidth = 8;
            this.Taikhoan.Name = "Taikhoan";
            this.Taikhoan.Width = 150;
            // 
            // MatKhau
            // 
            this.MatKhau.HeaderText = "Mật Khẩu";
            this.MatKhau.MinimumWidth = 8;
            this.MatKhau.Name = "MatKhau";
            this.MatKhau.Width = 150;
            // 
            // HoTen
            // 
            this.HoTen.HeaderText = "Ho Ten";
            this.HoTen.MinimumWidth = 8;
            this.HoTen.Name = "HoTen";
            this.HoTen.Width = 150;
            // 
            // Email
            // 
            this.Email.HeaderText = "Email";
            this.Email.MinimumWidth = 8;
            this.Email.Name = "Email";
            this.Email.Width = 150;
            // 
            // SDT
            // 
            this.SDT.HeaderText = "SDT";
            this.SDT.MinimumWidth = 8;
            this.SDT.Name = "SDT";
            this.SDT.Width = 150;
            // 
            // Role
            // 
            this.Role.HeaderText = "Chuc Vu";
            this.Role.MinimumWidth = 8;
            this.Role.Name = "Role";
            this.Role.Width = 150;
            // 
            // NgayTao
            // 
            this.NgayTao.HeaderText = "Ngay Tao";
            this.NgayTao.MinimumWidth = 8;
            this.NgayTao.Name = "NgayTao";
            this.NgayTao.Width = 150;
            // 
            // UC_Admin_User
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btn_search);
            this.Controls.Add(this.txtSearch);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "UC_Admin_User";
            this.Size = new System.Drawing.Size(1505, 603);
            this.Load += new System.EventHandler(this.UC_Admin_User_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btn_add;
        private Label label1;
        private Panel panel2;
        private Button btn_xoa;
        private Button btn_sua;
        private TextBox Text_mail;
        private TextBox Text_sdt;
        private TextBox Text_ht;
        private Label label6;
        private Label label5;
        private Label label4;
        private TextBox Text_mk;
        private TextBox Text_tk;
        private ComboBox combo_role;
        private Label label3;
        private Label label2;
        private DataGridView dataGridView1;
        private Button btn_search;
        private TextBox txtSearch;
        private DataGridViewTextBoxColumn Taikhoan;
        private DataGridViewTextBoxColumn MatKhau;
        private DataGridViewTextBoxColumn HoTen;
        private DataGridViewTextBoxColumn Email;
        private DataGridViewTextBoxColumn SDT;
        private DataGridViewTextBoxColumn Role;
        private DataGridViewTextBoxColumn NgayTao;
    }
}
