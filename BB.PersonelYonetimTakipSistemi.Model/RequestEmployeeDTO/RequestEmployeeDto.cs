using BB.PersonelYonetimTakipSistemi.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BB.PersonelYonetimTakipSistemi.Model.RequestEmployeeDTO
{
    public class RequestEmployeeDto
    {
        public Employee Employee{ get; set; }
        public Request Request { get; set; }
        public User User { get; set; }
    }
}
