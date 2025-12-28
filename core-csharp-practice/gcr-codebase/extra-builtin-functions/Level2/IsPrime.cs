using System;
class Program
{
    static void Main()
    {
        Console.Write("enter a num: ");
        int n = Convert.ToInt32(Console.ReadLine());
        bool isPrime = CheckPrime(n);
        Console.WriteLine(isPrime?"Prime":"Not Prime");
    }
    static bool CheckPrime(int n)
    {
        if(n==2) return true;
        if(n%2==0) return false;

        for(int i = 3; i * i < n; i += 2)
        {
            if(n%i==0) return false;
        }
        return true;
    }

}