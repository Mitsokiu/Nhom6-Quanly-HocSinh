using System;
using System.Drawing;
using System.Windows.Forms;
namespace GUI.UserControls
{
    partial class UC_GVBM_Diem
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
            this.button4 = new System.Windows.Forms.Button();
            this.txtMid = new System.Windows.Forms.TextBox();
            this.txtFinal = new System.Windows.Forms.TextBox();
            this.txt45 = new System.Windows.Forms.TextBox();
            this.txtQuiz15 = new System.Windows.Forms.TextBox();
            this.txtOral = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.cbBoxnamhoc = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBoxhk = new System.Windows.Forms.ComboBox();
            this.comboBoxlop = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtStudentID = new System.Windows.Forms.TextBox();
            this.lablstudent = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtnumber = new System.Windows.Forms.TextBox();
            this.btntail = new System.Windows.Forms.Button();
            this.btnnext = new System.Windows.Forms.Button();
            this.btnback = new System.Windows.Forms.Button();
            this.btnhead = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtave = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btnxuatpdf = new System.Windows.Forms.Button();
            this.btnxuatexcel = new System.Windows.Forms.Button();
            this.btnimportexcel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Lime;
            this.button4.Location = new System.Drawing.Point(196, 326);
            this.button4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(101, 33);
            this.button4.TabIndex = 34;
            this.button4.Text = "Lưu";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtMid
            // 
            this.txtMid.Location = new System.Drawing.Point(100, 264);
            this.txtMid.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMid.Name = "txtMid";
            this.txtMid.Size = new System.Drawing.Size(47, 26);
            this.txtMid.TabIndex = 32;
            // 
            // txtFinal
            // 
            this.txtFinal.Location = new System.Drawing.Point(250, 218);
            this.txtFinal.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtFinal.Name = "txtFinal";
            this.txtFinal.Size = new System.Drawing.Size(47, 26);
            this.txtFinal.TabIndex = 31;
            // 
            // txt45
            // 
            this.txt45.Location = new System.Drawing.Point(100, 219);
            this.txt45.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt45.Name = "txt45";
            this.txt45.Size = new System.Drawing.Size(47, 26);
            this.txt45.TabIndex = 30;
            // 
            // txtQuiz15
            // 
            this.txtQuiz15.Location = new System.Drawing.Point(250, 172);
            this.txtQuiz15.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtQuiz15.Name = "txtQuiz15";
            this.txtQuiz15.Size = new System.Drawing.Size(47, 26);
            this.txtQuiz15.TabIndex = 29;
            this.txtQuiz15.TextChanged += new System.EventHandler(this.txtQuiz15_TextChanged);
            // 
            // txtOral
            // 
            this.txtOral.Location = new System.Drawing.Point(100, 175);
            this.txtOral.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtOral.Name = "txtOral";
            this.txtOral.Size = new System.Drawing.Size(47, 26);
            this.txtOral.TabIndex = 28;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 267);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 20);
            this.label5.TabIndex = 27;
            this.label5.Text = "GK";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(183, 224);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 20);
            this.label4.TabIndex = 26;
            this.label4.Text = "Cuối Kì";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 224);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 20);
            this.label3.TabIndex = 25;
            this.label3.Text = "1 Tiết";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(183, 175);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 20);
            this.label2.TabIndex = 24;
            this.label2.Text = "15p";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 177);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 20);
            this.label1.TabIndex = 23;
            this.label1.Text = "Miệng";
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(91, 130);
            this.comboBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(75, 28);
            this.comboBox3.TabIndex = 21;
            this.comboBox3.Text = "Môn";
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(323, 75);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.Size = new System.Drawing.Size(1141, 381);
            this.dataGridView1.TabIndex = 18;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(9, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 23);
            this.label7.TabIndex = 39;
            this.label7.Text = "Năm Học";
            // 
            // cbBoxnamhoc
            // 
            this.cbBoxnamhoc.Location = new System.Drawing.Point(87, 13);
            this.cbBoxnamhoc.Name = "cbBoxnamhoc";
            this.cbBoxnamhoc.Size = new System.Drawing.Size(142, 28);
            this.cbBoxnamhoc.TabIndex = 40;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(7, 102);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 23);
            this.label6.TabIndex = 35;
            this.label6.Text = "Lớp";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(9, 63);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(78, 23);
            this.label8.TabIndex = 37;
            this.label8.Text = "HocKI";
            // 
            // comboBoxhk
            // 
            this.comboBoxhk.Location = new System.Drawing.Point(91, 58);
            this.comboBoxhk.Name = "comboBoxhk";
            this.comboBoxhk.Size = new System.Drawing.Size(142, 28);
            this.comboBoxhk.TabIndex = 38;
            // 
            // comboBoxlop
            // 
            this.comboBoxlop.Location = new System.Drawing.Point(91, 94);
            this.comboBoxlop.Name = "comboBoxlop";
            this.comboBoxlop.Size = new System.Drawing.Size(142, 28);
            this.comboBoxlop.TabIndex = 36;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(9, 130);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(78, 23);
            this.label9.TabIndex = 41;
            this.label9.Text = "Mon";
            // 
            // txtStudentID
            // 
            this.txtStudentID.Location = new System.Drawing.Point(100, 315);
            this.txtStudentID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtStudentID.Name = "txtStudentID";
            this.txtStudentID.Size = new System.Drawing.Size(47, 26);
            this.txtStudentID.TabIndex = 43;
            // 
            // lablstudent
            // 
            this.lablstudent.AutoSize = true;
            this.lablstudent.Location = new System.Drawing.Point(9, 321);
            this.lablstudent.Name = "lablstudent";
            this.lablstudent.Size = new System.Drawing.Size(26, 20);
            this.lablstudent.TabIndex = 42;
            this.lablstudent.Text = "ID";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtnumber);
            this.panel1.Controls.Add(this.btntail);
            this.panel1.Controls.Add(this.btnnext);
            this.panel1.Controls.Add(this.btnback);
            this.panel1.Controls.Add(this.btnhead);
            this.panel1.Location = new System.Drawing.Point(539, 457);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(488, 40);
            this.panel1.TabIndex = 44;
            // 
            // txtnumber
            // 
            this.txtnumber.Location = new System.Drawing.Point(194, 5);
            this.txtnumber.Name = "txtnumber";
            this.txtnumber.Size = new System.Drawing.Size(100, 26);
            this.txtnumber.TabIndex = 4;
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
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.txtave);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.cbBoxnamhoc);
            this.panel2.Controls.Add(this.comboBoxlop);
            this.panel2.Controls.Add(this.txtStudentID);
            this.panel2.Controls.Add(this.comboBoxhk);
            this.panel2.Controls.Add(this.lablstudent);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.button4);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.txtFinal);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.txtQuiz15);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.txtMid);
            this.panel2.Controls.Add(this.comboBox3);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.txt45);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtOral);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Location = new System.Drawing.Point(3, 74);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(318, 382);
            this.panel2.TabIndex = 45;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // txtave
            // 
            this.txtave.Location = new System.Drawing.Point(250, 267);
            this.txtave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtave.Name = "txtave";
            this.txtave.Size = new System.Drawing.Size(47, 26);
            this.txtave.TabIndex = 45;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(183, 273);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 20);
            this.label11.TabIndex = 44;
            this.label11.Text = "TB";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(3, 14);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(158, 25);
            this.label10.TabIndex = 46;
            this.label10.Text = "Cập Nhật Điểm";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // btnxuatpdf
            // 
            this.btnxuatpdf.BackColor = System.Drawing.Color.Lime;
            this.btnxuatpdf.Location = new System.Drawing.Point(1233, 30);
            this.btnxuatpdf.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnxuatpdf.Name = "btnxuatpdf";
            this.btnxuatpdf.Size = new System.Drawing.Size(101, 41);
            this.btnxuatpdf.TabIndex = 48;
            this.btnxuatpdf.Text = "Xuất PDF";
            this.btnxuatpdf.UseVisualStyleBackColor = false;
            this.btnxuatpdf.Click += new System.EventHandler(this.BtnExportPDF_Click);
            // 
            // btnxuatexcel
            // 
            this.btnxuatexcel.BackColor = System.Drawing.Color.Lime;
            this.btnxuatexcel.Location = new System.Drawing.Point(1363, 30);
            this.btnxuatexcel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnxuatexcel.Name = "btnxuatexcel";
            this.btnxuatexcel.Size = new System.Drawing.Size(101, 41);
            this.btnxuatexcel.TabIndex = 49;
            this.btnxuatexcel.Text = "Xuất Excel";
            this.btnxuatexcel.UseVisualStyleBackColor = false;
            this.btnxuatexcel.Click += new System.EventHandler(this.BtnExportExcel_Click);
            // 
            // btnimportexcel
            // 
            this.btnimportexcel.BackColor = System.Drawing.Color.Lime;
            this.btnimportexcel.Location = new System.Drawing.Point(1096, 30);
            this.btnimportexcel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnimportexcel.Name = "btnimportexcel";
            this.btnimportexcel.Size = new System.Drawing.Size(101, 41);
            this.btnimportexcel.TabIndex = 50;
            this.btnimportexcel.Text = "Nhập Excel";
            this.btnimportexcel.UseVisualStyleBackColor = false;
            this.btnimportexcel.Click += new System.EventHandler(this.BtnImportExcel_Click);
            // 
            // UC_GVBM_Diem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnimportexcel);
            this.Controls.Add(this.btnxuatexcel);
            this.Controls.Add(this.btnxuatpdf);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridView1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "UC_GVBM_Diem";
            this.Size = new System.Drawing.Size(1476, 535);
            this.Load += new System.EventHandler(this.UC_GVBM_Diem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button button4;
        private TextBox txtMid;
        private TextBox txtFinal;
        private TextBox txt45;
        private TextBox txtQuiz15;
        private TextBox txtOral;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private ComboBox comboBox3;
        private DataGridView dataGridView1;
        private Label label7;
        private ComboBox cbBoxnamhoc;
        private Label label6;
        private Label label8;
        private ComboBox comboBoxhk;
        private ComboBox comboBoxlop;
        private Label label9;
        private TextBox txtStudentID;
        private Label lablstudent;
        private Panel panel1;
        private TextBox txtnumber;
        private Button btntail;
        private Button btnnext;
        private Button btnback;
        private Button btnhead;
        private Panel panel2;
        private Label label10;
        private TextBox txtave;
        private Label label11;
        private Button btnxuatpdf;
        private Button btnxuatexcel;
        private Button btnimportexcel;
    }
}
