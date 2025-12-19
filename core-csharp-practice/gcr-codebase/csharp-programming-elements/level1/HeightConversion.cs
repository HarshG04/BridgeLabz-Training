using System;
class HeightConversion {
    static void Main() {
        double height = double.Parse(Console.ReadLine());
    
        double inch = (height/2.54);
        double feet = (int)(inch/12);
        inch = inch%12;

        Console.WriteLine(feet + " " + inch);
    }
}