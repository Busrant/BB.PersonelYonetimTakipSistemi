using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BB.PersonelYonetimTakipSistemi.Model.Companies
{
    public class CompanyDto
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime? CreateDate { get; set; }
        public bool? IsActive { get; set; }
        public string Address { get; set; }
        public string Logo { get; set; }
        public string Phone { get; set; }
    }
}
