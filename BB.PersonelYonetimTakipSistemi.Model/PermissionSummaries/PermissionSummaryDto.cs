using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BB.PersonelYonetimTakipSistemi.Model.PermissionSummaries
{
    public class PermissionSummaryDto
    {
        public int ID { get; set; }
        public int? EmployeeId { get; set; }
        public int? RequestTypeId { get; set; }
        public float? TotalPermissionDay { get; set; }
        public float? UsedPermissionDay { get; set; }
    }
}
