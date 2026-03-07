using System.Text.RegularExpressions;
using System.Collections.Generic;
using System;

class Patient
{
    public string Name { get; set; }
    public decimal BaseFee { get; set; }

    public virtual decimal CalculateFinalBill()
    {
        return BaseFee;
    }
}
class Inpatient : Patient
{
    public int DayStayed { get; set; }
    public decimal DailyRate { get;set; }

    public override decimal CalculateFinalBill()
    {
        return BaseFee + (DayStayed * DailyRate);
    }
}

class Outpatient : Patient
{
    public decimal ProcedureFee { get; set; }
    public override decimal CalculateFinalBill()
    {
        return BaseFee + ProcedureFee;
    }
}
class EmergencyPatient : Patient
{
    public int SevertiyLevel { get; set; }
    public override decimal CalculateFinalBill()
    {
        if (SevertiyLevel < 1 || SevertiyLevel > 5)
            throw new ArgumentException("SeverityLevel must be between 1 and 5");

        return BaseFee * SevertiyLevel;
    }
}
class HospitalBilling
{
    List<Patient> patients = new List<Patient>();
    
    public void AddPatient(Patient patient)
    {
        patients.Add(patient);
    }

    public void GenerateDailyReport()
    {
        foreach(var patient in patients)
        {
            Console.WriteLine($"Patient: {patient.Name}, Final Bill: {patient.CalculateFinalBill()}");
        }
    }

    public decimal CalculateTotalRevenue()
    {
        decimal total = 0;
        foreach(var patient in patients)
        {
            total += patient.CalculateFinalBill();
        }
        return total;
    }

    public int GetInpatientCount()
    {
        int count = 0;
        foreach(var patient in patients)
        {
            if(patient is Inpatient)
            {
                count++;
            }
        }
        return count;
    }
    
}

class Demo
{
    static void Main(string[] args)
    {
        HospitalBilling billing = new HospitalBilling();
        billing.AddPatient(new Inpatient { Name = "PatientA", BaseFee = 500, DayStayed = 3, DailyRate = 200 });
        billing.AddPatient(new Inpatient { Name = "PatientB", BaseFee = 600, DayStayed = 7, DailyRate = 200 });
        billing.AddPatient(new Outpatient { Name = "PatientC", BaseFee = 300  , ProcedureFee = 150 });
        billing.AddPatient(new EmergencyPatient { Name = "PatientD", BaseFee = 400, SevertiyLevel = 4 }); 
        billing.GenerateDailyReport();
        Console.WriteLine($"Total Revenue: {billing.CalculateTotalRevenue()}");
        Console.WriteLine($"Total Inpatients: {billing.GetInpatientCount()}");
        
    }
}