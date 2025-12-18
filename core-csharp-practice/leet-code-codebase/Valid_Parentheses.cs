using System.Collections.Generic;

public class Solution
{
    public bool IsValid(string s)
    {
        if (s.Length % 2 != 0)
            return false;

        Stack<char> stack = new Stack<char>();

        for (int i = 0; i < s.Length; i++)
        {
            char ch = s[i];

            if (ch == '(' || ch == '{' || ch == '[')
            {
                stack.Push(ch);
            }
            else
            {
                if (stack.Count == 0)
                    return false;

                char top = stack.Peek();

                if (ch == ')' && top != '(')
                    return false;
                else if (ch == '}' && top != '{')
                    return false;
                else if (ch == ']' && top != '[')
                    return false;
                else
                    stack.Pop();
            }
        }

        return stack.Count == 0;
    }
}
