using HealthClinicApp.Interface;
using HealthClinicApp.Utility;

namespace HealthClinicApp.UserMenu;

class AdminMenu
{
    public void DisplayAdminMenu()
    {
        IDoctor doctorUtility = new DoctorUtilityImpl();
        SpecialtyMenu specialtyMenu = new SpecialtyMenu();
        IPayment paymentUtility = new PaymentUtilityImpl();
        IAuditLog auditUtility = new AuditLogUtilityImpl();

        while(true)
        {
            Console.WriteLine("\n====== ADMIN MENU ======");
            Console.WriteLine("1. Add Doctor Profile");
            Console.WriteLine("2. Assign/Update Doctor Specialty");
            Console.WriteLine("3. Add Doctor Schedule");
            Console.WriteLine("4. Deactivate Doctor Profile");
            Console.WriteLine("5. Manage Specialties");
            Console.WriteLine("6. View Outstanding Bills");
            Console.WriteLine("7. Generate Revenue Report");
            Console.WriteLine("8. View Audit Logs");
            Console.WriteLine("0. Exit");
            Console.Write("Enter Choice: ");
            int ch = Convert.ToInt32(Console.ReadLine());

            switch(ch)
            {
                case 1: doctorUtility.RegisterNewDoctor(); break;
                case 2: doctorUtility.SetDoctorSpecility(); break;
                case 3: doctorUtility.AddDoctorSchedule(); break;
                case 4: doctorUtility.DeactivateDoctorProfile(); break;
                case 5: specialtyMenu.DisplaySpecialtyMenu(); break;
                case 6: paymentUtility.ViewOutstandingBills(); break;
                case 7: paymentUtility.GenerateRevenueReport(); break;
                case 8: auditUtility.ViewAuditLogs(); break;
                case 0:  return;
                default: break;
            }
        }
    }
}
