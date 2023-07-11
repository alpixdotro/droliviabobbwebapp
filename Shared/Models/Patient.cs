using BlazorApp.Shared.Models;
using System;
using System.Collections.Generic;

namespace BlazorApp.Client.Models
{
    public class Patient
    {
        // The following properties are used for the patient's information
        public int Id { get; set; } = 0;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public long PersonalId { get; set; }
        public string Gender { get; set; }
        public string SpokenLanguage { get; set; }

        public int Age {
            get
            {
                var now = DateTime.Today;
                var age = now.Year - DateOfBirth.Year;
                if (DateOfBirth > now.AddYears(-age)) age--;
                return age;
            }
        }


        // The following properties are used for the patient's address
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string StateProvince { get; set; }
        public string PostalCode { get; set; }

        // The following properties are used for the patient's doctor

        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }

        // Patient medical records
        public IObservable<MedicalRecord> MedicalRecords { get; set; }

        // The following properties are used for the patient's appointments
        public IObservable<Appointment> Appointments { get; set; }
        
    }
}
