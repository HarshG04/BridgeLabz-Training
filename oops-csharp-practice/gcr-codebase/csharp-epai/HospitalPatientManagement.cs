
using System;
using System.Collections.Generic;

abstract class Patient
{
    private int patientId;
    private string name;
    private int age;

    protected string diagnosis = string.Empty;
    protected List<string> medicalHistory = new List<string>();

    public int PatientId { get => patientId; set => patientId = value; }
    public string Name { get => name; set => name = value ?? string.Empty; }
    public int Age { get => age; set => age = value; }

    internal virtual string GetInternalInfo() => "Patient";

    public Patient(int id, string name, int age)
    {
        PatientId = id;
        Name = name;
        Age = age;
    }

    public void GetPatientDetails()
    {
        Console.WriteLine($"ID:{PatientId}, Name:{Name}, Age:{Age}");
    }

    public abstract double CalculateBill();
}

interface IMedicalRecord
{
    void AddRecord(string record);
    IEnumerable<string> ViewRecords();
}

class InPatient : Patient, IMedicalRecord
{
    private double roomChargePerDay;
    private int daysAdmitted;

    public InPatient(int id, string name, int age, double roomChargePerDay, int days) : base(id, name, age)
    {
        this.roomChargePerDay = roomChargePerDay;
        this.daysAdmitted = days;
    }

    internal override string GetInternalInfo() => "InPatient";

    public override double CalculateBill() => roomChargePerDay * daysAdmitted + 200; // treatment flat

    public void AddRecord(string record) => medicalHistory.Add(record);

    public IEnumerable<string> ViewRecords() => medicalHistory.AsReadOnly();
}

class OutPatient : Patient, IMedicalRecord
{
    private double consultationFee;

    public OutPatient(int id, string name, int age, double consultationFee) : base(id, name, age)
    {
        this.consultationFee = consultationFee;
    }

    internal override string GetInternalInfo() => "OutPatient";

    public override double CalculateBill() => consultationFee;

    public void AddRecord(string record) => medicalHistory.Add(record);

    public IEnumerable<string> ViewRecords() => medicalHistory.AsReadOnly();
}

class ProgramHospital
{
    static void Main()
    {
        var patients = new List<Patient>
        {
            new InPatient(1, "Eve", 40, 150, 3),
            new OutPatient(2, "Frank", 28, 50)
        };

        ((IMedicalRecord)patients[0]).AddRecord("Appendectomy");
        ((IMedicalRecord)patients[1]).AddRecord("Flu treatment");

        foreach (var p in patients)
        {
            p.GetPatientDetails();
            Console.WriteLine($"Type: {p.GetType().Name}, Bill: {p.CalculateBill():C}");
            Console.WriteLine("Records:");
            foreach (var r in ((IMedicalRecord)p).ViewRecords()) Console.WriteLine(" - " + r);
            Console.WriteLine();
        }
    }
}
