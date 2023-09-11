using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace USTIT.Services.StudentAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateNathionalityTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NationalityNameEn",
                table: "Nationalities",
                newName: "NationalityEn");

            migrationBuilder.RenameColumn(
                name: "NationalityNameAr",
                table: "Nationalities",
                newName: "NationalityAr");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NationalityEn",
                table: "Nationalities",
                newName: "NationalityNameEn");

            migrationBuilder.RenameColumn(
                name: "NationalityAr",
                table: "Nationalities",
                newName: "NationalityNameAr");
        }
    }
}
