using System;
using System.Configuration;
using System.Data.SqlClient;

namespace YourProjectName.DAL
{
    public class DBHelper
    {
        private readonly string connectionString;

        public DBHelper()
        {
            // Lấy chuỗi kết nối từ App.config
            connectionString = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
        }

        // Hàm trả về một kết nối SqlConnection
        protected SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

        // Hàm mở kết nối (nếu cần)
        protected void OpenConnection(SqlConnection conn)
        {
            if (conn.State == System.Data.ConnectionState.Closed)
                conn.Open();
        }

        // Hàm đóng kết nối (nếu cần)
        protected void CloseConnection(SqlConnection conn)
        {
            if (conn.State == System.Data.ConnectionState.Open)
                conn.Close();
        }
    }
}
