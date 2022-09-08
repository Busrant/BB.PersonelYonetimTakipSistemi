using System;
using System.ComponentModel.DataAnnotations;

namespace BB.PersonelYonetimTakipSistemi.Data.Model
{
    public class Company
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
