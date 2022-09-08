using Microsoft.EntityFrameworkCore.Migrations;

namespace BB.PersonelYonetimTakipSistemi.Data.Migrations
{
    public partial class mig6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LastCompletedEducationDegree",
                schema: "dbo",
                table: "Users",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastCompletedEducationDegree",
                schema: "dbo",
                table: "Users");
        }
    }
}
