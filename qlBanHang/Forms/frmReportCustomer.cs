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
    public partial class frmReportCustomer : Form
    {
        ModifyTest modifyTest = new ModifyTest();
        public frmReportCustomer()
        {
            InitializeComponent();
        }

        private void frmReportCustomer_Load(object sender, EventArgs e)
        {

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
                             SELECT * FROM ReportCus1
                             WHERE MONTH(ReportCus1.NgayBan) = @Thang AND YEAR(ReportCus1.NgayBan) = @Nam
                            ";

            //  truy vấn và cập nhật report
            DataSet dataSet = modifyTest.Table(query, new SqlParameter("@Thang", thangChon), new SqlParameter("@Nam", namChon));

            // Xóa các DataSource cũ
            reportViewerCus.LocalReport.DataSources.Clear();
            reportViewerCus.LocalReport.ReportEmbeddedResource = "qlBanHang.Report5.rdlc";


            ReportDataSource reportDataSource = new ReportDataSource();
            reportDataSource.Name = "DataSet6"; // Tên của DataSet trong report
            reportDataSource.Value = dataSet.Tables[0]; // Bảng dữ liệu trong DataSet
            reportViewerCus.LocalReport.DataSources.Add(reportDataSource);


            this.reportViewerCus.RefreshReport();
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
