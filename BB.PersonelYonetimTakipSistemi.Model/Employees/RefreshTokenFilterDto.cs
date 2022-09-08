using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BB.PersonelYonetimTakipSistemi.Model.Employees
{
    public class RefreshTokenFilterDto
    {
        public string Token { get; set; }
        public int UserId { get; set; }
    }
}
