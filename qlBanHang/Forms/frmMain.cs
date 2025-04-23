using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using qlBanHang.Class;


namespace qlBanHang.Forms
{
    
    public partial class frmMain : Form
    {
        // string TenDangNhap = "", MatKhau = "", Quyen = "";
        //frmDangNhap dangNhap = new frmDangNhap();
        //public string currentUserType { get; set; }
         frmDangNhap dangNhap = new frmDangNhap();
         //private frmDangNhap dangNhap;

        //   frmMain mainForm = new frmMain(dangNhap);
        private string currentUserType;
        public frmMain()
        {
            InitializeComponent();
        }
        public frmMain(string currentUserType)
        {
            InitializeComponent();

            this.currentUserType = currentUserType;
        }
       
        // Các phương thức khác trong lớp frmMain có thể sử dụng giá trị quyền từ trường currentUserType

        // Ví dụ:


        /*  public frmMain(string TenDangNhap, string MatKhau, string Quyen)
          {
              InitializeComponent();
              this.TenDangNhap= TenDangNhap;
              this.MatKhau= MatKhau;
              this.Quyen= Quyen;
          }
        */
        /*    public frmMain(frmDangNhap dangNhap)
            {
                InitializeComponent();
                this.dangNhap = dangNhap;
            }
        */

        /* public frmMain()
         {
             InitializeComponent();
              this.dangNhap = dangNhap;
             //this.currentUserType = currentUserType;

         }*/

        private void frmMain_Load(object sender, EventArgs e)
        {
            textBox1.Text = this.currentUserType;
        }

