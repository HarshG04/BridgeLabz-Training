using System;
class Program{

    
    static void Main()
    {
        while (min<=max)
        {
            int num = GenerateGuess();
            int feedback = UserFeedback(num);
            if(feedback==0) return;
            else if(feedback==1) max = num-1;
            else min = num+1;
        }
    }

    static int min = 1;
    static int max = 100;

    static int GenerateGuess()
    {
        int mid = (min+max)/2;
        return mid;
    }
    static int UserFeedback(int guess)
    {
        Console.WriteLine($"{guess} : is this number low, high or correct");
        string s = Console.ReadLine();
        switch (s)
        {
            case "high" : return 1;
            case "low" : return -1;
            default : return 0;
        }

    }
}


