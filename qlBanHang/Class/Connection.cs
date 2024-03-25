using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qlBanHang.Class
{
     class Connection
    {
        private static string stringConnection = @"Data Source=LAPTOP-97D4CDDM\SQLEXPRESS;Initial Catalog=quanlibanhang;Integrated Security=True";
        public static SqlConnection GetSqlConnection() 
        { 
            return new SqlConnection(stringConnection);
        }
    }
}
