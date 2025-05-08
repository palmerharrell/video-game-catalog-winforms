using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VideoGameCollection_WinForms.Repositories;

namespace VideoGameCollection_WinForms
{
    public partial class FormServerSelect : Form
    {
        public FormServerSelect()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            setServerLocation();
            Close();
        }

        private void setServerLocation()
        {
            if (rdbtnNetwork.Checked)
            {
                SqlRepository.server = SqlRepository.ServerLocation.Network;
            }
            else
            {
                SqlRepository.server = SqlRepository.ServerLocation.Local;
            }
        }
    }
}
