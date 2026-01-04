using System;

public class Animal
{
    public string name;
    public int age;
    public virtual void MakeSound()
    {
        Console.WriteLine("Animal makes a sound");
    }
}

public class Dog : Animal
{
    public override void MakeSound()
    {
        Console.WriteLine("Dog barks");
    }
}

public class Cat : Animal
{
    public override void MakeSound()
    {
        Console.WriteLine("Cat meows");
    }
}

public class Bird : Animal
{
    public override void MakeSound()
    {
        Console.WriteLine("Bird chirps");
    }
}

public class Program
{
    public static void Main()
    {
        Animal dog = new Dog { name = "A", age = 4 };
        Animal cat = new Cat { name = "B", age = 2 };
        Animal bird = new Bird { name = "C", age = 1 };
        dog.MakeSound();
        cat.MakeSound();
        bird.MakeSound();
    }
}

