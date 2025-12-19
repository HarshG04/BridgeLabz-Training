using System;
class KmToMiles2 {
  static void Main() {
        double km = double.Parse(Console.ReadLine());
        double miles = km/1.6;
        Console.WriteLine("The total miles is " + miles+ " mile for the given "+ km +" km");
    }
}