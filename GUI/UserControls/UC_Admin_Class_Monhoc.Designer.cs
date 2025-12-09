using System;
using System.Drawing;
using System.Windows.Forms;

namespace GUI.UserControls
{
    partial class UC_Admin_Class_Monhoc
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.mamon_Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameMH_Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.label_TenMon = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.textTenmon = new System.Windows.Forms.TextBox();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.txtMamon = new System.Windows.Forms.TextBox();
            this.label_MaMon = new System.Windows.Forms.Label();
            this.panel_Input = new System.Windows.Forms.Panel();
            this.label_Title = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel_Input.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(70)))), ((int)(((byte)(102)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeight = 35;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.mamon_Column,
            this.NameMH_Column});
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(390, 67);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 30;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(381, 448);
            this.dataGridView1.TabIndex = 0;
            // 
            // mamon_Column
            // 
            this.mamon_Column.HeaderText = "Mã Môn";
            this.mamon_Column.MinimumWidth = 8;
            this.mamon_Column.Name = "mamon_Column";
            this.mamon_Column.Width = 150;
            // 
            // NameMH_Column
            // 
            this.NameMH_Column.HeaderText = "Tên Môn Học";
            this.NameMH_Column.MinimumWidth = 8;
            this.NameMH_Column.Name = "NameMH_Column";
            this.NameMH_Column.Width = 200;
            // 
            // label_TenMon
            // 
            this.label_TenMon.AutoSize = true;
            this.label_TenMon.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_TenMon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(70)))), ((int)(((byte)(102)))));
            this.label_TenMon.Location = new System.Drawing.Point(13, 71);
            this.label_TenMon.Name = "label_TenMon";
            this.label_TenMon.Size = new System.Drawing.Size(80, 25);
            this.label_TenMon.TabIndex = 4;
            this.label_TenMon.Text = "Tên Môn";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // textTenmon
            // 
            this.textTenmon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textTenmon.Location = new System.Drawing.Point(94, 69);
            this.textTenmon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textTenmon.Name = "textTenmon";
            this.textTenmon.Size = new System.Drawing.Size(238, 26);
            this.textTenmon.TabIndex = 6;
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnXoa.FlatAppearance.BorderSize = 0;
            this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoa.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.Location = new System.Drawing.Point(251, 385);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(105, 50);
            this.btnXoa.TabIndex = 9;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // btnSua
            // 
            this.btnSua.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.btnSua.FlatAppearance.BorderSize = 0;
            this.btnSua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSua.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.ForeColor = System.Drawing.Color.White;
            this.btnSua.Location = new System.Drawing.Point(127, 385);
            this.btnSua.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(105, 50);
            this.btnSua.TabIndex = 8;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = false;
            this.btnSua.Click += new System.EventHandler(this.BtnEdit_Click);
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.btnThem.FlatAppearance.BorderSize = 0;
            this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThem.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.Location = new System.Drawing.Point(3, 385);
            this.btnThem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(105, 50);
            this.btnThem.TabIndex = 7;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // txtMamon
            // 
            this.txtMamon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMamon.Location = new System.Drawing.Point(94, 11);
            this.txtMamon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMamon.Name = "txtMamon";
            this.txtMamon.Size = new System.Drawing.Size(238, 26);
            this.txtMamon.TabIndex = 11;
            // 
            // label_MaMon
            // 
            this.label_MaMon.AutoSize = true;
            this.label_MaMon.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_MaMon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(70)))), ((int)(((byte)(102)))));
            this.label_MaMon.Location = new System.Drawing.Point(13, 14);
            this.label_MaMon.Name = "label_MaMon";
            this.label_MaMon.Size = new System.Drawing.Size(79, 25);
            this.label_MaMon.TabIndex = 10;
            this.label_MaMon.Text = "Mã Môn";
            // 
            // panel_Input
            // 
            this.panel_Input.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.panel_Input.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_Input.Controls.Add(this.label_MaMon);
            this.panel_Input.Controls.Add(this.label_TenMon);
            this.panel_Input.Controls.Add(this.txtMamon);
            this.panel_Input.Controls.Add(this.textTenmon);
            this.panel_Input.Controls.Add(this.btnThem);
            this.panel_Input.Controls.Add(this.btnXoa);
            this.panel_Input.Controls.Add(this.btnSua);
            this.panel_Input.Location = new System.Drawing.Point(3, 67);
            this.panel_Input.Name = "panel_Input";
            this.panel_Input.Size = new System.Drawing.Size(381, 448);
            this.panel_Input.TabIndex = 12;
            // 
            // label_Title
            // 
            this.label_Title.AutoSize = true;
            this.label_Title.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(70)))), ((int)(((byte)(102)))));
            this.label_Title.Location = new System.Drawing.Point(3, 10);
            this.label_Title.Name = "label_Title";
            this.label_Title.Size = new System.Drawing.Size(324, 45);
            this.label_Title.TabIndex = 17;
            this.label_Title.Text = "QUẢN LÝ MÔN HỌC";
            // 
            // UC_Admin_Class_Monhoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.label_Title);
            this.Controls.Add(this.panel_Input);
            this.Controls.Add(this.dataGridView1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "UC_Admin_Class_Monhoc";
            this.Size = new System.Drawing.Size(778, 560);
            this.Load += new System.EventHandler(this.UC_Admin_Class_Monhoc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel_Input.ResumeLayout(false);
            this.panel_Input.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        // Cập nhật tên biến ở đây
        private DataGridView dataGridView1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Label label_TenMon;
        private ContextMenuStrip contextMenuStrip1;
        private TextBox textTenmon;
        private Button btnXoa;
        private Button btnSua;
        private Button btnThem;
        private DataGridViewTextBoxColumn mamon_Column;
        private DataGridViewTextBoxColumn NameMH_Column;
        private TextBox txtMamon;
        private Label label_MaMon;
        private Panel panel_Input;
        private Label label_Title;
    }
}