using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyClass;
using System.Collections;

namespace GAMA
{
    public partial class FrmBranch : FrmMaster
    {
        public FrmBranch()
        {
            InitializeComponent();
        }

        //Variables****************************
        #region

        private string selectedId;
        public static DataGridViewRow selected_row = null;

        #endregion
        //*************************************

        //Events*******************************
        #region

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            (new FrmAddEditBranch(Moods.Add)).ShowDialog();

            LoadData();
        }
        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (!DataGridViewManager.IsOneRowSelected(dataGridView1, "یک سطر را برای ویرایش انتخاب کنید", "نام خوشه"))
            {
                return;
            }

            (new FrmAddEditBranch(Moods.Edit)).ShowDialog();

            LoadData();
        }
        private void FrmBranch_Load(object sender, EventArgs e)
        {
            SetLocations();
            Theme.Set(this);
            LoadData();
        }
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (!DataGridViewManager.IsOneRowSelected(dataGridView1, "یک سطر را برای حذف کردن انتخاب کنید", "نام خوشه"))
            {
                return;
            }

            if (MessageBox.Show("آیا از حذف کردن اطمینان دارید ؟", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (SqlServerClass.Delete(TableNames.BranchCourse, "Id = " + selectedId))
                {
                    DataGridViewManager.DeleteRow(dataGridView1, dataGridView1.CurrentCell.RowIndex);
                    MessageBox.Show("حذف شد");
                }
            }
        }
        private void BtnDetails_Click(object sender, EventArgs e)
        {
            if (!DataGridViewManager.IsOneRowSelected(dataGridView1, "یک سطر را برای نمایش جزییات انتخاب کنید", "نام خوشه"))
            {
                return;
            }

            (new FrmDetails(TableNames.BranchCourse, selectedId)).ShowDialog();
        }
        private void BtnAddGroup_Click(object sender, EventArgs e)
        {
            (new FrmAddEditGroup(Moods.Add)).ShowDialog();
        }
        private void FrmBranch_Paint(object sender, PaintEventArgs e)
        {
            Graphics gr = e.Graphics;

            gr.DrawLine(Theme.Pen1,
                btnDetails.Left,
                btnDelete.Top - 10,
                btnAddGroup.Right,
                btnDelete.Top - 10);
        }
        private void FrmBranch_FormClosed(object sender, FormClosedEventArgs e)
        {
            selected_row = null;
            selectedId = string.Empty;
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

        private void LoadData()
        {
            SqlServerClass.ShowQueryInDataGridView(dataGridView1, "EXEC Get_Branch_All");
        }
        private void SetLocations()
        {
            // Y
            Locations.CenterHeight(this, dataGridView1);
            dataGridView1.Top -= 10;
            Locations.Down(dataGridView1, 20, false, btnDelete, btnDetails, btnEdit, btnAdd, btnAddGroup);

            // X
            Locations.CenterWidth(this, dataGridView1, btnAdd);
            Locations.Right(btnAdd, 3, true, btnEdit, btnAddGroup);
            Locations.Left(btnAdd, 3, true, btnDelete, btnDetails);
        }

        #endregion
        //*************************************
    }
}