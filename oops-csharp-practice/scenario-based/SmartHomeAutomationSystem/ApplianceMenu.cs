
using System;

namespace SmartHomeAutomationSystem
{
    class AppliancesMenu
    {
        private Services myService = new Services();

        public void MyMenu()
        {
            while (true)
            {
                Console.WriteLine("\n==== Appliance Menu =====");
                Console.WriteLine("1: Turning Fan On");
                Console.WriteLine("2: Turning Fan Off");
                Console.WriteLine("3: Turning Light On");
                Console.WriteLine("4: Turning Light Off");
                Console.WriteLine("5: Turning AC On");
                Console.WriteLine("6: Turning AC Off");
                Console.WriteLine("7: Exit");

                Console.Write("Select Option: ");
                int option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1 : myService.TurnFanOn();
                            break;
                    case 2 : myService.TurnFanOff();
                            break;
                    case 3 : myService.TurnLightOn();
                            break;
                    case 4 : myService.TurnLightOff();
                            break;
                    case 5 : myService.TurnACOn();
                            break;
                    case 6 : myService.TurnACOff();
                            break;
                    case 7 : return;
                    default : break;
                    
                }
                
            }
        }

    }

}