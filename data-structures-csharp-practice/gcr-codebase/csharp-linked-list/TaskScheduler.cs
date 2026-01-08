using System;

class TaskNode
{
    public int taskId;
    public string taskName;
    public string priority;   // Urgent / Normal
    public DateTime dueDate;

    public TaskNode next;

    public TaskNode(int id, string name, string priority, DateTime due)
    {
        this.taskId = id;
        this.taskName = name;
        this.priority = priority;
        this.dueDate = due;
        this.next = null;
    }
}

class TaskScheduler
{
    private TaskNode head = null;
    private TaskNode current = null;

    public void AddTask()
    {
        Console.Write("Enter Task ID: ");
        int id = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter Task Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter Priority (Urgent/Normal): ");
        string priority = Console.ReadLine();

        Console.Write("Enter Due Date (yyyy-mm-dd): ");
        DateTime due = Convert.ToDateTime(Console.ReadLine());

        TaskNode newTask = new TaskNode(id, name, priority, due);

        if (head == null)
        {
            head = newTask;
            head.next = head;
            current = head;
        }
        else
        {
            TaskNode temp = head;

            while (temp.next != head) temp = temp.next;

            temp.next = newTask;
            newTask.next = head;
        }

        Console.WriteLine("Task Added.");
    }

    public void RemoveTask()
    {
        if (head == null)
        {
            Console.WriteLine("No tasks available.");
            return;
        }

        Console.Write("Enter Task ID to Remove: ");
        int id = Convert.ToInt32(Console.ReadLine());

        TaskNode temp = head;
        TaskNode prev = null;

        if (head.taskId == id)
        {
            // only one node present
            if (head.next == head)
            {
                head = null;
                current = null;
            }
            else
            {
                // find last node to fix circular link
                while (temp.next != head)
                    temp = temp.next;

                temp.next = head.next;
                head = head.next;
                current = head;
            }

            Console.WriteLine("Task Removed.");
            return;
        }

        temp = head.next;
        prev = head;

        while (temp != head)
        {
            if (temp.taskId == id)
            {
                prev.next = temp.next;
                Console.WriteLine("Task Removed.");
                return;
            }

            prev = temp;
            temp = temp.next;
        }

        Console.WriteLine("Task Not Found.");
    }



    public void ViewCurrentTask()
    {
        if (current == null)
        {
            Console.WriteLine("No tasks scheduled.");
            return;
        }

        Console.WriteLine($"\nCurrent Task: {current.taskId} : {current.taskName} | {current.priority} | {current.dueDate}");
        current = current.next;
    }

    public void DisplayAll()
    {
        if (head == null)
        {
            Console.WriteLine("No tasks to show.");
            return;
        }

        TaskNode temp = head;

        Console.WriteLine("\n===== All Tasks =====");

        while (temp != null)
        {
            Console.WriteLine($"{temp.taskId} | {temp.taskName} | {temp.priority} | {temp.dueDate}");
            temp = temp.next;

            if (temp == head) break;
        }

    }


    public void SearchByPriority()
    {
        if (head == null)
        {
            Console.WriteLine("No tasks available.");
            return;
        }

        Console.Write("Enter Priority to Search (Urgent/Normal): ");
        string p = Console.ReadLine();

        TaskNode temp = head;
        bool found = false;

        while (temp != null)
        {
            if (temp.priority.Equals(p, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine($"{temp.taskId} | {temp.taskName} | {temp.priority} | {temp.dueDate}");
                found = true;
            }

            temp = temp.next;

            if (temp == head)   // stop once full loop completes
                break;
        }
        
        if (!found)
        {
            Console.WriteLine("No task found with given priority.");
        }
    }

}

class Program
{
    static void Main()
    {
        TaskScheduler scheduler = new TaskScheduler();

        while (true)
        {
            Console.WriteLine("\n===== TASK SCHEDULER MENU =====");
            Console.WriteLine("1. Add Task");
            Console.WriteLine("2. Remove Task");
            Console.WriteLine("3. View Current Task & Move Next");
            Console.WriteLine("4. Display All Tasks");
            Console.WriteLine("5. Search Task by Priority");
            Console.WriteLine("6. Exit");
            Console.Write("Enter choice: ");

            int ch = Convert.ToInt32(Console.ReadLine());

            switch (ch)
            {
                case 1: scheduler.AddTask(); break;
                case 2: scheduler.RemoveTask(); break;
                case 3: scheduler.ViewCurrentTask(); break;
                case 4: scheduler.DisplayAll(); break;
                case 5: scheduler.SearchByPriority(); break;
                case 6: return;
                default: Console.WriteLine("Invalid choice."); break;
            }
        }
    }
}
