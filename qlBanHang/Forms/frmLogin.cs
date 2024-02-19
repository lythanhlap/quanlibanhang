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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
 

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-97D4CDDM\SQLEXPRESS;Initial Catalog=qlbh;Integrated Security=True");
            SqlDataAdapter dat = new SqlDataAdapter("select * from DSTaiKhoan where TenTaiKhoan = N'" + txtTenDangNhap.Text + "' and MatKhau= N'" + txtMatKhau + "'", conn);
            DataTable dtt = new DataTable();
            dat.Fill(dtt);
            if(dtt.Rows.Count > 0)
            {
                MessageBox.Show("Đăng nhập thành công!", "Thống Báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();    
                frmChinh fChinh = new frmChinh();
                fChinh.Show();


            }
            else
            {
                MessageBox.Show("Vui lòng điền thông tin đăng nhập!");
            }
            
        }
    }
}
