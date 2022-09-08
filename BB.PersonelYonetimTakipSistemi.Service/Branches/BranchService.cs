using AutoMapper;
using BB.PersonelYonetimTakipSistemi.Dal.Branches;
using BB.PersonelYonetimTakipSistemi.Data.Model;
using BB.PersonelYonetimTakipSistemi.Helper.DataResult;
using BB.PersonelYonetimTakipSistemi.Model.Branches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BB.PersonelYonetimTakipSistemi.Service.Branches
{
    public interface IBranchService
    {
        Task<IDataResult<BranchDto>> AddBranch(BranchDto branchDto);
        Task<IDataResult<BranchDto>> UpdateBranch(BranchDto branchDto, int id);
        Task<IDataResult<Branch>> DeleteBranch(int id);
        Task<IDataResult<List<Branch>>> GetAllBranch();
        Task<IDataResult<List<Branch>>> GetAllCompanyBranches(int companyId);
        Task<IDataResult<List<Branch>>> GetBranchCompany();
    }
    public class BranchService : IBranchService
    {
        private readonly IBranchDal _branchDal;
        private readonly IMapper _mapper;

        public BranchService(IBranchDal branchDal, IMapper mapper)
        {
            _branchDal = branchDal;
            _mapper = mapper;
        }

        public async Task<IDataResult<BranchDto>> AddBranch(BranchDto branchDto)
        {
            try
            {
                var branch = _mapper.Map<Branch>(branchDto);
                _branchDal.AddBranch(branch);
                return new SuccessDataResult<BranchDto>(branchDto);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public async Task<IDataResult<Branch>> DeleteBranch(int id)
        {
            try
            {
                return new SuccessDataResult<Branch>(await _branchDal.DeleteBranch(id));
            }
            catch (System.Exception ex)
            {
                return new ErrorDataResult<Branch>(ex.Message);
            }
        }

        public async Task<IDataResult<List<Branch>>> GetAllBranch()
        {
            try
            {
                return new SuccessDataResult<List<Branch>>(await _branchDal.GetAllBranches());
            }
            catch (System.Exception ex)
            {
                return new ErrorDataResult<List<Branch>>(ex.Message);
            }
        }

        public async Task<IDataResult<List<Branch>>> GetAllCompanyBranches(int companyId)
        {
            try
            {
                return new SuccessDataResult<List<Branch>>(await _branchDal.GetAllCompanyBranches(companyId));
            }
            catch (System.Exception ex)
            {
                return new ErrorDataResult<List<Branch>>(ex.Message);
            }
        }

        public async Task<IDataResult<List<Branch>>> GetBranchCompany()
        {
            try
            {
                return new SuccessDataResult<List<Branch>>(await _branchDal.GetBranchCompany());
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public async Task<IDataResult<BranchDto>> UpdateBranch(BranchDto branchDto, int id)
        {
            try
            {
                var branch = _mapper.Map<Branch>(branchDto);
                _branchDal.UpdateBranch(branch, id);
                return new SuccessDataResult<BranchDto>(branchDto);
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}
