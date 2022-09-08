using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BB.PersonelYonetimTakipSistemi.Data.Model
{
    public class UserRole
    {
        public int ID { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? EmployeeId { get; set; }
        public int? RoleId { get; set; }

    }
}
