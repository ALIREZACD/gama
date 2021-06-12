using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using GAMA;

namespace MyClass
{
    public partial class frmWebcamCapture : FrmMaster
    {
        public frmWebcamCapture()
        {
            InitializeComponent();
        }

        #region Fields

        Image _image;
        VideoCaptureDevice _webcam;
        FilterInfoCollection _webcams;
        private string _error;

        #endregion


        #region Properties

        public Image WebcamCapture
        {
            get
            {
                return _image;
            }
            set
            {
                _image = value;
                picWebcam.Image = value;
            }
        }

        #endregion


        #region Event Implication

        private void FrmWebcamCapture_Load(object sender, EventArgs e)
        {
            _webcams = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            cmbCameras.DataSource = _webcams;
            cmbCameras.DisplayMember = "Name";
            if (cmbCameras.Items.Count > 0)
            cmbCameras.SelectedIndex = 0;
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            if (cmbCameras.Items.Count == 0)
            {
                ShowError("دستگاهی برای ضبط ویدئو موجود نیست");
                return;
            }
            if (_webcam == null || !_webcam.IsRunning)
            {
                picWebcam.Tag = "HadRun";
                _webcam = new VideoCaptureDevice(((FilterInfo)cmbCameras.SelectedItem).MonikerString);
                _webcam.NewFrame += Webcam_NewFrame;
                _webcam.Start();
            }
            else
            {
                _webcam.Stop();
            }
        }

        private void Webcam_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap img = eventArgs.Frame;
            img.RotateFlip(RotateFlipType.Rotate180FlipX);
            picWebcam.Image = new Bitmap(img);
            img.Dispose();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (timer1.Interval != 20)
                timer1.Interval = 20;
            _error = _error.Substring(0, _error.Length - 1);
            lblError.Text = _error;
            if (_error.Length == 0)
                timer1.Stop();
        }

        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (picWebcam.Tag == null)
            {
                ShowError("لطفا از وبکم عکس بگیرید");
                return;
            }
            WebcamCapture = picWebcam.Image;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        #endregion


        #region Functions

        private void ShowError(string error)
        {
            _error = error;
            lblError.Text = _error;
            lblError.Width = lblError.PreferredWidth;
            lblError.Left = this.ClientSize.Width - lblError.Width;
            timer1.Interval = 3000;
            timer1.Start();
        }

        public static bool HasCamera() => new FilterInfoCollection(FilterCategory.VideoInputDevice).Count > 0;

        #endregion
    }
}
