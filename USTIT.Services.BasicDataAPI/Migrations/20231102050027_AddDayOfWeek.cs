using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace USTIT.Services.BasicDataAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddDayOfWeek : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WeekDays",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Day = table.Column<int>(type: "int", nullable: false),
                    DayArb = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeekDays", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "WeekDays",
                columns: new[] { "Id", "Day", "DayArb" },
                values: new object[,]
                {
                    { 1, 6, "السبت" },
                    { 2, 0, "الأحد" },
                    { 3, 1, "الإثنين" },
                    { 4, 2, "الثلاثاء" },
                    { 5, 3, "الأربعاء" },
                    { 6, 4, "الخميس" },
                    { 7, 5, "الجمعة" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_WeekDays_Day",
                table: "WeekDays",
                column: "Day",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WeekDays_DayArb",
                table: "WeekDays",
                column: "DayArb",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WeekDays");
        }
    }
}
