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
    public class OrderDAL
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

        public List<OrderDTO> GetAll()
        {
            List<OrderDTO> list = new List<OrderDTO>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM Orders";
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new OrderDTO
                    {
                        MaDonHang = reader["MaDonHang"].ToString(),
                        KhachHang = reader["KhachHang"].ToString(),
                        NgayDatHang = Convert.ToDateTime(reader["NgayDatHang"]),
                        TongTien = Convert.ToDouble(reader["TongTien"])
                    });
                }
            }
            return list;
        }

        public OrderDTO GetById(string maDon)
        {
            throw new NotImplementedException();
        }

        public bool Insert(OrderDTO dh)
        {
            throw new NotImplementedException();
        }

        public List<OrderDTO> Search(string keyword)
        {
            throw new NotImplementedException();
        }

        public bool Update(OrderDTO dh)
        {
            throw new NotImplementedException();
        }
    }
}
