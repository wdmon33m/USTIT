using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace USTIT.Services.BasicDataAPI.Migrations
{
    /// <inheritdoc />
    public partial class removeHallTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Halls");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Halls",
                columns: table => new
                {
                    HallNo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExamCapacity = table.Column<int>(type: "int", nullable: false),
                    HallName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LectureCapacity = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Halls", x => x.HallNo);
                });
        }
    }
}
