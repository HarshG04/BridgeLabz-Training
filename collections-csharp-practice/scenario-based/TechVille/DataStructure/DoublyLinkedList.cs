using System;
using TechVille.Modules;

namespace TechVille
{
    class DoublyLinkedList
    {
        private class Node
        {
            public Citizen Data;
            public Node Next;
            public Node Prev;

            public Node(Citizen citizen)
            {
                Data = citizen;
            }
        }

        private Node head;
        private Node tail;

        public void Insert(Citizen citizen)
        {
            Node newNode = new Node(citizen);

            if (head == null)
            {
                head = tail = newNode;
                return;
            }

            tail.Next = newNode;
            newNode.Prev = tail;
            tail = newNode;
        }

        public void DeleteById(int id)
        {
            if (head == null) return;

            Node temp = head;

            while (temp != null && temp.Data.CitizenID != id)
            {
                temp = temp.Next;
            }

            if (temp == null) return;

            // If deleting head
            if (temp == head)
                head = temp.Next;

            // If deleting tail
            if (temp == tail)
                tail = temp.Prev;

            if (temp.Prev != null)
                temp.Prev.Next = temp.Next;

            if (temp.Next != null)
                temp.Next.Prev = temp.Prev;
        }

        public void TraverseForward()
        {
            Node temp = head;
            while (temp != null)
            {
                Console.WriteLine(temp.Data);
                temp = temp.Next;
            }
        }

        public void TraverseBackward()
        {
            Node temp = tail;
            while (temp != null)
            {
                Console.WriteLine(temp.Data);
                temp = temp.Prev;
            }
        }
    }
}