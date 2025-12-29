public class Solution {
    public int[] Shuffle(int[] nums, int n) {
        int[] arr = new int[n*2];
        for(int i=0;i<n;i++){
            arr[i*2] = nums[i];
        }
        int j=0;
        for(int i=1;i<2*n;i+=2){
            arr[i] = nums[n+j];
            j++;
        }
        return arr;
    }
}