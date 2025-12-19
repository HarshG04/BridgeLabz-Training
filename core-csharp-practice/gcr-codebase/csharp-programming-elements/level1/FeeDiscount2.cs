using System;
class FeeDiscount2 {
    static void Main() {
        int fee = int.Parse(Console.ReadLine());
        int discountPercent  = int.Parse(Console.ReadLine());
        float discount = (fee*discountPercent)/100;
        float fianalPrice = fee - discount;
        Console.WriteLine(discount + " " + fianalPrice);
    }
}