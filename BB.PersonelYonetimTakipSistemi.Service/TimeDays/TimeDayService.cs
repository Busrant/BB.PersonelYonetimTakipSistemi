using AutoMapper;
using BB.PersonelYonetimTakipSistemi.Dal.TimeDays;
using BB.PersonelYonetimTakipSistemi.Data.Model;
using BB.PersonelYonetimTakipSistemi.Helper.DataResult;
using BB.PersonelYonetimTakipSistemi.Model.TimeDays;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BB.PersonelYonetimTakipSistemi.Service.TimeDays
{
    public interface ITimeDaysService
    {
        Task<IDataResult<TimeDayDto>> AddTimeDay(TimeDayDto timeDayDto);
        Task<IDataResult<TimeDayDto>> UpdateTimeDay(TimeDayDto timeDayDto, int id);
        Task<IDataResult<TimeDay>> DeleteTimeDay(int id);
        Task<IDataResult<List<TimeDay>>> GetAllTimeDay();
        Task<IDataResult<List<TimeDay>>> GetAllDayOffs(DateTime startDate, DateTime endDate);
    }
    public class TimeDayService : ITimeDaysService
    {
        private readonly ITimeDayDal _timeDal;
        private readonly IMapper _mapper;

        public TimeDayService(ITimeDayDal timeDal, IMapper mapper)
        {
            _timeDal = timeDal;
            _mapper = mapper;
        }

        public async Task<IDataResult<TimeDayDto>> AddTimeDay(TimeDayDto timeDayDto)
        {
            try
            {
                var timeDay = _mapper.Map<TimeDay>(timeDayDto);
                _timeDal.AddTimeDay(timeDay);
                return new SuccessDataResult<TimeDayDto>(timeDayDto);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public async Task<IDataResult<TimeDay>> DeleteTimeDay(int id)
        {
            try
            {
                return new SuccessDataResult<TimeDay>(await _timeDal.DeleteTimeDay(id));
            }
            catch (System.Exception ex)
            {
                return new ErrorDataResult<TimeDay>(ex.Message);
            }
        }

        public async Task<IDataResult<List<TimeDay>>> GetAllDayOffs(DateTime startDate, DateTime endDate)
        {
            try
            {
                return new SuccessDataResult<List<TimeDay>>(await _timeDal.GetAllDayOffs(startDate, endDate));
            }
            catch (System.Exception ex)
            {
                return new ErrorDataResult<List<TimeDay>>(ex.Message);
            }
        }

        public async Task<IDataResult<List<TimeDay>>> GetAllTimeDay()
        {
            try
            {
                return new SuccessDataResult<List<TimeDay>>(await _timeDal.GetAllTimeDay());
            }
            catch (System.Exception ex)
            {
                return new ErrorDataResult<List<TimeDay>>(ex.Message);
            }
        }

        public async Task<IDataResult<TimeDayDto>> UpdateTimeDay(TimeDayDto timeDayDto, int id)
        {
            try
            {
                var timeDay = _mapper.Map<TimeDay>(timeDayDto);
                _timeDal.UpdateTimeDay(timeDay, id);
                return new SuccessDataResult<TimeDayDto>(timeDayDto);
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
