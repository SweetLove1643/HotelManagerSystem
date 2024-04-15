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

            mEp = new ErrorProvider();
        }

        private void continueBtn_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(mailTb.Text))
            {
                mEp.SetError(mailTb, "Please enter your mail!");
            }
            else
            {
                var title = "This is a title";
                var body ="Ro22ty như cc";
                SendMail(title, body);
                Vertification vc = new Vertification(this);
                vc.Show();
                this.Hide();
            }
        }

        private void SendMail(string title, string body)
        {
            try
            {
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();

                message.From = new MailAddress("Hotel.HL.BB@gmail.com");
                message.To.Add(new MailAddress(mailTb.Text));
                message.Subject = title;
                message.Body = body;

                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("Hotel.HL.BB@gmail.com", "ucfocygvvxbawius");
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("err: " + ex.Message);
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
