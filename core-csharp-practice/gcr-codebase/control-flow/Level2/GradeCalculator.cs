using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter Chemistry Marks: ");
        int chem = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter Physics Marks: ");
        int phy = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter Maths Marks: ");
        int math = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine();
    
        double per = (chem+phy+math)/3.0;
        switch (per)
        {
            case >=80 : Console.WriteLine($"Marks : {per}\nGrade : A\nRemark: Level 4, above agency-normalized standards");
            break;
            case >= 70 and <=79 : Console.WriteLine($"Marks : {per}\nGrade : B\nRemark: Level 3, at agency-normalized standards");
            break;
            case >= 60 and <= 69 : Console.WriteLine($"Marks : {per}\nGrade : C\nRemark: (Level 2, below, but approaching agency-normalized standards)");
            break;
            case >= 50 and <= 59 : Console.WriteLine($"Marks : {per}\nGrade : D\nRemark: (Level 1, well below agency-normalized standards)");
            break;
            case >= 40 and <= 49 : Console.WriteLine($"Marks : {per}\nGrade : E\nRemark: (Level 1- , too below agency-normalized standards)");
            break;
            default : Console.WriteLine($"Marks : {per}\nGrade : R\nRemark: (Remedial standards)");
            break;
        }
    }
}