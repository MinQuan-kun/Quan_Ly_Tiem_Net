using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Do_anLaptrinhWinCK.All_Computer
{
    public partial class ThucDon : UserControl
    {
        Function fn = new Function();
        string query;

        public ThucDon()
        {
            InitializeComponent();
        }

        private void ThucDon_Load(object sender, EventArgs e)
        {
            loadDuLieu();

        }

        private void loadDuLieu()
        {
            databaseDataContext db = new databaseDataContext();
            var data = db.Menus.Select(m => new
            {
                m.FoodID,
                m.FoodName,
                m.Price
            }).ToList();

            dvgMenu.DataSource = data;
        }
        private void loadDuLieuTheoCategory(int categoryID)
        {
            databaseDataContext db = new databaseDataContext();

            // Lọc dữ liệu từ bảng Menu dựa trên CategoryID
            var data = db.Menus
                         .Where(menu => menu.CategoryID == categoryID)
                         .Select(menu => new
                         {
                             menu.FoodID,
                             menu.FoodName,
                             menu.Price
                         }).ToList();

            // Gán dữ liệu vào DataGridView
            dvgMenu.DataSource = data;
        }

        private void btnCom_Click(object sender, EventArgs e)
        {
            loadDuLieuTheoCategory(1); // Cơm
            loadPictureBoxesByCategory(1); 
        }

        private void btnNuoc_Click(object sender, EventArgs e)
        {
            loadDuLieuTheoCategory(2); // Nước uống
            loadPictureBoxesByCategory(2); 
        }

        private void btnSnack_Click(object sender, EventArgs e)
        {
            loadDuLieuTheoCategory(3); // Snack
            loadPictureBoxesByCategory(3); 
        }

        private void btnMi_Click(object sender, EventArgs e)
        {
            loadDuLieuTheoCategory(4); // Mì
            loadPictureBoxesByCategory(4); 
        }

        private void btnKem_Click(object sender, EventArgs e)
        {
            loadDuLieuTheoCategory(5); // Kem
            loadPictureBoxesByCategory(5);
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            databaseDataContext db = new databaseDataContext();

            // Lấy tất cả dữ liệu từ bảng Menu
            var data = db.Menus.Select(menu => new
            {
                menu.FoodID,
                menu.FoodName,
                menu.Price
            }).ToList();

            // Gán dữ liệu vào DataGridView
            dvgMenu.DataSource = data;
        }
        private void loadPictureBoxesByCategory(int categoryID)
        {
            databaseDataContext db = new databaseDataContext();

            // Lấy dữ liệu món ăn theo danh mục
            var data = db.Menus
                         .Where(menu => menu.CategoryID == categoryID)
                         .Select(menu => new
                         {
                             menu.FoodID,
                             menu.FoodName,
                             menu.Image
                         }).ToList();

            // Tạo một FlowLayoutPanel mới (nếu chưa có)
            if (panelMenu.Controls.Count == 0 || !(panelMenu.Controls[0] is FlowLayoutPanel))
            {
                FlowLayoutPanel flowPanel = new FlowLayoutPanel
                {
                    Dock = DockStyle.Fill, // Đảm bảo FlowLayoutPanel sẽ tự động điều chỉnh kích thước khi form thay đổi kích thước
                    AutoScroll = true,     // Tự động hiển thị thanh cuộn khi có quá nhiều hình ảnh
                    FlowDirection = FlowDirection.LeftToRight, // Sắp xếp hình ảnh theo chiều ngang
                    WrapContents = true,  // Cho phép các hình ảnh xuống dòng khi hết không gian
                    Padding = new Padding(10) // Thêm lề để tạo khoảng cách giữa các PictureBox
                };
                panelMenu.Controls.Add(flowPanel);
            }

            FlowLayoutPanel currentFlowPanel = (FlowLayoutPanel)panelMenu.Controls[0];

            // Xóa tất cả các PictureBox cũ trong FlowLayoutPanel
            currentFlowPanel.Controls.Clear();

            foreach (var item in data)
            {
                PictureBox pictureBox = new PictureBox
                {
                    Width = 200,  // Đặt chiều rộng mặc định cho hình ảnh
                    Height = 200, // Đặt chiều cao mặc định cho hình ảnh
                    SizeMode = PictureBoxSizeMode.Zoom, // Tự động điều chỉnh kích thước ảnh nhưng vẫn giữ tỷ lệ
                    BorderStyle = BorderStyle.FixedSingle
                };

                // Gán hình ảnh từ cột Image
                if (item.Image != null)
                {
                    using (var ms = new MemoryStream(item.Image.ToArray()))
                    {
                        pictureBox.Image = Image.FromStream(ms);
                    }
                }
                else
                {
                    pictureBox.BackColor = Color.Gray; // Hiển thị màu nền nếu không có ảnh
                }

                // Thêm PictureBox vào FlowLayoutPanel
                currentFlowPanel.Controls.Add(pictureBox);
            }
        }
    }
}
