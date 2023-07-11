using BlazorApp.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Api
{
    public class MockDataService
    {
        private List<Patient> _patients;
        private List<Doctor> _doctors;
        private List<Appointment> _appointments;
        private List<MedicalRecord> _medicalRecords;

        public List<Patient> Patients
        {
            get
            {
                if (_patients == null)
                {
                    InitializeMockData();
                    SetupRelations();
                }

                return _patients;
            }
        }

        private void InitializeMockData()
        {
            _patients = new List<Patient>
            {
                new Patient
                {
                    Id = 1,
                    FirstName = "Laszlo",
                    LastName = "Horvath",
                    PhoneNumber = "1234567890",
                    DateOfBirth = new DateTime(1990, 1, 1),
                    PersonalId = 1910109260017,
                    Gender = "Male",
                    SpokenLanguage = "English",
                    StreetAddress = "123 Main St",
                    City = "Targu-Mures",
                    StateProvince = "Mures",
                    PostalCode = "540000"
                },
                new Patient
                {
                    Id = 2,
                    FirstName = "John",
                    LastName = "Doe",
                    PhoneNumber = "1234567890",
                    DateOfBirth = new DateTime(1990, 5, 9),
                    PersonalId = 1910109260018,
                    Gender = "Male",
                    SpokenLanguage = "Romanian",
                    StreetAddress = "2 Main St",
                    City = "Targu-Mures",
                    StateProvince = "Mures",
                    PostalCode = "540000"
                }
            };

            _medicalRecords = new List<MedicalRecord>
            {
                new MedicalRecord
                {
                    Id = 1,
                    PatientId = 1,
                    Date = new DateTime(2021, 1, 1),
                    Observation = "Patient observation",
                    Diagnosis = "Rotten teeth",
                    Treatment = "Extraction",
                    Medication = "Tador",
                    Notes = "Patient will go on vacation to Italy, ask how it was"
                }
            };

            _doctors = new List<Doctor>
            {
                new Doctor
                {
                    Id = 1,
                    Name = "Dr. Olivia Bobb",
                    Specialization = "Stomatologie generala",
                    PhoneNumber = "1234567890",
                    Email = "dr@oliviabobb.com"
                }
            };

            _appointments = new List<Appointment>
            {
                new Appointment
                {
                    Id = 1,
                    PatientId = 1,
                    DoctorId = 1,
                    Date = new DateTime(2023, 7, 11),
                    AppointmentLocation = "Cabinet Sangeorz",
                    AppointmentType = "Consultatie",
                    AppointmentStatus = "In asteptare",
                    Notes = "Urgenta blablabla"
                }
            };
        }

        private void SetupRelations()
        {

            foreach (var appointment in _appointments)
            {
                appointment.Patient = _patients.FirstOrDefault(p => p.Id == appointment.PatientId);
                appointment.Doctor = _doctors.FirstOrDefault(d => d.Id == appointment.DoctorId);
            }

        }
    }
}