        private void mnuThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xác nhận thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Class.Functions.Disconnect();   //Đóng kết nối
                this.Close();
            }
            dangNhap.Show();
            
        }
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            dangNhap.Show();
        }

        private void mnuDangXuat_Click(object sender, EventArgs e)
        {
            this.Close();
            dangNhap.Show();
        }

        private void mnuNhaCungCap_Click(object sender, EventArgs e)
        {
            if (this.currentUserType.Replace(" ", "") == "kho" || this.currentUserType.Replace(" ", "") == "admin")
            {
                frmNhaCungCap ncc = new frmNhaCungCap();
                ncc.Show();
            }
            else
            {
                MessageBox.Show("Bạn không có quyền truy cập vào chức năng này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void mnuKhachHang_Click(object sender, EventArgs e)
        {
            if (this.currentUserType.Replace(" ", "") == "seller" || this.currentUserType.Replace(" ", "") == "admin")
            {
                frmKhachHang kh = new frmKhachHang();
                kh.Show();
            }
            else
            {
                MessageBox.Show("Bạn không có quyền truy cập vào chức năng này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void mnuNhanVien_Click(object sender, EventArgs e)
        {
            if (this.currentUserType.Replace(" ", "") == "admin")
            {
                frmNhanVien nv = new frmNhanVien();
                nv.Show();
            }
            else
            {
                MessageBox.Show("Bạn không có quyền truy cập vào chức năng này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void mnuSanPham_Click(object sender, EventArgs e)
        {
            if (this.currentUserType.Replace(" ", "") == "seller" || this.currentUserType.Replace(" ", "") == "admin" || this.currentUserType.Replace(" ","") == "kho")
            {
                frmSanPham sp = new frmSanPham();
                sp.Show();
            }
            else
            {
                MessageBox.Show("Bạn không có quyền truy cập vào chức năng này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void mnuHoaDonBan_Click(object sender, EventArgs e)
        {
            if (this.currentUserType.Replace(" ", "") == "seller" || this.currentUserType.Replace(" ", "") == "admin")
            {
                frmHoaDon hd = new frmHoaDon();
                hd.Show();
            }
            else
            {
                MessageBox.Show("Bạn không có quyền truy cập vào chức năng này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void mnuTimKiemHoaDon_Click(object sender, EventArgs e)
        {
            if (this.currentUserType.Replace(" ", "") == "seller" || this.currentUserType.Replace(" ", "") == "admin")
            {
                frmTimKiem tk = new frmTimKiem();
                tk.Show();
            }
            else
            {
                MessageBox.Show("Bạn không có quyền truy cập vào chức năng này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        

        private void btnHoaDon_Click(object sender, EventArgs e)
        {
            if (this.currentUserType.Replace(" ", "") == "seller" || this.currentUserType.Replace(" ", "") == "admin")
            {
                frmHoaDon hd = new frmHoaDon();
                hd.Show();
            }
            else
            {
                MessageBox.Show("Bạn không có quyền truy cập vào chức năng này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSanPham_Click(object sender, EventArgs e)
        {
            if(this.currentUserType.Replace(" ", "") == "seller" || this.currentUserType.Replace(" ", "") == "admin" || this.currentUserType.Replace(" ", "") == "kho")
            {
                frmSanPham sp = new frmSanPham();
                sp.Show();
            }
            else
            {
                MessageBox.Show("Bạn không có quyền truy cập vào chức năng này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnNhaCungCap_Click(object sender, EventArgs e)
        {
            if (this.currentUserType.Replace(" ", "") == "kho" || this.currentUserType.Replace(" ", "") == "admin")
            {
                frmNhaCungCap ncc = new frmNhaCungCap();
                ncc.Show();
            }
            else
            {
                MessageBox.Show("Bạn không có quyền truy cập vào chức năng này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            if (this.currentUserType.Replace(" ", "") == "admin")
            {
                frmNhanVien nv = new frmNhanVien();
                nv.Show();
            }
            else
            {
                MessageBox.Show("Bạn không có quyền truy cập vào chức năng này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            if (this.currentUserType.Replace(" ", "") == "seller" || this.currentUserType.Replace(" ", "") == "admin")
            {
                frmKhachHang kh = new frmKhachHang();
                kh.Show();
            }
            else
            {
                MessageBox.Show("Bạn không có quyền truy cập vào chức năng này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (this.currentUserType.Replace(" ", "") == "seller" || this.currentUserType.Replace(" ", "") == "admin")
            {
                frmQuanLiTaiKhoan t = new frmQuanLiTaiKhoan();
                this.Hide();
                t.Show();
                
            }
            else
            {
                MessageBox.Show("Bạn không có quyền truy cập vào chức năng này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void thốngKêDoanhThuTheoThángToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*frmReport rp = new frmReport();
            rp.ShowDialog();
            */
            if (this.currentUserType.Replace(" ","") == "seller" || this.currentUserType.Replace(" ", "") == "admin")
            {
                frmReport1 rp1 = new frmReport1();
                rp1.ShowDialog();
            }
            else
            {
                MessageBox.Show("Bạn không có quyền truy cập vào chức năng này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Khai báo một thuộc tính public để lưu trữ currentUserType
        //   public string currentUserType { get; set; }

        // Constructor của form Main để nhận giá trị currentUserType từ form Đăng nhập
        /*   public frmMain(string currentUserType)
           {
               InitializeComponent();
               this.currentUserType = currentUserType;
           }*/
        
        private void tàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //string quyen = dangNhap.layQuyen();

          

            if (this.currentUserType.Replace(" ", "") == "admin")
            {
                // Người dùng có quyền admin, cho phép mở form
                frmTaiKhoan frmTaiKhoan = new frmTaiKhoan();
                frmTaiKhoan.Show();
            }
            else
            {
                // Người dùng không có quyền admin, hiển thị thông báo hoặc thực hiện hành động khác tùy theo yêu cầu
                MessageBox.Show("Bạn không có quyền truy cập vào chức năng này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                // hoặc thực hiện hành động khác...
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Quyền của người dùng hiện tại là: " +this.currentUserType);

        }

        private void thoongsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.currentUserType.Replace(" ", "") == "seller" || this.currentUserType.Replace(" ", "") == "admin")
            {
                frmReportCustomer frmReportCustomer = new frmReportCustomer();
                frmReportCustomer.Show();
            }
            else
            {
                MessageBox.Show("Bạn không có quyền truy cập vào chức năng này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
    
}
