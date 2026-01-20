namespace SortingAadharNumbers
{
    class SortingMenu
    {
        private ISorting utility;

        public SortingMenu()
        {
            utility = new SortingUtilityImpl();
        }

        public void Menu()
        {
            while (true)
            {
                Console.WriteLine("\nThe Aadhar Sorting");
                Console.WriteLine("1. Add Aadhar");
                Console.WriteLine("2. Sort Aadhar");
                Console.WriteLine("3. Search Aadhar");
                Console.WriteLine("4. Display Aadhar");
                Console.WriteLine("5. Exit");
                Console.Write("Enter Choice : ");
                int ch = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();

                switch (ch)
                {
                    case 1: utility.AddAadhar(); break;
                    case 2: utility.SortAadhar(); break;
                    case 3: utility.GetAadhar(); break;
                    case 4: utility.DisplayAllAadhar(); break;
                    case 5: return;
                    default : break;
                }
            }
        }
    }

}