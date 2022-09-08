using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BB.PersonelYonetimTakipSistemi.Exception.User
{
    public class UserException:System.Exception
    {
        public UserException(string message): base(message)
        {

        }
        public UserException(string message, System.Exception innerException) : base(message, innerException)
        {

        }
    }
}
