using System;


class Hospital
{
    static string hospitalId = "H101";
    static string hospitalName = "Goyal Group of Hospitals";
    Doctor[] doctors;
    Patient[] patients;

    int dIdx = 0, pIdx = 0;

    public Hospital(int doctorCapacity, int patientCapacity)
    {
        doctors = new Doctor[doctorCapacity];
        patients = new Patient[patientCapacity];
    }

    public void AddDoctor()
    {
        if (dIdx >= doctors.Length)
        {
            Console.WriteLine("Cannot add more doctors.");
            return;
        }

        Console.Write("Enter Doctor Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter Specialization: ");
        string spec = Console.ReadLine();

        Console.Write("Enter Shift (Day/Night): ");
        string shift = Console.ReadLine();

        Console.Write("Enter Consultation Fees: ");
        int fees = int.Parse(Console.ReadLine());

        Console.Write("Enter Max Patients Doctor Can Handle: ");
        int max = int.Parse(Console.ReadLine());

        doctors[dIdx++] = new Doctor(name, spec, shift, fees, max);

        Console.WriteLine("\nDoctor Added Successfully.\n");
    }


    public void SearchDoctorBySpecialization(string specialization)
    {
        bool found = false;

        for (int i = 0; i < dIdx; i++)
        {
            if (doctors[i].specialization.Equals(specialization, StringComparison.OrdinalIgnoreCase))
            {
                doctors[i].ShowDetails();
                found = true;
            }
        }

        if (!found) Console.WriteLine("No Doctor Found.");
    }


    public Doctor SearchDoctorById(string id)
    {
        for (int i = 0; i < dIdx; i++)
        {
            if (doctors[i].doctorId.Equals(id, StringComparison.OrdinalIgnoreCase))
                return doctors[i];
        }

        Console.WriteLine("No Doctor Found.");
        return null;
    }


    public void AddPatient()
    {
        if (pIdx >= patients.Length)
        {
            Console.WriteLine("Cannot add more patients.");
            return;
        }

        Console.Write("Enter Patient Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter Age: ");
        int age = int.Parse(Console.ReadLine());

        Console.Write("Enter Ailment: ");
        string ailment = Console.ReadLine();

        Console.Write("Enter Required Doctor Specialization: ");
        string spec = Console.ReadLine();

        SearchDoctorBySpecialization(spec);

        Console.Write("Enter Doctor ID To Assign [-1 = Cancel]: ");
        string dId = Console.ReadLine();

        if (dId == "-1")
        {
            Console.WriteLine("Patient not added.");
            return;
        }

        Doctor assignedDoc = SearchDoctorById(dId);

        if (assignedDoc == null)
        {
            Console.WriteLine("Invalid Doctor ID. Patient not added.");
            return;
        }

        Console.Write("Will Patient be Admitted? (y/n): ");
        string type = Console.ReadLine();

        Patient p;

        if (type.ToLower() == "y")
        {
            Console.Write("Enter no of Admit Days: ");
            int stays = Convert.ToInt32(Console.ReadLine());

            p = new InPatient(name, age, ailment, assignedDoc, stays);
        }
        else
        {
            p = new OutPatient(name, age, ailment, assignedDoc);
        }

        patients[pIdx++] = p;

        if (p is IPayable)
        {
            Bill.Generate((IPayable)p, p);
        }
        Console.WriteLine("\nPatient Added Successfully.\n");

    }
}


class Doctor
{
    static int nextDoctorId = 101;

    public string doctorId;
    public string doctorName;
    public string specialization;
    public string shift;
    public int fees;

    public Patient[] patients;
    public int pIdx = 0;

    public Doctor(string name, string specialization, string shift, int fees, int maxPatients)
    {
        doctorId = "D" + nextDoctorId++;
        doctorName = name;
        this.specialization = specialization;
        this.shift = shift;
        this.fees = fees;
        patients = new Patient[maxPatients];
    }

    public void AssignPatient(Patient p)
    {
        if (pIdx < patients.Length)
            patients[pIdx++] = p;
    }

    public void ShowDetails()
    {
        Console.WriteLine("Doctor ID: " + doctorId + ", Name: " + doctorName +", Specialization: " + specialization +", Shift: " + shift +", Fees: " + fees);
    }
}


abstract class Patient
{
    static int nextId = 101;

    public int patientId;
    public string patientName;
    public int age;
    public string ailment;
    public Doctor assignedDoctor;

    protected Patient(string name, int age, string ailment, Doctor doctor)
    {
        patientId = nextId++;
        patientName = name;
        this.age = age;
        this.ailment = ailment;
        assignedDoctor = doctor;

        if (doctor != null) doctor.AssignPatient(this);
    }

    public virtual void DisplayInfo()
    {
        Console.WriteLine("Patient ID: " + patientId +", Name: " + patientName +", Age: " + age +", Ailment: " + ailment +", Doctor: " + assignedDoctor.doctorName);
    }
}


class InPatient : Patient, IPayable
{
    public DateTime admissionDate;
    public int noOfStays;

    public InPatient(string name, int age, string ailment, Doctor doctor, int noOfStays)
        : base(name, age, ailment, doctor)
    {
        this.admissionDate = DateTime.Now;
        this.noOfStays = noOfStays;
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine("Type: InPatient, Admission: " + admissionDate.ToShortDateString() +", Days Stayed: " + noOfStays);
    }

    public decimal CalculateBill()
    {
        return assignedDoctor.fees + (noOfStays * 100);
    }
}



class OutPatient : Patient, IPayable
{
    public DateTime appointmentDate;

    public OutPatient(string name, int age, string ailment, Doctor doctor)
        : base(name, age, ailment, doctor)
    {
        this.appointmentDate = DateTime.Now;
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine("Type: OutPatient, Appointment: " +appointmentDate.ToShortDateString());
    }

    public decimal CalculateBill()
    {
        return assignedDoctor.fees;
    }
}



class Bill
{
    public static void Generate(IPayable payable, Patient p)
    {
        Console.WriteLine("\n========== BILL ==========");
        Console.WriteLine("Patient: " + p.patientName);
        Console.WriteLine("Amount : " + payable.CalculateBill());
        Console.WriteLine("==========================\n");
    }
}

interface IPayable
{
    decimal CalculateBill();
}



class Program
{
    static void Main()
    {
        Hospital h = new Hospital(10, 20);

        while (true)
        {
            Console.WriteLine("\n===== HOSPITAL MENU =====");
            Console.WriteLine("1. Add Doctor");
            Console.WriteLine("2. Add Patient");
            Console.WriteLine("3. Exit");
            Console.Write("Enter Choice: ");

            int ch = int.Parse(Console.ReadLine());

            switch (ch)
            {
                case 1: h.AddDoctor(); break;
                case 2: h.AddPatient(); break;
                case 3: return;
                default: Console.WriteLine("Invalid Choice"); break;
            }
        }
    }
}
