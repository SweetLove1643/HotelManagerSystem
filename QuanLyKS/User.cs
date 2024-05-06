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
    public partial class User : Form
    {
        bool accountCollapse;

        public User()
        {
            InitializeComponent();
        }

        private int Number = 1;

        private void NextImage()
        {
            timer1.Start();
            Number++;
            if (Number > 5)
            {
                Number = 1;
            }
            picturePb.ImageLocation = string.Format(@"C:\Lap trinh tren Windows\HotelManagerSystem\QuanLyKS\Images\" + Number + ".jpg");
            Checked();
        }
        private void PreviousImage()
        {
            timer1.Start();
            Number--;
            if (Number < 1)
            {
                Number = 5;
            }
            picturePb.ImageLocation = string.Format(@"C:\Lap trinh tren Windows\HotelManagerSystem\QuanLyKS\Images\" + Number + ".jpg");
            Checked();
        }
        private void guna2Button8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            NextImage();
        }

        private void previousBtn_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            PreviousImage();
        }

        private void nextBtn_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            NextImage();
        }

        private void Checked()
        {
            if (Number == 1)
            {
                check1.Checked = true;
            }
            else if (Number == 2)
            {
                check2.Checked = true;
            }
            else if (Number == 3)
            {
                check3.Checked = true;
            }
            else if (Number == 4)
            {
                check4.Checked = true;
            }
            else if (Number == 5)
            {
                check5.Checked = true;
            }
        }

        private void ChangedChecked()
        {
            timer1.Start();
            if (check1.Checked == true)
            {
                Number = 1;
            }
            else if (check2.Checked == true)
            {
                Number = 2;
            }
            else if (check3.Checked == true)
            {
                Number = 3;
            }
            else if (check4.Checked == true)
            {
                Number = 4;
            }
            else if (check5.Checked == true)
            {
                Number = 5;
            }
            picturePb.ImageLocation = string.Format(@"C:\Lap trinh tren Windows\HotelManagerSystem\QuanLyKS\Images\" + Number + ".jpg");
        }

        private void User_Load(object sender, EventArgs e)
        {
            picturePb.ImageLocation = string.Format(@"C:\Lap trinh tren Windows\HotelManagerSystem\QuanLyKS\Images\" + Number + ".jpg");
            check1.Checked = true;

            accountTimer.Start();
        }

        private void check5_CheckedChanged(object sender, EventArgs e)
        {
            timer1.Stop();
            ChangedChecked();
        }

        private void accountTimer_Tick(object sender, EventArgs e)
        {
            if (accountCollapse)
            {
                accountContainer.Height += 10;
                if (accountContainer.Height == accountContainer.MaximumSize.Height)
                {
                    accountCollapse = false;
                    accountTimer.Stop();
                }
            }
            else
            {
                accountContainer.Height -= 10;
                if (accountContainer.Height == accountContainer.MinimumSize.Height)
                {
                    accountCollapse = true;
                    accountTimer.Stop();
                }
            }
        }

        private void userBtn_Click(object sender, EventArgs e)
        {
            accountTimer.Start();
        }

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            LogIn login = new LogIn();
            login.Show();
            this.Hide();
        }

        private void bookingBtn_Click(object sender, EventArgs e)
        {
            Booking bk = new Booking();
            bk.Show();
            this.Hide();
        }

        private void accountBtn_Click(object sender, EventArgs e)
        {
            UserInfo ui = new UserInfo();
            ui.Show();
            this.Hide();
        }
    }
}
