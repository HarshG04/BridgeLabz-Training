namespace TrafficManager
{
    class TrafficManagerMenu()
    {
        private IVehicle utility;

        public void Start()
        {
            Console.Write("Enter Capacity of road: ");
            int cap = Convert.ToInt32(Console.ReadLine());
            
            utility = new VehicleUtilityImpl(cap);

            while (true)
            {   
                Console.WriteLine("\n======================");
                Console.WriteLine("1: Add vehicle");
                Console.WriteLine("2: Remove Vehicle");
                Console.WriteLine("3: Display Road");
                
                Console.WriteLine("4. Exit");

                Console.Write("Enter Choise: ");
                int ch = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();

                switch (ch)
                {
                    case 1 : utility.AddVehicle(); break;
                    case 2 : utility.RemoveVehicle(); break;
                    case 3 : utility.DisplayRoad(); break;
                    case 4 : return;
                    default : break;
                }
            }

        }
    }
}