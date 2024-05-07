using QuanLyKS.Resources;
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
    public partial class Employee : Form
    {
        bool sidebarExpand;
        public Employee()
        {
            InitializeComponent();
        }

        private void sidebarTimer_Tick(object sender, EventArgs e)
        {
            if (sidebarExpand)
            {
                sidebar.Width -= 10;
                if (sidebar.Width == sidebar.MinimumSize.Width)
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

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            LogIn login = new LogIn();
            login.Show();
            this.Hide();
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Employee_Load(object sender, EventArgs e)
        {
            sidebarTimer.Start();
        }

        private void btnCheckIn_Click(object sender, EventArgs e)
        {

            sidebarTimer.Start();
            Check_inUC ch_uc = new Check_inUC();
            AddUserControl(ch_uc);

        }
        private void AddUserControl(UserControl uc)
        {
            uc.Dock = DockStyle.Fill;
            PanelContainer.Controls.Clear();
            PanelContainer.Controls.Add(uc);
            uc.BringToFront();
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            sidebarTimer.Start();

            PaymentUC pa_uc = new PaymentUC();
            AddUserControl(pa_uc);
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            sidebarTimer.Start();
            EmployeeInfoUC em_uc = new EmployeeInfoUC();
            AddUserControl(em_uc);
        }
    }
}
