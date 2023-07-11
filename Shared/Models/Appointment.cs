﻿using System;

namespace BlazorApp.Shared.Models
{
    public class Appointment
    {
        public int Id { get; set; }

        public Patient Patient { get; set; }

        public int PatientId { get; set; }
        

        public Doctor Doctor { get; set; }

        public int DoctorId { get; set; }

        public DateTime Date { get; set; }
        public string AppointmentLocation { get; set; }
        public string AppointmentType { get; set; }
        public string AppointmentStatus { get; set; }
        public string Notes { get; set; }

    }
}
