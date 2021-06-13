
namespace GAMA
{
    partial class FrmStandard
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmStandard));
            this.pnlSearch = new GAMA.PnlSimple();
            this.comboSearch = new GAMA.ComboSimple();
            this.lblSearch = new GAMA.LblSimple();
            this.btnDetails = new GAMA.BtnSimple();
            this.btnDelete = new GAMA.BtnSimple();
            this.btnAdd = new GAMA.BtnSimple();
            this.btnEdit = new GAMA.BtnSimple();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.pnlBranch = new GAMA.PnlSimple();
            this.comboBranch = new GAMA.ComboSimple();
            this.lblBranch = new GAMA.LblSimple();
            this.pnlGroup = new GAMA.PnlSimple();
            this.comboGroup = new GAMA.ComboSimple();
            this.lblGroup = new GAMA.LblSimple();
            this.pnlSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.pnlBranch.SuspendLayout();
            this.pnlGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSearch
            // 
            this.pnlSearch.ColumnIndex = 0;
            this.pnlSearch.Controls.Add(this.comboSearch);
            this.pnlSearch.Controls.Add(this.lblSearch);
            this.pnlSearch.Location = new System.Drawing.Point(177, 50);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.PareName = null;
            this.pnlSearch.RowIndex = 0;
            this.pnlSearch.Size = new System.Drawing.Size(390, 43);
            this.pnlSearch.TabIndex = 16;
            this.pnlSearch.Tag = "search";
            // 
            // comboSearch
            // 
            this.comboSearch.ColumnIndex = 0;
            this.comboSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboSearch.Font = new System.Drawing.Font("B Nazanin", 12F);
            this.comboSearch.FormattingEnabled = true;
            this.comboSearch.Items.AddRange(new object[] {
            "خوشه",
            "گروه",
            "همه"});
            this.comboSearch.Location = new System.Drawing.Point(3, 3);
            this.comboSearch.Name = "comboSearch";
            this.comboSearch.PareName = null;
            this.comboSearch.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.comboSearch.RowIndex = 0;
            this.comboSearch.Size = new System.Drawing.Size(189, 37);
            this.comboSearch.TabIndex = 2;
            this.comboSearch.SelectedIndexChanged += new System.EventHandler(this.ComboSearch_SelectedIndexChanged);
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.ColumnIndex = 0;
            this.lblSearch.Font = new System.Drawing.Font("B Nazanin", 13F);
            this.lblSearch.ForeColor = System.Drawing.Color.Black;
            this.lblSearch.Location = new System.Drawing.Point(224, 3);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.PareName = null;
            this.lblSearch.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblSearch.RowIndex = 0;
            this.lblSearch.Size = new System.Drawing.Size(117, 32);
            this.lblSearch.TabIndex = 1;
            this.lblSearch.Text = "فیلتر بر اساس :";
            // 
            // btnDetails
            // 
            this.btnDetails.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(49)))), ((int)(((byte)(72)))));
            this.btnDetails.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDetails.BackgroundImage")));
            this.btnDetails.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDetails.ColumnIndex = 0;
            this.btnDetails.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDetails.FlatAppearance.BorderSize = 0;
            this.btnDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDetails.Font = new System.Drawing.Font("B Nazanin", 12F);
            this.btnDetails.ForeColor = System.Drawing.Color.White;
            this.btnDetails.IsClicked = false;
            this.btnDetails.Location = new System.Drawing.Point(188, 545);
            this.btnDetails.Name = "btnDetails";
            this.btnDetails.PareName = null;
            this.btnDetails.RowIndex = 0;
            this.btnDetails.Size = new System.Drawing.Size(95, 37);
            this.btnDetails.TabIndex = 15;
            this.btnDetails.Text = "جزِییات";
            this.btnDetails.UseVisualStyleBackColor = true;
            this.btnDetails.Click += new System.EventHandler(this.BtnDetails_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(49)))), ((int)(((byte)(72)))));
            this.btnDelete.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDelete.BackgroundImage")));
            this.btnDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDelete.ColumnIndex = 0;
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("B Nazanin", 12F);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.IsClicked = false;
            this.btnDelete.Location = new System.Drawing.Point(289, 545);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.PareName = null;
            this.btnDelete.RowIndex = 0;
            this.btnDelete.Size = new System.Drawing.Size(95, 37);
            this.btnDelete.TabIndex = 14;
            this.btnDelete.Text = "حذف";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(49)))), ((int)(((byte)(72)))));
            this.btnAdd.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAdd.BackgroundImage")));
            this.btnAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAdd.ColumnIndex = 0;
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("B Nazanin", 12F);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.IsClicked = false;
            this.btnAdd.Location = new System.Drawing.Point(390, 545);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.PareName = null;
            this.btnAdd.RowIndex = 0;
            this.btnAdd.Size = new System.Drawing.Size(95, 37);
            this.btnAdd.TabIndex = 13;
            this.btnAdd.Text = "ثبت";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(49)))), ((int)(((byte)(72)))));
            this.btnEdit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEdit.BackgroundImage")));
            this.btnEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEdit.ColumnIndex = 0;
            this.btnEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEdit.FlatAppearance.BorderSize = 0;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Font = new System.Drawing.Font("B Nazanin", 12F);
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.IsClicked = false;
            this.btnEdit.Location = new System.Drawing.Point(491, 545);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.PareName = null;
            this.btnEdit.RowIndex = 0;
            this.btnEdit.Size = new System.Drawing.Size(95, 37);
            this.btnEdit.TabIndex = 12;
            this.btnEdit.Text = "ویرایش";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.BtnEdit_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(27, 177);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(691, 338);
            this.dataGridView1.TabIndex = 11;
            this.dataGridView1.DataSourceChanged += new System.EventHandler(this.DataGridView1_DataSourceChanged);
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.DataGridView1_SelectionChanged);
            // 
            // pnlBranch
            // 
            this.pnlBranch.ColumnIndex = 0;
            this.pnlBranch.Controls.Add(this.comboBranch);
            this.pnlBranch.Controls.Add(this.lblBranch);
            this.pnlBranch.Location = new System.Drawing.Point(174, 113);
            this.pnlBranch.Name = "pnlBranch";
            this.pnlBranch.PareName = null;
            this.pnlBranch.RowIndex = 0;
            this.pnlBranch.Size = new System.Drawing.Size(390, 43);
            this.pnlBranch.TabIndex = 17;
            this.pnlBranch.Tag = "خوشه";
            // 
            // comboBranch
            // 
            this.comboBranch.ColumnIndex = 0;
            this.comboBranch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBranch.Font = new System.Drawing.Font("B Nazanin", 12F);
            this.comboBranch.FormattingEnabled = true;
            this.comboBranch.Location = new System.Drawing.Point(3, 3);
            this.comboBranch.Name = "comboBranch";
            this.comboBranch.PareName = null;
            this.comboBranch.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.comboBranch.RowIndex = 0;
            this.comboBranch.Size = new System.Drawing.Size(189, 37);
            this.comboBranch.TabIndex = 2;
            this.comboBranch.SelectedIndexChanged += new System.EventHandler(this.Comboes_SelectedIndexChanged);
            // 
            // lblBranch
            // 
            this.lblBranch.AutoSize = true;
            this.lblBranch.ColumnIndex = 0;
            this.lblBranch.Font = new System.Drawing.Font("B Nazanin", 13F);
            this.lblBranch.ForeColor = System.Drawing.Color.Black;
            this.lblBranch.Location = new System.Drawing.Point(282, 3);
            this.lblBranch.Name = "lblBranch";
            this.lblBranch.PareName = null;
            this.lblBranch.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblBranch.RowIndex = 0;
            this.lblBranch.Size = new System.Drawing.Size(86, 32);
            this.lblBranch.TabIndex = 1;
            this.lblBranch.Text = "نام خوشه :";
            // 
            // pnlGroup
            // 
            this.pnlGroup.ColumnIndex = 0;
            this.pnlGroup.Controls.Add(this.comboGroup);
            this.pnlGroup.Controls.Add(this.lblGroup);
            this.pnlGroup.Location = new System.Drawing.Point(174, 113);
            this.pnlGroup.Name = "pnlGroup";
            this.pnlGroup.PareName = null;
            this.pnlGroup.RowIndex = 0;
            this.pnlGroup.Size = new System.Drawing.Size(390, 43);
            this.pnlGroup.TabIndex = 18;
            this.pnlGroup.Tag = "گروه";
            // 
            // comboGroup
            // 
            this.comboGroup.ColumnIndex = 0;
            this.comboGroup.DropDownHeight = 200;
            this.comboGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboGroup.Font = new System.Drawing.Font("B Nazanin", 12F);
            this.comboGroup.FormattingEnabled = true;
            this.comboGroup.IntegralHeight = false;
            this.comboGroup.Location = new System.Drawing.Point(3, 3);
            this.comboGroup.Name = "comboGroup";
            this.comboGroup.PareName = null;
            this.comboGroup.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.comboGroup.RowIndex = 0;
            this.comboGroup.Size = new System.Drawing.Size(189, 37);
            this.comboGroup.TabIndex = 2;
            this.comboGroup.SelectedIndexChanged += new System.EventHandler(this.Comboes_SelectedIndexChanged);
            // 
            // lblGroup
            // 
            this.lblGroup.AutoSize = true;
            this.lblGroup.ColumnIndex = 0;
            this.lblGroup.Font = new System.Drawing.Font("B Nazanin", 13F);
            this.lblGroup.ForeColor = System.Drawing.Color.Black;
            this.lblGroup.Location = new System.Drawing.Point(282, 3);
            this.lblGroup.Name = "lblGroup";
            this.lblGroup.PareName = null;
            this.lblGroup.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblGroup.RowIndex = 0;
            this.lblGroup.Size = new System.Drawing.Size(77, 32);
            this.lblGroup.TabIndex = 1;
            this.lblGroup.Text = "نام گروه :";
            // 
            // FrmStandard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.ClientSize = new System.Drawing.Size(745, 613);
            this.Controls.Add(this.pnlSearch);
            this.Controls.Add(this.btnDetails);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.pnlGroup);
            this.Controls.Add(this.pnlBranch);
            this.HasBorder = true;
            this.HasHeader = true;
            this.HeaderforeColor = System.Drawing.Color.White;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "FrmStandard";
            this.Text = "استاندارد";
            this.Load += new System.EventHandler(this.FrmStandard_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FrmStandard_Paint);
            this.Controls.SetChildIndex(this.pnlBranch, 0);
            this.Controls.SetChildIndex(this.pnlGroup, 0);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            this.Controls.SetChildIndex(this.btnEdit, 0);
            this.Controls.SetChildIndex(this.btnAdd, 0);
            this.Controls.SetChildIndex(this.btnDelete, 0);
            this.Controls.SetChildIndex(this.btnDetails, 0);
            this.Controls.SetChildIndex(this.pnlSearch, 0);
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.pnlBranch.ResumeLayout(false);
            this.pnlBranch.PerformLayout();
            this.pnlGroup.ResumeLayout(false);
            this.pnlGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private PnlSimple pnlSearch;
        private ComboSimple comboSearch;
        private LblSimple lblSearch;
        private BtnSimple btnDetails;
        private BtnSimple btnDelete;
        private BtnSimple btnAdd;
        private BtnSimple btnEdit;
        private System.Windows.Forms.DataGridView dataGridView1;
        private PnlSimple pnlBranch;
        private ComboSimple comboBranch;
        private LblSimple lblBranch;
        private PnlSimple pnlGroup;
        private ComboSimple comboGroup;
        private LblSimple lblGroup;
    }
}