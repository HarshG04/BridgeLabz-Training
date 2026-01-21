using System.Collections;

class Program
{
    public static void Main(string[] args)
    {
        ArrayList al = new ArrayList();
        LinkedList<int> ll = new LinkedList<int>();

        al.Add(1);
        al.Add(2);
        al.Add(3);
        al.Add(4);
        al.Add(5);

        ll.AddLast(10);
        ll.AddLast(20);
        ll.AddLast(30);
        ll.AddLast(40);
        ll.AddLast(50);

        Console.WriteLine("Original ArrayList : ");
        foreach(int i in al) Console.Write(i+" ");

        ReverseArrayList(al);

        Console.WriteLine("\nAftr Reverse ArrayList : ");
        foreach(int i in al) Console.Write(i+" ");


        Console.WriteLine("\nOriginal LinkedList : ");
        foreach(int i in ll) Console.Write(i+" ");

        ReverseLinkedList(ll);

        Console.WriteLine("\nAftr Reverse LinkedList : ");
        foreach(int i in ll) Console.Write(i+" ");
        
    }

    public static void ReverseArrayList(ArrayList list)
    {
        int i = 0, j = list.Count-1;
        while (i <= j)
        {
            Object temp = list[i];
            list[i] = list[j];
            list[j] = temp;

            i++;j--;
        }
    }

    public static void ReverseLinkedList(LinkedList<int> ll)
    {
        LinkedListNode<int> left = ll.First;
        LinkedListNode<int> right = ll.Last;

        while (left != right && left.Previous != right)
        {
            int temp = left.Value;
            left.Value = right.Value;
            right.Value = temp;

            left = left.Next;
            right = right.Previous;
        }
    }
}