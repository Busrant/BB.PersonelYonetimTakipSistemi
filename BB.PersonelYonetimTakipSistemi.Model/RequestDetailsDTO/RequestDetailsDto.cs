using BB.PersonelYonetimTakipSistemi.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BB.PersonelYonetimTakipSistemi.Model.RequestDetailsDTO
{
    public class RequestDetailsDto
    {
        public Request Request { get; set; }
        public PermissionType PermissionType { get; set; }
        public BB.PersonelYonetimTakipSistemi.Data.Model.RequestType RequestType { get; set; }
        public Employee Employee { get; set; }
        public User User { get; set; }
        public Department Department { get; set; }
        public Career Career { get; set; }
    }
}
