using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.data_structure_csharp_practice.scenario_based.ExamProctor
{
    // Encapsulated Student Class
    internal class Student
    {
        private static int nextId = 1;

        public int StudentId { get; }
        public Stack<int> NavigationStack { get; }
        public Dictionary<int, string> Answers { get; }

        public Student()
        {
            StudentId = nextId++;
            NavigationStack = new Stack<int>();
            Answers = new Dictionary<int, string>();
        }
    }
}
