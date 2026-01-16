namespace TrafficManager
{
    class VehicleNode
    {
        public static int NextId = 1;
        public string Id {get;set;}
        public VehicleNode Next {get;set;}

        public VehicleNode()
        {
            this.Id = "V"+NextId;
            NextId++;
        }
    }
}