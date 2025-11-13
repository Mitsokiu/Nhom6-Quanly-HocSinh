using System;
using System.Windows.Forms;
using DTO;
using BUS;

namespace GUI.UserControls
{
    public partial class UC_Admin_Class_Monhoc : UserControl
    {
        private MonHocBUS bus = new MonHocBUS();

        public UC_Admin_Class_Monhoc()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            dataGridView1.Rows.Clear();
            foreach (var mon in bus.GetAllMonHoc())
            {
                dataGridView1.Rows.Add(mon.MaMon, mon.TenMon);
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            MonHocDTO mon = new MonHocDTO
            {
                MaMon = textBox2.Text.Trim(),
                TenMon = textBox1.Text.Trim()
            };
            bus.AddMonHoc(mon);
            LoadData();
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            MonHocDTO mon = new MonHocDTO
            {
                MaMon = textBox2.Text.Trim(),
                TenMon = textBox1.Text.Trim()
            };
            if (bus.UpdateMonHoc(mon))
                LoadData();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            string maMon = textBox2.Text.Trim();
            if (bus.DeleteMonHoc(maMon))
                LoadData();
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dataGridView1.Rows[e.RowIndex];
            textBox2.Text = row.Cells[0].Value?.ToString();
            textBox1.Text = row.Cells[1].Value?.ToString();
        }
    }
}
