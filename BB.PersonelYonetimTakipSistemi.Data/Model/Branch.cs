using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BB.PersonelYonetimTakipSistemi.Data.Model
{
    public class Branch
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? CompanyId { get; set; }
        public bool? IsActive { get; set; }
    }
}
