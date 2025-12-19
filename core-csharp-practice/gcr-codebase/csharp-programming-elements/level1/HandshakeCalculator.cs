using System;

class HandshakeCalculator{
    static void Main(){

        int numberOfStudents = int.Parse(Console.ReadLine());
        int handshakes = (numberOfStudents * (numberOfStudents - 1)) / 2;

        Console.WriteLine("The maximum number of handshakes possible is " + handshakes);
    }
}