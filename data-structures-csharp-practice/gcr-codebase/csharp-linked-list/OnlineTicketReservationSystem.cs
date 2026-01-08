using System;

class TicketNode
{
    public int ticketId;
    public string customerName;
    public string movieName;
    public string seatNumber;
    public DateTime bookingTime;

    public TicketNode next;

    public TicketNode(int id, string customer, string movie, string seat)
    {
        ticketId = id;
        customerName = customer;
        movieName = movie;
        seatNumber = seat;
        bookingTime = DateTime.Now;
        next = null;
    }
}

class TicketSystem
{
    private TicketNode head = null;
    private TicketNode tail = null;
    private int ticketCounter = 1;

    // Add Ticket at End
    public void AddTicket()
    {
        Console.Write("Enter Customer Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter Movie Name: ");
        string movie = Console.ReadLine();

        Console.Write("Enter Seat Number: ");
        string seat = Console.ReadLine();

        TicketNode newTicket = new TicketNode(ticketCounter++, name, movie, seat);

        if (head == null)
        {
            head = newTicket;
            tail = newTicket;
            newTicket.next = head;
        }
        else
        {
            tail.next = newTicket;
            tail = newTicket;
            tail.next = head;
        }

        Console.WriteLine("Ticket Booked Successfully.\n");
    }

    // Remove Ticket by ID
    public void RemoveTicket()
    {
        if (head == null)
        {
            Console.WriteLine("No tickets available.");
            return;
        }

        Console.Write("Enter Ticket ID to Remove: ");
        int id = Convert.ToInt32(Console.ReadLine());

        TicketNode temp = head;
        TicketNode prev = null;

        // Special case: only one node
        if (head == tail && head.ticketId == id)
        {
            head = null;
            tail = null;
            Console.WriteLine("Ticket Removed.");
            return;
        }

        // Removing head
        if (head.ticketId == id)
        {
            tail.next = head.next;
            head = head.next;
            Console.WriteLine("Ticket Removed.");
            return;
        }

        while (temp.next != head)
        {
            prev = temp;
            temp = temp.next;

            if (temp.ticketId == id)
            {
                prev.next = temp.next;

                // If deleting tail
                if (temp == tail)
                    tail = prev;

                Console.WriteLine("Ticket Removed.");
                return;
            }
        }

        Console.WriteLine("Ticket Not Found.");
    }

    // Display All Tickets
    public void DisplayTickets()
    {
        if (head == null)
        {
            Console.WriteLine("No tickets booked.");
            return;
        }

        TicketNode temp = head;

        Console.WriteLine("\n===== Booked Tickets =====");

        while (true)
        {
            Console.WriteLine($"TicketID: {temp.ticketId}, Customer: {temp.customerName}, Movie: {temp.movieName}, Seat: {temp.seatNumber}, Time: {temp.bookingTime}");

            temp = temp.next;

            if (temp == head)
                break;
        }
    }

    // Search Ticket by Customer or Movie
    public void SearchTicket()
    {
        if (head == null)
        {
            Console.WriteLine("No tickets available.");
            return;
        }

        Console.Write("Enter Customer Name or Movie Name: ");
        string key = Console.ReadLine();

        TicketNode temp = head;
        bool found = false;

        while (true)
        {
            if (temp.customerName.Equals(key, StringComparison.OrdinalIgnoreCase) ||
                temp.movieName.Equals(key, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine($"TicketID: {temp.ticketId}, Customer: {temp.customerName}, Movie: {temp.movieName}, Seat: {temp.seatNumber}, Time: {temp.bookingTime}");
                found = true;
            }

            temp = temp.next;
            if (temp == head)
                break;
        }

        if (!found)
            Console.WriteLine("Ticket Not Found.");
    }

    // Count Tickets
    public void CountTickets()
    {
        if (head == null)
        {
            Console.WriteLine("Total Tickets: 0");
            return;
        }

        int count = 0;
        TicketNode temp = head;

        while (true)
        {
            count++;
            temp = temp.next;
            if (temp == head)
                break;
        }

        Console.WriteLine($"Total Tickets: {count}");
    }
}

class Program
{
    static void Main()
    {
        TicketSystem system = new TicketSystem();

        while (true)
        {
            Console.WriteLine("\n===== Ticket Reservation System =====");
            Console.WriteLine("1. Book Ticket");
            Console.WriteLine("2. Cancel Ticket");
            Console.WriteLine("3. View Tickets");
            Console.WriteLine("4. Search Ticket");
            Console.WriteLine("5. Count Tickets");
            Console.WriteLine("6. Exit");
            Console.Write("Enter Choice: ");

            int ch = Convert.ToInt32(Console.ReadLine());

            switch (ch)
            {
                case 1: system.AddTicket(); break;
                case 2: system.RemoveTicket(); break;
                case 3: system.DisplayTickets(); break;
                case 4: system.SearchTicket(); break;
                case 5: system.CountTickets(); break;
                case 6: return;
                default: Console.WriteLine("Invalid Choice."); break;
            }
        }
    }
}
