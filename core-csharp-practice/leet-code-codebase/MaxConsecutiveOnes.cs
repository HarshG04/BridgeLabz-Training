public class Solution {
    public int FindMaxConsecutiveOnes(int[] nums) {
        int max = 0;
        int idx = 0;
        int count = 0;
        for(int i=0;i<nums.Length;i++){
            if(nums[i]==1) count++;
            else{
                max = Math.Max(max,count);
                count = 0;
            }
        }
        max = Math.Max(max,count);
        return max;
    }
}