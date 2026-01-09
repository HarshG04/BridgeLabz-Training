using System;

class HashNode
{
    public int key;
    public int value;
    public HashNode next;

    public HashNode(int key, int value)
    {
        this.key = key;
        this.value = value;
        next = null;
    }
}

class MyHashMap
{
    private HashNode[] table;
    private int size = 10;

    public MyHashMap()
    {
        table = new HashNode[size];
    }

    private int Hash(int key)
    {
        return key % size;
    }

    // INSERT
    public void Put(int key, int value)
    {
        int index = Hash(key);
        HashNode node = table[index];

        if (node == null)
        {
            table[index] = new HashNode(key, value);
            return;
        }

        while (node.next != null)
        {
            if (node.key == key)
            {
                node.value = value;
                return;
            }
            node = node.next;
        }

        node.next = new HashNode(key, value);
    }

    // GET
    public int Get(int key)
    {
        int index = Hash(key);
        HashNode node = table[index];

        while (node != null)
        {
            if (node.key == key)
                return node.value;

            node = node.next;
        }

        return -1; // not found
    }

    // DELETE
    public void Remove(int key)
    {
        int index = Hash(key);
        HashNode node = table[index];
        HashNode prev = null;

        while (node != null)
        {
            if (node.key == key)
            {
                if (prev == null)
                    table[index] = node.next;
                else
                    prev.next = node.next;

                return;
            }

            prev = node;
            node = node.next;
        }
    }
}

class Program
{
    static void Main()
    {
        MyHashMap map = new MyHashMap();

        map.Put(1, 10);
        map.Put(2, 20);
        map.Put(12, 120); // collision

        Console.WriteLine(map.Get(1));   // 10
        Console.WriteLine(map.Get(12));  // 120

        map.Remove(2);
        Console.WriteLine(map.Get(2));   // -1
    }
}
