using Microsoft.Reporting.WinForms;
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
    public partial class frmReport1 : Form
    {
        ModifyTest modifyTest = new ModifyTest();

        public frmReport1()
        {
            InitializeComponent();
        }

        private void frmReport1_Load(object sender, EventArgs e)
        {
            
          //  SetupReport();
        }

        

       

        private void SetupReport()
        {
            int thangChon, namChon;
            if (!int.TryParse(textBoxThang.Text, out thangChon) || !int.TryParse(textBoxYear.Text, out namChon))
            {
                MessageBox.Show("Vui lòng nhập tháng và năm hợp lệ.");
                return;
            }

            // truy vấn SQL để lấy dữ liệu hóa đơn cho tháng và năm đã chọn
            //  string query = "SELECT * FROM HoaDon WHERE MONTH(NgayBan) = @Thang AND YEAR(NgayBan) = @Nam";
            // string query = "SELECT HoaDon.MaHD, ReportView.MaSP, ReportView.SoLuong, ReportView.DonGia, ReportView.ThanhTien,HoaDon.NgayBan  FROM HoaDon, ReportView WHERE  MONTH(NgayBan) = @Thang AND YEAR(NgayBan) = @Nam";
            string query = @"
                             SELECT HoaDon.MaHD, ReportView.MaSP, ReportView.SoLuong, ReportView.DonGia, ReportView.ThanhTien, HoaDon.NgayBan 
                             FROM HoaDon
                             JOIN ReportView ON HoaDon.MaHD = ReportView.MaHD
                             WHERE MONTH(HoaDon.NgayBan) = @Thang AND YEAR(HoaDon.NgayBan) = @Nam
                            ";

            //  truy vấn và cập nhật report
            DataSet dataSet = modifyTest.Table(query, new SqlParameter("@Thang", thangChon), new SqlParameter("@Nam", namChon));

            // Xóa các DataSource cũ
            reportViewer22.LocalReport.DataSources.Clear();
            reportViewer22.LocalReport.ReportEmbeddedResource = "qlBanHang.Report1.rdlc";


            ReportDataSource reportDataSource = new ReportDataSource();
            reportDataSource.Name = "DataSet3"; // Tên của DataSet trong report
            reportDataSource.Value = dataSet.Tables[0]; // Bảng dữ liệu trong DataSet
            reportViewer22.LocalReport.DataSources.Add(reportDataSource);

        
            this.reportViewer22.RefreshReport();
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            SetupReport();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}