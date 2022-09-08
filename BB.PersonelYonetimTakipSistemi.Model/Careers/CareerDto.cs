using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BB.PersonelYonetimTakipSistemi.Model.Careers
{
    public class CareerDto
    {
        public int ID { get; set; }
        public int? EmployeeId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? DepartmentId { get; set; }
        public int? BranchId { get; set; }
        public int? WorkTypeId { get; set; }
        public int? StatusId { get; set; }
        public DateTime? CreateDate { get; set; }
        public bool? IsActive { get; set; }
    }
}
