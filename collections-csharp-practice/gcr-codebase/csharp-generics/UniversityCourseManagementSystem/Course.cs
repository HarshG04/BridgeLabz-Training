namespace UniversityCourseManagement
{
    class Course<T> : BaseCourse where T : CourseType
    {
        public new T EvaluationType
        {
            get => (T)base.EvaluationType;
            set => base.EvaluationType = value;
        }
    }
}
