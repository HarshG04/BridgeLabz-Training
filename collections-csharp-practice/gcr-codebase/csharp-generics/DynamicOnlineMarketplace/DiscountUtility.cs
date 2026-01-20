using System;

namespace DynamicOnlineMarketplace
{
    class DiscountUtility
    {
        public static void ApplyDiscount<T>(T product, double percentage)
            where T : BaseProduct
        {
            if (percentage <= 0 || percentage > 100)
            {
                Console.WriteLine("Invalid discount percentage");
                return;
            }

            product.Price -= product.Price * percentage / 100;
        }
    }
}
