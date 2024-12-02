using Do_anLaptrinhWinCK.All_Customer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Do_anLaptrinhWinCK
{
    public partial class frmConfirm : Form
    {
        public frmConfirm()
        {
            InitializeComponent();
        }

        private void btnminisize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }


        private void btnXacnhan_Click(object sender, EventArgs e)
        {
            string name = txtUser.Text;
            string email = txtEmail.Text;
            databaseDataContext db = new databaseDataContext();
            User u = db.Users.FirstOrDefault(x => x.Username == txtUser.Text && x.Email == txtEmail.Text);
            if (u != null)
            {
                PanelInfor.Enabled = true;
                PanelOtp.Visible = true;

                Random rd = new Random();
                string newOtp = rd.Next(1000, 9999).ToString();

                u.OTP = newOtp;
                u.OTPDatesend = DateTime.Now;
                db.SubmitChanges();
                MessageBox.Show("Vui lòng nhập mã OTP vừa mới gửi", "Thông báo", MessageBoxButtons.OK);
            } 
            else
            {
                MessageBox.Show("Tài khoản không tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUser.Focus();
            }    
        }

        private void frmConfirm_Load(object sender, EventArgs e)
        {
            PanelOtp.Visible = false;
            PanelMk.Visible = false;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuilai_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            databaseDataContext db = new databaseDataContext();
            User user = db.Users.FirstOrDefault(u => u.Email == email);
            // Tạo mã OTP mới
            Random rd = new Random();
            string newOtp = rd.Next(1000, 9999).ToString();

            user.OTP = newOtp;
            user.OTPDatesend = DateTime.Now;
            db.SubmitChanges();

            // Gửi email với mã OTP mới
            SendMail.sendMailto(user.Email, "Mã OTP mới của bạn là: " + newOtp);
            MessageBox.Show("Mã OTP đã được gửi lại thành công!", "Thông báo");
        }

        private void btnXacnhan2_Click(object sender, EventArgs e)
        {
            string otp = txtOTP.Text;
            databaseDataContext db = new databaseDataContext();
            User user = db.Users.FirstOrDefault(u => u.OTP == otp);
            if(user != null)
            {
                if ((DateTime.Now - user.OTPDatesend.Value).TotalMinutes <= 5)
                {
                    PanelMk.Visible = true;
                    PanelOtp.Enabled = true;
                    MessageBox.Show("Nhập mã OTP thành công, vui lòng cập nhật lại mật khẩu", "Thông báo", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("Mã OTP đã hết hiệu lực!, vui lòng nhập mã OTP mới", "Thông báo");
                    txtOTP.Focus();
                    btnGuilai_Click(sender, e);
                }    
            }    
            else
            {
                MessageBox.Show("Mã OTP không hợp lệ, vui lòng nhập lại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtOTP.Focus();
            }    
        }

        private void btnXacnhan3_Click(object sender, EventArgs e)
        {
            string pass1 = txtMk.Text;
            string pass2 = txtMk2.Text;
            string name = txtUser.Text;
            string email = txtEmail.Text;
            string otp = txtOTP.Text;
            if (pass1 == pass2)
            {
                databaseDataContext db = new databaseDataContext();
                User u = db.Users.FirstOrDefault(x => x.Username == txtUser.Text && x.Email == txtEmail.Text);

                MD5 md5 = MD5.Create();
                byte[] inputBytes = Encoding.ASCII.GetBytes(pass1 + u.Randomkey);
                byte[] hashBytes = md5.ComputeHash(inputBytes);
                u.Password = hashBytes;
                db.SubmitChanges();
                MessageBox.Show("Cập nhật mật khẩu thành công", "Thông báo", MessageBoxButtons.OK);
                this.Close();
            }
            else
            {
                MessageBox.Show("Cập nhật mật khẩu thành công", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMk.Focus();
            }    
        }
    }
}
