using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace USTIT.Services.BasicDataAPI.Migrations
{
    /// <inheritdoc />
    public partial class CreateDepartmentTableAndSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DeptCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DepartmentNameEng = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DepartmentNameArb = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SemCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DeptCode);
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DeptCode", "DepartmentNameArb", "DepartmentNameEng", "SemCount" },
                values: new object[,]
                {
                    { "CSCSB", "علوم الحاسوب", "Computer Science (B.Sc.)", 8 },
                    { "CSTCB", "تكنولوجيا المعلومات و الاتصالات", "Information and Communication Technology (B.Sc.)", 8 },
                    { "ITISB", "نظم المعلومات", "Information System (B.Sc.)", 8 },
                    { "ITITB", "بكالوريوس تقنية المـعلومات", "Information Technology (B.Sc.)", 8 },
                    { "ITITD", "دبلوم تقنية المعلومات", "Information Technology (ASc.)", 6 },
                    { "ITNWD", "دبلوم تقنية نظم شبكات الحاسوب", "Networking (ASc.)", 6 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Departments_DepartmentNameArb",
                table: "Departments",
                column: "DepartmentNameArb",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Departments_DepartmentNameEng",
                table: "Departments",
                column: "DepartmentNameEng",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
