namespace AmbulanceRoute
{
    class AmbulanceRouteUtilityImpl : IAmbulanceRoute
    {
        private HospitalUnitList Hospital;

        public AmbulanceRouteUtilityImpl()
        {
            Hospital = new HospitalUnitList();
            CreateHospitalList();
        }

        private void CreateHospitalList()
        {
            Hospital.AddUnit("Emergency",true);
            Hospital.AddUnit("Radiology",true);
            Hospital.AddUnit("Surgery",true);
            Hospital.AddUnit("ICU",true);

            Console.WriteLine("Hospital Created Successfully .. .");
        }


        public void AddPatient()
        {
            Console.Write("Enter Patient Name: ");
            string patient = Console.ReadLine();

            Hospital.AddPatient(patient);
        }

        public void RemovePatient()
        {
            Console.Write("Enter Patient Name: ");
            string patient = Console.ReadLine();

            Hospital.RemovePatient(patient);
        }

        public void DisplayStatus()
        {
            Hospital.DisplayStatus();
        }

    }

}