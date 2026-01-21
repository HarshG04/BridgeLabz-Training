using System;
using System.Collections.Generic;

class Patient
{
    public string Name;
    public int Severity;

    public Patient(string name, int severity)
    {
        Name = name;
        Severity = severity;
    }
}

class HospitalTriage
{
    static void Main()
    {
        PriorityQueue<Patient, int> pq = new PriorityQueue<Patient, int>();

        pq.Enqueue(new Patient("John", 3), -3);
        pq.Enqueue(new Patient("Alice", 5), -5);
        pq.Enqueue(new Patient("Bob", 2), -2);

        while (pq.Count > 0)
        {
            Patient p = pq.Dequeue();
            Console.WriteLine(p.Name);
        }
    }
}
