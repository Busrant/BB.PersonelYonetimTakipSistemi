using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BB.PersonelYonetimTakipSistemi.Model.PermissionTypes
{
    public class PermissionTypeDto
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int? TotalValue { get; set; }
        public string PermissionKind { get; set; }
        public DateTime? CreateDate { get; set; }
        public string Desctription { get; set; }
    }
}
