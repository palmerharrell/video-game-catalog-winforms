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
    public partial class FormImageDisplay : Form
    {
        public Image? image;
        public FormImageDisplay()
        {
            InitializeComponent();
        }

        private void FormImageDisplay_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = image;
        }
    }
}
