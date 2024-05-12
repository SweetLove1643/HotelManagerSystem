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
    public partial class Booking : Form
    {
        private string username;
        public string Username { get => username; set => username = value; }
        public Booking()
        {
            InitializeComponent();
        }
        public Booking(string Username)
        {
            InitializeComponent();
            this.Username = Username;
        }


        private void btnBack_Click(object sender, EventArgs e)
        {
            User us = new User(this, Username);
            this.Hide();
            us.ShowDialog();
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
