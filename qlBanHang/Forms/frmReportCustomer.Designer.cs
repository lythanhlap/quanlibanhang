namespace qlBanHang.Forms
{
    partial class frmReportCustomer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnThongKe = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.textBoxYear = new System.Windows.Forms.TextBox();
            this.textBoxThang = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.reportViewerCus = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // btnThongKe
            // 
            this.btnThongKe.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnThongKe.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThongKe.Location = new System.Drawing.Point(596, 9);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(105, 29);
            this.btnThongKe.TabIndex = 16;
            this.btnThongKe.Text = "Thống kê";
            this.btnThongKe.UseVisualStyleBackColor = false;
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnThoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.Location = new System.Drawing.Point(707, 6);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(92, 32);
            this.btnThoat.TabIndex = 15;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = false;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // textBoxYear
            // 
            this.textBoxYear.Location = new System.Drawing.Point(414, 21);
            this.textBoxYear.Name = "textBoxYear";
            this.textBoxYear.Size = new System.Drawing.Size(90, 22);
            this.textBoxYear.TabIndex = 14;
            // 
            // textBoxThang
            // 
            this.textBoxThang.Location = new System.Drawing.Point(154, 21);
            this.textBoxThang.Name = "textBoxThang";
            this.textBoxThang.Size = new System.Drawing.Size(130, 22);
            this.textBoxThang.TabIndex = 13;
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.Location = new System.Drawing.Point(64, 16);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(84, 27);
            this.textBox3.TabIndex = 12;
            this.textBox3.Text = "Tháng";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(333, 18);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(75, 27);
            this.textBox1.TabIndex = 11;
            this.textBox1.Text = "Năm";
            // 
            // reportViewerCus
            // 
            this.reportViewerCus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.reportViewerCus.LocalReport.ReportEmbeddedResource = "qlBanHang.Report5.rdlc";
            this.reportViewerCus.Location = new System.Drawing.Point(0, 74);
            this.reportViewerCus.Name = "reportViewerCus";
            this.reportViewerCus.ServerReport.BearerToken = null;
            this.reportViewerCus.Size = new System.Drawing.Size(822, 378);
            this.reportViewerCus.TabIndex = 10;
            // 
            // frmReportCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(822, 452);
            this.Controls.Add(this.btnThongKe);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.textBoxYear);
            this.Controls.Add(this.textBoxThang);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.reportViewerCus);
            this.Name = "frmReportCustomer";
            this.Text = "frmReportCustomer";
            this.Load += new System.EventHandler(this.frmReportCustomer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnThongKe;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.TextBox textBoxYear;
        private System.Windows.Forms.TextBox textBoxThang;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewerCus;
    }
}