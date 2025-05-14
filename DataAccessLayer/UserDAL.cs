using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DTO;
using System.Configuration;

public class UserDAL
{
    private string connectionString = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

    public List<User> GetAllUsers()
    {
        List<User> users = new List<User>();
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            string sql = "SELECT * FROM Users";
            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                User u = new AdminDTO() // hoặc phân biệt nếu là Admin/Employee/Customer
                {
                    UserID = reader["UserID"].ToString(),
                    HoTen = reader["HoTen"].ToString(),
                    Email = reader["Email"].ToString(),
                    DiaChi = reader["DiaChi"].ToString(),
                    SoDienThoai = reader["SoDienThoai"].ToString(),
                    MatKhau = reader["MatKhau"].ToString()
                };
                users.Add(u);
            }
        }
        return users;
    }

    public bool Insert(User user)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            string sql = "INSERT INTO Users VALUES (@id, @name, @email, @diachi, @sdt, @pass)";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id", user.UserID);
            cmd.Parameters.AddWithValue("@name", user.HoTen);
            cmd.Parameters.AddWithValue("@email", user.Email);
            cmd.Parameters.AddWithValue("@diachi", user.DiaChi);
            cmd.Parameters.AddWithValue("@sdt", user.SoDienThoai);
            cmd.Parameters.AddWithValue("@pass", user.MatKhau);
            conn.Open();
            return cmd.ExecuteNonQuery() > 0;
        }
    }

    public bool Delete(string userID)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            string sql = "DELETE FROM Users WHERE UserID = @id";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id", userID);
            conn.Open();
            return cmd.ExecuteNonQuery() > 0;
        }
    }
    public User GetById(string userId)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            string sql = "SELECT * FROM Users WHERE UserID = @id";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id", userId);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return new UserDTO
                {
                    UserID = reader["UserID"].ToString(),
                    HoTen = reader["HoTen"].ToString(),
                    Email = reader["Email"].ToString(),
                    DiaChi = reader["DiaChi"].ToString(),
                    SoDienThoai = reader["SoDienThoai"].ToString(),
                    MatKhau = reader["MatKhau"].ToString()
                };
            }
            return null;
        }
    }

    public bool Update(User user)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            string sql = "UPDATE Users SET HoTen=@name, Email=@email, DiaChi=@diachi, SoDienThoai=@sdt, MatKhau=@pass WHERE UserID=@id";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id", user.UserID);
            cmd.Parameters.AddWithValue("@name", user.HoTen);
            cmd.Parameters.AddWithValue("@email", user.Email);
            cmd.Parameters.AddWithValue("@diachi", user.DiaChi);
            cmd.Parameters.AddWithValue("@sdt", user.SoDienThoai);
            cmd.Parameters.AddWithValue("@pass", user.MatKhau);
            conn.Open();
            return cmd.ExecuteNonQuery() > 0;
        }
    }

    public List<User> Search(string keyword)
    {
        List<User> result = new List<User>();
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            string sql = "SELECT * FROM Users WHERE HoTen LIKE @kw OR Email LIKE @kw";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@kw", "%" + keyword + "%");
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                result.Add(new UserDTO
                {
                    UserID = reader["UserID"].ToString(),
                    HoTen = reader["HoTen"].ToString(),
                    Email = reader["Email"].ToString(),
                    DiaChi = reader["DiaChi"].ToString(),
                    SoDienThoai = reader["SoDienThoai"].ToString(),
                    MatKhau = reader["MatKhau"].ToString()
                });
            }
        }
        return result;
    }
}
