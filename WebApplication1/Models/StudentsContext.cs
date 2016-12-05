using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using University.Models;

namespace University.Models
{
    public class StudentsContext:DbContext
    {
        public StudentsContext() : base("")
        { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }

        //For binding many to many
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().HasMany(c => c.Students)
                .WithMany(s => s.Courses)
                .Map(t => t.MapLeftKey("CourseId")
                .MapRightKey("StudentId")
                .ToTable("CourseStudent"));
        }
    }
}