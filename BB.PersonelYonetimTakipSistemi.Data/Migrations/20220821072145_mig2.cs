using Microsoft.EntityFrameworkCore.Migrations;

namespace BB.PersonelYonetimTakipSistemi.Data.Migrations
{
    public partial class mig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TimeDayTypeId",
                schema: "dbo",
                table: "TimeDays",
                type: "int",
                maxLength: 50,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EmployeeID",
                schema: "dbo",
                table: "RequestDayOffs",
                type: "int",
                maxLength: 50,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PermissionTypeId",
                schema: "dbo",
                table: "RequestDayOffs",
                type: "int",
                maxLength: 50,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ReplaceEmployeeId",
                schema: "dbo",
                table: "RequestDayOffs",
                type: "int",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RequestTypeId",
                schema: "dbo",
                table: "RequestDayOffs",
                type: "int",
                maxLength: 50,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CreateUserID",
                schema: "dbo",
                table: "RefreshTokens",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                schema: "dbo",
                table: "PermissionSummaries",
                type: "int",
                maxLength: 50,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RequestTypeId",
                schema: "dbo",
                table: "PermissionSummaries",
                type: "int",
                maxLength: 50,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                schema: "dbo",
                table: "Employees",
                type: "int",
                maxLength: 100,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                schema: "dbo",
                table: "Departments",
                type: "int",
                maxLength: 100,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BranchId",
                schema: "dbo",
                table: "Careers",
                type: "int",
                maxLength: 50,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                schema: "dbo",
                table: "Careers",
                type: "int",
                maxLength: 50,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                schema: "dbo",
                table: "Careers",
                type: "int",
                maxLength: 50,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                schema: "dbo",
                table: "Careers",
                type: "int",
                maxLength: 50,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WorkTypeId",
                schema: "dbo",
                table: "Careers",
                type: "int",
                maxLength: 50,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                schema: "dbo",
                table: "Branches",
                type: "int",
                maxLength: 50,
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TimeDayTypeId",
                schema: "dbo",
                table: "TimeDays");

            migrationBuilder.DropColumn(
                name: "EmployeeID",
                schema: "dbo",
                table: "RequestDayOffs");

            migrationBuilder.DropColumn(
                name: "PermissionTypeId",
                schema: "dbo",
                table: "RequestDayOffs");

            migrationBuilder.DropColumn(
                name: "ReplaceEmployeeId",
                schema: "dbo",
                table: "RequestDayOffs");

            migrationBuilder.DropColumn(
                name: "RequestTypeId",
                schema: "dbo",
                table: "RequestDayOffs");

            migrationBuilder.DropColumn(
                name: "CreateUserID",
                schema: "dbo",
                table: "RefreshTokens");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                schema: "dbo",
                table: "PermissionSummaries");

            migrationBuilder.DropColumn(
                name: "RequestTypeId",
                schema: "dbo",
                table: "PermissionSummaries");

            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "dbo",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                schema: "dbo",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "BranchId",
                schema: "dbo",
                table: "Careers");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                schema: "dbo",
                table: "Careers");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                schema: "dbo",
                table: "Careers");

            migrationBuilder.DropColumn(
                name: "StatusId",
                schema: "dbo",
                table: "Careers");

            migrationBuilder.DropColumn(
                name: "WorkTypeId",
                schema: "dbo",
                table: "Careers");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                schema: "dbo",
                table: "Branches");
        }
    }
}
