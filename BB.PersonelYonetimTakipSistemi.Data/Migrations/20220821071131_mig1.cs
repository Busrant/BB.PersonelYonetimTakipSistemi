using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BB.PersonelYonetimTakipSistemi.Data.Migrations
{
    public partial class mig1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Branches",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", maxLength: 50, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "DateTime", maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Careers",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", maxLength: 50, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "DateTime", maxLength: 50, nullable: false),
                    EndDate = table.Column<DateTime>(type: "DateTime", maxLength: 50, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "DateTime", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Careers", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", maxLength: 50, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "DateTime", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Logo = table.Column<string>(type: "nvarchar", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", maxLength: 50, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "DateTime", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ManagerId = table.Column<int>(type: "int", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", maxLength: 100, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(type: "DateTime", maxLength: 50, nullable: false),
                    CompanyEmail = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CompanyPhone = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    StartDateToCompany = table.Column<DateTime>(type: "DateTime", maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PermissionSummaries",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", maxLength: 50, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalPermissionDay = table.Column<double>(type: "float", nullable: false),
                    UsedPermissionDay = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionSummaries", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PermissionTypes",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", maxLength: 50, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    TotalValue = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    PermissionKind = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "DateTime", maxLength: 50, nullable: false),
                    Desctription = table.Column<string>(type: "nvarchar", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Token = table.Column<string>(type: "nvarchar", nullable: true),
                    Expires = table.Column<DateTime>(type: "DateTime", maxLength: 50, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "DateTime", maxLength: 50, nullable: false),
                    Revoked = table.Column<DateTime>(type: "DateTime", maxLength: 50, nullable: false),
                    CreatedByIp = table.Column<string>(type: "nvarchar", nullable: true),
                    RevokedByIp = table.Column<string>(type: "nvarchar", nullable: true),
                    ReplaceByToken = table.Column<string>(type: "nvarchar", nullable: true),
                    ReasonRevoked = table.Column<string>(type: "nvarchar", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "RequestDayOffs",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", maxLength: 50, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "DateTime", maxLength: 50, nullable: false),
                    EndDate = table.Column<DateTime>(type: "DateTime", maxLength: 50, nullable: false),
                    StartTime = table.Column<DateTime>(type: "DateTime", maxLength: 50, nullable: false),
                    EndTime = table.Column<DateTime>(type: "DateTime", maxLength: 50, nullable: false),
                    TotalDuration = table.Column<double>(type: "float", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    IsAccepted = table.Column<int>(type: "int", maxLength: 50, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "DateTime", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestDayOffs", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "RequestTypes",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", maxLength: 50, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Statuses",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", maxLength: 50, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TimeDays",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", maxLength: 50, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimeValue = table.Column<DateTime>(type: "DateTime", maxLength: 50, nullable: false),
                    Year = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    Month = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    Day = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    Quarter = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    Week = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    WeekOfMonthStartingMonDate = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    WeekOfMonthStartingWedDate = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    DayOfWeek = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    DayOfYear = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    DayOfMonth = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    DayName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DayNameTr = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MonthName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MonthNameTr = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeDays", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TimeDayTypes",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", maxLength: 50, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Explanation = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    EffectDay = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeDayTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", maxLength: 100, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(type: "DateTime", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    IdentityNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ProfilePhoto = table.Column<string>(type: "nvarchar", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "DateTime", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Gender = table.Column<bool>(type: "bit", nullable: false),
                    DisabilitySituation = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Nationality = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    BloodGroup = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MilitaryStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EducationalStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CompletedEducation = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    MaritialSituation = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "WorkTypes",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", maxLength: 50, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkTypes", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Branches",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Careers",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Companies",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Departments",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Employees",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "PermissionSummaries",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "PermissionTypes",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "RefreshTokens",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "RequestDayOffs",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "RequestTypes",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Statuses",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "TimeDays",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "TimeDayTypes",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "WorkTypes",
                schema: "dbo");
        }
    }
}
