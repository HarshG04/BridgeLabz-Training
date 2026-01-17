namespace FlashDealz
{
    class ProductUtilityImpl : IProduct
    {
        private Product[] products;
        private Random random = new Random();
        private double minDiscount;
        private double maxDiscount;

        public void AddProducts()
        {
            Console.Write("Enter No of Products: ");
            int cap = Convert.ToInt32(Console.ReadLine());
            
            Console.WriteLine("Enter Min and Max Discount: ");
            Console.Write("Min Discount: ");
            minDiscount = Convert.ToDouble(Console.ReadLine());
            Console.Write("Max Discount: ");
            maxDiscount = Convert.ToDouble(Console.ReadLine());
            
            
            products = new Product[cap];

            for(int i = 0; i < cap; i++)
            {
                Product product = new Product();
                double discount = random.NextDouble()*(maxDiscount-minDiscount)+minDiscount;
                product.Discount = Math.Round(discount,2);
                products[i] = product;
            }

            ShowProducts(products);

        }

        public void SortProducts()
        {
            Product[] temp = (Product[])products.Clone();
            QuickSort(temp,0,temp.Length-1);

            ShowProducts(temp);

        }

        public static void QuickSort(Product[] arr, int low, int high) {
            if (low < high) {
                int pi = Partition(arr, low, high);
                QuickSort(arr, low, pi - 1);
                QuickSort(arr, pi + 1, high);
            }
        }

        private static int Partition(Product[] arr, int low, int high) {

            double pivot = arr[high].Discount;
            int i = low - 1;
            for (int j = low; j < high; j++) {
                if (arr[j].Discount < pivot) {
                    i++;
                    (arr[i], arr[j]) = (arr[j], arr[i]);
                }
            }
            (arr[i + 1], arr[high]) = (arr[high], arr[i + 1]);
            return i + 1;
        }

        public void ShowProducts()
        {
            ShowProducts(products);
        }

        private void ShowProducts(Product[] arr)
        {
            for(int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }
        }



    }
}