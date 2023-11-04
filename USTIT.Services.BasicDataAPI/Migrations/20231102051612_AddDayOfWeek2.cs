using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace USTIT.Services.BasicDataAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddDayOfWeek2 : Migration
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
                    Day = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    { 1, "Saturday", "السبت" },
                    { 2, "Sunday", "الأحد" },
                    { 3, "Monday", "الإثنين" },
                    { 4, "Tuesday", "الثلاثاء" },
                    { 5, "Wednesday", "الأربعاء" },
                    { 6, "Thursday", "الخميس" },
                    { 7, "Friday", "الجمعة" }
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
