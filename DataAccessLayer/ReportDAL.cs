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
    public class ReportDAL
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

        public List<ReportDTO> GetAll()
        {
            List<ReportDTO> list = new List<ReportDTO>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM Reports";
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new ReportDTO
                    {
                        MaBaoCao = reader["MaBaoCao"].ToString(),
                        LoaiBaoCao = reader["LoaiBaoCao"].ToString(),
                        NoiDung = reader["NoiDung"].ToString()
                    });
                }
            }
            return list;
        }
    }
}
