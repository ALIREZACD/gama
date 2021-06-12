namespace MyClass
{
    partial class frmWebcamCapture
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
            this.components = new System.ComponentModel.Container();
            this.lblError = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.picWebcam = new GAMA.PctrBSimple();
            this.cmbCameras = new GAMA.ComboSimple();
            this.btnStart = new GAMA.BtnSimple();
            this.btnSubmit = new GAMA.BtnSimple();
            this.btnCancel = new GAMA.BtnSimple();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblSimple1 = new GAMA.LblSimple();
            ((System.ComponentModel.ISupportInitialize)(this.picWebcam)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblError
            // 
            this.lblError.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblError.AutoSize = true;
            this.lblError.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(535, 391);
            this.lblError.Name = "lblError";
            this.lblError.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblError.Size = new System.Drawing.Size(0, 19);
            this.lblError.TabIndex = 7;
            // 
            // timer1
            // 
            this.timer1.Interval = 2000;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // picWebcam
            // 
            this.picWebcam.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picWebcam.ColumnIndex = 0;
            this.picWebcam.Image = global::GAMA.Properties.Resources.Webcam;
            this.picWebcam.Location = new System.Drawing.Point(0, 64);
            this.picWebcam.Name = "picWebcam";
            this.picWebcam.PareName = null;
            this.picWebcam.RowIndex = 0;
            this.picWebcam.Size = new System.Drawing.Size(543, 324);
            this.picWebcam.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picWebcam.TabIndex = 8;
            this.picWebcam.TabStop = false;
            // 
            // cmbCameras
            // 
            this.cmbCameras.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbCameras.ColumnIndex = 0;
            this.cmbCameras.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCameras.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cmbCameras.FormattingEnabled = true;
            this.cmbCameras.Location = new System.Drawing.Point(220, 32);
            this.cmbCameras.Name = "cmbCameras";
            this.cmbCameras.PareName = null;
            this.cmbCameras.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbCameras.RowIndex = 0;
            this.cmbCameras.Size = new System.Drawing.Size(168, 28);
            this.cmbCameras.TabIndex = 9;
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.btnStart.BackgroundColor = System.Drawing.Color.White;
            this.btnStart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnStart.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnStart.BorderRadius = 10;
            this.btnStart.BorderSize = 0;
            this.btnStart.ColumnIndex = 0;
            this.btnStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStart.FlatAppearance.BorderSize = 0;
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.ForeColor = System.Drawing.Color.White;
            this.btnStart.IsClicked = false;
            this.btnStart.Location = new System.Drawing.Point(469, 3);
            this.btnStart.Name = "btnStart";
            this.btnStart.PareName = null;
            this.btnStart.RowIndex = 0;
            this.btnStart.Size = new System.Drawing.Size(71, 32);
            this.btnStart.TabIndex = 10;
            this.btnStart.Text = "شروع";
            this.btnStart.TextColor = System.Drawing.Color.White;
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.btnSubmit.BackgroundColor = System.Drawing.Color.White;
            this.btnSubmit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSubmit.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnSubmit.BorderRadius = 10;
            this.btnSubmit.BorderSize = 0;
            this.btnSubmit.ColumnIndex = 0;
            this.btnSubmit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSubmit.FlatAppearance.BorderSize = 0;
            this.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmit.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.ForeColor = System.Drawing.Color.White;
            this.btnSubmit.IsClicked = false;
            this.btnSubmit.Location = new System.Drawing.Point(403, 3);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.PareName = null;
            this.btnSubmit.RowIndex = 0;
            this.btnSubmit.Size = new System.Drawing.Size(60, 32);
            this.btnSubmit.TabIndex = 11;
            this.btnSubmit.Text = "ثبت";
            this.btnSubmit.TextColor = System.Drawing.Color.White;
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.BtnSubmit_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.btnCancel.BackgroundColor = System.Drawing.Color.White;
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCancel.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnCancel.BorderRadius = 10;
            this.btnCancel.BorderSize = 0;
            this.btnCancel.ColumnIndex = 0;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.IsClicked = false;
            this.btnCancel.Location = new System.Drawing.Point(329, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.PareName = null;
            this.btnCancel.RowIndex = 0;
            this.btnCancel.Size = new System.Drawing.Size(68, 32);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "انصراف";
            this.btnCancel.TextColor = System.Drawing.Color.White;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnStart);
            this.flowLayoutPanel1.Controls.Add(this.btnSubmit);
            this.flowLayoutPanel1.Controls.Add(this.btnCancel);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 413);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(543, 40);
            this.flowLayoutPanel1.TabIndex = 13;
            // 
            // lblSimple1
            // 
            this.lblSimple1.AutoSize = true;
            this.lblSimple1.ColumnIndex = 0;
            this.lblSimple1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSimple1.ForeColor = System.Drawing.Color.Black;
            this.lblSimple1.Location = new System.Drawing.Point(394, 36);
            this.lblSimple1.Name = "lblSimple1";
            this.lblSimple1.PareName = null;
            this.lblSimple1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblSimple1.RowIndex = 0;
            this.lblSimple1.Size = new System.Drawing.Size(147, 19);
            this.lblSimple1.TabIndex = 14;
            this.lblSimple1.Text = "یک دوربین را انتخاب کنید";
            // 
            // frmWebcamCapture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(543, 453);
            this.Controls.Add(this.lblSimple1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.cmbCameras);
            this.Controls.Add(this.picWebcam);
            this.Controls.Add(this.lblError);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmWebcamCapture";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "دوربین";
            this.Load += new System.EventHandler(this.FrmWebcamCapture_Load);
            this.Controls.SetChildIndex(this.lblError, 0);
            this.Controls.SetChildIndex(this.picWebcam, 0);
            this.Controls.SetChildIndex(this.cmbCameras, 0);
            this.Controls.SetChildIndex(this.flowLayoutPanel1, 0);
            this.Controls.SetChildIndex(this.lblSimple1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.picWebcam)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Timer timer1;
        private GAMA.PctrBSimple picWebcam;
        private GAMA.ComboSimple cmbCameras;
        private GAMA.BtnSimple btnStart;
        private GAMA.BtnSimple btnSubmit;
        private GAMA.BtnSimple btnCancel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private GAMA.LblSimple lblSimple1;
    }
}