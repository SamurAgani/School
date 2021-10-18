using SchoolApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Repository
{
    public class TaskContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Admin> Admins { get; set; }

        public DbSet<TeacherTopicClass> TeacherTopicClass { get; set; }


        public TaskContext() : base("Connection") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Student>().HasKey(x => x.Id);
            modelBuilder.Entity<Student>().HasIndex(x => x.Id);

            modelBuilder.Entity<Teacher>().HasKey(x => x.Id);
            modelBuilder.Entity<Teacher>().HasIndex(x => x.Id);

            modelBuilder.Entity<Class>().HasKey(x => x.Id);
            modelBuilder.Entity<Class>().HasIndex(x => x.Id);

            modelBuilder.Entity<Gender>().HasKey(x => x.Id);
            modelBuilder.Entity<Gender>().HasIndex(x => x.Id);

            modelBuilder.Entity<Topic>().HasKey(x => x.Id);
            modelBuilder.Entity<Topic>().HasIndex(x => x.Id);

            modelBuilder.Entity<Admin>().HasKey(x => x.Id);
            modelBuilder.Entity<Admin>().HasIndex(x => x.Id);

            modelBuilder.Entity<TeacherTopicClass>().HasKey(x => x.Id);
            modelBuilder.Entity<TeacherTopicClass>().HasIndex(x => x.Id);
        }
    }
}
