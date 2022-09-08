using BB.PersonelYonetimTakipSistemi.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BB.PersonelYonetimTakipSistemi.Model.ReplaceEmployeeDTO
{
    public class ReplaceEmployeeDto
    {
        public User User { get; set; }
        public Career Career { get; set; }
        public Employee Employee { get; set; }
    }
}
