using System;

class Operators
{
    static void Main(string[] args)
    {
        Console.WriteLine("===== ARITHMETIC OPERATORS =====");
        int a1 = 7, a2 = 2;
        Console.WriteLine("a1 = 7, a2 = 2");
        Console.WriteLine("Addition: " + (a1 + a2));
        Console.WriteLine("Subtraction: " + (a1 - a2));
        Console.WriteLine("Multiplication: " + (a1 * a2));
        Console.WriteLine("Division: " + (a1 / a2));
        Console.WriteLine("Modulus: " + (a1 % a2));

        Console.WriteLine("\n===== RELATIONAL OPERATORS =====");
        int r1 = 7, r2 = 2;
        Console.WriteLine("r1 = 7, r2 = 2");
        Console.WriteLine("Equal to: " + (r1 == r2));
        Console.WriteLine("Not equal to: " + (r1 != r2));
        Console.WriteLine("Greater than: " + (r1 > r2));
        Console.WriteLine("Less than: " + (r1 < r2));
        Console.WriteLine("Greater than or equal to: " + (r1 >= r2));
        Console.WriteLine("Less than or equal to: " + (r1 <= r2));

        Console.WriteLine("\n===== LOGICAL OPERATORS =====");
        bool l1 = true, l2 = false;
        Console.WriteLine("l1 = true, l2 = false");
        Console.WriteLine("AND (l1 && l2): " + (l1 && l2));
        Console.WriteLine("OR (l1 || l2): " + (l1 || l2));
        Console.WriteLine("NOT (!l1): " + (!l1));
        Console.WriteLine("NOT (!l2): " + (!l2));

        Console.WriteLine("\n===== ASSIGNMENT OPERATORS =====");
        int asg1 = 10, asg2 = 5;
        Console.WriteLine("Initial asg1 = 10, asg2 = 5");
        asg1 += asg2;
        Console.WriteLine("After += : " + asg1);
        asg1 -= asg2;
        Console.WriteLine("After -= : " + asg1);
        asg1 *= asg2;
        Console.WriteLine("After *= : " + asg1);
        asg1 /= asg2;
        Console.WriteLine("After /= : " + asg1);
        asg1 %= asg2;
        Console.WriteLine("After %= : " + asg1);

        Console.WriteLine("\n===== UNARY OPERATORS =====");
        int u = 5;
        Console.WriteLine("Initial u = 5");
        Console.WriteLine("Pre-increment (++u): " + (++u));
        Console.WriteLine("Post-increment (u++): " + (u++));
        Console.WriteLine("Current u: " + u);
        Console.WriteLine("Pre-decrement (--u): " + (--u));
        Console.WriteLine("Post-decrement (u--): " + (u--));
        Console.WriteLine("Final u: " + u);

        Console.WriteLine("\n===== TERNARY OPERATOR =====");
        int t1 = 10, t2 = 20;
        int max = (t1 > t2) ? t1 : t2;
        Console.WriteLine("t1 = 10, t2 = 20");
        Console.WriteLine("Maximum value: " + max);

        Console.WriteLine("\n===== IS (INSTANCE OF) OPERATOR =====");
        Animal animal = new Dog();
        Console.WriteLine("animal is Animal: " + (animal is Animal));
        Console.WriteLine("animal is Dog: " + (animal is Dog));
        Console.WriteLine("animal is string: " + (animal is string));
    }
}

class Animal { }
class Dog : Animal { }
