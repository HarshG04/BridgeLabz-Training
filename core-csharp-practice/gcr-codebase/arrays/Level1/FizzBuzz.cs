using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        int n = Convert.ToInt32(Console.ReadLine());
        if(n<0) Console.WriteLine("Number is Not Positive");
        else
        {
            string[] arr = new string[n+1];
            for(int i = 0; i <= n; i++)
            {
                if(i%3==0 && i%5==0) arr[i] = "FizzBuzz";
                else if(i%3==0) arr[i] = "Fizz";
                else if(i%5==0) arr[i] = "Buzz";
                else arr[i] = i.ToString();
            }

            for(int i=0;i<=n;i++) Console.WriteLine($"Position {i} = {arr[i]}");
        }
    }
}