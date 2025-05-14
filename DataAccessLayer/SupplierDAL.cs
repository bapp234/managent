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
    public class SupplierDAL
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

        public List<SupplierDTO> GetAll()
        {
            List<SupplierDTO> list = new List<SupplierDTO>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM Suppliers";
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new SupplierDTO
                    {
                        MaNCC = reader["MaNCC"].ToString(),
                        TenNCC = reader["TenNCC"].ToString(),
                        DiaChi = reader["DiaChi"].ToString(),
                        Email = reader["Email"].ToString()
                    });
                }
            }
            return list;
        }
        public SupplierDTO GetById(string maNCC)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM Suppliers WHERE MaNCC = @id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", maNCC);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new SupplierDTO
                    {
                        MaNCC = reader["MaNCC"].ToString(),
                        TenNCC = reader["TenNCC"].ToString(),
                        DiaChi = reader["DiaChi"].ToString(),
                        Email = reader["Email"].ToString()
                    };
                }
                return null;
            }
        }

        public bool Update(SupplierDTO supplier)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = "UPDATE Suppliers SET TenNCC=@ten, DiaChi=@dc, Email=@email WHERE MaNCC=@id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", supplier.MaNCC);
                cmd.Parameters.AddWithValue("@ten", supplier.TenNCC);
                cmd.Parameters.AddWithValue("@dc", supplier.DiaChi);
                cmd.Parameters.AddWithValue("@email", supplier.Email);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public List<SupplierDTO> Search(string keyword)
        {
            List<SupplierDTO> list = new List<SupplierDTO>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM Suppliers WHERE TenNCC LIKE @kw";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@kw", "%" + keyword + "%");
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new SupplierDTO
                    {
                        MaNCC = reader["MaNCC"].ToString(),
                        TenNCC = reader["TenNCC"].ToString(),
                        DiaChi = reader["DiaChi"].ToString(),
                        Email = reader["Email"].ToString()
                    });
                }
            }
            return list;
        }
    }
}
