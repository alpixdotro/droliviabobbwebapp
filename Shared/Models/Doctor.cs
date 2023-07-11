using System;
using System.Collections.Generic;

namespace BlazorApp.Shared.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Specialization { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }


        public List<Patient> Patients { get; set; }
        public List<Appointment> Appointments { get; set; }

        
    }
}
