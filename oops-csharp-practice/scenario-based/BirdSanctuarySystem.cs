using System;

class Sanctuary 
{ 
    static string sanctuaryName = "EcoWing Wildlife Conservation Center"; 
    static string ownerGroup = "Goyal Foundation"; 
    public Bird[] birds; 
    public int idx=0; 

    public Sanctuary(int cap)
    {
        birds = new Bird[cap];
    }

    public void GetAllBirds()
    {
        Console.WriteLine("\n--- Bird Details ---");
        for (int i = 0; i < birds.Length; i++)
        {
            birds[i].GetBird();
        }
    }
    public void GetAllBirdsActivities()
    {
        Console.WriteLine("\n--- Bird Activities ---");
        for (int i = 0; i < birds.Length; i++)
        {
            if (birds[i] is IFlyable) ((IFlyable)birds[i]).Fly();

            if (birds[i] is ISwimmable) ((ISwimmable)birds[i]).Swim();
        }
    }    
}

class Bird
{
    public string birdName;

    public Bird(string birdName)
    {
        this.birdName = birdName;
    }
    public void GetBird()
    {
        Console.WriteLine("Bird Name: " + this.birdName);
    }
}

interface IFlyable
{
    void Fly();
}

interface ISwimmable
{
    void Swim();
}

class Eagle : Bird, IFlyable
{
    public Eagle(string name) : base(name) { }

    public void Fly()
    {
        Console.WriteLine($"{birdName} can fly");
    }
}

class Sparrow : Bird, IFlyable
{
    public Sparrow(string name) : base(name) { }

    public void Fly()
    {
        Console.WriteLine($"{birdName} can fly");
    }
}

class Duck : Bird, ISwimmable
{
    public Duck(string name) : base(name) { }

    public void Swim()
    {
        Console.WriteLine($"{birdName} can swim");
    }
}

class Penguin : Bird, ISwimmable
{
    public Penguin(string name) : base(name) { }

    public void Swim()
    {
        Console.WriteLine($"{birdName} can swim");
    }
}

class Seagull : Bird, IFlyable, ISwimmable
{
    public Seagull(string name) : base(name) { }

    public void Fly()
    {
        Console.WriteLine($"{birdName} can fly");
    }

    public void Swim()
    {
        Console.WriteLine($"{birdName} can swim");
    }
}


class Program
{
    static void Main()
    {
        Sanctuary s1 = new Sanctuary(5);

        s1.birds[s1.idx++] = new Eagle("Golden Eagle");
        s1.birds[s1.idx++] = new Sparrow("House Sparrow");
        s1.birds[s1.idx++] = new Duck("Mallard Duck");
        s1.birds[s1.idx++] = new Penguin("Emperor Penguin");
        s1.birds[s1.idx++] = new Seagull("Sea Gull");

        s1.GetAllBirds();

        s1.GetAllBirdsActivities();
    }
}
