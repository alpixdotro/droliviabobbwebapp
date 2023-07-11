using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorApp.Shared.Models
{
    public class MedicalRecord : CommonProperties
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        public DateTime Date { get; set; }
        public string Observation { get; set; }
        public string Diagnosis { get; set; }
        public string Treatment { get; set; }
        public string Medication { get; set; }
        public string Notes { get; set; }
        
    }
}
