using System;

public class MedicalRecord
{
    public int Id { get; set; }
    public int PatientId { get; set; }
    public DateTime Date { get; set; }
    public string Observation { get; set; }
    public string Diagnosis { get; set; }
    public string Treatment { get; set; }
    public string Medication { get; set; }
    public string Notes { get; set; }
}