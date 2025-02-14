﻿using System;
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
    public partial class FrmAddEditCourse : FrmMaster
    {
        public FrmAddEditCourse(Moods m)
        {
            InitializeComponent();
            mood = m;
        }

        //Variables****************************
        #region

        private string id;
        private readonly Moods mood;
        private DataGridViewRow row = null;
        private readonly string table = TableNames.Course;

        #endregion
        //*************************************

        //Events*******************************
        #region 

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (ControlManager.CheckEmptyControls(panel1))
            {
                return;
            }

            string time = DateTimeManager.GetTime(DateTime.Now).Substring(0, 5);
            string idGroup = SqlServerClass.Select(TableNames.GroupCourse, "Id", string.Format("groupName = N'{0}'", comboGroupName.SelectedItem));

            string[] fields = {
                "IdGroup",
                "CourseName",
                "OldCode",
                "NewCode",
                "TypeCourse",
                //"TypeKaroDanesh",
                "PreCourse",
                "CourseGrade",
                "CourseLatin",
                "NazariHour",
                "AmaliHour",
                "KarvarziHour",
                "ProjectHour",
                "Description",
                "InsertDate",
                "InsertTime",
                "UserId" };
            string[] values = {
                idGroup,
                txtName.Text,
                txtOldCode.Text,
                txtNewCode.Text,
                txtTypeCourse.Text,
                //txtTypeKaroDanesh.Text,
                txtPreCourse.Text,
                txtCourseGrade.Text,
                txtCourseLatin.Text,
                txtNazariHour.Text,
                txtAmaliHour.Text,
                txtKarvarziHour.Text,
                txtProjectHour.Text,
                txtDescription.Text,
                StaticData.current_date,
                time,
                Convert.ToString(StaticData.current_user.Id) };

            switch (mood)
            {
                case Moods.Add:
                    if (SqlServerClass.RowExists(table, string.Format("CourseName = N'{0}'", txtName.Text)))
                    {
                        MessageBox.Show("دوره ای با همین نام ثبت شده است");
                        return;

                    }

                    if (SqlServerClass.InsertWithFields(table, fields[0], values[0], fields[1], values[1], fields[2], values[2], fields[3], values[3], fields[4], values[4], fields[5], values[5], fields[6], values[6], fields[7], values[7], fields[8], values[8], fields[9], values[9], fields[10], values[10], fields[11], values[11], fields[12], values[12], fields[13], values[13], fields[14], values[14], fields[15], values[15], fields[16], values[16]))
                    {
                        MessageBox.Show("درج شد");
                        Close();
                    }
                    break;
                case Moods.Edit:
                    if (SqlServerClass.Update(table, fields, values, string.Format("Id = {0}", id)))
                    {
                        MessageBox.Show("ویرایش شد");
                        Close();
                    }
                    break;
                default:
                    break;
            }
        }
        private void FrmAddEditCourse_Load(object sender, EventArgs e)
        {
            string headerText = string.Empty;
            ControlManager.SetComboItems(comboGroupName, SqlCaptureManager.AllGroups());
            txtId.ReadOnly = true;

            switch (mood)
            {
                case Moods.Add:
                    headerText = "اضافه کردن";
                    btnAdd.Text = "ثبت";
                    FindId();
                    FindGroup();
                    break;
                case Moods.Edit:
                    headerText = "ویرایش";
                    btnAdd.Text = "ویرایش";
                    row = FrmStandard.selected_row;
                    LoadData();
                    break;
                default:
                    break;
            }

            Text = string.Format("{0} دوره", headerText);
            SetLocations();
        }
        private void FrmAddEditCourse_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphic = e.Graphics;

            graphic.DrawLine(Theme.Pen1,
                panel1.Left + 20,
                btnAdd.Top - 10,
                panel1.Right - 20,
                btnAdd.Top - 10);
        }

        #endregion
        //*************************************

        //Methods******************************
        #region 

        private void FindId()
        {
            txtId.Text = Convert.ToString(SqlServerClass.RowCount(table, "Id") + 1);
        }
        private void LoadData()
        {
            if (row == null)
            {
                return;
            }

            ControlManager.LoadValues(row, panel1);

            id = Convert.ToString(row.Cells["id"].Value);
        }
        private void FindGroup()
        {
            if (FrmGroup.selected_row == null)
            {
                return;
            }

            comboGroupName.SelectedItem = FrmGroup.selected_row.Cells["نام گروه"].Value;
        }
        private void SetLocations()
        {
            panel1.Designer.SetSize();
            panel1.Height += 20;
            panel1.Designer.SetLocation();
            txtDescription.Height = txtKarvarziHour.Bottom - txtAmaliHour.Top;

            // Y
            panel1.Top = HeaderHeight + 15;
            btnAdd.Top = panel1.Bottom + 20;
            mainlbl9.Top = mainlbl8.Top;

            // X
            Locations.CenterWidth(this, panel1, btnAdd);
        }

        #endregion
        //*************************************
    }
}
