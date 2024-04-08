using qlBanHang.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace qlBanHang.Forms
{
    public partial class frmTaiKhoan : Form
    {
        DataTable dtTK;
        
        public frmTaiKhoan()
        {
            InitializeComponent();
        }

        public void LoadDataGridView()
        {
            string sql;
            sql = "SELECT * FROM TaiKhoan";
            dtTK = Functions.GetDataToTable(sql); //lấy dữ liệu
            dgvTaiKhoan.DataSource = dtTK;
            dgvTaiKhoan.Columns[0].HeaderText = "Tên đăng nhập";
            dgvTaiKhoan.Columns[1].HeaderText = "Mật khẩu";
            dgvTaiKhoan.Columns[2].HeaderText = "Quyền";

            dgvTaiKhoan.AllowUserToAddRows = false;
            dgvTaiKhoan.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void frmTaiKhoan_Load(object sender, EventArgs e)
        {
           
            txtTenDangNhap.Enabled = false; ;
            btnLuu.Enabled = false;
            btnBoQua.Enabled = false;
            LoadDataGridView();

        }

        private void btnDong_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Xác nhận đóng?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }
        private void ResetValues()
        {
            txtTenDangNhap.Text = "";
            txtNhapMatKhau.Text = "";
            txtQuyen.Text = "";


        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnBoQua.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            ResetValues();
            txtTenDangNhap.Enabled = true;
            txtTenDangNhap.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;

            if (txtTenDangNhap.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập Tên đăng nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenDangNhap.Focus();
                return;
            }

            if (txtNhapMatKhau.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập Mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNhapMatKhau.Focus();
                return;
            }

            if (txtQuyen.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập Quyền", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtQuyen.Focus();
                return;
            }
            sql = "SELECT TenDangNhap FROM TaiKhoan WHERE TenDangNhap=N'" + txtTenDangNhap.Text.Trim() + "'";
            if (Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã sản phẩm đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenDangNhap.Focus();
                txtTenDangNhap.Text = "";
                return;
            }
            sql = "INSERT INTO TaiKhoan VALUES (N'" + txtTenDangNhap.Text.Trim() + "', N'" + txtNhapMatKhau.Text.Trim() + "', N'" + txtNhapMatKhau.Text.Trim() + "')";
            Class.Functions.RunSQL(sql);
            LoadDataGridView();
            ResetValues();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnBoQua.Enabled = false;
            btnLuu.Enabled = false;
            txtTenDangNhap.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (dtTK.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTenDangNhap.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn Tài Khoản nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE TaiKhoan WHERE TenDangNhap=N'" + txtTenDangNhap.Text + "'";
                Functions.RunSqlDel(sql);
                LoadDataGridView();
                ResetValues();
            }
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            ResetValues();
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnThem.Enabled = true;
            btnBoQua.Enabled = false;
            btnLuu.Enabled = false;
            txtTenDangNhap.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;

            if (dtTK.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (txtTenDangNhap.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn sản phẩm nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (txtNhapMatKhau.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNhapMatKhau.Focus();
                return;
            }
            if (txtQuyen.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtQuyen.Focus();
                return;
            }


            /*   sql = "UPDATE TaiKhoan SET MatKhau = N'" + txtNhapMatKhau.Text.Trim() + "', Quyen = N'" + txtQuyen.Text.Trim() + "' WHERE MaNV = N'" + txtTenDangNhap.Text.Trim() + "'";
               Functions.RunSQL(sql);
               LoadDataGridView();
               ResetValues();
               btnBoQua.Enabled = false;
            */
            sql = "UPDATE TaiKhoan SET MatKhau = N'" + txtNhapMatKhau.Text.Trim() + "', Quyen = N'" + txtQuyen.Text.Trim() + "' WHERE TenDangNhap = N'" + txtTenDangNhap.Text.Trim() + "'";

            try
            {
                Functions.RunSQL(sql);
                LoadDataGridView();
                MessageBox.Show("Tài khoản đã được cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetValues();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật tài khoản: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void dgvTaiKhoan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenDangNhap.Focus();
                return;
            }
            if (dtTK.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            txtTenDangNhap.Text = dgvTaiKhoan.CurrentRow.Cells["TenDangNhap"].Value.ToString();
            txtNhapMatKhau.Text = dgvTaiKhoan.CurrentRow.Cells["MatKhau"].Value.ToString();
            txtQuyen.Text = dgvTaiKhoan.CurrentRow.Cells["Quyen"].Value.ToString();
            

            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnBoQua.Enabled = true;
        }
       
    }
       
}
