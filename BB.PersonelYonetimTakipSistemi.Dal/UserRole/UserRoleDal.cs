using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BB.PersonelYonetimTakipSistemi.Dal.UserRole
{

    public interface IUserRoleDal
    {
        bool CheckUserRole(int userRoleId);
    }

    public class UserRoleDal : IUserRoleDal
    {
        public bool CheckUserRole(int userRoleId)
        {
            throw new NotImplementedException();
        }
    }
}
