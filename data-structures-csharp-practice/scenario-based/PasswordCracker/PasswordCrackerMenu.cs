namespace PasswordCracker
{
    class PasswordCrackerMenu
    {
        private IPassword utility;

        public void Start()
        {
            utility = new PasswordUtilityImpl();

            while(true)
            {
                Console.WriteLine("\n===Password Cracker===");
                Console.WriteLine("1: Set Password");
                Console.WriteLine("2: Generate Strings of Length n");
                Console.WriteLine("3: Crack Password");
                Console.WriteLine("4: Exit");

                Console.Write("Enter Choice: ");
                int ch = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
                switch (ch)
                {
                    case 1 : utility.SetPassword(); break;
                    case 2 : utility.GenerateStrings(); break;
                    case 3 : utility.DecodePassword(); break;
                    case 4 : return;
                    default : break;
                }
            }
        }

    }
}