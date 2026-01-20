namespace ResumeScreeningSystem
{
    abstract class JobRole
    {
        public abstract string GetRoleName();
        public abstract int RequiredExperience();
    }

    abstract class BaseResume
    {
        public string CandidateName { get; set; } = "";
        public int Experience { get; set; }
        public JobRole Role { get; set; } = null!;

        public override string ToString()
        {
            return $"Name: {CandidateName}, Role: {Role.GetRoleName()}, Experience: {Experience} years";
        }
    }

     class SoftwareEngineer : JobRole
    {
        public override string GetRoleName() => "Software Engineer";
        public override int RequiredExperience() => 2;
    }

    class DataScientist : JobRole
    {
        public override string GetRoleName() => "Data Scientist";
        public override int RequiredExperience() => 3;
    }


    class Resume<T> : BaseResume where T : JobRole, new()
    {
        public Resume()
        {
            Role = new T();
        }
    }




}
