using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class EmployeeDTO : User
    {
        public string BoPhan { get; set; }
        public double Luong { get; set; }
    }
}
