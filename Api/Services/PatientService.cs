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

                var patient1 = new PatientModel
                {
                    FirstName = "Alice",
                    LastName = "Johnson",
                    PhoneNumber = "9876543210",
                    EmailAddress = "alice.johnson@example.com",
                    DateOfBirth = new DateTime(1985, 1, 15),
                    PersonalId = 8501151234567,
                    Gender = "Female",
                    SpokenLanguage = "English",
                    StreetAddress = "456 Elm St",
                    City = "Springfield",
                    StateProvince = "Illinois",
                    PostalCode = "12345",
                    DoctorId = 1
                };

                var patient2 = new PatientModel
                {
                    FirstName = "John",
                    LastName = "Smith",
                    PhoneNumber = "5551234567",
                    EmailAddress = "john.smith@example.com",
                    DateOfBirth = new DateTime(1978, 3, 10),
                    PersonalId = 7803109876543,
                    Gender = "Male",
                    SpokenLanguage = "English",
                    StreetAddress = "789 Oak Ave",
                    City = "New York City",
                    StateProvince = "New York",
                    PostalCode = "67890",
                    DoctorId = 1
                };

                var patient3 = new PatientModel
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

                var patient4 = new PatientModel
                {
                    FirstName = "Emma",
                    LastName = "Davis",
                    PhoneNumber = "9998887777",
                    EmailAddress = "emma.davis@example.com",
                    DateOfBirth = new DateTime(1982, 12, 5),
                    PersonalId = 8212057654321,
                    Gender = "Female",
                    SpokenLanguage = "English",
                    StreetAddress = "321 Pine Ln",
                    City = "Los Angeles",
                    StateProvince = "California",
                    DoctorId = 1
                };

                var patient5 = new PatientModel
                {
                    FirstName = "Michael",
                    LastName = "Anderson",
                    PhoneNumber = "4445556666",
                    DateOfBirth = new DateTime(1995, 11, 20),
                    PersonalId = 9511208765432,
                    Gender = "Male",
                    SpokenLanguage = "English",
                    StreetAddress = "987 Maple St",
                    City = "Chicago",
                    StateProvince = "Illinois",
                    PostalCode = "67890",
                    DoctorId = 1
                };

                context.Patients.Add(patient1);
                context.Patients.Add(patient2);
                context.Patients.Add(patient3);
                context.Patients.Add(patient4);
                context.Patients.Add(patient5);

                context.SaveChanges();
            }
        }
    }
}
