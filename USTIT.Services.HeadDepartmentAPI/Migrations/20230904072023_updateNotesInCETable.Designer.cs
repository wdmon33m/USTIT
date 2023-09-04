﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using USTIT.Services.HeadDepartmentAPI.Data;

#nullable disable

namespace USTIT.Services.HeadDepartmentAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230904072023_updateNotesInCETable")]
    partial class updateNotesInCETable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("USTIT.Services.HeadDepartmentAPI.Models.Absence", b =>
                {
                    b.Property<int>("AbsenceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AbsenceId"));

                    b.Property<DateTime>("ADate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ANo")
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasComputedColumnSql("'A-' + CAST(StdGroupNo AS NVARCHAR(50)) + '-' + SUBSTRING(CENo, 13, LEN(CENo)) + '-' + CAST(ADate AS NVARCHAR(20))");

                    b.Property<string>("CENo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StdGroupNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("TransactionDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserID")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AbsenceId");

                    b.ToTable("Absences");
                });

            modelBuilder.Entity("USTIT.Services.HeadDepartmentAPI.Models.CourseEnrollment", b =>
                {
                    b.Property<int>("CEId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CEId"));

                    b.Property<int>("AcYear")
                        .HasColumnType("int");

                    b.Property<string>("CENo")
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasComputedColumnSql("CAST([DeptCode] AS NVARCHAR(10)) + '-' + CAST([AcYear] AS NVARCHAR(4)) + '-' + CAST([SemNo] AS NVARCHAR(2)) + '-' + CAST([CourseCode] AS NVARCHAR(50))");

                    b.Property<int>("ClassNo")
                        .HasColumnType("int");

                    b.Property<string>("CourseCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CourseWeight")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("int")
                        .HasComputedColumnSql("(([LectureWeight]+[TutorialWeight])+[LabWeight])");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeptCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("HasTutorial")
                        .HasColumnType("bit");

                    b.Property<int>("LabWeight")
                        .HasColumnType("int");

                    b.Property<int>("LectureWeight")
                        .HasColumnType("int");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SemNo")
                        .HasColumnType("int");

                    b.Property<string>("TeacherNo")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<int>("TutorialWeight")
                        .HasColumnType("int");

                    b.Property<string>("UserID")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("CEId");

                    b.ToTable("CourseEnrollments");
                });
#pragma warning restore 612, 618
        }
    }
}
