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

namespace Do_anLaptrinhWinCK
{
    public partial class frmDangky : Form
    {
        public frmDangky()
        {
            InitializeComponent();
        }

        private void frmDangky_Load(object sender, EventArgs e)
        {
            // Kiểm tra trạng thái tài khoản
            databaseDataContext db = new databaseDataContext();
            string username = txtUsername.Text.Trim();

            if (!string.IsNullOrEmpty(username))
            {
                User user = db.Users.FirstOrDefault(u => u.Username == username);
                if (user != null && user.Active == "Đã khóa")
                {
                    Paneldk.Visible = false;
                    PanelXacthuc.Visible = true;
                    MessageBox.Show("Tài khoản chưa xác thực. Vui lòng nhập mã OTP để kích hoạt tài khoản.", "Thông báo");
                }
                else
                {
                    Paneldk.Visible = true;
                    PanelXacthuc.Visible = false;
                }
            }
            else
            {
                Paneldk.Visible = true;
                PanelXacthuc.Visible = false;
            }
        }

        private void btnminisize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnQuaylai_Click(object sender, EventArgs e)
        {
            this.Close();
            frmMain frmMain = new frmMain();
            frmMain.ShowDialog();
        }

        private void btnDangky_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text == "" || txtUser.Text == "" || txtPass.Text == "" || txtConfimpass.Text == "")
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin", "Thông báo");
                return;
            }
            if (txtPass.Text != txtConfimpass.Text)
            {
                MessageBox.Show("Vui lòng điền chính xác mật khẩu", "Thông báo");
                txtPass.Focus();
                return;
            }

            // Kiểm tra username và email đã tồn tại chưa 
            databaseDataContext db = new databaseDataContext();
            User ExitUser = db.Users.FirstOrDefault(x => x.Username == txtUser.Text || x.Email == txtEmail.Text);
            if (ExitUser != null)
            {
                if (ExitUser.Username == txtUser.Text)
                {
                    MessageBox.Show("Tên tài khoản đã tồn tại. Vui lòng chọn tên khác!", "Thông báo");
                    txtUser.Focus();
                }
                else if (ExitUser.Email == txtEmail.Text)
                {
                    MessageBox.Show("Email này đã được sử dụng. Vui lòng chọn email khác!", "Thông báo");
                    txtEmail.Focus();
                }
                return;
            }

            // Tạo mã otp
            string taikhoan = txtUser.Text;
            string matkhau = txtPass.Text;
            string email = txtEmail.Text;
            Random rd = new Random();
            string otp = rd.Next(1000, 9999).ToString();
            bool Checkotp = false;

            //Mã hóa mật khẩu 
            MD5 md5 = MD5.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes(matkhau + otp);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            // Tạo và thêm dữ liệu đăng ký vào database
            User user = new User();
            user.Username = taikhoan;
            user.Password = hashBytes;
            user.Email = txtEmail.Text;
            user.OTP = otp;
            user.Randomkey = otp;
            user.OTPDatesend = DateTime.Now;
            user.OTPDatecreate = DateTime.Now;
            user.Role = "Người dùng";
            user.Active = "Đã khóa";
            user.DataActive = null;
            db.Users.InsertOnSubmit(user);
            db.SubmitChanges();

            // Gửi email xác thực OTP
            SendMail.sendMailto(user.Email, "Mã OTP xác thực của bạn là: " + user.OTP);

            MessageBox.Show("Đăng ký thành công! Vui lòng kiểm tra email để xác thực tài khoản.", "Thông báo");

            // Hiển thị giao diện xác thực OTP
            Paneldk.Visible = false;
            PanelXacthuc.Visible = true;
        }

        private void btnGuilai_Click(object sender, EventArgs e)
        {
            string _username = txtUsername.Text.Trim();

            if (string.IsNullOrEmpty(_username))
            {
                MessageBox.Show("Vui lòng nhập tên tài khoản để gửi lại mã OTP!", "Thông báo");
                txtUsername.Focus();
                return;
            }

            // Kiểm tra thông tin trong cơ sở dữ liệu
            databaseDataContext db = new databaseDataContext();
            User user = db.Users.FirstOrDefault(u => u.Username == _username);

            if (user != null)
            {
                // Tạo mã OTP mới
                Random rd = new Random();
                string newOtp = rd.Next(1000, 9999).ToString();

                // Cập nhật thông tin OTP trong cơ sở dữ liệu
                user.OTP = newOtp;
                user.OTPDatesend = DateTime.Now;
                db.SubmitChanges();

                // Gửi email với mã OTP mới
                SendMail.sendMailto(user.Email, "Mã OTP mới của bạn là: " + newOtp);
                MessageBox.Show("Mã OTP đã được gửi lại thành công!", "Thông báo");
            }
            else
            {
                MessageBox.Show("Tài khoản không tồn tại. Vui lòng kiểm tra lại!", "Lỗi");
                txtUsername.Focus();
            }
        }

        private void btnXacthuc_Click(object sender, EventArgs e)
        {
            string inputOtp = txtOTP.Text;
            string _username = txtUsername.Text;

            if (txtOTP.Text == "" || txtUsername.Text == "")
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin", "Thông báo");
                return;
            }

            // Kiểm tra thông tin này có trong dữ liệu chưa
            databaseDataContext db = new databaseDataContext();
            User user = db.Users.FirstOrDefault(u => u.Username == txtUsername.Text);
            if (user != null)
            {
                if (user.OTP == inputOtp)
                {
                    if((DateTime.Now - user.OTPDatesend.Value).TotalMinutes <= 5)
                    {
                        user.DataActive = DateTime.Now;
                        user.Active = "Đang hoạt động";
                        db.SubmitChanges();
                        MessageBox.Show("Xác thực thành công!", "Thông báo");

                        // Đóng form xác thực và mở giao diện chính
                        this.Hide();
                        frmMain frmMain = new frmMain();
                        frmMain.ShowDialog();
                        this.Close();
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
                    MessageBox.Show("Mã OTP không đúng, vui lòng nhập lại", "Thông báo");
                    txtOTP.Focus();
                }    
            }
            else
            {
                MessageBox.Show("Thông tin này chưa được đăng ký hoặc đã nhập sai", "Lỗi", MessageBoxButtons.OK);
                txtUsername.Focus();
                return;
            }
        }
    }
}
