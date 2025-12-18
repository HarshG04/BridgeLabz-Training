public class Solution
{
    public bool IsPalindrome(int x)
    {
        int y = x;
        if (x >= 0)
        {
            int rev = 0;
            while (x > 0)
            {
                rev = rev * 10 + x % 10;
                x /= 10;
            }
            return rev == y;
        }
        else return false;
    }
}
