namespace HealthClinicApp.UserMenu;

class HealthClinicMenu
{
    public void DisplayHealthClinicMenu()
    {
        AdminMenu adminMenu = new AdminMenu();
        ReceptionistMenu receptionistMenu = new ReceptionistMenu();
        DoctorMenu doctorMenu = new DoctorMenu();
        PatientMenu patientMenu = new PatientMenu();

        while(true)
        {
            Console.WriteLine("\n=== HEALTH CLINIC SYSTEM ===");
            Console.WriteLine("1. Administrator");
            Console.WriteLine("2. Receptionist");
            Console.WriteLine("3. Doctor");
            Console.WriteLine("4. Patient");
            Console.WriteLine("0. Exit");
            Console.Write("Enter Choice: ");
            int ch = Convert.ToInt32(Console.ReadLine());

            switch(ch)
            {
                case 1: adminMenu.DisplayAdminMenu(); break;
                case 2: receptionistMenu.DisplayReceptionistMenu(); break;
                case 3: doctorMenu.DisplayDoctorMenu(); break;
                case 4: patientMenu.DisplayPatientMenu(); break;
                case 0: return;
                default : break;
            }
        }
    }
}
