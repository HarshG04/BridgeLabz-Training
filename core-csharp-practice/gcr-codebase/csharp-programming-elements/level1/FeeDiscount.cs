using System;
class FeeDiscount {
  static void Main() {
        int fee = 125000;
        int discountPercent  = 10;
        float discount = (fee*discountPercent)/100;
        float fianalPrice = fee - discount;
        Console.WriteLine(discount + " " + fianalPrice);
    }
}