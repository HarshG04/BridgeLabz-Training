namespace StreamBuzz;

class StreamBuzzMenu
{
    private Creatorutil util = new Creatorutil();

    public void UserMenu()
    {
        while(true){
            Console.WriteLine("\n=======Stream Buzz==========");
            Console.WriteLine("1: Create New Creator");
            Console.WriteLine("2: Show Top Posts");
            Console.WriteLine("3: Display Average Weekly Likes");
            Console.WriteLine("4: Exit");
            Console.Write("Enter Choice: ");
            int ch = Convert.ToInt32(Console.ReadLine());
            switch (ch)
            {
                case 1 : util.RegisterCreator();   
                        break;
                case 2 : util.GetTopPostCounts();
                        break;
                case 3 : util.CalculateAverageLikes();
                        break;
                case 4 : Console.WriteLine("Logging off — Keep Creating with StreamBuzz!");
                        return;
                default : break;

            }
        }
    }


}