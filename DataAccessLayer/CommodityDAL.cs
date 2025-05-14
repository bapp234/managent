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
    public class CommodityDAL
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

        public List<CommodityDTO> GetAll()
        {
            List<CommodityDTO> list = new List<CommodityDTO>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM Commodity";
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new CommodityDTO
                    {
                        MaHang = reader["MaHang"].ToString(),
                        TenHang = reader["TenHang"].ToString(),
                        SoLuong = Convert.ToInt32(reader["SoLuong"]),
                        DonViTinh = reader["DonViTinh"].ToString(),
                        DonGia = reader["DonGia"].ToString(),
                        MaLoai = reader["MaLoai"].ToString()
                    });
                }
            }
            return list;
        }
        public CommodityDTO GetById(string maHang)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM Commodity WHERE MaHang = @id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", maHang);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new CommodityDTO
                    {
                        MaHang = reader["MaHang"].ToString(),
                        TenHang = reader["TenHang"].ToString(),
                        SoLuong = Convert.ToInt32(reader["SoLuong"]),
                        DonViTinh = reader["DonViTinh"].ToString(),
                        DonGia = reader["DonGia"].ToString(),
                        MaLoai = reader["MaLoai"].ToString()
                    };
                }
                return null;
            }
        }

        public bool Update(CommodityDTO item)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = "UPDATE Commodity SET TenHang=@ten, SoLuong=@sl, DonViTinh=@dvt, DonGia=@gia, MaLoai=@ml WHERE MaHang=@id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", item.MaHang);
                cmd.Parameters.AddWithValue("@ten", item.TenHang);
                cmd.Parameters.AddWithValue("@sl", item.SoLuong);
                cmd.Parameters.AddWithValue("@dvt", item.DonViTinh);
                cmd.Parameters.AddWithValue("@gia", item.DonGia);
                cmd.Parameters.AddWithValue("@ml", item.MaLoai);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public List<CommodityDTO> Search(string keyword)
        {
            List<CommodityDTO> list = new List<CommodityDTO>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM Commodity WHERE TenHang LIKE @kw";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@kw", "%" + keyword + "%");
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new CommodityDTO
                    {
                        MaHang = reader["MaHang"].ToString(),
                        TenHang = reader["TenHang"].ToString(),
                        SoLuong = Convert.ToInt32(reader["SoLuong"]),
                        DonViTinh = reader["DonViTinh"].ToString(),
                        DonGia = reader["DonGia"].ToString(),
                        MaLoai = reader["MaLoai"].ToString()
                    });
                }
            }
            return list;
        }

        public bool Insert(CommodityDTO hh)
        {
            throw new NotImplementedException();
        }
    }
}
