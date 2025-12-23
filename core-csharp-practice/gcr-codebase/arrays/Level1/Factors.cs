using System;

class Program
{
    static void Main()
    {
        
        Console.Write("Enter a num: ");
        int n = Convert.ToInt32(Console.ReadLine());

        int maxFactors = 10;
        int[] fact = new int[maxFactors];

        int idx = 0;

        for(int i = 1; i <= n; i++)
        {   
            if(n%i==0) fact[idx++] = i;
            if (idx >= maxFactors)
            {
                maxFactors *= 2;
                int[] temp = new int[maxFactors];
                for(int j=0;j<fact.Length;j++) temp[j] = fact[j];
                fact = temp;
            }
        }

        Console.WriteLine("Factors are: ");
        for(int i=0;i<fact.Length;i++) {if(fact[i]==0) break; Console.Write(fact[i]+" ");}
    }
}