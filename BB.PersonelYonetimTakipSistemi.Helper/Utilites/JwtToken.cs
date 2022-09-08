using BB.PersonelYonetimTakipSistemi.Model.AppSettings;
using BB.PersonelYonetimTakipSistemi.Model.Employees;
using BB.PersonelYonetimTakipSistemi.Model.JwtGenerateDTO;
using BB.PersonelYonetimTakipSistemi.Model.Users;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BB.PersonelYonetimTakipSistemi.Helper.Utilites
{
    public interface IJwtToken
    {
        public string GenerateToken(TokenModelDto tokenModel);
        public int? ValidateToken(string token);
    }

    public class JwtToken : IJwtToken
    {
        private readonly AppSettings _appSettings;

        public JwtToken(AppSettings appSettings)
        {
            _appSettings = appSettings;
        }

        public int? ValidateToken(string token)
        {
            if (token == null)
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var userId = int.Parse(jwtToken.Claims.First(x => x.Type == "id").Value);

                // return user id from JWT token if validation successful
                return userId;
            }
            catch
            {
                // return null if validation fails
                return null;
            }
        }
        public string GenerateToken(TokenModelDto tokenModel)
        {

            // Yeni bir DTO yapılacak
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("SecretKeyDüzeltDahaSonrBunuGenericYap");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", tokenModel.Employee.ID.ToString()),
                    new Claim("name", tokenModel.User.Name),
                    new Claim("surname", tokenModel.User.Surname),
                    new Claim("email", tokenModel.Employee.CompanyEmail),
                    new Claim("birthDate", tokenModel.User.BirthDate.Value.ToShortDateString().ToString()),
                    new Claim("departmentId", tokenModel.Career.DepartmentId.ToString()),
                    new Claim("branchId",tokenModel.Career.BranchId.ToString()),
                    new Claim("statusId", tokenModel.Career.StatusId.ToString()),
                    new Claim("workTypeId", tokenModel.Career.WorkTypeId.ToString()),
                    new Claim("companyId", tokenModel.Company.ID.ToString()),
                    new Claim("roleId",tokenModel.Role.ID.ToString()),
                    new Claim("userRoleId",tokenModel.UserRole.ID.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

    }
}
