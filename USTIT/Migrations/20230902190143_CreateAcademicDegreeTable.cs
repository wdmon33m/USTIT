using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace USTIT.Services.BasicDataAPI.Migrations
{
    /// <inheritdoc />
    public partial class CreateAcademicDegreeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AcademicDegrees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AcademicDegreeArb = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AcademicDegreeEng = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademicDegrees", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AcademicDegrees",
                columns: new[] { "Id", "AcademicDegreeArb", "AcademicDegreeEng" },
                values: new object[,]
                {
                    { 1, "بروفيسور", "Professor" },
                    { 2, "دكتور", "Doctor" },
                    { 3, "ماجستير", "Master's" },
                    { 4, "بكلاريوس", "Bachelor's" },
                    { 5, "دبلوم", "Diploma" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AcademicDegrees");
        }
    }
}
