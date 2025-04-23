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
    public partial class frmQuanLiTaiKhoan : Form
    {
        public frmQuanLiTaiKhoan()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmQuanLiTaiKhoan_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'quanlibanhangDataSet7.QLTaiKhoan' table. You can move, or remove it, as needed.
            this.qLTaiKhoanTableAdapter.Fill(this.quanlibanhangDataSet7.QLTaiKhoan);
            LoadTaiKhoan();

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            addAccount t = new addAccount();
            t.Show();
        }
        private void LoadTaiKhoan()
        {
            string sql = "SELECT * FROM QLTaiKhoan";
            dataGridView1.DataSource = Functions.GetDataToTable(sql);
        }

        private void btnHienThi_Click(object sender, EventArgs e)
        {
            LoadTaiKhoan();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn tài khoản cần xoá!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string tenDangNhap = dataGridView1.CurrentRow.Cells[1].Value.ToString(); // ✔ sửa đúng tên cột

            DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xoá tài khoản '{tenDangNhap}' không?", "Xác nhận xoá", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                string sql = "DELETE FROM QLTaiKhoan WHERE tenDangNhap = N'" + tenDangNhap + "'";
                try
                {
                    Functions.RunSqlDel(sql);
                    MessageBox.Show("Xoá tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadTaiKhoan();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xoá tài khoản: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
