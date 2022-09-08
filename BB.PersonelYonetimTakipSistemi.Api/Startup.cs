using AutoMapper;
using BB.PersonelYonetimTakipSistemi.Dal.Employees;
using BB.PersonelYonetimTakipSistemi.Dal.Requests;
using BB.PersonelYonetimTakipSistemi.Data.Context;
using BB.PersonelYonetimTakipSistemi.Data.Model;
using BB.PersonelYonetimTakipSistemi.Model.Employees;
using BB.PersonelYonetimTakipSistemi.Model.Requests;
using BB.PersonelYonetimTakipSistemi.Service.Employees;
using BB.PersonelYonetimTakipSistemi.Service.Requests;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using BB.PersonelYonetimTakipSistemi.Model.AppSettings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using BB.PersonelYonetimTakipSistemi.Service.Departments;
using BB.PersonelYonetimTakipSistemi.Dal.Departments;
using BB.PersonelYonetimTakipSistemi.Model.Departments;
using BB.PersonelYonetimTakipSistemi.Service.Users;
using BB.PersonelYonetimTakipSistemi.Dal.Users;
using BB.PersonelYonetimTakipSistemi.Service.Branches;
using BB.PersonelYonetimTakipSistemi.Dal.Branches;
using BB.PersonelYonetimTakipSistemi.Service.Careers;
using BB.PersonelYonetimTakipSistemi.Dal.Careers;
using BB.PersonelYonetimTakipSistemi.Service.Companies;
using BB.PersonelYonetimTakipSistemi.Dal.Companies;
using BB.PersonelYonetimTakipSistemi.Service.PermissionSummaries;
using BB.PersonelYonetimTakipSistemi.Dal.PermissionSummaries;
using BB.PersonelYonetimTakipSistemi.Service.PermissionTypes;
using BB.PersonelYonetimTakipSistemi.Dal.PermissionTypes;
using BB.PersonelYonetimTakipSistemi.Service.RequestTypes;
using BB.PersonelYonetimTakipSistemi.Dal.RequestTypes;
using BB.PersonelYonetimTakipSistemi.Service.Statuses;
using BB.PersonelYonetimTakipSistemi.Dal.Statuses;
using BB.PersonelYonetimTakipSistemi.Service.TimeDays;
using BB.PersonelYonetimTakipSistemi.Dal.TimeDays;
using BB.PersonelYonetimTakipSistemi.Service.WorkTypes;
using BB.PersonelYonetimTakipSistemi.Dal.WorkTypes;
using BB.PersonelYonetimTakipSistemi.Model.Branches;
using BB.PersonelYonetimTakipSistemi.Model.Careers;
using BB.PersonelYonetimTakipSistemi.Model.Companies;
using BB.PersonelYonetimTakipSistemi.Model.PermissionSummaries;
using BB.PersonelYonetimTakipSistemi.Model.PermissionTypes;
using BB.PersonelYonetimTakipSistemi.Model.RequestType;
using BB.PersonelYonetimTakipSistemi.Model.Statuses;
using BB.PersonelYonetimTakipSistemi.Model.TimeDays;
using BB.PersonelYonetimTakipSistemi.Model.Users;
using BB.PersonelYonetimTakipSistemi.Model.WorkTypes;

namespace BB.PersonelYonetimTakipSistemi.Api
{
    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BB.PersonelYonetimTakipSistemi.Api", Version = "v1" });
            });
            services.AddDbContext<ApplicationContext>(conf =>
            {
                conf.UseSqlServer("Data Source=localhost;Initial Catalog=BBPersonelYonetimTakipSistemi;Integrated Security=True");
                conf.EnableSensitiveDataLogging();
            });

            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            //var appSettings = appSettingsSection.Get<AppSettings>();
            //var key = Encoding.ASCII.GetBytes(appSettings.Connection);
            //services.AddAuthentication(x =>
            //{
            //    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //});


            //var appSettings = appSettingsSection.Get<AppSettings>();
            //var key = Encoding.ASCII.GetBytes(appSettings.Connection);


            services.AddDbContext<ApplicationContext>(conf =>
            {
                conf.UseSqlServer(Configuration.GetSection("ConnectionStrings").GetChildren().FirstOrDefault(config => config.Key == "DefaultConnection").Value);
                conf.EnableSensitiveDataLogging();
            });

            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IEmployeesDal, EmployeeDal>();

            services.AddScoped<IRequestService, RequestService>();
            services.AddScoped<IRequestDal, RequestDal>();

            services.AddScoped<IDepartmentsService, DepartmentService>();
            services.AddScoped<IDepartmentDal, DepartmentDal>();

            services.AddScoped<IUsersService, UserService>();
            services.AddScoped<IUserDal, UserDal>();

            services.AddScoped<IBranchService, BranchService>();
            services.AddScoped<IBranchDal, BranchDal>();

            services.AddScoped<ICareerService, CareerService>();
            services.AddScoped<ICareerDal, CareerDal>();

            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<ICompanyDal, CompanyDal>();

            services.AddScoped<IPermissionSummaryService, PermissionSummaryService>();
            services.AddScoped<IPermissionSummaryDal, PermissionSummaryDal>();

            services.AddScoped<IPermissionTypeService, PermissionTypeService>();
            services.AddScoped<IPermissionTypeDal, PermissionTypeDal>();

            services.AddScoped<IRequestTypeService, RequestTypeService>();
            services.AddScoped<IRequestTypeDal, RequestTypeDal>();

            services.AddScoped<IStatusService, StatusService>();
            services.AddScoped<IStatusDal, StatusDal>();

            services.AddScoped<ITimeDaysService, TimeDayService>();
            services.AddScoped<ITimeDayDal, TimeDayDal>();

            services.AddScoped<IWorkTypeService, WorkTypeService>();
            services.AddScoped<IWorkTypeDal, WorkTypeDal>();

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddMvc();
        }

        public class MappingProfile : Profile
        {
            public MappingProfile()
            {
                // Add as many of these lines as you need to map your objects
                CreateMap<Employee, EmployeeDto>();
                CreateMap<EmployeeDto, Employee>();

                CreateMap<Request, RequestsDto>();
                CreateMap<RequestsDto, Request>();

                CreateMap<Department, DepartmentDto>();
                CreateMap<DepartmentDto, Department>();

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



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BB.PersonelYonetimTakipSistemi.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
