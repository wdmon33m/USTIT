using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace USTIT.Services.StudentAPI.Migrations
{
    /// <inheritdoc />
    public partial class addReligionTableAndSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Religions",
                columns: table => new
                {
                    ReligionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReligionNameAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReligionNameEn = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Religions", x => x.ReligionId);
                });

            migrationBuilder.InsertData(
                table: "Religions",
                columns: new[] { "ReligionId", "ReligionNameAr", "ReligionNameEn" },
                values: new object[,]
                {
                    { 1, "مسلم", "MUSLIM" },
                    { 2, "مسيحي", "CHRISTIAN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Religions");
        }
    }
}
