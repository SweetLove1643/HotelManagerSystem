using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace QuanLyKS
{
    public partial class Admin : Form
    {
        bool sidebarExpand;
        bool accountCollapse;
        public Admin()
        {
            InitializeComponent();
        }

        

        private void sidebarTimer_Tick(object sender, EventArgs e)
        {
            if(sidebarExpand)
            {
                sidebar.Width -= 10;
                if(sidebar.Width==sidebar.MinimumSize.Width)
                {
                    sidebarExpand = false;
                    sidebarTimer.Stop();
                }
            }
            else
            {
                sidebar.Width += 10;
                if (sidebar.Width == sidebar.MaximumSize.Width)
                {
                    sidebarExpand = true;
                    sidebarTimer.Stop();
                }
            }
        }

        private void adminBtn_Click(object sender, EventArgs e)
        {
            sidebarTimer.Start();
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Admin_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {

        }

        private void accountContainer_Tick(object sender, EventArgs e)
        {
            if(accountCollapse)
            {
                accountContainer.Height += 10;
                blankContainer.Height -= 10;
                if(accountContainer.Height==accountContainer.MaximumSize.Height && blankContainer.Height==blankContainer.MinimumSize.Height)
                {
                    accountCollapse = false;
                    accountTimer.Stop();
                    blankTimer.Stop();
                }
            }
            else
            {
                accountContainer.Height -= 10;
                blankContainer.Height += 10;
                if(accountContainer.Height==accountContainer.MinimumSize.Height && blankContainer.Height==blankContainer.MaximumSize.Height)
                {
                    accountCollapse = true;
                    accountTimer.Stop();
                    blankTimer.Stop();
                }
            }
        }

        private void accountBtn_Click(object sender, EventArgs e)
        {
            accountTimer.Start();
            blankTimer.Start();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            LogIn login = new LogIn();
            login.Show();
            this.Hide();
        }
    }
}
