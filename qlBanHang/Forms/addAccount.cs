using qlBanHang.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace qlBanHang.Forms
{
    public partial class addAccount : Form
    {
        public addAccount()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void addAccount_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
           
                string tenTK = txtTenTaiKhoan.Text.Trim();
                string tenDN = txtTenDangNhap.Text.Trim();
                string email = txtEmail.Text.Trim();
                string matKhau = txtMatKhau.Text.Trim();
                string vaiTro = comboBox1.SelectedItem?.ToString();

            addAccount add = new addAccount();
                // Kiểm tra dữ liệu đầu vào
                if (tenTK.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập tên tài khoản", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTenTaiKhoan.Focus();
                    this.Close();
                    return;
                }

                if (tenDN.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập tên đăng nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTenDangNhap.Focus();
                this.Close();
                    return;
                }

                if (email.Length == 0 || !email.Contains("@") || !email.Contains(".") )
                {
                    MessageBox.Show("Email không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEmail.Focus();
                this.Close();
                    return;
                }

                if (matKhau.Length < 8)
                {
                    MessageBox.Show("Mật khẩu phải từ 8 ký tự trở lên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMatKhau.Focus();
                this.Close();
                    return;
                }

                if (string.IsNullOrEmpty(vaiTro))
                {
                    MessageBox.Show("Bạn phải chọn vai trò", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    comboBox1.Focus();
                this.Close();
                    return;
                }

                // Kiểm tra trùng tên đăng nhập
                string sqlCheck = "SELECT tenDangNhap FROM QLTaiKhoan WHERE tenDangNhap = N'" + tenDN + "'";
                if (Functions.CheckKey(sqlCheck))
                {
                    MessageBox.Show("Tên đăng nhập đã tồn tại, vui lòng chọn tên khác", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTenDangNhap.Focus();
                this.Close();
                    return;
                }

                // Tạo câu lệnh thêm tài khoản
                string sqlInsert = "INSERT INTO QLTaiKhoan (tenTaiKhoan, tenDangNhap, email, matKhau, vaiTro) " +
                                   "VALUES (N'" + tenTK + "', N'" + tenDN + "', N'" + email + "', N'" + matKhau + "', N'" + vaiTro + "')";

                try
                {
                    Functions.RunSQL(sqlInsert);
                    MessageBox.Show("Thêm tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    //// Nếu có DataGridView: Load lại danh sách tài khoản
                    //LoadTaiKhoan();

                    // Reset form
                    ResetForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thêm tài khoản: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            this.Close();
            

        }
        private void ResetForm()
        {
            txtTenTaiKhoan.Clear();
            txtTenDangNhap.Clear();
            txtEmail.Clear();
            txtMatKhau.Clear();
            comboBox1.SelectedIndex = 0;
            txtTenTaiKhoan.Focus();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            ResetForm();
        }
    }
}
