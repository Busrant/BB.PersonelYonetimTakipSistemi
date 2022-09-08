using BB.PersonelYonetimTakipSistemi.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BB.PersonelYonetimTakipSistemi.Model.TeamLeadersDTO
{
    public class TeamLeadersDto
    {
        public Employee Employee{ get; set; }
        public User User { get; set; }
        public Career Career { get; set; }
    }
}
