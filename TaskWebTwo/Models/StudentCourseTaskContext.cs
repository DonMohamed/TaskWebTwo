using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TaskWebTwo.Models;

public partial class StudentCourseTaskContext : DbContext
{

    public StudentCourseTaskContext(DbContextOptions<StudentCourseTaskContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Class> Classes { get; set; }

    public virtual DbSet<Gender> Genders { get; set; }
    public virtual DbSet<Student> Students { get; set; }
    public virtual DbSet<Teacher> Teachers { get; set; }
    public virtual DbSet<Course> Courses { get; set; }
    public virtual DbSet<StudentCourse> StudentCourses { get; set; }
    public virtual DbSet<TeacherStudent> TeacherStudents { get; set; }






    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {




        modelBuilder.Entity<StudentCourse>()
          .HasKey(m => new { m.CourseId, m.StudentID });
        modelBuilder.Entity<TeacherStudent>()
  .HasKey(m => new { m.TeacherId, m.StudentId });

        modelBuilder.Entity<Class>(entity =>
        {
            entity.ToTable("Class");

            entity.Property(e => e.ClassName).HasMaxLength(50);
        });

        modelBuilder.Entity<Gender>(entity =>
        {
            entity.ToTable("Gender");

            entity.Property(e => e.GenderName).HasMaxLength(50);
        });


        modelBuilder.Entity<Class>().HasData(
           new Class
           {
               ClassId=1,
               ClassName="الفصل الدراسى الاول"
              
           },
           new Class
           {
               ClassId = 2,
               ClassName = "الفصل الدراسى الثانى"
           }
           );

        modelBuilder.Entity<Gender>().HasData(
          new Gender
          {
              GenderId = 1,
              GenderName = "ذكر"

          },
          new Gender
          {
              GenderId = 2,
              GenderName = "انثى"
          }
          );
        modelBuilder.Entity<Course>().HasData(
         new Course
         {
             Id = 1,
             CourseName = "فيزياء"
         },
         new Course
         {
             Id = 2,
             CourseName = "تاريخ"
         }
         );
        modelBuilder.Entity<Teacher>().HasData(
         new Teacher
         {
             Id = 1,
             Name = "ابراهيم محمد",
             CourseId=1

         },
         new Teacher
         {
             Id = 2,
             Name = "محمود فؤاد",
             CourseId = 1
         }
         );

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
