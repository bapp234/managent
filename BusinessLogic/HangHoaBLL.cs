using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using DTO;

namespace BusinessLogic
{
    public class HangHoaBLL
    {
        private CommodityDAL hangHoaDAL = new CommodityDAL();

        public List<CommodityDTO> GetAll()
        {
            return hangHoaDAL.GetAll();
        }

        public CommodityDTO GetById(string maHang)
        {
            return hangHoaDAL.GetById(maHang);
        }

        public bool Insert(CommodityDTO hh)
        {
            return hangHoaDAL.Insert(hh);
        }

        public bool Update(CommodityDTO hh)
        {
            return hangHoaDAL.Update(hh);
        }

        public List<CommodityDTO> Search(string keyword)
        {
            return hangHoaDAL.Search(keyword);
        }
    }

}
