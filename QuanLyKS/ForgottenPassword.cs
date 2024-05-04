using QuanLyKS.ClassFuncion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKS
{
    public partial class ForgottenPassword : Form
    {
        private LogIn lnF;


        public ForgottenPassword(LogIn ln)
        {
            InitializeComponent();
            lnF = ln;
        }

        private void continueBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txbMail.Text)) // kiểm tra txb rỗng
                {
                    mPb.Visible = true;
                    invalidInfoTT.SetToolTip(mPb, "Please enter your mail!");
                }
                else
                {
                    mPb.Visible = false;
                    if (IsValidEmail(txbMail.Text)) // Kiểm tra định dạng email người dùng nhập
                    {
                        if (DataProvider.Instance.ExecuteNonQuerry("EXEC SeachEmail @Email ", new object[] { txbMail.Text }) != 0)// email tồn tại trong db thì...
                        {
                            var title = "Mã xác nhận OTP";
                            var body = "Mã xác nhận OTP của bạn là";
                            SendMail(title, body);
                            Vertification vc = new Vertification(this);
                            vc.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Email này chưa liên kết với bất kì tài khoản", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Email chưa đúng định dạng", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }

            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void SendMail(string title, string body)
        {
            try
            {
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();

                message.From = new MailAddress("Hotel.HL.BB@gmail.com");
                message.To.Add(new MailAddress(txbMail.Text));
                message.Subject = title;
                message.Body = body;

                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("Hotel.HL.BB@gmail.com", "ucfocygvvxbawius");
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);
                MessageBox.Show("OTP đã được gửi qua mail", "Messages", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show("err: " + ex.Message);
            }
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                MailAddress mailAddress = new MailAddress(email);
                return true;
            }
            catch (FormatException ex)
            {
                return false;
            }
        }
        private void backBtn_Click(object sender, EventArgs e)
        {
            lnF.Show();
            this.Hide();
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
