class RotationPoint
{
    public static void Main(string[] args)
    {
        int[] arr = {5,6,7,8,9,10,1,2,3,4};
        int idx = FindRotationPoint(arr);
        if (idx != -1)
        {
            Console.WriteLine(arr[idx]);
        }

    }

    public static int FindRotationPoint(int[] arr)
    {
        int i=0,j=arr.Length-1;
        if(arr[i]<=arr[j]) return i;


        while (i <= j)
        {
            int mid = (i+j)/2;
            if(mid>0 && arr[mid]<arr[mid-1]) return mid;
            if(arr[mid]>=arr[i]) i = mid+1;
            else j = mid-1;
        }
        return -1;
    }
}
