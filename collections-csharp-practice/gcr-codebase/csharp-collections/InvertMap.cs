using System;
using System.Collections.Generic;

class InvertMap
{
    static void Main()
    {
        Dictionary<string, int> map = new Dictionary<string, int>();
        map["A"] = 1;
        map["B"] = 2;
        map["C"] = 1;

        Dictionary<int, List<string>> invertedMap = new Dictionary<int, List<string>>();

        foreach(string key in map.Keys)
        {
            if(!invertedMap.ContainsKey(map[key])) invertedMap[map[key]] = new List<string>();

            invertedMap[map[key]].Add(key);
        }

        foreach(int key in invertedMap.Keys)
        {
            Console.Write(key +" : ");

            foreach(string val in invertedMap[key])
            {
                Console.Write(val+", ");
            }
            Console.WriteLine();
        }

    }
}
