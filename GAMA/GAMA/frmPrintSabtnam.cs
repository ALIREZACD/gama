using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GAMA
{
    public partial class frmPrintSabtnam : GAMA.FrmMaster
    {
        public frmPrintSabtnam()
        {
            InitializeComponent();
        }

        private void FrmPrintSabtnam_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
    }
}
