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
    [Migration("20231102055624_AddDayOfWeek9")]
    partial class AddDayOfWeek9
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
                    b.Property<string>("ANo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("ADate")
                        .HasColumnType("datetime2");

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

                    b.HasKey("ANo");

                    b.ToTable("Absences");
                });

            modelBuilder.Entity("USTIT.Services.HeadDepartmentAPI.Models.AbsenceDetails", b =>
                {
                    b.Property<string>("ANo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FullStdId")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<DateTime?>("TransactionDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserID")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ANo");

                    b.ToTable("AbsenceDetails");
                });

            modelBuilder.Entity("USTIT.Services.HeadDepartmentAPI.Models.CourseEnrollment", b =>
                {
                    b.Property<string>("CENo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AcYear")
                        .HasColumnType("int");

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
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("CENo");

                    b.ToTable("CourseEnrollments");
                });

            modelBuilder.Entity("USTIT.Services.HeadDepartmentAPI.Models.LectureSchedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CENo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("DayOfWeek")
                        .HasColumnType("int");

                    b.Property<int>("HallNo")
                        .HasColumnType("int");

                    b.Property<int>("LectureTimeId")
                        .HasColumnType("int");

                    b.Property<string>("StdGroupNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("CENo")
                        .IsUnique();

                    b.HasIndex("DayOfWeek")
                        .IsUnique();

                    b.HasIndex("LectureTimeId");

                    b.HasIndex("StdGroupNo")
                        .IsUnique();

                    b.ToTable("LectureSchedules");
                });

            modelBuilder.Entity("USTIT.Services.HeadDepartmentAPI.Models.LectureTime", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<TimeOnly>("EndAt")
                        .HasColumnType("time");

                    b.Property<string>("NameArb")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameEng")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<TimeOnly>("StartAt")
                        .HasColumnType("time");

                    b.HasKey("Id");

                    b.ToTable("LectureTimes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            EndAt = new TimeOnly(10, 30, 0),
                            NameArb = "المحاضرة الأولى",
                            NameEng = "First Lecture",
                            StartAt = new TimeOnly(8, 30, 0)
                        },
                        new
                        {
                            Id = 2,
                            EndAt = new TimeOnly(13, 0, 0),
                            NameArb = "المحاضرة الثانية",
                            NameEng = "Second Lecture",
                            StartAt = new TimeOnly(11, 0, 0)
                        },
                        new
                        {
                            Id = 3,
                            EndAt = new TimeOnly(16, 0, 0),
                            NameArb = "المحاضرة الثالثة",
                            NameEng = "Third Lecture",
                            StartAt = new TimeOnly(14, 0, 0)
                        },
                        new
                        {
                            Id = 4,
                            EndAt = new TimeOnly(18, 0, 0),
                            NameArb = "المحاضرة الرابعة",
                            NameEng = "Forth Lecture",
                            StartAt = new TimeOnly(16, 0, 0)
                        });
                });

            modelBuilder.Entity("USTIT.Services.HeadDepartmentAPI.Models.StudentGroup", b =>
                {
                    b.Property<string>("StdGroupNo")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AcYear")
                        .HasColumnType("int");

                    b.Property<int>("ClassNo")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeptCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FromStd")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GroupNo")
                        .HasColumnType("int");

                    b.Property<int>("SemNo")
                        .HasColumnType("int");

                    b.Property<int>("StdCount")
                        .HasColumnType("int");

                    b.Property<string>("ToStd")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StdGroupNo");

                    b.ToTable("StudentGroups");
                });

            modelBuilder.Entity("USTIT.Services.HeadDepartmentAPI.Models.LectureSchedule", b =>
                {
                    b.HasOne("USTIT.Services.HeadDepartmentAPI.Models.CourseEnrollment", "CourseEnrollment")
                        .WithMany()
                        .HasForeignKey("CENo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("USTIT.Services.HeadDepartmentAPI.Models.LectureTime", "LectureTime")
                        .WithMany()
                        .HasForeignKey("LectureTimeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("USTIT.Services.HeadDepartmentAPI.Models.StudentGroup", "StudentGroup")
                        .WithMany()
                        .HasForeignKey("StdGroupNo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CourseEnrollment");

                    b.Navigation("LectureTime");

                    b.Navigation("StudentGroup");
                });
#pragma warning restore 612, 618
        }
    }
}
