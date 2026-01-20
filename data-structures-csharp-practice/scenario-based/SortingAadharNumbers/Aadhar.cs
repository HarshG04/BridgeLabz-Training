namespace SortingAadharNumbers{
    class Aadhar
    {
        public static int NextId = 101;
        public string AdharName {get;}
        public long AadharNumber{get;set;}

        public Aadhar()
        {
            this.AdharName = "A-"+NextId;
            NextId++;
        }

        public override string ToString()
        {
            return $"{AadharNumber} || {AdharName}";
        }
    }

}