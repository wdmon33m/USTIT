﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using USTIT.Services.StudentAPI.Data;

#nullable disable

namespace USTIT.Services.StudentAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230911172214_CreateStudentBasicInfoTable")]
    partial class CreateStudentBasicInfoTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("USTIT.Services.StudentAPI.Models.Nationality", b =>
                {
                    b.Property<int>("NationalityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NationalityId"));

                    b.Property<string>("CountryCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NationalityAr")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NationalityEn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("NationalityId");

                    b.ToTable("Nationalities");
                });

            modelBuilder.Entity("USTIT.Services.StudentAPI.Models.Religion", b =>
                {
                    b.Property<int>("ReligionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReligionId"));

                    b.Property<string>("ReligionNameAr")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReligionNameEn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ReligionId");

                    b.ToTable("Religions");

                    b.HasData(
                        new
                        {
                            ReligionId = 1,
                            ReligionNameAr = "مسلم",
                            ReligionNameEn = "MUSLIM"
                        },
                        new
                        {
                            ReligionId = 2,
                            ReligionNameAr = "مسيحي",
                            ReligionNameEn = "CHRISTIAN"
                        });
                });

            modelBuilder.Entity("USTIT.Services.StudentAPI.Models.Student", b =>
                {
                    b.Property<string>("FullStdID")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<int>("AcYear")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeptCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StdNo")
                        .HasColumnType("int");

                    b.Property<string>("UserID")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("FullStdID");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("USTIT.Services.StudentAPI.Models.StudentBasicInfo", b =>
                {
                    b.Property<string>("FullStdID")
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<int>("Batch")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<int>("NationalityId")
                        .HasColumnType("int");

                    b.Property<string>("NationalityNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ReligionId")
                        .HasColumnType("int");

                    b.HasKey("FullStdID");

                    b.HasIndex("NationalityId");

                    b.HasIndex("ReligionId");

                    b.ToTable("StudentBasicInfos");
                });

            modelBuilder.Entity("USTIT.Services.StudentAPI.Models.StudentNames", b =>
                {
                    b.Property<string>("FullStdID")
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<string>("ArFirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ArFourthName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ArFullName")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("nvarchar(max)")
                        .HasComputedColumnSql("[ArFirstName] + ' ' + [ArSecondName] + ' ' + [ArThirdName] + ' ' + [ArFourthName]");

                    b.Property<string>("ArSecondName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ArThirdName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EnFirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EnFourthName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EnFullName")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("nvarchar(max)")
                        .HasComputedColumnSql("[EnFirstName] + ' ' + [EnSecondName] + ' ' + [EnThirdName] + ' ' + [EnFourthName]");

                    b.Property<string>("EnSecondName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EnThirdName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FullStdID");

                    b.ToTable("StudentNames");
                });

            modelBuilder.Entity("USTIT.Services.StudentAPI.Models.StudentBasicInfo", b =>
                {
                    b.HasOne("USTIT.Services.StudentAPI.Models.Nationality", "Nationality")
                        .WithMany()
                        .HasForeignKey("NationalityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("USTIT.Services.StudentAPI.Models.Religion", "Religion")
                        .WithMany()
                        .HasForeignKey("ReligionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Nationality");

                    b.Navigation("Religion");
                });

            modelBuilder.Entity("USTIT.Services.StudentAPI.Models.StudentNames", b =>
                {
                    b.HasOne("USTIT.Services.StudentAPI.Models.Student", "Student")
                        .WithMany()
                        .HasForeignKey("FullStdID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");
                });
#pragma warning restore 612, 618
        }
    }
}
