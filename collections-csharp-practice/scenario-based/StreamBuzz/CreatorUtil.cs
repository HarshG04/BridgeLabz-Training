namespace StreamBuzz;

class Creatorutil
{
    
    public static List<CreatorStats> EngagementBoard = new List<CreatorStats>();

    public void RegisterCreator()
    {
        CreatorStats newCreator = new CreatorStats();
        Console.Write("Enter Name: ");
        newCreator.CreatorName = Console.ReadLine();

        for(int i = 0; i < 4; i++)
        {
            Console.Write($"Likes For Week {i+1}: ");
            newCreator.WeeklyLikes[i] = Convert.ToInt32(Console.ReadLine());
        }
        
        EngagementBoard.Add(newCreator);

        Console.WriteLine("Creator Registered Successfully");
    }
    public void GetTopPostCounts()
    {
        Console.Write("Enter Like Threshold: ");
        double likeThreshold = Convert.ToDouble(Console.ReadLine());
        
        Dictionary<string,int> map = new Dictionary<string, int>();
        foreach(CreatorStats creator in EngagementBoard)
        {
            int count = 0;
            foreach(int likes in creator.WeeklyLikes)
            {
                if(likes>=likeThreshold) count++;
            }

            if (count > 0) map.Add(creator.CreatorName,count);
        }

        if(map.Count==0)
        {
            Console.WriteLine("No top-performing posts this week");
            return;
        }

        foreach(string name in map.Keys)
        {
            Console.WriteLine(name + " - " + map[name]);
        }
    }

    public void CalculateAverageLikes()
    {
        int totalLikes = 0;
        foreach(CreatorStats creator in EngagementBoard)
        {
            foreach(int likes in creator.WeeklyLikes)
            {
                totalLikes += likes;
            }
        }

        double average = totalLikes/EngagementBoard.Count;
        Console.WriteLine($"Overall average weekly likes: {average}");
    }



}