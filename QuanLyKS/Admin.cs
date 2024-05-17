using QuanLyKS.Resources;
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
        private string username;
        public string Username { get => username; set => username = value; }

        AccountUC ac_uc = new AccountUC();
        EmployeeUC em_uc = new EmployeeUC();
        InvoiceUC in_uc = new InvoiceUC();
        CustomerUC cu_uc = new CustomerUC();
        RoomUC ro_uc = new RoomUC();
        AdminInfoUC adinfo_uc = new AdminInfoUC();


        public Admin()
        {
            InitializeComponent();
        }
        public Admin(string Username)
        {
            InitializeComponent();
            this.Username = Username;
        }

        private void AddUserControl(UserControl uc)
        {
            try
            {
                uc.Dock = DockStyle.Fill;
                panelContainer.Controls.Clear();
                panelContainer.Controls.Add(uc);
                uc.BringToFront();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            sidebarTimer.Start();

            accountTimer.Start();
            blankTimer.Start();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {

        }

        private void accountContainer_Tick(object sender, EventArgs e)
        {
            if (accountCollapse)
            {
                accountContainer.Height += 10;
                blankContainer.Height -= 10;
                if (accountContainer.Height == accountContainer.MaximumSize.Height && blankContainer.Height == blankContainer.MinimumSize.Height)
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
                if (accountContainer.Height == accountContainer.MinimumSize.Height && blankContainer.Height == blankContainer.MaximumSize.Height)
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

            /*AddUserControl(ac_uc);
            ac_uc.LoadFormAccount();*/
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            LogIn login = new LogIn();
            this.Hide();
            login.ShowDialog();
        }

        private void employeeBtn_Click(object sender, EventArgs e)
        {
            sidebarTimer.Start();

            AddUserControl(em_uc);
            em_uc.LoadFormEmployyes();
        }

        private void customerBtn_Click(object sender, EventArgs e)
        {
            sidebarTimer.Start();

            AddUserControl(cu_uc);
            cu_uc.LoadFormCustomer();
        }

        private void InvoiceBtn_Click(object sender, EventArgs e)
        {
            sidebarTimer.Start();

            AddUserControl(in_uc);
            in_uc.LoadFormInvoice();
        }

        private void roomBtn_Click(object sender, EventArgs e)
        {
            sidebarTimer.Start();

            AddUserControl(ro_uc);
            ro_uc.LoadFormRoom();
        }
        private void btnProperties_Click(object sender, EventArgs e)
        {
            sidebarTimer.Start();

            adinfo_uc.Username = this.Username;
            AddUserControl(adinfo_uc);
            adinfo_uc.LoadFormProperties();
        }
        private void allAccBtn_Click(object sender, EventArgs e)
        {
            sidebarTimer.Start();
            accountTimer.Start();
            blankTimer.Start();

            AddUserControl(ac_uc);
            ac_uc.LoadFormAccount();
        }

        private void employeeAccBtn_Click(object sender, EventArgs e)
        {
            sidebarTimer.Start();
            accountTimer.Start();
            blankTimer.Start();
            AddUserControl(ac_uc);
            ac_uc.FillEmployyes();
        }

        private void customerAccBtn_Click(object sender, EventArgs e)
        {
            sidebarTimer.Start();
            accountTimer.Start();
            blankTimer.Start();
            AddUserControl(ac_uc);
            ac_uc.FillCustomer();
        }
    }
}
