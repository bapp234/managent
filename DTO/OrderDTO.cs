using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class OrderDTO
    {
        public string MaDonHang { get; set; }
        public string KhachHang { get; set; }
        public List<CommodityDTO> DanhSachHangHoa { get; set; }
        public DateTime NgayDatHang { get; set; }
        public double TongTien { get; set; }
    }
}
