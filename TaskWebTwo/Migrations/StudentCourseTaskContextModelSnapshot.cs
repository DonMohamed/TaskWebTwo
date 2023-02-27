﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TaskWebTwo.Models;

#nullable disable

namespace TaskWebTwo.Migrations
{
    [DbContext(typeof(StudentCourseTaskContext))]
    partial class StudentCourseTaskContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TaskWebTwo.Models.Class", b =>
                {
                    b.Property<int>("ClassId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClassId"));

                    b.Property<string>("ClassName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ClassId");

                    b.ToTable("Class", (string)null);

                    b.HasData(
                        new
                        {
                            ClassId = 1,
                            ClassName = "الفصل الدراسى الاول"
                        },
                        new
                        {
                            ClassId = 2,
                            ClassName = "الفصل الدراسى الثانى"
                        });
                });

            modelBuilder.Entity("TaskWebTwo.Models.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CourseName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Courses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CourseName = "فيزياء"
                        },
                        new
                        {
                            Id = 2,
                            CourseName = "تاريخ"
                        });
                });

            modelBuilder.Entity("TaskWebTwo.Models.Gender", b =>
                {
                    b.Property<int>("GenderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GenderId"));

                    b.Property<string>("GenderName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("GenderId");

                    b.ToTable("Gender", (string)null);

                    b.HasData(
                        new
                        {
                            GenderId = 1,
                            GenderName = "ذكر"
                        },
                        new
                        {
                            GenderId = 2,
                            GenderName = "انثى"
                        });
                });

            modelBuilder.Entity("TaskWebTwo.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<int>("ClassType")
                        .HasColumnType("int");

                    b.Property<DateTime>("DOB")
                        .HasColumnType("datetime2");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("TaskWebTwo.Models.StudentCourse", b =>
                {
                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<int>("StudentID")
                        .HasColumnType("int");

                    b.Property<int>("StudyPeriod")
                        .HasColumnType("int");

                    b.Property<DateTime>("startingCourse")
                        .HasColumnType("datetime2");

                    b.HasKey("CourseId", "StudentID");

                    b.HasIndex("StudentID");

                    b.ToTable("StudentCourses");
                });

            modelBuilder.Entity("TaskWebTwo.Models.Teacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("Teachers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CourseId = 1,
                            Name = "ابراهيم محمد"
                        },
                        new
                        {
                            Id = 2,
                            CourseId = 1,
                            Name = "محمود فؤاد"
                        });
                });

            modelBuilder.Entity("TaskWebTwo.Models.TeacherStudent", b =>
                {
                    b.Property<int>("TeacherId")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("TeacherId", "StudentId");

                    b.HasIndex("StudentId");

                    b.ToTable("TeacherStudents");
                });

            modelBuilder.Entity("TaskWebTwo.Models.StudentCourse", b =>
                {
                    b.HasOne("TaskWebTwo.Models.Course", "course")
                        .WithMany("students")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TaskWebTwo.Models.Student", "student")
                        .WithMany("courses")
                        .HasForeignKey("StudentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("course");

                    b.Navigation("student");
                });

            modelBuilder.Entity("TaskWebTwo.Models.Teacher", b =>
                {
                    b.HasOne("TaskWebTwo.Models.Course", "courses")
                        .WithMany("teachers")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("courses");
                });

            modelBuilder.Entity("TaskWebTwo.Models.TeacherStudent", b =>
                {
                    b.HasOne("TaskWebTwo.Models.Student", "student")
                        .WithMany("teachers")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TaskWebTwo.Models.Teacher", "teacher")
                        .WithMany("students")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("student");

                    b.Navigation("teacher");
                });

            modelBuilder.Entity("TaskWebTwo.Models.Course", b =>
                {
                    b.Navigation("students");

                    b.Navigation("teachers");
                });

            modelBuilder.Entity("TaskWebTwo.Models.Student", b =>
                {
                    b.Navigation("courses");

                    b.Navigation("teachers");
                });

            modelBuilder.Entity("TaskWebTwo.Models.Teacher", b =>
                {
                    b.Navigation("students");
                });
#pragma warning restore 612, 618
        }
    }
}