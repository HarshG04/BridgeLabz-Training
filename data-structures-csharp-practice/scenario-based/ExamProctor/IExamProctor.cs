using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.data_structure_csharp_practice.scenario_based.ExamProctor
{
    // Interface Class 
    internal interface IExamProctor
    {
        void CreateAnswerKey();
        void CreateStudent();
        void ViewCurrentStudent();
        void TrackNavigation();
        void SubmitAllAnswers();
        void SubmitExam();
    }
}
