using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qlBanHang
{
    public class ModifyTest
    {
        private string connectionString = @"Data Source=LAPTOP-97D4CDDM\SQLEXPRESS;Initial Catalog=quanlibanhang;Integrated Security=True";

        // Hàm thực hiện truy vấn và trả về dữ liệu dưới dạng DataSet
        public DataSet Table(string query, params SqlParameter[] parameters)
        {
            DataSet dataSet = new DataSet();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Thêm tham số nếu có
                    command.Parameters.AddRange(parameters);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dataSet);
                }
            }

            return dataSet;
        }


    }
}
