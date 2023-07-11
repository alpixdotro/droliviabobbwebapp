using System;

namespace BlazorApp.Client.Models
{
    public class Appointment
    {
        public int Id { get; set; }

        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }

        public DateTime Date { get; set; }
        public string AppointmentLocation { get; set; }
        public string AppointmentType { get; set; }
        public string AppointmentStatus { get; set; }
        public string Notes { get; set; }

    }
}
