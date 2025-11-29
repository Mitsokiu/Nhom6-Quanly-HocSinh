namespace GUI.UserControls
{
    partial class UC_Admin_ThongBao
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btndel = new System.Windows.Forms.Button();
            this.btnupdate = new System.Windows.Forms.Button();
            this.btnadd = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.comboBoxrole = new System.Windows.Forms.ComboBox();
            this.labeldate = new System.Windows.Forms.Label();
            this.labelrole = new System.Windows.Forms.Label();
            this.textBoxmes = new System.Windows.Forms.TextBox();
            this.textBoxtitle = new System.Windows.Forms.TextBox();
            this.labelmes = new System.Windows.Forms.Label();
            this.labeltitle = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Target = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btntail = new System.Windows.Forms.Button();
            this.btnnext = new System.Windows.Forms.Button();
            this.btnback = new System.Windows.Forms.Button();
            this.btnhead = new System.Windows.Forms.Button();
            this.lblpage = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btndel);
            this.panel1.Controls.Add(this.btnupdate);
            this.panel1.Controls.Add(this.btnadd);
            this.panel1.Controls.Add(this.dateTimePicker1);
            this.panel1.Controls.Add(this.comboBoxrole);
            this.panel1.Controls.Add(this.labeldate);
            this.panel1.Controls.Add(this.labelrole);
            this.panel1.Controls.Add(this.textBoxmes);
            this.panel1.Controls.Add(this.textBoxtitle);
            this.panel1.Controls.Add(this.labelmes);
            this.panel1.Controls.Add(this.labeltitle);
            this.panel1.Location = new System.Drawing.Point(3, 69);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(342, 519);
            this.panel1.TabIndex = 0;
            // 
            // btndel
            // 
            this.btndel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btndel.Location = new System.Drawing.Point(230, 437);
            this.btndel.Name = "btndel";
            this.btndel.Size = new System.Drawing.Size(83, 49);
            this.btndel.TabIndex = 12;
            this.btndel.Text = "Xóa";
            this.btndel.UseVisualStyleBackColor = false;
            this.btndel.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnupdate
            // 
            this.btnupdate.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btnupdate.Location = new System.Drawing.Point(120, 437);
            this.btnupdate.Name = "btnupdate";
            this.btnupdate.Size = new System.Drawing.Size(83, 49);
            this.btnupdate.TabIndex = 11;
            this.btnupdate.Text = "Sửa";
            this.btnupdate.UseVisualStyleBackColor = false;
            this.btnupdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnadd
            // 
            this.btnadd.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btnadd.Location = new System.Drawing.Point(19, 437);
            this.btnadd.Name = "btnadd";
            this.btnadd.Size = new System.Drawing.Size(83, 49);
            this.btnadd.TabIndex = 10;
            this.btnadd.Text = "Thêm";
            this.btnadd.UseVisualStyleBackColor = false;
            this.btnadd.Click += new System.EventHandler(this.btnadd_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(98, 218);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(224, 26);
            this.dateTimePicker1.TabIndex = 9;
            // 
            // comboBoxrole
            // 
            this.comboBoxrole.FormattingEnabled = true;
            this.comboBoxrole.Items.AddRange(new object[] {
            "All",
            "gvcn",
            "gvbm",
            "student"});
            this.comboBoxrole.Location = new System.Drawing.Point(98, 154);
            this.comboBoxrole.Name = "comboBoxrole";
            this.comboBoxrole.Size = new System.Drawing.Size(224, 28);
            this.comboBoxrole.TabIndex = 8;
            // 
            // labeldate
            // 
            this.labeldate.AutoSize = true;
            this.labeldate.Location = new System.Drawing.Point(15, 218);
            this.labeldate.Name = "labeldate";
            this.labeldate.Size = new System.Drawing.Size(76, 20);
            this.labeldate.TabIndex = 5;
            this.labeldate.Text = "Ngày Tạo";
            // 
            // labelrole
            // 
            this.labelrole.AutoSize = true;
            this.labelrole.Location = new System.Drawing.Point(15, 154);
            this.labelrole.Name = "labelrole";
            this.labelrole.Size = new System.Drawing.Size(65, 20);
            this.labelrole.TabIndex = 4;
            this.labelrole.Text = "Gửi đến";
            // 
            // textBoxmes
            // 
            this.textBoxmes.Location = new System.Drawing.Point(98, 86);
            this.textBoxmes.Name = "textBoxmes";
            this.textBoxmes.Size = new System.Drawing.Size(224, 26);
            this.textBoxmes.TabIndex = 3;
            // 
            // textBoxtitle
            // 
            this.textBoxtitle.Location = new System.Drawing.Point(98, 22);
            this.textBoxtitle.Name = "textBoxtitle";
            this.textBoxtitle.Size = new System.Drawing.Size(224, 26);
            this.textBoxtitle.TabIndex = 2;
            // 
            // labelmes
            // 
            this.labelmes.AutoSize = true;
            this.labelmes.Location = new System.Drawing.Point(15, 86);
            this.labelmes.Name = "labelmes";
            this.labelmes.Size = new System.Drawing.Size(75, 20);
            this.labelmes.TabIndex = 1;
            this.labelmes.Text = "Nội Dung";
            // 
            // labeltitle
            // 
            this.labeltitle.AutoSize = true;
            this.labeltitle.Location = new System.Drawing.Point(15, 22);
            this.labeltitle.Name = "labeltitle";
            this.labeltitle.Size = new System.Drawing.Size(64, 20);
            this.labeltitle.TabIndex = 0;
            this.labeltitle.Text = "Tiêu Đề";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Location = new System.Drawing.Point(352, 69);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(773, 519);
            this.panel2.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Target,
            this.title,
            this.mes,
            this.Date});
            this.dataGridView1.Location = new System.Drawing.Point(4, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(766, 512);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.MinimumWidth = 8;
            this.ID.Name = "ID";
            this.ID.Width = 150;
            // 
            // Target
            // 
            this.Target.HeaderText = "Gửi Đến";
            this.Target.MinimumWidth = 8;
            this.Target.Name = "Target";
            this.Target.Width = 150;
            // 
            // title
            // 
            this.title.HeaderText = "Tiêu Đề";
            this.title.MinimumWidth = 8;
            this.title.Name = "title";
            this.title.Width = 150;
            // 
            // mes
            // 
            this.mes.HeaderText = "Nội Dung";
            this.mes.MinimumWidth = 8;
            this.mes.Name = "mes";
            this.mes.Width = 150;
            // 
            // Date
            // 
            this.Date.HeaderText = "Ngày Tạo";
            this.Date.MinimumWidth = 8;
            this.Date.Name = "Date";
            this.Date.Width = 150;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(3, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(162, 25);
            this.label6.TabIndex = 21;
            this.label6.Text = "Tạo Thông Báo";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lblpage);
            this.panel3.Controls.Add(this.btntail);
            this.panel3.Controls.Add(this.btnnext);
            this.panel3.Controls.Add(this.btnback);
            this.panel3.Controls.Add(this.btnhead);
            this.panel3.Location = new System.Drawing.Point(450, 591);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(488, 40);
            this.panel3.TabIndex = 22;
            // 
            // btntail
            // 
            this.btntail.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.btntail.Location = new System.Drawing.Point(400, 4);
            this.btntail.Name = "btntail";
            this.btntail.Size = new System.Drawing.Size(75, 28);
            this.btntail.TabIndex = 3;
            this.btntail.Text = ">>";
            this.btntail.UseVisualStyleBackColor = false;
            // 
            // btnnext
            // 
            this.btnnext.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.btnnext.Location = new System.Drawing.Point(319, 4);
            this.btnnext.Name = "btnnext";
            this.btnnext.Size = new System.Drawing.Size(75, 28);
            this.btnnext.TabIndex = 2;
            this.btnnext.Text = ">";
            this.btnnext.UseVisualStyleBackColor = false;
            // 
            // btnback
            // 
            this.btnback.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.btnback.Location = new System.Drawing.Point(95, 4);
            this.btnback.Name = "btnback";
            this.btnback.Size = new System.Drawing.Size(75, 28);
            this.btnback.TabIndex = 1;
            this.btnback.Text = "<";
            this.btnback.UseVisualStyleBackColor = false;
            // 
            // btnhead
            // 
            this.btnhead.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.btnhead.Location = new System.Drawing.Point(14, 4);
            this.btnhead.Name = "btnhead";
            this.btnhead.Size = new System.Drawing.Size(75, 28);
            this.btnhead.TabIndex = 0;
            this.btnhead.Text = "<<";
            this.btnhead.UseVisualStyleBackColor = false;
            // 
            // lblpage
            // 
            this.lblpage.AutoSize = true;
            this.lblpage.Location = new System.Drawing.Point(235, 10);
            this.lblpage.Name = "lblpage";
            this.lblpage.Size = new System.Drawing.Size(18, 20);
            this.lblpage.TabIndex = 6;
            this.lblpage.Text = "1";
            // 
            // UC_Admin_ThongBao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "UC_Admin_ThongBao";
            this.Size = new System.Drawing.Size(1129, 650);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labeldate;
        private System.Windows.Forms.Label labelrole;
        private System.Windows.Forms.TextBox textBoxmes;
        private System.Windows.Forms.TextBox textBoxtitle;
        private System.Windows.Forms.Label labelmes;
        private System.Windows.Forms.Label labeltitle;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ComboBox comboBoxrole;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button btndel;
        private System.Windows.Forms.Button btnupdate;
        private System.Windows.Forms.Button btnadd;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Target;
        private System.Windows.Forms.DataGridViewTextBoxColumn title;
        private System.Windows.Forms.DataGridViewTextBoxColumn mes;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btntail;
        private System.Windows.Forms.Button btnnext;
        private System.Windows.Forms.Button btnback;
        private System.Windows.Forms.Button btnhead;
        private System.Windows.Forms.Label lblpage;
    }
}
