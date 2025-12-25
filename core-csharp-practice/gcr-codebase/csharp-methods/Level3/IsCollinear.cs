using System;
class Program
{
    static void Main()
    {
        Console.WriteLine("Enter x1 and y1: ");
        double x1 = Convert.ToDouble(Console.ReadLine());
        double y1 = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Enter x2 and y2: ");
        double x2 = Convert.ToDouble(Console.ReadLine());
        double y2 = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Enter x3 and y3: ");
        double x3 = Convert.ToDouble(Console.ReadLine());
        double y3 = Convert.ToDouble(Console.ReadLine());

        bool slopeCheck = AreCollinearSlope(x1, y1, x2, y2, x3, y3);
        bool areaCheck  = AreCollinearArea(x1, y1, x2, y2, x3, y3);

        Console.WriteLine($"\nCollinear using slope method? {slopeCheck}");
        Console.WriteLine($"Collinear using area method?  {areaCheck}");
    }

    static bool AreCollinearSlope(double x1, double y1,double x2, double y2,double x3, double y3)
    {
        double slopeAB, slopeBC, slopeAC;

        slopeAB = (y2 - y1) / (x2 - x1);
        slopeBC = (y3 - y2) / (x3 - x2);
        slopeAC = (y3 - y1) / (x3 - x1);

        return slopeAB == slopeBC && slopeBC == slopeAC;
    }

    static bool AreCollinearArea(double x1, double y1,double x2, double y2,double x3, double y3)
    {
        double area = 0.5 * (x1 * (y2 - y3) +x2 * (y3 - y1) +x3 * (y1 - y2));
        return area==0;
    }
}
