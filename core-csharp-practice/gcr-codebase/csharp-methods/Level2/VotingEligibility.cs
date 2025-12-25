using System;
class Divisibility
{
    static void Main()
    {   
        Console.Write("Enter 10 ages: ");
        int[] ages = new int[10];
        StudentVoteChecker svc = new();
        
        for(int i=0;i<10;i++)
        {
            ages[i] = Convert.ToInt32(Console.ReadLine());
            bool canVote = svc.CanStudentVote(ages[i]);
            Console.WriteLine(canVote ? "User Can Vote" : "User Can not vote");
        }
        
    }

    class StudentVoteChecker
    {
         public bool CanStudentVote(int age)
        {
            return age >= 18;
        }
    }
}

