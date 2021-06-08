using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyClass;

namespace GAMA
{
    public partial class FrmSabtNamCourse : FrmMaster
    {
        public FrmSabtNamCourse()
        {
            InitializeComponent();
        }

        //Variables****************************
        #region

        private string selectedId;
        public static DataGridViewRow selected_row;

        #endregion
        //*************************************

        //Events*******************************
        #region

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            (new FrmAddEditSabtNamCourse(Moods.Add)).ShowDialog();

            LoadAllData();
        }
        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (!DataGridViewManager.IsOneRowSelected(dataGridView1, "یک سطر را برای ویرایش انتخاب کنید", "دوره"))
            {
                return;
            }

            (new FrmAddEditSabtNamCourse(Moods.Edit)).ShowDialog();

            LoadAllData();
        }
        private void BtnDetails_Click(object sender, EventArgs e)
        {
            if (!DataGridViewManager.IsOneRowSelected(dataGridView1, "یک سطر را برای نمایش جزییات انتخاب کنید", "دوره"))
            {
                return;
            }

            (new FrmDetails(TableNames.SabtnamCourse,selectedId)).ShowDialog();
        }
        private void FrmSabtNamCourse_Load(object sender, EventArgs e)
        {
            LoadAllData();
            SetLocations();
            Theme.Set(this);
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        }
        private void FrmSabtNamCourse_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphic = e.Graphics;

            graphic.DrawLine(Theme.Pen1,
                btnDetails.Left,
                btnDetails.Top - 10,
                btnEdit.Right,
                btnDetails.Top - 10);
        }
        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 0)
            {
                selected_row = dataGridView1.SelectedRows[0];
                selectedId = Convert.ToString(selected_row.Cells["id"].Value);
            }
            else
            {
                selected_row = null;
                selectedId = string.Empty;
            }
        }
        private void DataGridView1_DataSourceChanged(object sender, EventArgs e)
        {
            if (dataGridView1.Columns.Contains("id"))
            {
                dataGridView1.Columns["id"].Visible = false;
            }
        }

        #endregion
        //*************************************

        //Methods******************************
        #region

        private void LoadAllData()
        {
            SqlServerClass.ShowQueryInDataGridView(dataGridView1, "EXEC Get_SabtnamCourse_All");
        }
        private void SetLocations()
        {
            // Y
            Locations.CenterHeight(this, dataGridView1);
            dataGridView1.Top += 15;
            //Locations.Up(dataGridView1, 30, true, panel1);
            Locations.Down(dataGridView1, 25, false, btnAdd, btnDetails, btnEdit);

            // X
            Locations.CenterWidth(this, dataGridView1, btnAdd);
            Locations.Right(btnAdd, 3, true, btnEdit);
            Locations.Left(btnAdd, 3, true, btnDetails);
        }

        #endregion
        //*************************************
    }
}
