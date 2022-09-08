using System;
using System.ComponentModel.DataAnnotations;

namespace BB.PersonelYonetimTakipSistemi.Data.Model
{
    public class Department
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? CompanyId { get; set; }
        public bool? IsActive { get; set; }
        public int? ManagerId { get; set; }
    }
}
