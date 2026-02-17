using HealthClinicApp.Interface;
using HealthClinicApp.Utility;

namespace HealthClinicApp.UserMenu;

class SpecialtyMenu
{
    public void DisplaySpecialtyMenu()
    {
        ISpecialty specialtyUtility = new SpecialtyUtilityImpl();

        while(true)
        {
            Console.WriteLine("\n--- SPECIALTY MANAGEMENT ---");
            Console.WriteLine("1. Add Specialty");
            Console.WriteLine("2. View All Specialties");
            Console.WriteLine("3. Update Specialty");
            Console.WriteLine("4. Delete Specialty");
            Console.WriteLine("0. Back");
            Console.Write("Enter Choice : ");
            int ch = Convert.ToInt32(Console.ReadLine());

            switch(ch)
            {
                case 1: specialtyUtility.AddNewSpecialty(); break;
                case 2: specialtyUtility.DisplayAllSpecialty(); break;
                case 3: specialtyUtility.UpdateSpecialty(); break;
                case 4: specialtyUtility.DeleteSpecialty(); break;
                case 0: return;
                default : break;
            }
        }
    }
}
