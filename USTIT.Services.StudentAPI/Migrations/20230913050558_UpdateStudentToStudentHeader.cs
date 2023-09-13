using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace USTIT.Services.StudentAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateStudentToStudentHeader : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentNames_Students_FullStdID",
                table: "StudentNames");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Students",
                table: "Students");

            migrationBuilder.RenameTable(
                name: "Students",
                newName: "StudentHeaders");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentHeaders",
                table: "StudentHeaders",
                column: "FullStdID");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentNames_StudentHeaders_FullStdID",
                table: "StudentNames",
                column: "FullStdID",
                principalTable: "StudentHeaders",
                principalColumn: "FullStdID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentNames_StudentHeaders_FullStdID",
                table: "StudentNames");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentHeaders",
                table: "StudentHeaders");

            migrationBuilder.RenameTable(
                name: "StudentHeaders",
                newName: "Students");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Students",
                table: "Students",
                column: "FullStdID");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentNames_Students_FullStdID",
                table: "StudentNames",
                column: "FullStdID",
                principalTable: "Students",
                principalColumn: "FullStdID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
