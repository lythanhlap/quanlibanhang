using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace qlBanHang
{
    public partial class frmChuongTrinh : Form
    {
        bool isThoat = true;
        public frmChuongTrinh()
        {
            InitializeComponent();
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            isThoat = false;
            this.Close();
            frmDangNhap frm = new frmDangNhap();
            frm.Show();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if(isThoat)
            {
                Application.Exit();
            }
          //  Application.Exit();
        }
    }
}
