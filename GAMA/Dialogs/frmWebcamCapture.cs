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
        VideoCaptureDevice _device;
        FilterInfoCollection _filters;

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
            _filters = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            cmbCameras.DataSource = _filters;
            cmbCameras.DisplayMember = "Name";
            if (cmbCameras.Items.Count > 0)
                cmbCameras.SelectedIndex = 0;
        }

        private void Webcam_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            using (Bitmap bitmap = new Bitmap(eventArgs.Frame, picWebcam.ClientSize))
                picWebcam.Image = new Bitmap(bitmap);
            eventArgs.Frame.Dispose();
            GC.Collect();
        }

        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (picWebcam.Tag == null)
            {
                FarsiMessageBox.Show("لطفا از وبکم عکس بگیرید");
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

        private void FrmWebcamCapture_FormClosed(object sender, FormClosedEventArgs e)
        {
            _device?.Stop();
        }

        private void CmbCameras_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCameras.Items.Count == 0)
            {
                FarsiMessageBox.Show("دستگاهی برای ضبط ویدئو موجود نیست");
                return;
            }
            _device = new VideoCaptureDevice(_filters[cmbCameras.SelectedIndex].MonikerString);
            _device.NewFrame += Webcam_NewFrame;
            _device.Start();
        }

        #endregion


        #region Functions

        public static bool HasCamera() => new FilterInfoCollection(FilterCategory.VideoInputDevice).Count > 0;

        #endregion
    }
}
