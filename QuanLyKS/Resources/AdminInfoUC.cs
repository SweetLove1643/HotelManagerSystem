using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKS.Resources
{
    public partial class AdminInfoUC : UserControl
    {
        public AdminInfoUC()
        {
            InitializeComponent();
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            updateBtn.Visible = false;
            confirmBtn.Visible = true;
        }

        private void confirmBtn_Click(object sender, EventArgs e)
        {
            updateBtn.Visible = true;
            confirmBtn.Visible = false;
        }
    }
}
