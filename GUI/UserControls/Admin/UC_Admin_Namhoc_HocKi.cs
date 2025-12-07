using BUS;
using DTO;
using System;
using System.Windows.Forms;

namespace GUI.UserControls
{
    public partial class UC_Admin_Namhoc_Hocki : UserControl
    {
        public UC_Admin_Namhoc_Hocki()
        {
            InitializeComponent();
            LoadData();
            dataGridView1.CellClick += DataGridView1_CellClick;
            button4.Click += BtnAdd_Click;
            btnUpdate.Click += BtnUpdate_Click;
            btnDelete.Click += BtnDelete_Click;
        }

        private void LoadData()
        {
            dataGridView1.Rows.Clear();
            var list = AcademicYearBUS.GetAllYears();
            foreach (var y in list)
            {
                dataGridView1.Rows.Add(
                    y.YearId,
                    y.Name,
                    y.StartDate.ToString("yyyy-MM-dd"),
                    y.EndDate.ToString("yyyy-MM-dd")
                );
            }
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dataGridView1.Rows[e.RowIndex];

                textId.Text = row.Cells[0].Value?.ToString() ?? "";
                textNam.Text = row.Cells[1].Value?.ToString() ?? "";

                if (row.Cells[2].Value != null && DateTime.TryParse(row.Cells[2].Value.ToString(), out DateTime start))
                    dtpStart.Value = start;

                if (row.Cells[3].Value != null && DateTime.TryParse(row.Cells[3].Value.ToString(), out DateTime end))
                    dtpEnd.Value = end;
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            var year = new AcademicYearDTO
            {
                Name = textNam.Text,
                StartDate = dtpStart.Value,
                EndDate = dtpEnd.Value
            };
            if (AcademicYearBUS.AddYear(year))
                LoadData();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textId.Text, out int id))
            {
                var year = new AcademicYearDTO
                {
                    YearId = id,
                    Name = textNam.Text,
                    StartDate = dtpStart.Value,
                    EndDate = dtpEnd.Value
                };
                if (AcademicYearBUS.UpdateYear(year))
                    LoadData();
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textId.Text, out int id))
            {
                if (AcademicYearBUS.DeleteYear(id))
                    LoadData();
            }
        }
    }
}
