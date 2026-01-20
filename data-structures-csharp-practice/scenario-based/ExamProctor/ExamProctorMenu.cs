using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.data_structure_csharp_practice.scenario_based.ExamProctor
{
    internal class ExamProctorMenu
    {
        private IExamProctor proctor;
        public void Menu()
        {
            proctor = new ExamProctorUtilityImpl();
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Exam Proctor System");
                Console.WriteLine("1. Create Answer Key (Admin)");
                Console.WriteLine("2. Create Student");
                Console.WriteLine("3. View Current Student");
                Console.WriteLine("4. Track Question Navigation");
                Console.WriteLine("5. Submit All Answers");
                Console.WriteLine("6. Submit Exam");
                Console.WriteLine("7. Exit");
                Console.Write("Enter choice: ");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        proctor.CreateAnswerKey();
                        break;
                    case 2:
                        proctor.CreateStudent();
                        break;
                    case 3:
                        proctor.ViewCurrentStudent();
                        break;
                    case 4:
                        proctor.TrackNavigation();
                        break;
                    case 5:
                        proctor.SubmitAllAnswers();
                        break;
                    case 6:
                        proctor.SubmitExam();
                        break;
                    case 7:
                        return;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }
    }
}
