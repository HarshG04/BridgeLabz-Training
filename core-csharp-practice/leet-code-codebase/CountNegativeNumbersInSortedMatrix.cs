public class Solution {
    public int CountNegatives(int[][] grid) {
        int count = 0;
        int i = 0, j = grid[0].Length-1;
        while(i<grid.Length && j>=0){
            // Console.WriteLine(i+" "+j);
            if(grid[i][j]<0) {
                // Console.WriteLine("Found: "+i+" "+j);
                count += grid.Length-i;
                // Console.WriteLine("Count: "+count);
                j--;
            }else i++;
        }

        return count;
    }
}