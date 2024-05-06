using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKS
{
    public partial class UserInfo : Form
    {
        public UserInfo()
        {
            InitializeComponent();
        }

        private void confirmBtn_Click(object sender, EventArgs e)
        {
            updateBtn.Visible = true;
            confirmBtn.Visible = false;
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            updateBtn.Visible = false;
            confirmBtn.Visible = true;
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            User u = new User();
            u.Show();
            this.Hide();
        }
    }
}
