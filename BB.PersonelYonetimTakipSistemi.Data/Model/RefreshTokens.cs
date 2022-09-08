using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BB.PersonelYonetimTakipSistemi.Data.Model
{
    public class RefreshTokens
    {
        public int ID { get; set; }
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
