using System;

class IntOperation{
    static void Main(){

        int a = int.Parse(Console.ReadLine());
        int b = int.Parse(Console.ReadLine());
        int c = int.Parse(Console.ReadLine());

        int result1 = a + b * c;
        int result2 = a * b + c;
        int result3 = c + a / b;
        int result4 = a % b + c;

        Console.WriteLine("The results of Int Operations are " + result1 + ", " + result2 + ", " +result3 + ", and " + result4);
    }
}
