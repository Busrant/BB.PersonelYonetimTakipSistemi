using BB.PersonelYonetimTakipSistemi.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BB.PersonelYonetimTakipSistemi.Model.AllEmployeeDTO
{
    public class AllEmployeeDto
    {
        public Employee Employee{ get; set; }
        public User User { get; set; }
        public Career Career { get; set; }
        public Department Department { get; set; }
        public Status Status { get; set; }
    }
}
