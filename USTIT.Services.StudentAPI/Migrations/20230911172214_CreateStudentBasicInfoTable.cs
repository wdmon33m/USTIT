using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace USTIT.Services.StudentAPI.Migrations
{
    /// <inheritdoc />
    public partial class CreateStudentBasicInfoTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StudentBasicInfos",
                columns: table => new
                {
                    FullStdID = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    Batch = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NationalityNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NationalityId = table.Column<int>(type: "int", nullable: false),
                    ReligionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentBasicInfos", x => x.FullStdID);
                    table.ForeignKey(
                        name: "FK_StudentBasicInfos_Nationalities_NationalityId",
                        column: x => x.NationalityId,
                        principalTable: "Nationalities",
                        principalColumn: "NationalityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentBasicInfos_Religions_ReligionId",
                        column: x => x.ReligionId,
                        principalTable: "Religions",
                        principalColumn: "ReligionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentBasicInfos_NationalityId",
                table: "StudentBasicInfos",
                column: "NationalityId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentBasicInfos_ReligionId",
                table: "StudentBasicInfos",
                column: "ReligionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentBasicInfos");
        }
    }
}
