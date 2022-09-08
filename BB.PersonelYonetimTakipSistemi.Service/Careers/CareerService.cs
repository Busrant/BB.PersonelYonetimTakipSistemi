using AutoMapper;
using BB.PersonelYonetimTakipSistemi.Dal.Careers;
using BB.PersonelYonetimTakipSistemi.Data.Model;
using BB.PersonelYonetimTakipSistemi.Helper.DataResult;
using BB.PersonelYonetimTakipSistemi.Model.Careers;
using BB.PersonelYonetimTakipSistemi.Model.EmployeeCareerDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BB.PersonelYonetimTakipSistemi.Service.Careers
{
    public interface ICareerService
    {
        Task<IDataResult<CareerDto>> AddCareer(CareerDto careerDto);
        Task<IDataResult<CareerDto>> UpdateCareer(CareerDto careerDto, int id);
        Task<IDataResult<Career>> DeleteCareer(int id);
        Task<IDataResult<List<Career>>> GetAllCareer();
        Task<IDataResult<List<EmployeeCareerDto>>> GetEmployeeCareer(int employeeId);
    }
    public class CareerService : ICareerService
    {
        private readonly ICareerDal _careerDal;
        private readonly IMapper _mapper;

        public CareerService(ICareerDal careerDal, IMapper mapper)
        {
            _careerDal = careerDal;
            _mapper = mapper;
        }

        public async Task<IDataResult<CareerDto>> AddCareer(CareerDto careerDto)
        {
            try
            {
                var career = _mapper.Map<Career>(careerDto);
                _careerDal.AddCareer(career);
                return new SuccessDataResult<CareerDto>(careerDto);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public async Task<IDataResult<Career>> DeleteCareer(int id)
        {
            try
            {
                return new SuccessDataResult<Career>(await _careerDal.DeleteCareer(id));
            }
            catch (System.Exception ex)
            {
                return new ErrorDataResult<Career>(ex.Message);
            }
        }

        public async Task<IDataResult<List<Career>>> GetAllCareer()
        {
            try
            {
                return new SuccessDataResult<List<Career>>(await _careerDal.GetAllCareers());
            }
            catch (System.Exception ex)
            {
                return new ErrorDataResult<List<Career>>(ex.Message);
            }
        }

        public async Task<IDataResult<List<EmployeeCareerDto>>> GetEmployeeCareer(int employeeId)
        {
            try
            {
                return new SuccessDataResult<List<EmployeeCareerDto>>( _careerDal.GetEmployeeCareer(employeeId));
            }
            catch (System.Exception ex)
            {
                return new ErrorDataResult<List<EmployeeCareerDto>>(ex.Message);
            }
        }

        public async Task<IDataResult<CareerDto>> UpdateCareer(CareerDto careerDto, int id)
        {
            try
            {
                var career = _mapper.Map<Career>(careerDto);
                _careerDal.UpdateCareer(career, id);
                return new SuccessDataResult<CareerDto>(careerDto);
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
