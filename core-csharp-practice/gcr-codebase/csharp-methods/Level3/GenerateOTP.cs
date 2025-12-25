using System;

class Program
{
    static void Main()
    {
        int[] otps = new int[10];

        for (int i = 0; i < 10; i++)
        {
            otps[i] = GenerateOTP();
            Console.WriteLine($"OTP {i + 1}: {otps[i]}");
        }

        bool unique = IsUnique(otps);

        Console.WriteLine($"\nAre all OTPs unique? {unique}");
    }

    static int GenerateOTP()
    {   
        Random rnd = new Random();
        int n = rnd.Next(100000, 1000000);
        return n;
    }

    static bool IsUnique(int[] otps)
    {
        for(int i = 0; i < otps.Length; i++)
        {
            for(int j = i + 1; j < otps.Length; j++)
            {
                if(otps[i]==otps[j]) return false;
            }
        }

        return true;
    }
}
