using System;
class Program
{
    static void Main()
    {
        Console.WriteLine("Enter 5 values : ");
        int[] arr = new int[5];
        for(int i=0;i<5;i++) arr[i] = Convert.ToInt32(Console.ReadLine());

        CheckPositivity(arr);

        int check = Compare(arr);
        if(check==0) Console.WriteLine("Equal");
        Console.WriteLine(check==1 ? "Greater" : "Lesser");

    
    }

    static void CheckPositivity(int[] arr)
    {   

        foreach(int i in arr)
        {
            if (i > 0)
            {
                bool check = CheckOddEven(i);
                Console.WriteLine(check ? $"{i} : Positive and Even" : $"{i} : Positive and Odd");
            }else if(i<0) Console.WriteLine($"{i} : Number is Negative");
            else Console.WriteLine($"{i} : Number is Zero");
        }
    }

    static bool CheckOddEven(int n) {return (n%2==0);}

    static int Compare(int[] arr)
    {
        if(arr[0]==arr[4]) return 0;
        return arr[0]>arr[4] ? 1 : -1;
    }

}