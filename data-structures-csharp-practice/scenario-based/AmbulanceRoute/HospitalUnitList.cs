namespace AmbulanceRoute
{
    class HospitalUnitNode
    {
        public string UnitName{get;set;}
        public bool IsAvailable{get;set;}
        public string PatientName {get;set;}
        public HospitalUnitNode Next {get;set;}  
    }

    class HospitalUnitList
    {
        private HospitalUnitNode Head;
        private HospitalUnitNode Tail;
        private HospitalUnitNode Curr;
        private int size = 0;


        public void AddUnit(string unitName,bool IsAvailable)
        {
            HospitalUnitNode newUnit = new HospitalUnitNode();
            newUnit.UnitName = unitName;
            newUnit.IsAvailable = IsAvailable;

            if (size == 0)
            {
                Head = newUnit;
                Tail = newUnit;
                Curr = Head;
            }
            else
            {
                Tail.Next = newUnit;
                Tail = newUnit;
            }
            Tail.Next = Head;
            size++;

            Console.WriteLine($"Unit {unitName} Added Successfully");
        }

        public void AddPatient(string patientName)
        {
            HospitalUnitNode temp = Curr;
            while (true)
            {
                if (temp.IsAvailable)
                {
                    temp.PatientName = patientName;
                    temp.IsAvailable = false;
                    Console.WriteLine($"Patient Admitted In {temp.UnitName}");
                    Curr = temp.Next;
                    return;
                }
                temp = temp.Next;
                if(temp==Curr)  break;
            }

            Console.WriteLine("No Space Is Available");
        }
        public void RemovePatient(string patientName)
        {
            HospitalUnitNode temp = Head;
            while (true)
            {
                if (temp.PatientName != null && temp.PatientName.Equals(patientName))
                {
                    temp.PatientName = null;
                    temp.IsAvailable = true;
                    Console.WriteLine($"Patient Removed From {temp.UnitName}");
                    return;
                }
                temp = temp.Next;
                if(temp==Head)  break;
            }

            Console.WriteLine("No Patient Found");
        }


        public void DisplayStatus()
        {
            if (Head == null)
            {
                Console.WriteLine("Hospital is empty");
                return;
            }

            HospitalUnitNode temp = Head;

            Console.WriteLine("\n--- Hospital Unit Status ---");
            while(true)
            {
                Console.WriteLine(
                    $"Unit: {temp.UnitName} | " +
                    $"Available: {temp.IsAvailable} | " +
                    $"Patient: {(temp.PatientName ?? "None")}"
                );
                temp = temp.Next;
                if(temp==Head) break;
            } 
        }
        
    }
}