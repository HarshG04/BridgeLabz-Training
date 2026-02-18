using System;
using TechVille.Modules;

namespace TechVille
{
    class CircularLinkedList
    {
        private class Node
        {
            public Citizen Data;
            public Node Next;

            public Node(Citizen citizen)
            {
                Data = citizen;
            }
        }

        private Node tail;

        public void Insert(Citizen citizen)
        {
            Node newNode = new Node(citizen);

            if (tail == null)
            {
                tail = newNode;
                tail.Next = tail;
                return;
            }

            newNode.Next = tail.Next;
            tail.Next = newNode;
            tail = newNode;
        }

        public void DeleteById(int id)
        {
            if (tail == null) return;

            Node current = tail.Next;
            Node previous = tail;

            do
            {
                if (current.Data.CitizenID == id)
                {
                    // Only one node
                    if (current == tail && current.Next == tail)
                    {
                        tail = null;
                        return;
                    }

                    previous.Next = current.Next;

                    if (current == tail)
                        tail = previous;

                    return;
                }

                previous = current;
                current = current.Next;

            } while (current != tail.Next);
        }

        public void Traverse()
        {
            if (tail == null) return;

            Node temp = tail.Next;

            do
            {
                Console.WriteLine(temp.Data);
                temp = temp.Next;
            } while (temp != tail.Next);
        }

        public void RoundRobin(int cycles)
        {
            if (tail == null) return;

            Node temp = tail.Next;
            int count = 0;

            while (count < cycles)
            {
                Console.WriteLine(temp.Data);
                temp = temp.Next;
                count++;
            }
        }
    }
}
