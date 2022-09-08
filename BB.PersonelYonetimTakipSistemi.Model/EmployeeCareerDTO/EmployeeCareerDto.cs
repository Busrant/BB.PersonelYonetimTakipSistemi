using BB.PersonelYonetimTakipSistemi.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BB.PersonelYonetimTakipSistemi.Model.EmployeeCareerDTO
{
    public class EmployeeCareerDto
    {
        public Career Career { get; set; }
        public Branch Branch { get; set; }
        public Department Department { get; set; }
        public Status Status { get; set; }
        public WorkType WorkType { get; set; }
        public Company Company { get; set; }
    }
}
