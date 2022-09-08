using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BB.PersonelYonetimTakipSistemi.Model.Employees
{
    public class RefreshTokenDto
    {
        public int Id { get; set; } 
        public int CreateUserID { get; set; } 
        public string Token { get; set; } 
        public DateTime Expires { get; set; } 
        public DateTime CreateDate { get; set; } 
        public DateTime Revoked { get; set; } 
        public string CreatedByIp { get; set; } 
        public string RevokedByIp { get; set; } 
        public string ReplaceByToken { get; set; } 
        public string ReasonRevoked { get; set; }
    }
}
