using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BB.PersonelYonetimTakipSistemi.Data.Model
{
    public class PermissionType
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int? TotalValue { get; set; }
        public string PermissionKind { get; set; }
        public DateTime? CreateDate { get; set; }
        public string Desctription { get; set; }

    }
}
