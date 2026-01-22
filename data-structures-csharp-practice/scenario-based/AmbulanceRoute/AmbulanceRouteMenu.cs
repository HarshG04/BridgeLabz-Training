namespace AmbulanceRoute
{
    class AmbulanceRouteMenu
    {
        private IAmbulanceRoute utility;

        public AmbulanceRouteMenu()
        {
            utility = new AmbulanceRouteUtilityImpl();
        }

        public void HospitalMenu()
        {
            while (true)
            {
                Console.WriteLine("\n=== AmbulanceRoute === ");
                Console.WriteLine("1: Add Patient");
                Console.WriteLine("2: Discharge Patient");
                Console.WriteLine("3: Show Status");
                Console.WriteLine("4: Exit");
                Console.Write("Enter Choice: ");
                int ch = Convert.ToInt32(Console.ReadLine());

                switch (ch)
                {
                    case 1 : utility.AddPatient(); break;
                    case 2 : utility.RemovePatient(); break;
                    case 3 : utility.DisplayStatus(); break;
                    case 4 : return;
                    default : break;
                }

            }
        }

    }

}