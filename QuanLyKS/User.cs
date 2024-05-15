using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace QuanLyKS
{
    public partial class User : Form
    {
        bool accountCollapse;
        private string username;
        private Booking bF;
        public string Username { get => username; set => username = value; }
        public Booking BF { get => bF; set => bF = value; }

        public User()
        {
            InitializeComponent();
        }
        public User(string Username)
        {
            InitializeComponent();
            this.Username = Username;
        }
        public User(Booking bk, string Username)
        {
            InitializeComponent();
            BF = bk;
            this.Username = Username;
        }


        private int Number = 1;
        private void NextImage()
        {
            try
            {
                timer1.Start();
                Number++;
                if (Number > 5)
                {
                    Number = 1;
                }
                picturePb.ImageLocation = string.Format(@"C:\Users\Admin\Documents\Visual studio\LapTrinhWindowns\ProjectHotelManagerSystem\QuanLyKS\Images\" + Number + ".jpg");
                Checked();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void PreviousImage()
        {
            try
            {
                timer1.Start();
                Number--;
                if (Number < 1)
                {
                    Number = 5;
                }
                picturePb.ImageLocation = string.Format(@"C:\Users\Admin\Documents\Visual studio\LapTrinhWindowns\ProjectHotelManagerSystem\QuanLyKS\Images\" + Number + ".jpg");
                Checked();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
            try
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ChangedChecked()
        {
            try
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
                picturePb.ImageLocation = string.Format(@"C:\Users\Admin\Documents\Visual studio\LapTrinhWindowns\ProjectHotelManagerSystem\QuanLyKS\Images\" + Number + ".jpg");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void User_Load(object sender, EventArgs e)
        {
            try
            {
                picturePb.ImageLocation = string.Format(@"C:\Users\Admin\Documents\Visual studio\LapTrinhWindowns\ProjectHotelManagerSystem\QuanLyKS\Images\" + Number + ".jpg");
                check1.Checked = true;

                accountTimer.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void check5_CheckedChanged(object sender, EventArgs e)
        {
            timer1.Stop();
            ChangedChecked();
        }

        private void accountTimer_Tick(object sender, EventArgs e)
        {
            try
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
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message);
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
            try
            {
                if (BF != null)
                {
                    this.Hide();
                    BF.Show();
                }
                else
                {
                    Booking bk = new Booking();
                    this.Hide();
                    bk.ShowDialog();
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void accountBtn_Click(object sender, EventArgs e)
        {
            btnconfirm ui = new btnconfirm(Username);
            this.Hide();
            ui.ShowDialog();
        }
    }
}
