﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using USTIT.Services.BasicDataAPI.Data;

#nullable disable

namespace USTIT.Services.BasicDataAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("USTIT.Services.BasicDataAPI.Models.AcademicDegree", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AcademicDegreeArb")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AcademicDegreeEng")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AcademicDegrees");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AcademicDegreeArb = "بروفيسور",
                            AcademicDegreeEng = "Professor"
                        },
                        new
                        {
                            Id = 2,
                            AcademicDegreeArb = "دكتور",
                            AcademicDegreeEng = "Doctor"
                        },
                        new
                        {
                            Id = 3,
                            AcademicDegreeArb = "ماجستير",
                            AcademicDegreeEng = "Master's"
                        },
                        new
                        {
                            Id = 4,
                            AcademicDegreeArb = "بكلاريوس",
                            AcademicDegreeEng = "Bachelor's"
                        },
                        new
                        {
                            Id = 5,
                            AcademicDegreeArb = "دبلوم",
                            AcademicDegreeEng = "Diploma"
                        });
                });

            modelBuilder.Entity("USTIT.Services.BasicDataAPI.Models.Course", b =>
                {
                    b.Property<string>("CourseCode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CourseTitle")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CourseCode");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("USTIT.Services.BasicDataAPI.Models.Teacher", b =>
                {
                    b.Property<string>("TeacherNo")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AcademicDegreeID")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsCollaborator")
                        .HasColumnType("bit");

                    b.Property<bool>("IsLecturer")
                        .HasColumnType("bit");

                    b.Property<bool>("IsTeacherAssistant")
                        .HasColumnType("bit");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime?>("RegistrationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("TeacherName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("TeacherNo");

                    b.HasIndex("AcademicDegreeID");

                    b.HasIndex("TeacherName")
                        .IsUnique();

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("USTIT.Services.BasicDataAPI.Models.Teacher", b =>
                {
                    b.HasOne("USTIT.Services.BasicDataAPI.Models.AcademicDegree", "AcademicDegree")
                        .WithMany()
                        .HasForeignKey("AcademicDegreeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AcademicDegree");
                });
#pragma warning restore 612, 618
        }
    }
}
