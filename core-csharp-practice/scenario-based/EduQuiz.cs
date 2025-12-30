using System;
class EduQuiz
{
    private string[] correctAnswer = new string[10];



    // private void GetNoOfStudents()
    // {
    //     Console.Write("Enter No. Of Students: ");
    //     int num = Convert.ToInt32(Console.ReadLine());
    //     studentAnswer = new string[num,10];
    // }

    public void QuizMenu()
    {
        while(true){
            Console.WriteLine("\n\n-----Quiz Menu-----------");
            Console.WriteLine("1: Enter Correct Answer");
            Console.WriteLine("2: Enter Student's Answer and Get Score");
            Console.WriteLine("Other : Exit System");

            int option = Convert.ToInt32(Console.ReadLine());
            switch (option)
            {
                case 1 : EnterCorrectAnswers();
                        break;
                case 2 : GetStudentMarks();
                        break;
                default : return;
            }
        }
    }

    private void EnterCorrectAnswers()
    {
        Console.WriteLine("Enter correct answers: ");
        for(int i = 0; i < correctAnswer.Length; i++)
        {
            correctAnswer[i] = Console.ReadLine();
        }
        Console.WriteLine("---Done---\n");
    }

    private void GetStudentMarks()
    {
        string[] student = new string[10];
        Console.WriteLine("Enter student answers: ");
        for(int i = 0; i < student.Length; i++)
        {
            student[i] = Console.ReadLine();
            
        }
        Console.WriteLine("---Done---\n");

        // calculating Student Score and Percentage
        CalculateScore(student);

    }
    private void CalculateScore(string[] student)
    {
        int score = 0;
        for(int i = 0; i < correctAnswer.Length; i++)
        {
            if (correctAnswer[i].Equals(student[i]))
            {
                Console.WriteLine($"Question-{i+1} : Correct");
                score++;
            }
            else Console.WriteLine($"Question-{i+1} : InCorrect");
            
        }

        int percentage = score*10;


        bool isPass = false;
        isPass = score>3;
        Console.WriteLine("----------------------------------");
        Console.WriteLine($"Student Score : {score}");
        Console.WriteLine($"Student percentage : {percentage}%");
        Console.WriteLine($"Status : {(isPass ? "Pass" : "Fail")}");
        Console.WriteLine("----------------------------------");

    }

}


class Program
{
    static void Main()
    {
        EduQuiz quiz = new EduQuiz();
        quiz.QuizMenu();
    }
}