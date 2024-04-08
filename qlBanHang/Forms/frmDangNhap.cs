using qlBanHang.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace qlBanHang.Forms
{
    public partial class frmDangNhap : Form
    {
        
        public string currentUserType;

        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xác nhận thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Functions.Disconnect();       //Đóng kết nối
                Application.Exit();
            }
        }
       
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string sql;
            
            if (txtTenDangNhap.Text.Trim().Length == 0)
            {
                MessageBox.Show("Chưa nhập tên đăng nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenDangNhap.Focus();
                return;
            }
            if (txtMatKhau.Text.Trim().Length == 0)
            {
                MessageBox.Show("Chưa nhập mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMatKhau.Focus();
                return;
            }

            /* string sql1 = "SELECT Quyen FROM TaiKhoan WHERE TenDangNhap = '" + txtTenDangNhap.Text.Trim() + "' AND MatKhau = '" + txtMatKhau.Text.Trim() + "'";
             string quyen = Functions.GetFieldValues(sql1);
             currentUserType = quyen;
             //frmDangNhap frmDangNhap = new frmDangNhap();
             // frmDangNhap.currentUserType = quyen;
            */
           

            sql = "Select count(*) from TaiKhoan where TenDangNhap = '" + txtTenDangNhap.Text.Trim() + "' and MatKhau = '" + txtMatKhau.Text.Trim() + "'";


            string sql1 = "SELECT TenDangNhap FROM TaiKhoan Where TenDangNhap = '" + txtTenDangNhap.Text.Trim() + "'";
            string name = Functions.GetFieldValues(sql1);
            // currentUserType = quyen;
            if (string.Compare(name, txtTenDangNhap.Text.Trim(), true) == 0)
            {
                string sql2 = "SELECT Quyen FROM TaiKhoan WHERE TenDangNhap = '" + name + "' ";
                string quyen = Functions.GetFieldValues(sql2);
                currentUserType = quyen;
            }
            

            if (Convert.ToInt32(Functions.GetFieldValues(sql)) == 1)
                   {



                       frmMain frmMain = new frmMain(currentUserType) ;
                       frmMain.Show();
                       this.Hide();
                       txtTenDangNhap.Text = "";
                       txtMatKhau.Text = "";
                       txtTenDangNhap.Focus();
                   }
                   else
                   {
                       MessageBox.Show("Tài khoản không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                       txtTenDangNhap.Text = "";
                       txtMatKhau.Text = "";
                       txtTenDangNhap.Focus();
                       return;
                   }

            /*   sql = "SELECT Quyen FROM TaiKhoan WHERE TenDangNhap = '" + txtTenDangNhap.Text.Trim() + "' AND MatKhau = '" + txtMatKhau.Text.Trim() + "'";
                string quyen = Functions.GetFieldValues(sql); // Lấy quyền của tài khoản

                if (!string.IsNullOrEmpty(quyen))
                {
                    // Lưu quyền vào biến để sử dụng ở những nơi khác trong ứng dụng
                    currentUserType = quyen;

                    // Đóng form đăng nhập
                    this.Hide();
                }
                else
                {
                    // Đăng nhập không thành công
                    MessageBox.Show("Tài khoản không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTenDangNhap.Text = "";
                    txtMatKhau.Text = "";
                    txtTenDangNhap.Focus();
                }
            */

            
        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {
            Functions.Connect();  //Mở kết nối
        }

        
        
        public string a = "admin";
        
        
       

    }
}
