﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
//using System.Data;


namespace qlBanHang
{
    public partial class frmDangNhap : Form
    {
  /*      string tenTaiKhoan = "admin";
        string matKhau = "admin";*/
        SqlConnection conn;
        public frmDangNhap()
        {
            InitializeComponent();
        }

        public string taikhoan = "";
        public string loaitk;
        
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            /*
            if (string.IsNullOrEmpty(txtTenDangNhap.Text)) 
            {
                MessageBox.Show("Nhập tài khoản!");
                txtTenDangNhap.Select();
                return;
            }
            if (string.IsNullOrEmpty(txtMatKhau.Text))
            {
                MessageBox.Show("Nhập mật khẩu!");
                txtMatKhau.Select();
                return;
            }
            taikhoan = txtTenDangNhap.Text;
            loaitk = "";
            if (loaitk.Equals("admin"))
            {
                loaitk = "admin";

            }
            else if (loaitk.Equals(kho))
            {
                loaitk = "kho";
            }
            else if (loaitk.Equals(thungan))
            {
                loaitk = "thungan";
            }

*/

                 
                       SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-97D4CDDM\SQLEXPRESS;Initial Catalog=QuanLyBanHang;Integrated Security=True ");

                       try
                       {
                           con.Open();
                           string taikhoan = txbTenDangNhap.Text;
                           string matkhau = txbMatKhau.Text;
                           string sql = "select * from DSTaiKhoan where TaiKhoan = '" + taikhoan + "' and MatKhau = '" + matkhau + "' ";
                           SqlCommand cmd = new SqlCommand(sql, con);
                           SqlDataReader rdr = cmd.ExecuteReader();

                           if (rdr.Read() == true)
                           {
                               frmChuongTrinh frm = new frmChuongTrinh();
                               frm.Show();
                               this.Hide();
                           }
                           else
                           {
                               MessageBox.Show("Sai tài khoản hoặc mật khẩu!", "Lỗi!");
                               txbTenDangNhap.Focus();                }
                       }
                       catch(Exception ex)
                       {
                           MessageBox.Show("Lỗi kết nối!");
                       }

           /*
                       if (kiemTraDangNhap(txbTenDangNhap.Text, txbMatKhau.Text))
                       {
                           frmChuongTrinh frm = new frmChuongTrinh();
                           frm.Show();
                           this.Hide();
                       }
                       else
                       {
                           MessageBox.Show("Sai tên tài khoản hoặc mật khẩu", "Lỗi!");
                           txbTenDangNhap.Focus();
                       }
           */
        }
 
        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

/*
        bool kiemTraDangNhap(string tenTaiKhoan, string matKhau)
        {
            if(tenTaiKhoan == this.tenTaiKhoan && matKhau == this.matKhau)
            {
                return true;
            }
            return false;
        }
*/


    }
}
