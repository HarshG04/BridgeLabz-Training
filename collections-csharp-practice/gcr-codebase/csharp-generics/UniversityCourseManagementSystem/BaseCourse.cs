namespace UniversityCourseManagement
{
    abstract class BaseCourse
    {
        public string CourseName { get; set; } = "";
        public string Department { get; set; } = "";
        public CourseType EvaluationType { get; set; } = null!;

        public override string ToString()
        {
            return $"Course: {CourseName}, Department: {Department}, Evaluation: {EvaluationType.GetEvaluationType()}";
        }
    }
}
