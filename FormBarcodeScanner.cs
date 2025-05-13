using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VideoGameCollection_WinForms
{
    public partial class FormBarcodeScanner : Form
    {
        public FormBarcodeScanner()
        {
            InitializeComponent();
        }

        private void btnStopScanning_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
