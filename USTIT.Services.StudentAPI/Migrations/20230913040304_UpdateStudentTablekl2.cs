﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace USTIT.Services.StudentAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateStudentTablekl2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentNames_Students_FullStdID",
                table: "StudentNames");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
