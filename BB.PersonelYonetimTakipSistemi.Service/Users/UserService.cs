using AutoMapper;
using BB.PersonelYonetimTakipSistemi.Dal.Users;
using BB.PersonelYonetimTakipSistemi.Data.Model;
using BB.PersonelYonetimTakipSistemi.Exception.User;
using BB.PersonelYonetimTakipSistemi.Helper.DataResult;
using BB.PersonelYonetimTakipSistemi.Helper.Utilites;
using BB.PersonelYonetimTakipSistemi.Model.AppSettings;
using BB.PersonelYonetimTakipSistemi.Model.Employees;
using BB.PersonelYonetimTakipSistemi.Model.GeneralInformationDto;
using BB.PersonelYonetimTakipSistemi.Model.Users;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BB.PersonelYonetimTakipSistemi.Service.Users
{
    public interface IUsersService
    {
        Task<IDataResult<AuthenticateResponse>> AuthenticateToken(AuthenticateRequest model, string username, string url);
        Task<IDataResult<RefreshTokenDto>> AddRefreshTokenAsync(RefreshTokenDto refreshTokenDto);
        Task<IDataResult<bool>> DeleteRefreshTokenAsync(string Token);
        Task<IDataResult<EmployeeDto>> GetEmployeeByTokenAsync(string Token);
        Task<IDataResult<List<User>>> GetUpComingBirthday();
        Task<IDataResult<User>> GetUserDetail(int userId);
        Task<IDataResult<UserDto>> UpdateUser(UserDto userDto, int id);
        Task<IDataResult<UserDto>> AddUser(UserDto userDto);
        Task<IDataResult<GeneralInformationDto>> UpdateGeneralInformations(GeneralInformationDto generalInformationDto, int id);
        Task<IDataResult<UserDto>> UpdateAdressInformation(UserDto userDto, int id);

    }

    public class UserService : IUsersService
    {
        private readonly IUserDal _userDal;
        private readonly AppSettings _appSettings;
        private readonly IMapper _mapper;
        private readonly ILogger<UserService> _logger;

        public UserService(IOptions<AppSettings> appSettings, IUserDal userDal, IMapper mapper, ILogger<UserService> logger)
        {
            _logger = logger;
            _appSettings = appSettings.Value;
            _userDal = userDal;
            _mapper = mapper;
        }

        public Task<IDataResult<RefreshTokenDto>> AddRefreshTokenAsync(RefreshTokenDto refreshTokenDto)
        {
            throw new NotImplementedException();
        }

        public async Task<IDataResult<AuthenticateResponse>> AuthenticateToken(AuthenticateRequest model, string username, string url)
        {
            try
            {
                JwtToken jwtToken = new JwtToken(_appSettings);
                var user = _userDal.AuthenticateToken(model, username, url);
                if (user == null)
                    throw new UserException("Kullanıcı adı veya şifre hatalı. Lütfen tekrar deneyiniz.");
                else
                {
                    var token = jwtToken.GenerateToken(user);
                    return new SuccessDataResult<AuthenticateResponse>(new AuthenticateResponse(user, token));
                }
            }
            catch (System.Exception ex)
            {

                throw ex;
            }
        }

        public Task<IDataResult<bool>> DeleteRefreshTokenAsync(string Token)
        {
            throw new NotImplementedException();
        }


        public Task<IDataResult<EmployeeDto>> GetEmployeeByTokenAsync(string Token)
        {
            throw new NotImplementedException();
        }


        public async Task<IDataResult<List<User>>> GetUpComingBirthday()
        {
            try
            {
                return new SuccessDataResult<List<User>>(await _userDal.GetUpComingBirthday());
            }
            catch (System.Exception ex)
            {

                return new ErrorDataResult<List<User>>(ex.Message);
            }
        }

        public async Task<IDataResult<User>> GetUserDetail(int userId)
        {
            try
            {
                return new SuccessDataResult<User>(await _userDal.GetUserDetail(userId));
            }
            catch (System.Exception ex)
            {
                return new ErrorDataResult<User>(ex.Message);
            }
        }

        public async Task<IDataResult<UserDto>> UpdateUser(UserDto userDto , int id)
        {
            User user = _mapper.Map<User>(userDto);
            _userDal.UpdateUser(user, id);
            UserDto dto = _mapper.Map<UserDto>(user);
            return new SuccessDataResult<UserDto>(dto);

        }

        public async Task<IDataResult<GeneralInformationDto>> UpdateGeneralInformations(GeneralInformationDto generalInformationDto, int id)
        {
            try
            {
            return new SuccessDataResult<GeneralInformationDto>(await _userDal.UpdateGeneralInformations(generalInformationDto, id));
             
            }
            catch (System.Exception)
            {
                throw;
            }

        }

        public async Task<IDataResult<UserDto>> UpdateAdressInformation(UserDto userDto, int id)
        {
            try
            {
                User user = _mapper.Map<User>(userDto);
                await _userDal.UpdateAdressInformation(user, id);
                UserDto dto = _mapper.Map<UserDto>(user);
                return new SuccessDataResult<UserDto>(dto);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public async Task<IDataResult<UserDto>> AddUser(UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            var res = _mapper.Map<UserDto>(await _userDal.AddUser(user));
            return new SuccessDataResult<UserDto>(res);
        }
    }
}
