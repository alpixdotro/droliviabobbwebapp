using Api.Data;
using BlazorApp.Shared.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Services
{
    public class PatientService
    {
        private readonly FunctionDbContext _dbContext;

        public PatientService(FunctionDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void InsertData()
        {
            var optionsBuilder = new DbContextOptionsBuilder<FunctionDbContext>();

            optionsBuilder.UseMySQL("Server=droliviabobbmysql.mysql.database.azure.com;User ID=alpixapps_dev_admin;Password=Yp8Br12c1109#oli;Database=droliviabobbdb");

            using (var context = new FunctionDbContext(optionsBuilder.Options))
            {
                // Creates the database if not exists
                context.Database.EnsureCreated();

                var patient = new Patient
                {
                    FirstName = "Janos",
                    LastName = "Doerty",
                    PhoneNumber = "1234567890",
                    EmailAddress = "test@email.com",
                    DateOfBirth = new DateTime(1990, 1, 1),
                    PersonalId = 1910109260017,
                    Gender = "Male",
                    SpokenLanguage = "English",
                    StreetAddress = "123 Main St",
                    City = "Targu-Mures",
                    StateProvince = "Mures",
                    PostalCode = "540000",
                    DoctorId = 1


                };

                context.Patients.Add(patient);

                context.SaveChanges();
            }
        }
    }
}
