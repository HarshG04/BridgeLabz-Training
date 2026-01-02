using System;

class Bus
{
    string[,] busStops;              // [i,0]=name  [i,1]=distance wrt initial point
    Passanger[] passengerInfo;       // array of passenger objects

    int totalPassengers = 0;
    int currStop = 0;

    public void SetBusStopage()
    {
        Console.Write("Enter the no. of stoppages: ");
        int n = Convert.ToInt32(Console.ReadLine());

        busStops = new string[n, 2];

        Console.WriteLine("Enter Stop name and their distance from initial stop:");

        for (int i = 0; i < n; i++)
        {
            Console.Write($"{i + 1} Stop Name: ");
            busStops[i, 0] = Console.ReadLine();

            Console.Write("Distance wrt Initial stop: ");
            busStops[i, 1] = Console.ReadLine();
        }

        Console.Write("Enter Bus Capacity: ");
        int cap = Convert.ToInt32(Console.ReadLine());

        passengerInfo = new Passanger[cap];
    }

    public void StartBus()
    {
        Console.WriteLine($"Stop Name : {busStops[currStop, 0]}");
        BoardPassenger();
        MoveBus();
    }

    public void MoveBus()
    {
        if (currStop == busStops.GetLength(0) - 1)
            return;

        currStop++;

        Console.WriteLine($"\nStop Name : {busStops[currStop, 0]}");

        bool isLastStop = currStop == busStops.GetLength(0) - 1;

        // LAST STOP — auto deboard everyone
        if (isLastStop)
        {
            Console.WriteLine("\nLast Stop Reached — Auto Deboarding All Passengers:\n");
            ForceDeboardAll();
            return;
        }

        GetOffPassenger();
        BoardPassenger();

        MoveBus();
    }

    public void BoardPassenger()
    {
        if (totalPassengers >= passengerInfo.Length)
        {
            Console.WriteLine("Bus is full");
            return;
        }

        int available = passengerInfo.Length - totalPassengers;

        Console.Write($"Enter no. of passengers to board (capacity left {available}): ");
        int n = Convert.ToInt32(Console.ReadLine());
        if (n == 0) return;

        n = Math.Min(n, available);

        for (int i = 0; i < passengerInfo.Length && n > 0; i++)
        {
            if (passengerInfo[i] == null)
            {
                Console.Write("Enter Passenger Name: ");
                string pname = Console.ReadLine();

                Console.Write("Enter destination stop name: ");
                string des = Console.ReadLine();

                Console.Write("Enter Lucky Number: ");
                int lnum = Convert.ToInt32(Console.ReadLine());

                int[] disFair = CalculateDistanceAndFare(des);

                Passanger p = new Passanger(
                    pname,
                    busStops[currStop, 0],
                    des,
                    i + 1,
                    disFair[1],
                    disFair[0],
                    lnum
                );

                passengerInfo[i] = p;

                totalPassengers++;

                n--;
            }
        }
    }

    public void GetOffPassenger()
    {
        Console.WriteLine("\nDeboarding Passengers... :");

        for (int i = 0; i < passengerInfo.Length; i++)
        {
            if (passengerInfo[i] != null && passengerInfo[i].endPoint.Equals(busStops[currStop, 0]))
            {
                Console.WriteLine($"Name: {passengerInfo[i].name} || Fare: {passengerInfo[i].fair} || Winner: {passengerInfo[i].CheckWin()}");
                passengerInfo[i] = null;
                totalPassengers--;
            }
        }
    }

    private void ForceDeboardAll()
    {
        for (int i = 0; i < passengerInfo.Length; i++)
        {
            if (passengerInfo[i] != null)
            {
                Console.WriteLine($"Name: {passengerInfo[i].name} || Fare: {passengerInfo[i].fair} || Winner: {passengerInfo[i].CheckWin()}");
                passengerInfo[i] = null;
            }
        }

        totalPassengers = 0;
    }

    int[] CalculateDistanceAndFare(string des)
    {
        int passDistance = 0;

        for (int i = currStop; i < busStops.GetLength(0); i++)
        {
            if (busStops[i, 0].Equals(des))
            {
                passDistance =
                    Convert.ToInt32(busStops[i, 1]) -
                    Convert.ToInt32(busStops[currStop, 1]);
                break;
            }
        }

        return new int[] { passDistance, passDistance * 10 };
    }
}

class Passanger
{
    public string name;
    public int seatNo;
    public string startPoint;
    public string endPoint;
    public int lottaryNumber;
    private bool isWinner;
    public int travelDistance;
    public int fair;

    public Passanger(string name,string startPoint,string endPoint,int seatNo,int fair,int travelDistance,int lottaryNumber)
    {
        this.name = name;
        this.seatNo = seatNo;
        this.startPoint = startPoint;
        this.endPoint = endPoint;
        this.fair = fair;
        this.travelDistance = travelDistance;
        this.lottaryNumber = lottaryNumber;
        this.isWinner = SetWin();
    }

    private bool SetWin()
    {
        return (lottaryNumber % 3 == 0 && lottaryNumber % 5 == 0);
    }

    public bool CheckWin()
    {
        return this.isWinner;
    }
}

class Program
{
    static void Main()
    {
        Bus bus = new Bus();
        bus.SetBusStopage();

        Console.WriteLine("\nBus Journey Started!!!");
        bus.StartBus();
        Console.WriteLine("\nBus has reached the Destination!!!");
    }
}
