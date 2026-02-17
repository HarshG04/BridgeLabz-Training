using HealthClinicApp.Interface;
using HealthClinicApp.Utility;

namespace HealthClinicApp.UserMenu;

class PatientMenu
{
    public void DisplayPatientMenu()
    {
        IAppointment appointmentUtility = new AppointmentUtilityImpl();

        while(true)
        {
            Console.WriteLine("\n--- PATIENT MENU ---");
            Console.WriteLine("1. Cancel Appointment");
            Console.WriteLine("0. Exit");
            Console.Write("Enter Choice: ");
            int ch = Convert.ToInt32(Console.ReadLine());
            

            switch(ch)
            {
                case 1: appointmentUtility.CancelAppointment(); break;
                case 0: return;
                default : break;
            }
        }
    }
}
