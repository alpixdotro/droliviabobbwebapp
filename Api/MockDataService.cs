using BlazorApp.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api
{
    public class MockDataService
    {
        public List<Patient>? _patients = default;
        public List<Doctor>? _doctors = default;
        public List<Appointment>? _appointments = default;
        public List<MedicalRecord>? _medicalRecords = default;

        public List<Patient>? Patients
        {
            get
            {
                //we will use these in initialization of Employees
                _doctors ??= InitializeMockDoctors();

                _medicalRecords ??= InitializeMockMedicalRecords();

                _appointments ??= InitializeMockAppointments();

                _patients ??= InitializeMockPatients();

                return _patients;
            }
        }



        private List<Patient> InitializeMockPatients()
        {
            var p1 = new Patient
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
                PostalCode = "540000",
                DoctorId = 1,
                Doctor = _doctors.FirstOrDefault(d => d.Id == 1),
                MedicalRecords = new List<MedicalRecord>
                {
                    _medicalRecords.FirstOrDefault(m => m.Id == 1)
                },
            };

            var p2 = new Patient
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
                PostalCode = "540000",
                DoctorId = 1,
                Doctor = _doctors.FirstOrDefault(d => d.Id == 1),
                MedicalRecords = _medicalRecords.Where(m => m.PatientId == 2).ToList(),
                Appointments = _appointments.Where(a => a.PatientId == 2).ToList()
            };

            return new List<Patient> { p1, p2 };
        }

        private List<MedicalRecord> InitializeMockMedicalRecords()
        {
            var mr1 = new MedicalRecord
            {
                Id = 1,
                PatientId = 1,
                Patient = _patients.FirstOrDefault(p => p.Id == 1),
                Date = new DateTime(2021, 1, 1),
                Observation = "Patient observation",
                Diagnosis = "Rotten teeth",
                Treatment = "Extraction",
                Medication = "Tador",
                Notes = "Patient will go on vacation to italy, ask how it was"
            };

            return new List<MedicalRecord> { mr1 };
        }


        private List<Doctor> InitializeMockDoctors()
        {
            var d1 = new Doctor
            {
                Id = 1,
                Name = "Dr. Olivia Bobb",
                Specialization = "Stomatologie generala",
                PhoneNumber = "1234567890",
                Email = "dr@oliviabobb.com",
                Patients = _patients.FindAll(p => p.DoctorId == 1),
                Appointments = _appointments.FindAll(a => a.DoctorId == 1)

            };

            return new List<Doctor> { d1 };
        }

        private List<Appointment> InitializeMockAppointments()
        {

            var a1 = new Appointment
            {
                Id = 1,
                Patient = Patients.FirstOrDefault(p => p.Id == 1),
                PatientId = 1,
                Doctor = _doctors.FirstOrDefault(d => d.Id == 1),
                DoctorId = 1,
                Date = new DateTime(2023, 7, 11),
                AppointmentLocation = "Cabinet Sangeorz",
                AppointmentType = "Consultatie",
                AppointmentStatus = "In asteptare",
                Notes = "Urgenta blablabla",

            };

            return new List<Appointment> { a1 };
        }

    }
}