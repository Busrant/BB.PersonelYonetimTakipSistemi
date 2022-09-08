using AutoMapper;
using BB.PersonelYonetimTakipSistemi.Data.Model;
using BB.PersonelYonetimTakipSistemi.Model.Branches;
using BB.PersonelYonetimTakipSistemi.Model.Careers;
using BB.PersonelYonetimTakipSistemi.Model.Companies;
using BB.PersonelYonetimTakipSistemi.Model.Departments;
using BB.PersonelYonetimTakipSistemi.Model.Employees;
using BB.PersonelYonetimTakipSistemi.Model.PermissionSummaries;
using BB.PersonelYonetimTakipSistemi.Model.PermissionTypes;
using BB.PersonelYonetimTakipSistemi.Model.Requests;
using BB.PersonelYonetimTakipSistemi.Model.RequestType;
using BB.PersonelYonetimTakipSistemi.Model.Statuses;
using BB.PersonelYonetimTakipSistemi.Model.TimeDays;
using BB.PersonelYonetimTakipSistemi.Model.Users;
using BB.PersonelYonetimTakipSistemi.Model.WorkTypes;

namespace BB.PersonelYonetimTakipSistemi.Helper.DataResult.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<EmployeeDto, Employee>().ReverseMap();
            CreateMap<Employee, EmployeeDto>().ReverseMap();

            CreateMap<RequestsDto, Request>().ReverseMap();
            CreateMap<Request, RequestsDto>().ReverseMap();

            CreateMap<DepartmentDto, Department>().ReverseMap();
            CreateMap<Department, DepartmentDto>().ReverseMap();

            CreateMap<BranchDto, Branch>().ReverseMap();
            CreateMap<Branch, BranchDto>().ReverseMap();

            CreateMap<CareerDto, Career>().ReverseMap();
            CreateMap<Career, CareerDto>().ReverseMap();

            CreateMap<CompanyDto, Company>().ReverseMap();
            CreateMap<Company, CompanyDto>().ReverseMap();

            CreateMap<PermissionSummaryDto, PermissionSummary>().ReverseMap();
            CreateMap<PermissionSummary, PermissionSummaryDto>().ReverseMap();

            CreateMap<PermissionTypeDto, PermissionType>().ReverseMap();
            CreateMap<PermissionType, PermissionTypeDto>().ReverseMap();

            CreateMap<RequestTypeDto, RequestType>().ReverseMap();
            CreateMap<RequestType, RequestTypeDto>().ReverseMap();

            CreateMap<StatusDto, Status>().ReverseMap();
            CreateMap<Status, StatusDto>().ReverseMap();

            CreateMap<TimeDayDto, TimeDay>().ReverseMap();
            CreateMap<TimeDay, TimeDayDto>().ReverseMap();

            CreateMap<UserDto, User>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();

            CreateMap<WorkTypeDto, WorkType>().ReverseMap();
            CreateMap<WorkType, WorkTypeDto>().ReverseMap();
        }
    }
}
