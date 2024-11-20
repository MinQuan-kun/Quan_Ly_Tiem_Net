using Do_anLaptrinhWinCK;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace health_management
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void frmLogin_Load(object sender, EventArgs e)
        {
            SetRoundedCorners(30);
        }

        private void SetRoundedCorners(int radius)
        {
            radius = Math.Min(radius, Math.Min(this.Width / 2, this.Height / 2));

            var path = new GraphicsPath();
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(this.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(this.Width - radius, this.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, this.Height - radius, radius, radius, 90, 90);
            path.CloseAllFigures();

            this.Region = new Region(path);
        }
        private Point mouseOffset;
        private bool isMouseDown = false;

        private void frmLogin_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseOffset = new Point(-e.X, -e.Y);
                isMouseDown = true;
            }
        }

        private void frmLogin_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown)
            {
                Point mousePosition = Control.MousePosition;
                mousePosition.Offset(mouseOffset.X, mouseOffset.Y);
                this.Location = mousePosition;
            }
        }

        private void frmLogin_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isMouseDown = false;
            }
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string _username = txtUsername.Text;
            string _password = txtPassword.Text;

            // Kiểm tra thông tin tài khoản
            if (string.IsNullOrWhiteSpace(_username))
            {
                MessageBox.Show("Vui lòng nhập tên người dùng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(_password))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Giả lập kiểm tra thông tin đăng nhập
            if (_username == "admin" && _password == "123")
            {
                lblerror.Visible = false;
                MessageBox.Show($"Xin chào Admin!", "Đăng nhập thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Chuyển đến from Main
                frmMain adminfrom = new frmMain();
                this.Hide();
                adminfrom.ShowDialog();
                this.Show();
            }
            else if (_username == "user" && _password == "123")
            {
                lblerror.Visible = false;
                MessageBox.Show($"Xin chào {_username}!", "Đăng nhập thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Chuyển đến from Main
                frmMain userFrom = new frmMain();
                this.Hide();
                userFrom.ShowDialog();
                this.Show();
            }
            else
            {
                lblerror.Visible = true;
                return;
            }
        }
        private void linkQuenmk_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn muốn khôi phục mật khẩu của mình? Một email khôi phục sẽ được gửi tới bạn.",
                "Quên mật khẩu",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                //MessageBox.Show("Hệ thống đã gửi email khôi phục đến địa chỉ của bạn.",
                //    "Thông báo",
                //    MessageBoxButtons.OK,
                //    MessageBoxIcon.Information);
                this.Hide();
                frmKhoiphuctk recoveryForm = new frmKhoiphuctk();
                recoveryForm.ShowDialog();

            }
            else
            {
                MessageBox.Show("Bạn đã hủy yêu cầu khôi phục mật khẩu.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }
    }
}
