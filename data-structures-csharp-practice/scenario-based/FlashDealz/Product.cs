namespace FlashDealz
{
    class Product
    {
        private static int NextId = 1;
        public string Id {get;}
        public double Discount {get;set;}

        public Product(){
            this.Id = "P"+NextId;
            NextId++;
        }

        public override string ToString()
        {
            return $"{Id}  -->  {Discount} %";
        }
    }
}