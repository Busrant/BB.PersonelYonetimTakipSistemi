using System;

namespace BB.PersonelYonetimTakipSistemi.Model.Employees
{
    public class EmployeeDto
    {
        public int ID { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? UserId { get; set; }
        public string CompanyEmail { get; set; }
        public string CompanyPhone { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime? StartDateToCompany { get; set; }
        public bool? IsActive { get; set; }
    }
}
