using HealthClinicApp.UserMenu;

namespace HealthClinicApp;

class HealthClinicMain
{
    public static void Main(string[] args)
    {
        HealthClinicMenu MainMenu = new HealthClinicMenu();
        MainMenu.DisplayHealthClinicMenu();

    }
}