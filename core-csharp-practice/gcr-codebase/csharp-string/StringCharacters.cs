using System;
class Program
{
    static void Main()
    {
        Console.Write("Enter String: ");
        string s = Console.ReadLine();
        char[] arr = CharArr(s);
        char[] arr1 = s.ToCharArray();
        Console.Write("using method: ");
        foreach(char ch in arr) Console.Write(ch+" ");
        Console.Write("\nusing inbuilt: ");
        foreach(char ch in arr1) Console.Write(ch+" ");
    }
    static char[] CharArr(string s)
    {
        char[] arr = new char[s.Length];
        int idx = 0;
        foreach(char ch in s){
            arr[idx++] = ch;
        }
        return arr;
    }
}
