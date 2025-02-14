﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyClass;
using System.Globalization;

namespace GAMA
{
    public partial class FrmAddEditBranch : FrmMaster
    {
        public FrmAddEditBranch(Moods m)
        {
            InitializeComponent();
            mood = m;
        }

        //Variables****************************
        #region

        private string id;
        private readonly Moods mood;
        private DataGridViewRow row = null;
        private readonly string table = TableNames.BranchCourse;

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

            string[] fields = { "branchName", "InsertDate", "InsertTime", "UserId" };
            string[] values = { txtName.Text, StaticData.current_date, time, Convert.ToString(StaticData.current_user.Id) };

            switch (mood)
            {
                case Moods.Add:
                    if (SqlServerClass.RowExists(table, string.Format("branchname = N'{0}'", txtName.Text)))
                    {
                        MessageBox.Show("خوشه ای با همین نام ثبت شده است");
                        return;
                    }

                    if (SqlServerClass.InsertWithFields(table, fields[0], values[0], fields[1], values[1], fields[2], values[2], fields[3], values[3]))
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
        private void FrmAddEditBranch_Load(object sender, EventArgs e)
        {
            string headerText = string.Empty;
            txtId.ReadOnly = true;

            switch (mood)
            {
                case Moods.Add:
                    headerText = "اضافه کردن";
                    btnAdd.Text = "ثبت";
                    FindId();
                    break;
                case Moods.Edit:
                    headerText = "ویرایش";
                    btnAdd.Text = "ویرایش";
                    row = FrmBranch.selected_row;
                    LoadData();
                    break;
                default:
                    break;
            }

            Text = string.Format("{0} خوشه", headerText);
            SetLocations();
        }
        private void FrmAddEditBranch_Paint(object sender, PaintEventArgs e)
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
        private void SetLocations()
        {
            panel1.Designer.SetSize();
            panel1.Designer.SetLocation();

            // Y
            panel1.Top = HeaderHeight + 15;
            btnAdd.Top = panel1.Bottom + 20;

            // x
            Locations.CenterWidth(this, panel1, btnAdd);
        }

        #endregion
        //*************************************
    }
}
