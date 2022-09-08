using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BB.PersonelYonetimTakipSistemi.Model.GeneralInformationDto
{
    public class GeneralInformationDto
    {
        public int UserId { get; set; }
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public DateTime StartDate { get; set; }
        public int DepartmentId { get; set; }
        public int StatusId { get; set; }
        public string Username { get; set; }
        public int WorkTypeId { get; set; }
    }
}
