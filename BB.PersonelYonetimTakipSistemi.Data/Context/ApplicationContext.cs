using BB.PersonelYonetimTakipSistemi.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace BB.PersonelYonetimTakipSistemi.Data.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        public ApplicationContext()
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Request> RequestDayOffs { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<RequestType> RequestTypes { get; set; }
        public DbSet<RefreshTokens> RefreshTokens { get; set; }
        public DbSet<Career> Careers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<PermissionSummary> PermissionSummaries { get; set; }
        public DbSet<PermissionType> PermissionTypes { get; set; }
        public DbSet<TimeDay> TimeDays { get; set; }
        public DbSet<TimeDayType> TimeDayTypes { get; set; }
        public DbSet<WorkType> WorkTypes { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Role> Roles { get; set; }  

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=BBPersonelYonetimTakipSistemi;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");

            #region Employees
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employees");

                entity.Property(i => i.ID).HasColumnName("ID").HasColumnType("int").HasMaxLength(100);
                entity.Property(i => i.CreateDate).HasColumnName("CreateDate").HasColumnType("DateTime").HasMaxLength(50).IsRequired(false);
                entity.Property(i => i.UserId).HasColumnName("UserId").HasColumnType("int").HasMaxLength(100).IsRequired(false);
                entity.Property(i => i.CompanyEmail).HasColumnName("CompanyEmail").HasColumnType("nvarchar").HasMaxLength(200);
                entity.Property(i => i.CompanyPhone).HasColumnName("CompanyPhone").HasColumnType("nvarchar").HasMaxLength(100);
                entity.Property(i => i.UserName).HasColumnName("UserName").HasColumnType("nvarchar").HasMaxLength(80);
                entity.Property(i => i.Password).HasColumnName("Password").HasColumnType("nvarchar(max)");
                entity.Property(i => i.StartDateToCompany).HasColumnName("StartDateToCompany").HasColumnType("DateTime").HasMaxLength(100).IsRequired(false);
                entity.Property(i => i.IsActive).HasColumnName("IsActive").HasColumnType("bit").HasMaxLength(10).IsRequired(false);
            });
            #endregion

            #region User

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("Users");
                entity.Property(i => i.ID).HasColumnName("ID").HasColumnType("int").HasMaxLength(100);
                entity.Property(i => i.CreateDate).HasColumnName("CreateDate").HasColumnType("DateTime").HasMaxLength(50).IsRequired(false);
                entity.Property(i => i.Name).HasColumnName("Name").HasColumnType("nvarchar").HasMaxLength(250);
                entity.Property(i => i.Surname).HasColumnName("Surname").HasColumnType("nvarchar").HasMaxLength(250);
                entity.Property(i => i.IdentityNumber).HasColumnName("IdentityNumber").HasColumnType("nvarchar").HasMaxLength(100);
                entity.Property(i => i.Address).HasColumnName("Address").HasColumnType("nvarchar").HasMaxLength(500);
                entity.Property(i => i.Phone).HasColumnName("Phone").HasColumnType("nvarchar").HasMaxLength(100);
                entity.Property(i => i.ProfilePhoto).HasColumnName("ProfilePhoto").HasColumnType("nvarchar").HasMaxLength(3999);
                entity.Property(i => i.BirthDate).HasColumnName("BirthDate").HasColumnType("DateTime").HasMaxLength(50).IsRequired(false);
                entity.Property(i => i.Email).HasColumnName("Email").HasColumnType("nvarchar").HasMaxLength(100);
                entity.Property(i => i.Gender).HasColumnName("Gender").HasColumnType("bit").IsRequired(false);
                entity.Property(i => i.DisabilitySituation).HasColumnName("DisabilitySituation").HasColumnType("nvarchar").HasMaxLength(250);
                entity.Property(i => i.Nationality).HasColumnName("Nationality").HasColumnType("nvarchar").HasMaxLength(100);
                entity.Property(i => i.BloodGroup).HasColumnName("BloodGroup").HasColumnType("nvarchar").HasMaxLength(50);
                entity.Property(i => i.MilitaryStatus).HasColumnName("MilitaryStatus").HasColumnType("nvarchar").HasMaxLength(50);
                entity.Property(i => i.EducationalStatus).HasColumnName("EducationalStatus").HasColumnType("nvarchar").HasMaxLength(50);
                entity.Property(i => i.LastCompletedEducationDegree).HasColumnName("LastCompletedEducationDegree").HasColumnType("nvarchar").HasMaxLength(250);
                entity.Property(i => i.CompletedEducation).HasColumnName("CompletedEducation").HasColumnType("nvarchar").HasMaxLength(100);
                entity.Property(i => i.MaritialSituation).HasColumnName("MaritialSituation").HasColumnType("bit").IsRequired(false);
            });
            #endregion

            #region Department
            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("Departments");

                entity.Property(i => i.ID).HasColumnName("ID").HasColumnType("int").HasMaxLength(50);
                entity.Property(i => i.Name).HasColumnName("Name").HasColumnType("nvarchar").HasMaxLength(250);
                entity.Property(i => i.CreateDate).HasColumnName("CreateDate").HasColumnType("DateTime").HasMaxLength(50).IsRequired(false);
                entity.Property(i => i.CompanyId).HasColumnName("CompanyId").HasColumnType("int").HasMaxLength(100).IsRequired(false);
                entity.Property(i => i.IsActive).HasColumnName("IsActive").HasColumnType("bit").IsRequired(false);
                entity.Property(i => i.ManagerId).HasColumnName("ManagerId").HasColumnType("int").HasMaxLength(50).IsRequired(false);
            });
            #endregion

            #region Status
            modelBuilder.Entity<Status>(entity =>
            {
                entity.ToTable("Statuses");

                entity.Property(i => i.ID).HasColumnName("ID").HasColumnType("int").HasMaxLength(50);
                entity.Property(i => i.Name).HasColumnName("Name").HasColumnType("nvarchar").HasMaxLength(150);
            });
            #endregion

            #region RequestDayOff
            modelBuilder.Entity<Request>(entity =>
            {
                entity.ToTable("RequestDayOffs");
                entity.Property(i => i.ID).HasColumnName("ID").HasColumnType("int").HasMaxLength(50);
                entity.Property(i => i.EmployeeID).HasColumnName("EmployeeID").HasColumnType("int").HasMaxLength(50).IsRequired(false);
                entity.Property(i => i.PermissionTypeId).HasColumnName("PermissionTypeId").HasColumnType("int").HasMaxLength(50).IsRequired(false);
                entity.Property(i => i.StartDate).HasColumnName("StartDate").HasColumnType("DateTime").HasMaxLength(50).IsRequired(false);
                entity.Property(i => i.EndDate).HasColumnName("EndDate").HasColumnType("DateTime").HasMaxLength(50).IsRequired(false);
                entity.Property(i => i.StartTime).HasColumnName("StartTime").HasColumnType("DateTime").HasMaxLength(50).IsRequired(false);
                entity.Property(i => i.EndTime).HasColumnName("EndTime").HasColumnType("DateTime").HasMaxLength(50).IsRequired(false);
                entity.Property(i => i.TotalDuration).HasColumnName("TotalDuration").HasColumnType("float").HasMaxLength(100).IsRequired(false);
                entity.Property(i => i.Description).HasColumnName("Description").HasColumnType("nvarchar").HasMaxLength(250);
                entity.Property(i => i.ReplaceEmployeeId).HasColumnName("ReplaceEmployeeId").HasColumnType("int").HasMaxLength(50).IsRequired(false);
                entity.Property(i => i.IsAccepted).HasColumnName("IsAccepted").HasColumnType("int").HasMaxLength(50);
                entity.Property(i => i.RequestTypeId).HasColumnName("RequestTypeId").HasColumnType("int").HasMaxLength(50).IsRequired(false);
                entity.Property(i => i.CreateDate).HasColumnName("CreateDate").HasColumnType("DateTime").HasMaxLength(50).IsRequired(false);
            });
            #endregion

            #region RequestType
            modelBuilder.Entity<RequestType>(entity =>
            {
                entity.ToTable("RequestTypes");
                entity.Property(i => i.ID).HasColumnName("ID").HasColumnType("int").HasMaxLength(50);
                entity.Property(i => i.Name).HasColumnName("Name").HasColumnType("nvarchar").HasMaxLength(100);

            });
            #endregion

            #region Company
            modelBuilder.Entity<Company>(entity =>
            {
                entity.ToTable("Companies");

                entity.Property(i => i.ID).HasColumnName("ID").HasColumnType("int").HasMaxLength(50);
                entity.Property(i => i.Name).HasColumnName("Name").HasColumnType("nvarchar").HasMaxLength(250);
                entity.Property(i => i.CreateDate).HasColumnName("CreateDate").HasColumnType("DateTime").HasMaxLength(50).IsRequired(false);
                entity.Property(i => i.IsActive).HasColumnName("IsActive").HasColumnType("bit").IsRequired(false);
                entity.Property(i => i.Address).HasColumnName("Address").HasColumnType("nvarchar").HasMaxLength(500);
                entity.Property(i => i.Logo).HasColumnName("Logo").HasColumnType("nvarchar").HasMaxLength(3999);
                entity.Property(i => i.Phone).HasColumnName("Phone").HasColumnType("nvarchar").HasMaxLength(100);
            });
            #endregion

            #region RefreshToken
            modelBuilder.Entity<RefreshTokens>(entity =>
            {
                entity.ToTable("RefreshTokens");

                entity.Property(i => i.ID).HasColumnName("ID").HasColumnType("int");
                entity.Property(i => i.CreateUserID).HasColumnName("CreateUserID").HasColumnType("int");
                entity.Property(i => i.Token).HasColumnName("Token").HasColumnType("nvarchar");
                entity.Property(i => i.Expires).HasColumnName("Expires").HasColumnType("DateTime").HasMaxLength(50);
                entity.Property(i => i.CreateDate).HasColumnName("CreateDate").HasColumnType("DateTime").HasMaxLength(50);
                entity.Property(i => i.Revoked).HasColumnName("Revoked").HasColumnType("DateTime").IsRequired().HasMaxLength(50);
                entity.Property(i => i.CreatedByIp).HasColumnName("CreatedByIp").HasColumnType("nvarchar");
                entity.Property(i => i.RevokedByIp).HasColumnName("RevokedByIp").HasColumnType("nvarchar");
                entity.Property(i => i.ReplaceByToken).HasColumnName("ReplaceByToken").HasColumnType("nvarchar");
                entity.Property(i => i.ReasonRevoked).HasColumnName("ReasonRevoked").HasColumnType("nvarchar");
            });
            #endregion

            #region Career
            modelBuilder.Entity<Career>(entity =>
            {
                entity.ToTable("Careers");

                entity.Property(i => i.ID).HasColumnName("ID").HasColumnType("int").HasMaxLength(50);
                entity.Property(i => i.EmployeeId).HasColumnName("EmployeeId").HasColumnType("int").HasMaxLength(50).IsRequired(false);
                entity.Property(i => i.StartDate).HasColumnName("StartDate").HasColumnType("DateTime").HasMaxLength(50).IsRequired(false);
                entity.Property(i => i.EndDate).HasColumnName("EndDate").HasColumnType("DateTime").HasMaxLength(50).IsRequired(false);
                entity.Property(i => i.DepartmentId).HasColumnName("DepartmentId").HasColumnType("int").HasMaxLength(50).IsRequired(false);
                entity.Property(i => i.BranchId).HasColumnName("BranchId").HasColumnType("int").HasMaxLength(50).IsRequired(false);
                entity.Property(i => i.WorkTypeId).HasColumnName("WorkTypeId").HasColumnType("int").HasMaxLength(50).IsRequired(false);
                entity.Property(i => i.StatusId).HasColumnName("StatusId").HasColumnType("int").HasMaxLength(50).IsRequired(false);
                entity.Property(i => i.CreateDate).HasColumnName("CreateDate").HasColumnType("DateTime").HasMaxLength(50).IsRequired(false);
                entity.Property(i => i.IsActive).HasColumnName("IsActive").HasColumnType("bit").IsRequired(false);
            });
            #endregion

            #region Branch
            modelBuilder.Entity<Branch>(entity =>
            {
                entity.ToTable("Branches");

                entity.Property(i => i.ID).HasColumnName("ID").HasColumnType("int").HasMaxLength(50);
                entity.Property(i => i.Name).HasColumnName("Name").HasColumnType("nvarchar").HasMaxLength(100);
                entity.Property(i => i.CreateDate).HasColumnName("CreateDate").HasColumnType("DateTime").HasMaxLength(100).IsRequired(false);
                entity.Property(i => i.CompanyId).HasColumnName("CompanyId").HasColumnType("int").HasMaxLength(50).IsRequired(false);
                entity.Property(i => i.IsActive).HasColumnName("IsActive").HasColumnType("bit").IsRequired(false);
            });
            #endregion

            #region PermissionSummary
            modelBuilder.Entity<PermissionSummary>(entity =>
            {
                entity.ToTable("PermissionSummaries");

                entity.Property(i => i.ID).HasColumnName("ID").HasColumnType("int").HasMaxLength(50);
                entity.Property(i => i.EmployeeId).HasColumnName("EmployeeId").HasColumnType("int").HasMaxLength(50).IsRequired(false);
                entity.Property(i => i.RequestTypeId).HasColumnName("RequestTypeId").HasColumnType("int").HasMaxLength(50).IsRequired(false);
                entity.Property(i => i.TotalPermissionDay).HasColumnName("TotalPermissionDay").HasColumnType("float").IsRequired(false);
                entity.Property(i => i.UsedPermissionDay).HasColumnName("UsedPermissionDay").HasColumnType("float").IsRequired(false);
            });
            #endregion

            #region PermissionType
            modelBuilder.Entity<PermissionType>(entity =>
            {
                entity.ToTable("PermissionTypes");

                entity.Property(i => i.ID).HasColumnName("ID").HasColumnType("int").HasMaxLength(50);
                entity.Property(i => i.Name).HasColumnName("Name").HasColumnType("nvarchar").HasMaxLength(150);
                entity.Property(i => i.TotalValue).HasColumnName("TotalValue").HasColumnType("int").HasMaxLength(50).IsRequired(false);
                entity.Property(i => i.PermissionKind).HasColumnName("PermissionKind").HasColumnType("nvarchar").HasMaxLength(100).IsRequired(false);
                entity.Property(i => i.CreateDate).HasColumnName("CreateDate").HasColumnType("DateTime").HasMaxLength(50);
                entity.Property(i => i.Desctription).HasColumnName("Desctription").HasColumnType("nvarchar").HasMaxLength(3999);
            });
            #endregion

            #region TimeDay
            modelBuilder.Entity<TimeDay>(entity =>
            {
                entity.ToTable("TimeDays");

                entity.Property(i => i.ID).HasColumnName("ID").HasColumnType("int").HasMaxLength(50);
                entity.Property(i => i.TimeValue).HasColumnName("TimeValue").HasColumnType("DateTime").HasMaxLength(50).IsRequired(false);
                entity.Property(i => i.Year).HasColumnName("Year").HasColumnType("int").HasMaxLength(50).IsRequired(false);
                entity.Property(i => i.Month).HasColumnName("Month").HasColumnType("int").HasMaxLength(50).IsRequired(false);
                entity.Property(i => i.Day).HasColumnName("Day").HasColumnType("int").HasMaxLength(50).IsRequired(false);
                entity.Property(i => i.Quarter).HasColumnName("Quarter").HasColumnType("int").HasMaxLength(50).IsRequired(false);
                entity.Property(i => i.Week).HasColumnName("Week").HasColumnType("int").HasMaxLength(50).IsRequired(false);
                entity.Property(i => i.WeekOfMonthStartingMonDate).HasColumnName("WeekOfMonthStartingMonDate").HasColumnType("int").HasMaxLength(50).IsRequired(false);
                entity.Property(i => i.WeekOfMonthStartingWedDate).HasColumnName("WeekOfMonthStartingWedDate").HasColumnType("int").HasMaxLength(50).IsRequired(false);
                entity.Property(i => i.DayOfWeek).HasColumnName("DayOfWeek").HasColumnType("int").HasMaxLength(50).IsRequired(false);
                entity.Property(i => i.DayOfYear).HasColumnName("DayOfYear").HasColumnType("int").HasMaxLength(50).IsRequired(false);
                entity.Property(i => i.DayOfMonth).HasColumnName("DayOfMonth").HasColumnType("int").HasMaxLength(50).IsRequired(false);
                entity.Property(i => i.DayName).HasColumnName("DayName").HasColumnType("nvarchar").HasMaxLength(50).IsRequired(false);
                entity.Property(i => i.DayNameTr).HasColumnName("DayNameTr").HasColumnType("nvarchar").HasMaxLength(50).IsRequired(false);
                entity.Property(i => i.MonthName).HasColumnName("MonthName").HasColumnType("nvarchar").HasMaxLength(50).IsRequired(false);
                entity.Property(i => i.MonthNameTr).HasColumnName("MonthNameTr").HasColumnType("nvarchar").HasMaxLength(50).IsRequired(false);
                entity.Property(i => i.TimeDayTypeId).HasColumnName("TimeDayTypeId").HasColumnType("int").HasMaxLength(50).IsRequired(false);
            });
            #endregion

            #region TimeDayType
            modelBuilder.Entity<TimeDayType>(entity =>
            {
                entity.ToTable("TimeDayTypes");

                entity.Property(i => i.ID).HasColumnName("ID").HasColumnType("int").HasMaxLength(50);
                entity.Property(i => i.Explanation).HasColumnName("Explanation").HasColumnType("nvarchar").HasMaxLength(200);
                entity.Property(i => i.EffectDay).HasColumnName("EffectDay").HasColumnType("float").IsRequired(false);
            });
            #endregion

            #region WorkType
            modelBuilder.Entity<WorkType>(entity =>
            {
                entity.ToTable("WorkTypes");

                entity.Property(i => i.ID).HasColumnName("ID").HasColumnType("int").HasMaxLength(50);
                entity.Property(i => i.Name).HasColumnName("Name").HasColumnType("nvarchar").HasMaxLength(100);
            });
            #endregion

            #region UserRole
            
                  modelBuilder.Entity<UserRole>(entity =>
                  {
                      entity.ToTable("UserRoles");

                      entity.Property(i => i.ID).HasColumnName("ID").HasColumnType("int").HasMaxLength(50);
                      entity.Property(i => i.CreateDate).HasColumnName("CreateDate").HasColumnType("DateTime").HasMaxLength(50);
                      entity.Property(i => i.EmployeeId).HasColumnName("EmployeeId").HasColumnType("int");
                      entity.Property(i => i.RoleId).HasColumnName("RoleId").HasColumnType("int");

                  });
            #endregion

            #region Role
            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Roles");

                entity.Property(i => i.ID).HasColumnName("ID").HasColumnType("int").HasMaxLength(50);
                entity.Property(i => i.CreateDate).HasColumnName("CreateDate").HasColumnType("DateTime").HasMaxLength(50);
                entity.Property(i => i.Name).HasColumnName("Name").HasColumnType("nvarchar").HasMaxLength(100);
            });
            #endregion
        }
    }
}
