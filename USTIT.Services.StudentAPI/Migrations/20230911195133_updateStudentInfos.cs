using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace USTIT.Services.StudentAPI.Migrations
{
    /// <inheritdoc />
    public partial class updateStudentInfos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NatId",
                table: "StudentBasicInfos");

            migrationBuilder.DropColumn(
                name: "ReID",
                table: "StudentBasicInfos");

            migrationBuilder.AlterColumn<int>(
                name: "ReligionId",
                table: "StudentBasicInfos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NationalityNo",
                table: "StudentBasicInfos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "NationalityId",
                table: "StudentBasicInfos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "StudentBasicInfos",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.CreateIndex(
                name: "IX_StudentBasicInfos_NationalityId",
                table: "StudentBasicInfos",
                column: "NationalityId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentBasicInfos_ReligionId",
                table: "StudentBasicInfos",
                column: "ReligionId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentBasicInfos_Nationalities_NationalityId",
                table: "StudentBasicInfos",
                column: "NationalityId",
                principalTable: "Nationalities",
                principalColumn: "NationalityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentBasicInfos_Religions_ReligionId",
                table: "StudentBasicInfos",
                column: "ReligionId",
                principalTable: "Religions",
                principalColumn: "ReligionId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentBasicInfos_Nationalities_NationalityId",
                table: "StudentBasicInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentBasicInfos_Religions_ReligionId",
                table: "StudentBasicInfos");

            migrationBuilder.DropIndex(
                name: "IX_StudentBasicInfos_NationalityId",
                table: "StudentBasicInfos");

            migrationBuilder.DropIndex(
                name: "IX_StudentBasicInfos_ReligionId",
                table: "StudentBasicInfos");

            migrationBuilder.AlterColumn<int>(
                name: "ReligionId",
                table: "StudentBasicInfos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "NationalityNo",
                table: "StudentBasicInfos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "NationalityId",
                table: "StudentBasicInfos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "StudentBasicInfos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NatId",
                table: "StudentBasicInfos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReID",
                table: "StudentBasicInfos",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
