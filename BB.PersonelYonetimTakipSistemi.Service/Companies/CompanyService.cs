using AutoMapper;
using BB.PersonelYonetimTakipSistemi.Dal.Companies;
using BB.PersonelYonetimTakipSistemi.Data.Model;
using BB.PersonelYonetimTakipSistemi.Helper.DataResult;
using BB.PersonelYonetimTakipSistemi.Model.Companies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BB.PersonelYonetimTakipSistemi.Service.Companies
{
    public interface ICompanyService
    {
        Task<IDataResult<CompanyDto>> AddCompany(CompanyDto companyDto);
        Task<IDataResult<CompanyDto>> UpdateCompany(CompanyDto companyDto, int id);
        Task<IDataResult<Company>> DeleteCompany(int id);
        Task<IDataResult<List<Company>>> GetAllCompany();
    }
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyDal _companyDal;
        private readonly IMapper _mapper;

        public CompanyService(ICompanyDal companyDal, IMapper mapper)
        {
            _companyDal = companyDal;
            _mapper = mapper;
        }

        public async Task<IDataResult<CompanyDto>> AddCompany(CompanyDto companyDto)
        {
            try
            {
                var company = _mapper.Map<Company>(companyDto);
                _companyDal.AddCompany(company);
                return new SuccessDataResult<CompanyDto>(companyDto);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public async Task<IDataResult<Company>> DeleteCompany(int id)
        {
            try
            {
                return new SuccessDataResult<Company>(await _companyDal.DeleteCompany(id));
            }
            catch (System.Exception ex)
            {
                return new ErrorDataResult<Company>(ex.Message);
            }
        }

        public async Task<IDataResult<List<Company>>> GetAllCompany()
        {
            try
            {
                return new SuccessDataResult<List<Company>>(await _companyDal.GetAllCompanies());
            }
            catch (System.Exception ex)
            {
                return new ErrorDataResult<List<Company>>(ex.Message);
            }
        }

        public async Task<IDataResult<CompanyDto>> UpdateCompany(CompanyDto companyDto, int id)
        {
            try
            {
                var company = _mapper.Map<Company>(companyDto);
                _companyDal.UpdateCompany(company, id);
                return new SuccessDataResult<CompanyDto>(companyDto);
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
