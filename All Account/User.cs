using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Do_anLaptrinhWinCK.All_Customer
{
    public partial class User : UserControl
    {
        public User()
        {
            InitializeComponent();
        }

        private void Khachhang_Load(object sender, EventArgs e)
        {
            loadDuLieu();
        }
        private void loadDuLieu()
        {
            databaseDataContext db = new databaseDataContext();
            dgvUsers.DataSource = db.Users
                .OrderBy(m => m.UserID)
                .Select(m => new
                {
                    m.UserID,
                    m.Password,
                    m.Username,
                    m.Role,
                    m.CardID,
                    m.Active,
                    m.Email,
                    m.OTP,
                    m.Point
                }).ToList();
        }
    }
}
