class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter the Number of Books: ");
        int n = Convert.ToInt32(Console.ReadLine());
        int[] prices = new int[n];
        Console.WriteLine("Enter Book Prices: ");
        for(int i = 0; i < n; i++)
        {
            prices[i] = Convert.ToInt32(Console.ReadLine());
        }

        Program p = new Program();
        
        Console.WriteLine("Sorting Prices....");
        p.MergeSort(prices,0,n-1);

        Console.WriteLine("Sorted Book Prices: ");
        for(int i = 0; i < n; i++)
        {
            Console.WriteLine(prices[i]);
        }
    }

    public void MergeSort(int[] prices,int i,int j)
    {
        if(i>=j) return;
        
        int mid = (j+i)/2;

        MergeSort(prices,i,mid);
        MergeSort(prices,mid+1,j);

        Merge(prices,i,mid,j);

    }

    public void Merge(int[] prices,int i,int mid,int j)
    {
        int n1 = mid-i+1;
        int n2 = j-mid;

        int[] l = new int[n1];
        int[] r = new int[n2];
        for(int k=0;k<n1;k++) l[k] = prices[i+k];
        for(int k=0;k<n2;k++) r[k] = prices[mid+1+k];

        int a=0,b=0;
        while(a<n1 && b < n2)
        {
            if (l[a] <= r[b])
            {
                prices[i] = l[a++];
            }
            else
            {
                prices[i] = r[b++];
            }
            i++;
        }

        while (a < n1)
        {
            prices[i++] = l[a++];
        }
        while (b < n2)
        {
            prices[i++] = r[b++];
        }


    }
}