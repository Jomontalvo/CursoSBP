﻿using CursoSBP.Common.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CursoSBP.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        #region Define SQL Entities
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Campus> Campus { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.ApplyConfiguration(new StudentConfig());
            //modelBuilder.ApplyConfiguration(new SubjectConfig());
            //modelBuilder.ApplyConfiguration(new CampusConfig());
            //modelBuilder.ApplyConfiguration(new ScheduleConfig());
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(Student))!);
        }
    }
}