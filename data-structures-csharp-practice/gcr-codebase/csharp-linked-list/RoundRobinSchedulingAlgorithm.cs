using System;

class ProcessNode
{
    public int processId;
    public int burstTime;
    public int priority;

    public int remainingTime;
    public int waitingTime;
    public int turnAroundTime;

    public ProcessNode next;

    public ProcessNode(int id, int burst, int priority)
    {
        this.processId = id;
        this.burstTime = burst;
        this.priority = priority;

        this.remainingTime = burst;
        this.next = null;
    }
}

class RoundRobinScheduler
{
    private ProcessNode head = null;
    private ProcessNode tail = null;
    private int processCount = 0;

    public void AddProcess()
    {
        Console.Write("Enter Process ID: ");
        int id = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter Burst Time: ");
        int bt = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter Priority: ");
        int p = Convert.ToInt32(Console.ReadLine());

        ProcessNode newNode = new ProcessNode(id, bt, p);

        if (head == null)
        {
            head = tail = newNode;
            newNode.next = head;
        }
        else
        {
            tail.next = newNode;
            newNode.next = head;
            tail = newNode;
        }

        processCount++;
        Console.WriteLine("Process Added.");
    }

    public void DisplayProcesses()
    {
        if (head == null)
        {
            Console.WriteLine("No processes available.");
            return;
        }

        ProcessNode temp = head;

        Console.WriteLine("\nProcess Queue:");
        do
        {
            Console.WriteLine($"P{temp.processId} | BT={temp.burstTime} | RT={temp.remainingTime} | Priority={temp.priority}");
            temp = temp.next;
        }
        while (temp != head);
    }

    public void SimulateRoundRobin()
    {
        if (head == null)
        {
            Console.WriteLine("No processes to schedule.");
            return;
        }

        Console.Write("Enter Time Quantum: ");
        int quantum = Convert.ToInt32(Console.ReadLine());

        int time = 0;

        ProcessNode temp = head;

        Console.WriteLine("\n===== Round Robin Execution =====");

        while (head != null)
        {
            if (temp.remainingTime > 0)
            {
                int exec = Math.Min(quantum, temp.remainingTime);

                temp.remainingTime -= exec;
                time += exec;

                Console.WriteLine($"\nExecuted P{temp.processId} for {exec} units | Remaining={temp.remainingTime}");

                if (temp.remainingTime == 0)
                {
                    temp.turnAroundTime = time;
                    temp.waitingTime = temp.turnAroundTime - temp.burstTime;

                    Console.WriteLine($"--> P{temp.processId} Finished");
                    RemoveProcess(temp.processId);
                }
            }

            if (head == null)
                break;

            temp = temp.next;

            DisplayProcesses();
        }

        CalculateAverages();
    }

    private void RemoveProcess(int id)
    {
        if (head == null) return;

        ProcessNode current = head;
        ProcessNode prev = null;

        do
        {
            if (current.processId == id)
            {
                if (current == head && current == tail)
                {
                    head = tail = null;
                }
                else if (current == head)
                {
                    tail.next = head.next;
                    head = head.next;
                }
                else if (current == tail)
                {
                    prev.next = head;
                    tail = prev;
                }
                else
                {
                    prev.next = current.next;
                }

                processCount--;
                return;
            }

            prev = current;
            current = current.next;
        }
        while (current != head);
    }

    public void CalculateAverages()
    {
        Console.WriteLine("\n===== Final Stats =====");
        Console.WriteLine("(Already printed — modify if you want separate report)");
        Console.WriteLine("Waiting Time = TurnAround - BurstTime");
    }
}

class Program
{
    static void Main()
    {
        RoundRobinScheduler scheduler = new RoundRobinScheduler();

        while (true)
        {
            Console.WriteLine("\n===== CPU Scheduler Menu =====");
            Console.WriteLine("1. Add Process");
            Console.WriteLine("2. Display Processes");
            Console.WriteLine("3. Simulate Round Robin");
            Console.WriteLine("4. Exit");
            Console.Write("Enter choice: ");

            int ch = Convert.ToInt32(Console.ReadLine());
            if (ch == 4) break;

            switch (ch)
            {
                case 1: scheduler.AddProcess(); break;
                case 2: scheduler.DisplayProcesses(); break;
                case 3: scheduler.SimulateRoundRobin(); break;
                default: Console.WriteLine("Invalid choice."); break;
            }
        }
    }
}
