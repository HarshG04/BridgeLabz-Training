using System;
using TechVille.Modules;

namespace TechVille
{
    class SinglyLinkedList
    {
        private class Node
        {
            public Citizen Data;
            public Node Next;

            public Node(Citizen citizen)
            {
                Data = citizen;
                Next = null;
            }
        }

        private Node head;

        public void Insert(Citizen citizen)
        {
            Node newNode = new Node(citizen);

            if (head == null)
            {
                head = newNode;
                return;
            }

            Node temp = head;
            while (temp.Next != null)
                temp = temp.Next;

            temp.Next = newNode;
        }

        public Citizen SearchById(int id)
        {
            Node temp = head;

            while (temp != null)
            {
                if (temp.Data.CitizenID == id)
                    return temp.Data;

                temp = temp.Next;
            }

            return null;
        }

        public Citizen SearchByName(string name)
        {
            Node temp = head;

            while (temp != null)
            {
                if (temp.Data.CitizenName.ToLower() == name.ToLower())
                    return temp.Data;

                temp = temp.Next;
            }

            return null;
        }

        public void DeleteById(int id)
        {
            if (head == null) return;

            if (head.Data.CitizenID == id)
            {
                head = head.Next;
                return;
            }

            Node temp = head;

            while (temp.Next != null &&
                   temp.Next.Data.CitizenID != id)
            {
                temp = temp.Next;
            }

            if (temp.Next != null)
                temp.Next = temp.Next.Next;
        }

        public void Traverse()
        {
            Node temp = head;

            while (temp != null)
            {
                Console.WriteLine(temp.Data);
                temp = temp.Next;
            }
        }
    }
}
