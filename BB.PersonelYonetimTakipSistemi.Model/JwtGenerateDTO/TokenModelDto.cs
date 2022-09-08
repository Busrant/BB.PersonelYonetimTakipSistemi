using BB.PersonelYonetimTakipSistemi.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BB.PersonelYonetimTakipSistemi.Model.JwtGenerateDTO
{
    public class TokenModelDto
    {
        public User User { get; set; }
        public Employee Employee { get; set; }
        public Career Career { get; set; }
        public Company Company { get; set; }
        public Department Department { get; set; }
        public Role Role { get; set; }  
        public UserRole UserRole { get; set; }
    }
}
