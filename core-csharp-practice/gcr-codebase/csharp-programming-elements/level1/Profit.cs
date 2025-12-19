using System;
class Profit {
  static void Main() {
        int costPrice = 129;
        int sellingPrice = 191;
        
        int profit = sellingPrice - costPrice;
        double profitPercentage = (profit*100)/costPrice;
        Console.WriteLine("The Cost Price is INR " + costPrice + " and Selling Price is INR " + sellingPrice+ "\nThe Profit is INR "+ profit+ " and the Profit Percentage is "+ profitPercentage);
    }
}