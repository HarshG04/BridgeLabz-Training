using System;
class Program
{
    static void Main()
    {
        string s = "Hello My Name is Harsh Goyal";
        string[,] arr = SplitText(s);
        for(int i = 0; i < arr.GetLength(0); i++)
        {
            Console.WriteLine($"{arr[i,0]} : {arr[i,1]}");
        }
    }
    static string[,] SplitText(string s)
    {
        int count = 0;
        foreach(char ch in s) if(ch==' ') count++;
        string[,] arr = new string[count+1,2];
        int i=0,j=0;
        int idx = 0;
        while(j < s.Length)
        {
            if(s[j]==' ')
            {
                arr[idx,0] = s.Substring(i,j-i);
                arr[idx,1] = GetLength(arr[idx,0]).ToString();
                i = ++j;
                idx++;
            }
            j++;
        }
        arr[idx,0] = s.Substring(i);
        arr[idx,1] = GetLength(arr[idx,0]).ToString();
        
        return arr;

    }
    static int GetLength(string s)
    {
        int len = 0;
        foreach(char ch in s) len++;
        return len;

    }
}