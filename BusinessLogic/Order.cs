using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DataAccessLayer;
namespace BusinessLogic
{
    public class Order
    {
        private OrderDAL donHangDAL = new OrderDAL();

        public List<OrderDTO> GetAll()
        {
            return donHangDAL.GetAll();
        }

        public OrderDTO GetById(string maDon)
        {
            return donHangDAL.GetById(maDon);
        }

        public bool Insert(OrderDTO dh)
        {
            return donHangDAL.Insert(dh);
        }

        public bool Update(OrderDTO dh)
        {
            return donHangDAL.Update(dh);
        }

        public List<OrderDTO> Search(string keyword)
        {
            return donHangDAL.Search(keyword);
        }
    }
}
