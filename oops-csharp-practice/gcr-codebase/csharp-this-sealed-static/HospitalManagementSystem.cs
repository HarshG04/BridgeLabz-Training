using System;

class Patient
{
    public static string hospitalName = "Goyal Group of Hospitals";
    private static int totalPatients;

    public string name;
    public int age;
    public string ailment;
    public readonly int patientID;

    public Patient(string name, int age, string ailment, int patientID)
    {
        this.name = name;
        this.age = age;
        this.ailment = ailment;
        this.patientID = patientID;
        totalPatients++;
    }

    public static void GetTotalPatients()
    {
        Console.WriteLine("\nTotal Patients: " + totalPatients);
    }

    public static void ShowPatientDetails(object obj)
    {
        if (obj is Patient p)
        {
            Console.WriteLine("\nPatient Details");
            Console.WriteLine("Hospital: " + hospitalName);
            Console.WriteLine("Name: " + p.name);
            Console.WriteLine("Age: " + p.age);
            Console.WriteLine("Ailment: " + p.ailment);
            Console.WriteLine("Patient ID: " + p.patientID);
        }
        else
        {
            Console.WriteLine("Object is not a Patient");
        }
    }
}

class Program
{
    static void Main()
    {
        Patient p1 = new Patient("Harsh", 21, "Fever", 1001);
        Patient p2 = new Patient("Aditya", 22, "Migraine", 1002);

        Patient.ShowPatientDetails(p1);
        Patient.ShowPatientDetails(p2);

        Patient.GetTotalPatients();

        Patient.ShowPatientDetails("Hello");
    }
}
