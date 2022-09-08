using BB.PersonelYonetimTakipSistemi.Model.JwtGenerateDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BB.PersonelYonetimTakipSistemi.Model.Employees
{
    public class AuthenticateResponse
    {
        public int id { get; set; }
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string JwtToken { get; set; }
        public EmployeeDto LoginEmployeeDto { get; set; }



        public AuthenticateResponse(TokenModelDto user, string jwtToken)

        {

            //id = user.ID;

            //Firstname = user.Name;

            //Surname = user.Surname;

            //Username = user.Username;

            JwtToken = jwtToken;

            //LoginUserDTO = user;

        }
    }

}
