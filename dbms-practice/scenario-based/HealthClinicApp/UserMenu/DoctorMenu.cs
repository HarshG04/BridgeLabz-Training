using HealthClinicApp.Interface;
using HealthClinicApp.Utility;

namespace HealthClinicApp.UserMenu;

class DoctorMenu
{
    public void DisplayDoctorMenu()
    {
        IPatient patientUtility = new PatientUtilityImpl();
        IVisit visitUtility = new VisitUtilityImpl();
        IPrescription prescriptionUtility = new PrescriptionUtilityImpl();

        while(true)
        {
            Console.WriteLine("\n--- DOCTOR MENU ---");
            Console.WriteLine("1. View Patient Visit History");
            Console.WriteLine("2. Record Patient Visit");
            Console.WriteLine("3. View Patient Medical History");
            Console.WriteLine("4. Add Prescription");
            Console.WriteLine("5. Add Medicine");
            Console.WriteLine("0. Exit");
            Console.Write("Enter Choice: ");
            int ch = Convert.ToInt32(Console.ReadLine());
            
            switch(ch)
            {
                case 1: patientUtility.ViewPatientHistory(); break;
                case 2: visitUtility.RecordPatientVisit(); break;
                case 3: visitUtility.ViewPatientMedicalHistory(); break;
                case 4: prescriptionUtility.CreatePrescription(); break;
                case 5: prescriptionUtility.AddMedicine(); break;
                case 0: return;
                default : break;
            }
        }
    }
}
