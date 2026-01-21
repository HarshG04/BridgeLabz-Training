using System;

namespace EduResult
{
    class EduResultMenu
    {
        private IEduResult utility;

        public EduResultMenu()
        {
            utility = new EduResultUtilityImpl();
        }

        public void ShowMenu()
        {
  

            while(true)
            {
                Console.WriteLine("\n===== EDU RESULT MENU =====");
                Console.WriteLine("1. Add District Results");
                Console.WriteLine("2. Show District Rank List");
                Console.WriteLine("3. Sort State Result");
                Console.WriteLine("4. Show State Rank List");
                Console.WriteLine("5. Exit");
                Console.Write("Enter choice: ");

                int ch = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();

                switch (ch)
                {
                    case 1: utility.AddResult(); break;
                    case 2: utility.ShowDistrictRankList(); break;
                    case 3: utility.SortResult(); break;
                    case 4: utility.ShowRankList(); break;
                    case 5: return;
                    default: break;
                }

            }
        }
    }
}
