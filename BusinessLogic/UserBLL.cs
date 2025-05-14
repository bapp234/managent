using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace BusinessLogic
{
    public class UserBLL
    {
        private UserDAL userDAL = new UserDAL();

        public List<User> GetAllUsers()
        {
            return userDAL.GetAllUsers();
        }

        public User GetUserById(string userId)
        {
            return userDAL.GetById(userId);
        }

        public bool InsertUser(User user)
        {
            return userDAL.Insert(user);
        }

        public bool UpdateUser(User user)
        {
            return userDAL.Update(user);
        }

        public List<User> SearchUser(string keyword)
        {
            return userDAL.Search(keyword);
        }

        public bool Login(string userId, string password)
        {
            User user = userDAL.GetById(userId);
            return user != null && user.MatKhau == password;
        }
    }
}
