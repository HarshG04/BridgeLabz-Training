namespace EduResult{
    class Student
    {
        private static int NextId = 101;
        public string StudentId {get;}
        public int Marks {get;set;}
        public string District {get;set;}

        public Student()
        {
            StudentId = "S"+NextId;
            NextId++;
        }

        public override string ToString()
        {
            return $"{StudentId} || {Marks} || {District}";
        } 
    }
}