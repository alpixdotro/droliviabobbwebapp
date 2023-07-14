using BlazorApp.Shared.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Data
{
    public class FunctionDbContext : DbContext
    {
        
        public FunctionDbContext(DbContextOptions<FunctionDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //#warning To protect potentially sensitive information in your connection string, you should move it out of source code.See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.

            optionsBuilder.UseMySQL("Server=droliviabobbmysql.mysql.database.azure.com;User ID=alpixapps_dev_admin;Password=Yp8Br12c1109#oli;Database=droliviabobbdb");
        }

        public DbSet<Patient> Patients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.FirstName).IsRequired();
                entity.Property(e => e.LastName).IsRequired();
                entity.Property(e => e.PhoneNumber).IsRequired();
                entity.Property(e => e.EmailAddress).IsRequired();
                entity.Property(e => e.DateOfBirth).IsRequired();
                entity.Property(e => e.PersonalId).IsRequired();
                entity.Property(e => e.Gender).IsRequired();
                entity.Property(e => e.SpokenLanguage).IsRequired();
                entity.Property(e => e.StreetAddress).IsRequired();
                entity.Property(e => e.City).IsRequired();
                entity.Property(e => e.StateProvince).IsRequired();
                entity.Property(e => e.PostalCode).IsRequired();
                entity.Property(e => e.DoctorId).IsRequired();


            });
        }
    }
    
}
