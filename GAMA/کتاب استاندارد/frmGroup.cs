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
    public partial class FrmGroup : FrmMaster
    {
        public FrmGroup()
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
            (new FrmAddEditGroup(Moods.Add)).ShowDialog();

            MainCombo1_SelectedIndexChanged(null, null);
        }
        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (!DataGridViewManager.IsOneRowSelected(dataGridView1, "یک سطر را برای ویرایش انتخاب کنید", "نام گروه"))
            {
                return;
            }

            (new FrmAddEditGroup(Moods.Edit)).ShowDialog();

            MainCombo1_SelectedIndexChanged(null, null);
        }
        private void FrmGroup_Load(object sender, EventArgs e)
        {
            ControlManager.SetComboItems(mainCombo1, SqlCaptureManager.AllBranchs());
            mainCombo1.Items.Add("همه");
            mainCombo1.SelectedItem = "همه";

            SetLocations();
            Theme.Set(this, panel1);
        }
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (!DataGridViewManager.IsOneRowSelected(dataGridView1, "یک سطر را برای حذف کردن انتخاب کنید", "نام گروه"))
            {
                return;
            }

            if (MessageBox.Show("آیا از حذف کردن اطمینان دارید ؟", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (SqlServerClass.Delete(TableNames.GroupCourse, "Id = " +selectedId))
                {
                    DataGridViewManager.DeleteRow(dataGridView1, dataGridView1.CurrentCell.RowIndex);
                    MessageBox.Show("حذف شد");
                }
            }
        }
        private void BtnDetails_Click(object sender, EventArgs e)
        {
            if (!DataGridViewManager.IsOneRowSelected(dataGridView1, "یک سطر را برای نمایش جزییات انتخاب کنید", "نام گروه"))
            {
                return;
            }

            (new FrmDetails(TableNames.GroupCourse, selectedId)).ShowDialog();
        }
        private void BtnAddCourse_Click(object sender, EventArgs e)
        {
            (new FrmAddEditCourse(Moods.Add)).ShowDialog();
        }
        private void FrmGroup_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphic = e.Graphics;

            graphic.DrawLine(Theme.Pen1,
                btnDetails.Left,
                btnDetails.Top - 10,
                btnAddCourse.Right,
                btnDetails.Top - 10);
        }
        private void FrmGroup_FormClosed(object sender, FormClosedEventArgs e)
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
        private void MainCombo1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataGridViewManager.Clear(dataGridView1);

            if (mainCombo1.SelectedIndex == -1)
            {
                return;
            }

            if (Convert.ToString(mainCombo1.SelectedItem) == "همه")
            {
                LoadAllData();
            }
            else
            {
                LoadData();
            }
        }

        #endregion
        //*************************************

        //Methods******************************
        #region

        private void LoadData()
        {
            string id = SqlServerClass.Select(TableNames.BranchCourse, "Id", string.Format("branchName = N'{0}'", mainCombo1.SelectedItem));

            SqlServerClass.ShowQueryInDataGridView(dataGridView1, string.Format("EXEC Get_Group_Condition_BranchId @id = {0}", id));
        }
        private void LoadAllData()
        {
            SqlServerClass.ShowQueryInDataGridView(dataGridView1, "EXEC Get_Group_All");
        }
        private void SetLocations()
        {
            // Y
            Locations.CenterHeight(this, dataGridView1);
            dataGridView1.Top += 15;
            Locations.Up(dataGridView1, 30, true, panel1);
            Locations.Down(dataGridView1, 25, false, btnAdd, btnDelete, btnDetails, btnEdit, btnAddCourse);

            // X
            Locations.CenterWidth(this, dataGridView1, btnAdd);
            Locations.Right(btnAdd, 3, true, btnEdit, btnAddCourse);
            Locations.Left(btnAdd, 3, true, btnDelete, btnDetails);
            Locations.RightOrder(panel1, 1, mainlbl1);
        }

        #endregion
        //*************************************
    }
}
