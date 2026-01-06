using System;

class TelecomComapny
{
    static string name = "Goyal Communications Pvt. Ltd.";
    CallLog[] callLogs;
    private int idx;

    public TelecomComapny(int cap)
    {
        callLogs = new CallLog[cap];
        idx = 0;
    }

    public void AddCallLog()
    {
        if(idx>=callLogs.Length)
        {
            Console.WriteLine("====Capacity is Full====");
            return;
        }
        Console.Write("Enter Phone Number: "); 
        int pno = Convert.ToInt32(Console.ReadLine()); 
        Console.Write("Enter Message: ");
        string msg = Console.ReadLine(); 
        CallLog newCallLog = new CallLog(pno,msg); 
        callLogs[idx++] = newCallLog; 
    }

   public void SearchByKeyword()
    {
        Console.Write("Enter the keyword: ");
        string keyword = Console.ReadLine();

        for (int i = 0; i < idx; i++)
        {
            if (callLogs[i].message.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0)
            {
                callLogs[i].ShowCallLog();
            }
        }
    }


    public void FilterByTime()
    {
        for (int i = 0; i < idx - 1; i++)
        {
            bool flag = true;

            for (int j = 0; j < idx - 1 - i; j++)
            {
                CallLog c1 = callLogs[j];
                CallLog c2 = callLogs[j + 1];

                if (c1.timeStamp.CompareTo(c2.timeStamp) > 0)
                {
                    callLogs[j] = c2;
                    callLogs[j + 1] = c1;
                    flag = false;
                }
            }

            if (flag) break;
        }

        ShowAllLogs();
    }

    public void ShowAllLogs()
    {
        if (idx == 0)
        {
            Console.WriteLine("No logs available.");
            return;
        }

        Console.WriteLine("===== All Logs ===== ");
        for (int i = 0; i < idx; i++)
        {
            callLogs[i].ShowCallLog();
        }
    }
}

class CallLog
{
    public int phoneNumber;
    public string message;
    public DateTime timeStamp;

    static Random r = new Random();

    public CallLog(int pno, string msg)
    {
        phoneNumber = pno;
        message = msg;

        DateTime start = DateTime.Now.AddDays(-7);   // last 7 days
        int range = (int)(DateTime.Now - start).TotalSeconds;

        timeStamp = start.AddSeconds(r.Next(range));
    }

    public void ShowCallLog()
    {
        Console.WriteLine($"Phone Number : {phoneNumber}");
        Console.WriteLine($"Message      : {message}");
        Console.WriteLine($"Time Stamp   : {timeStamp}");
        Console.WriteLine();
    }
}

class Program
{
    
    static void Main(String[] args)
    {
        Console.Write("Enter call log capacity: ");
        int cap = Convert.ToInt32(Console.ReadLine());

        TelecomComapny t = new TelecomComapny(cap);

        while (true)
        {
            Console.WriteLine("\n1. Add Call Log");
            Console.WriteLine("2. Show All Call Logs");
            Console.WriteLine("3. Search By Keyword");
            Console.WriteLine("4. Sort By Time");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:t.AddCallLog();
                    break;

                case 2:t.ShowAllLogs();
                    break;

                case 3:t.SearchByKeyword();
                    break;

                case 4:t.FilterByTime();
                    break;

                case 5:return;

                default:Console.WriteLine("Invalid choice");
                    break;
            }
        }
    }
}
