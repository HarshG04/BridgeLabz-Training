using System;
class PenDistribution {
  static void Main() {
        int totalPens = 14;
        int students = 3;
        int receivedPen = totalPens / students;
        int nondistributedPens = totalPens%students;
        Console.WriteLine("The Pen Per Student is "+ receivedPen + " and the remaining pen not distributed is " + nondistributedPens);
    }
}