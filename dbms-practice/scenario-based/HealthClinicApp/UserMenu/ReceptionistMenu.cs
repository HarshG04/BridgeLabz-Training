using HealthClinicApp.Interface;
using HealthClinicApp.Utility;

namespace HealthClinicApp.UserMenu;

class ReceptionistMenu
{
    public void DisplayReceptionistMenu()
    {
        IPatient patientUtility = new PatientUtilityImpl();
        IAppointment appUtility = new AppointmentUtilityImpl();
        IPayment payUtility = new PaymentUtilityImpl();
        IDoctor doctorUtility = new DoctorUtilityImpl();

        while(true)
        {
            Console.WriteLine("\n--- RECEPTIONIST MENU ---");
            Console.WriteLine("1. Register New Patient");
            Console.WriteLine("2. Update Patient Info");
            Console.WriteLine("3. Search Patient");
            Console.WriteLine("4. View Patient Visit History");
            Console.WriteLine("5. Book Appointment");
            Console.WriteLine("6. Check Doctor Availability");
            Console.WriteLine("7. Cancel Appointment");
            Console.WriteLine("8. Reschedule Appointment");
            Console.WriteLine("9. View Daily Schedule");
            Console.WriteLine("10. Generate Bill");
            Console.WriteLine("11. Record Payment");
            Console.WriteLine("12. View Outstanding Bills");
            Console.WriteLine("13: View Doctor By Specialty");
            Console.WriteLine("0. Exit");
            Console.Write("Enter Choice : ");
            int ch = Convert.ToInt32(Console.ReadLine());

            switch(ch)
            {
                case 1: patientUtility.AddNewPatient(); break;
                case 2: patientUtility.UpdatePatientInfo(); break;
                case 3: patientUtility.SearchPatientRecord(); break;
                case 4: patientUtility.ViewPatientHistory(); break;
                case 5: appUtility.BookAppointment(); break;
                case 6: appUtility.CheckDoctorAvailability(); break;
                case 7: appUtility.CancelAppointment(); break;
                case 8: appUtility.RescheduleAppointment(); break;
                case 9: appUtility.ViewDailyAppointmentSchedule(); break;
                case 10: payUtility.GenerateBill(); break;
                case 11: payUtility.PayBill(); break;
                case 12: payUtility.ViewOutstandingBills(); break;
                case 13: doctorUtility.ViewDoctorsBySpecialty(); break;
                case 0: return;
                default : break;
            }
        }
    }
}
