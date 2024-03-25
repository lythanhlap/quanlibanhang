using qlBanHang.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ReportingServices.Diagnostics.Internal;
using Microsoft.SqlServer.Server;
using System.Data.Common;


namespace qlBanHang
{
   public class Modify
    {
        public Modify()
        {
        }
        SqlDataAdapter dataAdapter;
        SqlCommand sqlCommand;
        public DataTable Table(string query)
        {
            DataTable dataTable = new DataTable();
            using(SqlConnection sqlConnection = Class.Connection.GetSqlConnection())
            {
                sqlConnection.Open();
                dataAdapter = new SqlDataAdapter(query, sqlConnection);
                dataAdapter.Fill(dataTable);
                sqlConnection.Close();
                
            }
            return dataTable;
        }
        public void Command(string query)
        {
            using(SqlConnection sqlConnection = Class.Connection.GetSqlConnection())
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();

            }
        }

        
    }
}
