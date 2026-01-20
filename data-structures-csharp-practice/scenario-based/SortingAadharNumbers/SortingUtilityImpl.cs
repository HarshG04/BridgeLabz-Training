namespace SortingAadharNumbers
{
    class SortingUtilityImpl : ISorting
    {
        private Aadhar[] aadhars;
        private bool IsSorted = false;
        private static Random random = new Random();

        public void AddAadhar()
        {
            Console.Write("Enter No of Aadhars: ");
            int n = Convert.ToInt32(Console.ReadLine());
            
            aadhars = new Aadhar[n];

            for(int i = 0; i < n; i++)
            {
                Aadhar adhar = new Aadhar();
                adhar.AadharNumber = random.NextInt64(111111111111,999999999999);
                aadhars[i] = adhar;
            }

            DisplayAllAadhar();
        }
        public void SortAadhar()
        {
            if (aadhars == null || aadhars.Length == 0)
            {
                Console.WriteLine("No Aadhar data available");
                return;
            }

            Console.WriteLine("Sorting Aadhar Numbers...");
            long max = aadhars[0].AadharNumber;
            for(int i=1;i<aadhars.Length;i++) max = Math.Max(max,aadhars[i].AadharNumber);

            for(long k = 1; (max / k) > 0; k *= 10)
            {
                CountSort(k);
            }

            IsSorted = true;
            Console.WriteLine("Aadhars Numbers Are Sorted");
        }

        private void CountSort(long k)
        {
            
            int[] freq = new int[10];

            for(int i = 0; i < aadhars.Length; i++)
            {
                freq[(aadhars[i].AadharNumber/k)%10]++;
            }

            for(int i = 1; i < freq.Length; i++)
            {
                freq[i] += freq[i-1];
            }

            Aadhar[] ans = new Aadhar[aadhars.Length];

            for(int i = ans.Length-1; i >=0; i--)
            {
                int idx = (int)((aadhars[i].AadharNumber/k)%10);
                ans[freq[idx]-1] = aadhars[i];
                freq[idx]--;
            }

            for(int i = 0; i < aadhars.Length; i++)
            {
                aadhars[i] = ans[i];
            }
        }

        public void GetAadhar()
        {
            if (aadhars == null || aadhars.Length == 0)
            {
                Console.WriteLine("No Aadhar data available");
                return;
            }

            Console.Write("Enter Adhar Number: ");
            long number = Convert.ToInt64(Console.ReadLine());

            if(!IsSorted) SortAadhar();
        
            int foundIdx = BinarySearch(number);
            if(foundIdx!=-1) Console.WriteLine(aadhars[foundIdx]);
            else Console.WriteLine("Number Not Found");
        }

        private int BinarySearch(long number)
        {
            int i=0, j=aadhars.Length-1;
            while (i <= j)
            {
                int mid = (i+j)/2;
                if(aadhars[mid].AadharNumber==number) return mid;
                else if(aadhars[mid].AadharNumber > number) j = mid-1;
                else i = mid+1;
            } 

            return -1;
        }



        public void DisplayAllAadhar()
        {
            if (aadhars == null || aadhars.Length == 0)
            {
                Console.WriteLine("No Aadhar data available");
                return;
            }

            for(int i = 0; i < aadhars.Length; i++)
            {
                Console.WriteLine(aadhars[i]);
            }
        }
    }
}