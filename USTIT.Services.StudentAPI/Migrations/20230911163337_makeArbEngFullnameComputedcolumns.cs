using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace USTIT.Services.StudentAPI.Migrations
{
    /// <inheritdoc />
    public partial class makeArbEngFullnameComputedcolumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "EnFullName",
                table: "StudentNames",
                type: "nvarchar(max)",
                nullable: true,
                computedColumnSql: "[EnFirstName] + ' ' + [EnSecondName] + ' ' + [EnThirdName] + ' ' + [EnFourthName]",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ArFullName",
                table: "StudentNames",
                type: "nvarchar(max)",
                nullable: true,
                computedColumnSql: "[ArFirstName] + ' ' + [ArSecondName] + ' ' + [ArThirdName] + ' ' + [ArFourthName]",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "EnFullName",
                table: "StudentNames",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldComputedColumnSql: "[EnFirstName] + ' ' + [EnSecondName] + ' ' + [EnThirdName] + ' ' + [EnFourthName]");

            migrationBuilder.AlterColumn<string>(
                name: "ArFullName",
                table: "StudentNames",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldComputedColumnSql: "[ArFirstName] + ' ' + [ArSecondName] + ' ' + [ArThirdName] + ' ' + [ArFourthName]");
        }
    }
}
