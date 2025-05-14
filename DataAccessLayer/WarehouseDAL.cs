using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DataAccessLayer
{
    public class WarehouseDAL
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

        public List<WarehouseDTO> GetAll()
        {
            List<WarehouseDTO> list = new List<WarehouseDTO>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM Warehouse";
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new WarehouseDTO
                    {
                        MaKho = reader["MaKho"].ToString(),
                        TenKho = reader["TenKho"].ToString(),
                        DiaChi = reader["DiaChi"].ToString()
                    });
                }
            }
            return list;
        }
    }
}
