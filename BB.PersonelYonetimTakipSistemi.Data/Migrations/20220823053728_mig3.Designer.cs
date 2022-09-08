﻿// <auto-generated />
using System;
using BB.PersonelYonetimTakipSistemi.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BB.PersonelYonetimTakipSistemi.Data.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20220823053728_mig3")]
    partial class mig3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("dbo")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BB.PersonelYonetimTakipSistemi.Data.Model.Branch", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CompanyId")
                        .HasMaxLength(50)
                        .HasColumnType("int")
                        .HasColumnName("CompanyId");

                    b.Property<DateTime>("CreateDate")
                        .HasMaxLength(100)
                        .HasColumnType("DateTime")
                        .HasColumnName("CreateDate");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit")
                        .HasColumnName("IsActive");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Name");

                    b.HasKey("ID");

                    b.ToTable("Branches");
                });

            modelBuilder.Entity("BB.PersonelYonetimTakipSistemi.Data.Model.Career", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BranchId")
                        .HasMaxLength(50)
                        .HasColumnType("int")
                        .HasColumnName("BranchId");

                    b.Property<DateTime>("CreateDate")
                        .HasMaxLength(50)
                        .HasColumnType("DateTime")
                        .HasColumnName("CreateDate");

                    b.Property<int>("DepartmentId")
                        .HasMaxLength(50)
                        .HasColumnType("int")
                        .HasColumnName("DepartmentId");

                    b.Property<int>("EmployeeId")
                        .HasMaxLength(50)
                        .HasColumnType("int")
                        .HasColumnName("EmployeeId");

                    b.Property<DateTime>("EndDate")
                        .HasMaxLength(50)
                        .HasColumnType("DateTime")
                        .HasColumnName("EndDate");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit")
                        .HasColumnName("IsActive");

                    b.Property<DateTime>("StartDate")
                        .HasMaxLength(50)
                        .HasColumnType("DateTime")
                        .HasColumnName("StartDate");

                    b.Property<int>("StatusId")
                        .HasMaxLength(50)
                        .HasColumnType("int")
                        .HasColumnName("StatusId");

                    b.Property<int>("WorkTypeId")
                        .HasMaxLength(50)
                        .HasColumnType("int")
                        .HasColumnName("WorkTypeId");

                    b.HasKey("ID");

                    b.ToTable("Careers");
                });

            modelBuilder.Entity("BB.PersonelYonetimTakipSistemi.Data.Model.Company", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasColumnName("Address");

                    b.Property<DateTime>("CreateDate")
                        .HasMaxLength(50)
                        .HasColumnType("DateTime")
                        .HasColumnName("CreateDate");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit")
                        .HasColumnName("IsActive");

                    b.Property<string>("Logo")
                        .HasColumnType("nvarchar")
                        .HasColumnName("Logo");

                    b.Property<string>("Name")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("Name");

                    b.Property<string>("Phone")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Phone");

                    b.HasKey("ID");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("BB.PersonelYonetimTakipSistemi.Data.Model.Department", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CompanyId")
                        .HasMaxLength(100)
                        .HasColumnType("int")
                        .HasColumnName("CompanyId");

                    b.Property<DateTime>("CreateDate")
                        .HasMaxLength(50)
                        .HasColumnType("DateTime")
                        .HasColumnName("CreateDate");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit")
                        .HasColumnName("IsActive");

                    b.Property<int>("ManagerId")
                        .HasMaxLength(50)
                        .HasColumnType("int")
                        .HasColumnName("ManagerId");

                    b.Property<string>("Name")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("Name");

                    b.HasKey("ID");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("BB.PersonelYonetimTakipSistemi.Data.Model.Employee", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(100)
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CompanyEmail")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("CompanyEmail");

                    b.Property<string>("CompanyPhone")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("CompanyPhone");

                    b.Property<DateTime>("CreateDate")
                        .HasMaxLength(50)
                        .HasColumnType("DateTime")
                        .HasColumnName("CreateDate");

                    b.Property<bool>("IsActive")
                        .HasMaxLength(10)
                        .HasColumnType("bit")
                        .HasColumnName("IsActive");

                    b.Property<string>("Password")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("Password");

                    b.Property<DateTime>("StartDateToCompany")
                        .HasMaxLength(100)
                        .HasColumnType("DateTime")
                        .HasColumnName("StartDateToCompany");

                    b.Property<int>("UserId")
                        .HasMaxLength(100)
                        .HasColumnType("int")
                        .HasColumnName("UserId");

                    b.Property<string>("UserName")
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)")
                        .HasColumnName("UserName");

                    b.HasKey("ID");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("BB.PersonelYonetimTakipSistemi.Data.Model.PermissionSummary", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EmployeeId")
                        .HasMaxLength(50)
                        .HasColumnType("int")
                        .HasColumnName("EmployeeId");

                    b.Property<int>("RequestTypeId")
                        .HasMaxLength(50)
                        .HasColumnType("int")
                        .HasColumnName("RequestTypeId");

                    b.Property<double>("TotalPermissionDay")
                        .HasColumnType("float")
                        .HasColumnName("TotalPermissionDay");

                    b.Property<double>("UsedPermissionDay")
                        .HasColumnType("float")
                        .HasColumnName("UsedPermissionDay");

                    b.HasKey("ID");

                    b.ToTable("PermissionSummaries");
                });

            modelBuilder.Entity("BB.PersonelYonetimTakipSistemi.Data.Model.PermissionType", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDate")
                        .HasMaxLength(50)
                        .HasColumnType("DateTime")
                        .HasColumnName("CreateDate");

                    b.Property<string>("Desctription")
                        .HasColumnType("nvarchar")
                        .HasColumnName("Desctription");

                    b.Property<string>("Name")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("Name");

                    b.Property<string>("PermissionKind")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("PermissionKind");

                    b.Property<int>("TotalValue")
                        .HasMaxLength(50)
                        .HasColumnType("int")
                        .HasColumnName("TotalValue");

                    b.HasKey("ID");

                    b.ToTable("PermissionTypes");
                });

            modelBuilder.Entity("BB.PersonelYonetimTakipSistemi.Data.Model.RefreshTokens", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDate")
                        .HasMaxLength(50)
                        .HasColumnType("DateTime")
                        .HasColumnName("CreateDate");

                    b.Property<int>("CreateUserID")
                        .HasColumnType("int")
                        .HasColumnName("CreateUserID");

                    b.Property<string>("CreatedByIp")
                        .HasColumnType("nvarchar")
                        .HasColumnName("CreatedByIp");

                    b.Property<DateTime>("Expires")
                        .HasMaxLength(50)
                        .HasColumnType("DateTime")
                        .HasColumnName("Expires");

                    b.Property<string>("ReasonRevoked")
                        .HasColumnType("nvarchar")
                        .HasColumnName("ReasonRevoked");

                    b.Property<string>("ReplaceByToken")
                        .HasColumnType("nvarchar")
                        .HasColumnName("ReplaceByToken");

                    b.Property<DateTime>("Revoked")
                        .HasMaxLength(50)
                        .HasColumnType("DateTime")
                        .HasColumnName("Revoked");

                    b.Property<string>("RevokedByIp")
                        .HasColumnType("nvarchar")
                        .HasColumnName("RevokedByIp");

                    b.Property<string>("Token")
                        .HasColumnType("nvarchar")
                        .HasColumnName("Token");

                    b.HasKey("ID");

                    b.ToTable("RefreshTokens");
                });

            modelBuilder.Entity("BB.PersonelYonetimTakipSistemi.Data.Model.Request", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDate")
                        .HasMaxLength(50)
                        .HasColumnType("DateTime")
                        .HasColumnName("CreateDate");

                    b.Property<string>("Description")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("Description");

                    b.Property<int>("EmployeeID")
                        .HasMaxLength(50)
                        .HasColumnType("int")
                        .HasColumnName("EmployeeID");

                    b.Property<DateTime>("EndDate")
                        .HasMaxLength(50)
                        .HasColumnType("DateTime")
                        .HasColumnName("EndDate");

                    b.Property<DateTime>("EndTime")
                        .HasMaxLength(50)
                        .HasColumnType("DateTime")
                        .HasColumnName("EndTime");

                    b.Property<int?>("IsAccepted")
                        .HasMaxLength(50)
                        .HasColumnType("int")
                        .HasColumnName("IsAccepted");

                    b.Property<int>("PermissionTypeId")
                        .HasMaxLength(50)
                        .HasColumnType("int")
                        .HasColumnName("PermissionTypeId");

                    b.Property<int?>("ReplaceEmployeeId")
                        .HasMaxLength(50)
                        .HasColumnType("int")
                        .HasColumnName("ReplaceEmployeeId");

                    b.Property<int>("RequestTypeId")
                        .HasMaxLength(50)
                        .HasColumnType("int")
                        .HasColumnName("RequestTypeId");

                    b.Property<DateTime>("StartDate")
                        .HasMaxLength(50)
                        .HasColumnType("DateTime")
                        .HasColumnName("StartDate");

                    b.Property<DateTime>("StartTime")
                        .HasMaxLength(50)
                        .HasColumnType("DateTime")
                        .HasColumnName("StartTime");

                    b.Property<double>("TotalDuration")
                        .HasMaxLength(100)
                        .HasColumnType("float")
                        .HasColumnName("TotalDuration");

                    b.HasKey("ID");

                    b.ToTable("RequestDayOffs");
                });

            modelBuilder.Entity("BB.PersonelYonetimTakipSistemi.Data.Model.RequestType", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Name");

                    b.HasKey("ID");

                    b.ToTable("RequestTypes");
                });

            modelBuilder.Entity("BB.PersonelYonetimTakipSistemi.Data.Model.Status", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("Name");

                    b.HasKey("ID");

                    b.ToTable("Statuses");
                });

            modelBuilder.Entity("BB.PersonelYonetimTakipSistemi.Data.Model.TimeDay", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Day")
                        .HasMaxLength(50)
                        .HasColumnType("int")
                        .HasColumnName("Day");

                    b.Property<string>("DayName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("DayName");

                    b.Property<string>("DayNameTr")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("DayNameTr");

                    b.Property<int>("DayOfMonth")
                        .HasMaxLength(50)
                        .HasColumnType("int")
                        .HasColumnName("DayOfMonth");

                    b.Property<int>("DayOfWeek")
                        .HasMaxLength(50)
                        .HasColumnType("int")
                        .HasColumnName("DayOfWeek");

                    b.Property<int>("DayOfYear")
                        .HasMaxLength(50)
                        .HasColumnType("int")
                        .HasColumnName("DayOfYear");

                    b.Property<int>("Month")
                        .HasMaxLength(50)
                        .HasColumnType("int")
                        .HasColumnName("Month");

                    b.Property<string>("MonthName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("MonthName");

                    b.Property<string>("MonthNameTr")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("MonthNameTr");

                    b.Property<int>("Quarter")
                        .HasMaxLength(50)
                        .HasColumnType("int")
                        .HasColumnName("Quarter");

                    b.Property<int>("TimeDayTypeId")
                        .HasMaxLength(50)
                        .HasColumnType("int")
                        .HasColumnName("TimeDayTypeId");

                    b.Property<DateTime>("TimeValue")
                        .HasMaxLength(50)
                        .HasColumnType("DateTime")
                        .HasColumnName("TimeValue");

                    b.Property<int>("Week")
                        .HasMaxLength(50)
                        .HasColumnType("int")
                        .HasColumnName("Week");

                    b.Property<int>("WeekOfMonthStartingMonDate")
                        .HasMaxLength(50)
                        .HasColumnType("int")
                        .HasColumnName("WeekOfMonthStartingMonDate");

                    b.Property<int>("WeekOfMonthStartingWedDate")
                        .HasMaxLength(50)
                        .HasColumnType("int")
                        .HasColumnName("WeekOfMonthStartingWedDate");

                    b.Property<int>("Year")
                        .HasMaxLength(50)
                        .HasColumnType("int")
                        .HasColumnName("Year");

                    b.HasKey("ID");

                    b.ToTable("TimeDays");
                });

            modelBuilder.Entity("BB.PersonelYonetimTakipSistemi.Data.Model.TimeDayType", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("EffectDay")
                        .HasColumnType("float")
                        .HasColumnName("EffectDay");

                    b.Property<string>("Explanation")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("Explanation");

                    b.HasKey("ID");

                    b.ToTable("TimeDayTypes");
                });

            modelBuilder.Entity("BB.PersonelYonetimTakipSistemi.Data.Model.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(100)
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasColumnName("Address");

                    b.Property<DateTime>("BirthDate")
                        .HasMaxLength(50)
                        .HasColumnType("DateTime")
                        .HasColumnName("BirthDate");

                    b.Property<string>("BloodGroup")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("BloodGroup");

                    b.Property<string>("CompletedEducation")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("CompletedEducation");

                    b.Property<DateTime>("CreateDate")
                        .HasMaxLength(50)
                        .HasColumnType("DateTime")
                        .HasColumnName("CreateDate");

                    b.Property<string>("DisabilitySituation")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("DisabilitySituation");

                    b.Property<string>("EducationalStatus")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("EducationalStatus");

                    b.Property<string>("Email")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Email");

                    b.Property<bool>("Gender")
                        .HasColumnType("bit")
                        .HasColumnName("Gender");

                    b.Property<string>("IdentityNumber")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("IdentityNumber");

                    b.Property<bool>("MaritialSituation")
                        .HasColumnType("bit")
                        .HasColumnName("MaritialSituation");

                    b.Property<string>("MilitaryStatus")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("MilitaryStatus");

                    b.Property<string>("Name")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("Name");

                    b.Property<string>("Nationality")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Nationality");

                    b.Property<string>("Phone")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Phone");

                    b.Property<string>("ProfilePhoto")
                        .HasColumnType("nvarchar")
                        .HasColumnName("ProfilePhoto");

                    b.Property<string>("Surname")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("Surname");

                    b.HasKey("ID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BB.PersonelYonetimTakipSistemi.Data.Model.WorkType", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Name");

                    b.HasKey("ID");

                    b.ToTable("WorkTypes");
                });
#pragma warning restore 612, 618
        }
    }
}
