using System.Collections;

namespace TrafficManager
{
    class VehicleUtilityImpl : IVehicle
    {
        private int capacity;   // total capacity of road
        private int curr;       // current no of vehicles on road

        private Queue<VehicleNode> queue;

        private VehicleNode Head;
        private VehicleNode Tail;

        public VehicleUtilityImpl(int capacity)
        {
            queue = new Queue<VehicleNode>();
            this.capacity = capacity;
            curr = 0;
        }

        public void AddVehicle()
        {
            VehicleNode newVehicle = new VehicleNode();
            queue.Enqueue(newVehicle);
            Console.WriteLine($"Vehicle {newVehicle.Id} Added To Queue");

            AddToRoad();
        }

        private void AddToRoad()
        {
            if(curr==capacity) 
            {   
                Console.WriteLine("capacity is full for now");
                return;
            }


            while (queue.Count>0 && curr < capacity)
            {
                VehicleNode newVehicle = queue.Dequeue();
                if(Head==null)
                {
                    Head = newVehicle;
                    Tail = newVehicle;
                    newVehicle.Next = Head;
                }
                else
                {
                    Tail.Next = newVehicle;
                    Tail = newVehicle;
                    Tail.Next = Head;                    
                }

                curr++;
                Console.WriteLine($"Vehicle {newVehicle.Id} Added To Road [{curr}/{capacity}]");
            }
        }

        public void RemoveVehicle()
        {
            if(Head==null && Tail==null)
            {
                Console.WriteLine("No Vehicle On Road");
                return;
            }
            
            // removing head

            VehicleNode removedVehicle = Head;
            if(Head==Tail)
            {
                Head = null;
                Tail = null;
            }
            else
            {
                Tail.Next = Head.Next;
                Head = Head.Next;
            }

            curr--;
            Console.WriteLine($"Vehicle {removedVehicle.Id} Removed [{curr}/{capacity}]");
            AddToRoad();
        }

        public void DisplayRoad()
        {
            if(Head == null)
            {
                Console.WriteLine("No Vehicles On Road");
                return;
            }

            Console.WriteLine();
            VehicleNode temp = Head;


            do
            {
                Console.Write($"[{temp.Id}]-->");
                temp = temp.Next;
            }
            while(temp != Head);
        }

    }
}