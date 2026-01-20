using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.data_structure_csharp_practice.scenario_based.ExamProctor
{
    internal class ExamProctorUtilityImpl : IExamProctor
    {
        private Student currentStudent;
        private Dictionary<int, string> correctAnswers;

        public ExamProctorUtilityImpl()
        {
            correctAnswers = new Dictionary<int, string>();
        }

        public void CreateAnswerKey()
        {
            Console.Write("Enter total number of questions: ");
            int total = Convert.ToInt32(Console.ReadLine());

            correctAnswers.Clear();

            for (int i = 1; i <= total; i++)
            {
                Console.Write("Enter correct answer for Q" + i + ": ");
                correctAnswers[i] = Console.ReadLine();
            }
        }

        public void CreateStudent()
        {
            currentStudent = new Student();
            Console.WriteLine("Student created with ID: " + currentStudent.StudentId);
        }

        public void ViewCurrentStudent()
        {
            if (currentStudent == null)
            {
                Console.WriteLine("No student is currently active.");
                return;
            }

            Console.WriteLine("Current Student ID: " + currentStudent.StudentId);
        }

        public void TrackNavigation()
        {
            if (currentStudent == null)
            {
                Console.WriteLine("No student is currently active.");
                return;
            }

            Console.Write("Enter number of questions visited: ");
            int count = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                Console.Write("Enter question ID visited: ");
                int qid = Convert.ToInt32(Console.ReadLine());
                currentStudent.NavigationStack.Push(qid);
            }
        }

        public void SubmitAllAnswers()
        {
            if (currentStudent == null)
            {
                Console.WriteLine("No student is currently active.");
                return;
            }

            foreach (int qid in correctAnswers.Keys)
            {
                Console.Write("Enter answer for Q" + qid + ": ");
                currentStudent.Answers[qid] = Console.ReadLine();
            }
        }

        public void SubmitExam()
        {
            if (currentStudent == null)
            {
                Console.WriteLine("No student is currently active.");
                return;
            }

            int score = CalculateScore(currentStudent.Answers);
            Console.WriteLine(
                "Final Score for Student " + currentStudent.StudentId +
                ": " + score + "/" + correctAnswers.Count
            );
        }

        private int CalculateScore(Dictionary<int, string> studentAnswers)
        {
            int score = 0;

            foreach (KeyValuePair<int, string> entry in correctAnswers)
            {
                if (studentAnswers.ContainsKey(entry.Key) &&
                    studentAnswers[entry.Key] == entry.Value)
                {
                    score++;
                }
            }
            return score;
        }
    }
}
