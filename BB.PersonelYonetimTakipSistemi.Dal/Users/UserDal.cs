using BB.PersonelYonetimTakipSistemi.Dal.Base;
using BB.PersonelYonetimTakipSistemi.Data.Context;
using BB.PersonelYonetimTakipSistemi.Data.Model;
using BB.PersonelYonetimTakipSistemi.Model.Employees;
using Microsoft.EntityFrameworkCore;
using System;
using System.Net;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using BB.PersonelYonetimTakipSistemi.Model.JwtGenerateDTO;
using BB.PersonelYonetimTakipSistemi.Model.GeneralInformationDto;

namespace BB.PersonelYonetimTakipSistemi.Dal.Users
{

    public interface IUserDal
    {
        TokenModelDto AuthenticateToken(AuthenticateRequest authenticateRequest, string Username, string Password);
        Task<RefreshTokenDto> AddRefreshTokenAsync(RefreshTokenDto refreshTokenDto);
        Task<bool> DeleteRefreshTokenAsync(string Token);
        Task<Employee> GetEmployeeByTokenAsync(string Token);
        Task<List<User>> GetUpComingBirthday();
        Task<User> GetUserDetail(int userId);
        Task<User> AddUser(User user);
        void UpdateUser(User user, int id);
        Task<GeneralInformationDto> UpdateGeneralInformations(GeneralInformationDto generalInformationDto, int id);
        Task<User> UpdateAdressInformation(User user, int id);
    }

    public class UserDal : BaseDal, IUserDal
    {
        private readonly ApplicationContext _applicationContext;

        public UserDal(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public async Task<RefreshTokenDto> AddRefreshTokenAsync(RefreshTokenDto refreshTokenDto)
        {
            try
            {
                var res = await _applicationContext.AddAsync(refreshTokenDto);
                res.State = EntityState.Added;
                await _applicationContext.SaveChangesAsync();

                return res.Entity;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<User> AddUser(User user)
        {
            try
            {
                using (ApplicationContext context = new ApplicationContext())
                {
                    var result = await context.AddAsync(user);
                    if (result.State == EntityState.Added)
                    {
                        await context.SaveChangesAsync();
                        var addedUser = await context.Users.Where(i => i == user).FirstAsync();
                        return addedUser;
                    }
                    return null;

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public TokenModelDto AuthenticateToken(AuthenticateRequest authenticateRequest, string Username, string Password)
        {
            try
            {                                                  
                var pss = ToMD5(authenticateRequest.Password);
                var emp = from E in _applicationContext.Employees
                          join U in _applicationContext.Users on E.UserId equals U.ID
                          join C in _applicationContext.Careers on E.ID equals C.EmployeeId
                          join D in _applicationContext.Departments on C.DepartmentId equals D.ID
                          join Co in _applicationContext.Companies on D.CompanyId equals Co.ID
                          join UR in _applicationContext.UserRoles on E.ID equals UR.EmployeeId
                          join R in _applicationContext.Roles on UR.RoleId equals R.ID
                          where E.CompanyEmail == authenticateRequest.Username &&
                           pss == E.Password
                          select new TokenModelDto { Employee = E, User = U, Career = C, Company = Co, Department = D , Role = R, UserRole= UR};
                var res = emp.FirstOrDefault();

                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        

        public async Task<bool> DeleteRefreshTokenAsync(string Token)
        {
            try
            {
                var tkn = await _applicationContext.RefreshTokens.SingleOrDefaultAsync(x => x.Token == Token);
                var res = _applicationContext.Remove(tkn);
                res.State = EntityState.Deleted;
                await _applicationContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<Employee> GetEmployeeByTokenAsync(string Token)
        {
            try
            {
                var res = await (from rft in _applicationContext.RefreshTokens
                                 join emp in _applicationContext.Employees on rft.CreateUserID equals emp.ID
                                 where rft.Token == Token
                                 select emp).FirstOrDefaultAsync();
                return res;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<User>> GetUpComingBirthday()
        {
            try
            {
                var result = await _applicationContext.Users.Where(i => (i.BirthDate.Value.Day >= DateTime.Now.Day && i.BirthDate.Value.Month == DateTime.Now.Month) || (i.BirthDate.Value.Month == DateTime.Now.AddMonths(1).Month)).OrderBy(i => i.BirthDate.Value.Month).ThenBy(i => i.BirthDate.Value.Day).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<User> GetUserDetail(int userId)
        {
            try
            {
                var result = await _applicationContext.Users.FirstOrDefaultAsync(i => i.ID == userId);
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<User> UpdateAdressInformation(User user, int id)
        {
            try
            {
                var result = (from U in _applicationContext.Users
                              where user.ID == U.ID
                              select U).FirstOrDefault();
                result.Address = user.Address;
                result.Phone = user.Phone;
                _applicationContext.SaveChanges();
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<GeneralInformationDto> UpdateGeneralInformations(GeneralInformationDto generalInformationDto, int id)
        {
            try
            {
                var result = (from C in _applicationContext.Careers
                              where generalInformationDto.EmployeeId == C.EmployeeId && C.IsActive == true
                              select C).FirstOrDefault();

                result.StartDate = generalInformationDto.StartDate;
                result.DepartmentId = generalInformationDto.DepartmentId;
                result.StatusId = generalInformationDto.StatusId;
                result.WorkTypeId = generalInformationDto.WorkTypeId;



                var res = (from U in _applicationContext.Users
                           where U.ID == generalInformationDto.UserId
                           select U).FirstOrDefault();

                res.Name = generalInformationDto.Name;
                res.Surname = generalInformationDto.Surname;


                var res2 = (from E in _applicationContext.Employees
                            where E.ID == generalInformationDto.EmployeeId
                            select E).FirstOrDefault();

                res2.UserName = generalInformationDto.Username;
                res2.CompanyEmail = generalInformationDto.Email;
                _applicationContext.SaveChanges();

                return new GeneralInformationDto
                {
                    DepartmentId = (int)result.DepartmentId,
                    Email = res2.CompanyEmail,
                    EmployeeId = res2.ID,
                    Name = res.Name,
                    Surname = res.Surname,
                    StartDate = (DateTime)result.StartDate,
                    StatusId = (int)result.StatusId,
                    UserId = res.ID,
                    Username = res2.UserName,
                    WorkTypeId = (int)result.WorkTypeId
                };

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async void UpdateUser(User user, int id)
        {
            try
            {
                using (ApplicationContext context = new ApplicationContext())
                {
                    var result = context.Users.Update(user);
                    if (result.State == EntityState.Modified)
                    {
                        await context.SaveChangesAsync();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
