using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CustomerDTO : User
    {
        public List<OrderDTO> LichSuMuaHang { get; set; }
    }
}
