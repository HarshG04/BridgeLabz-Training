class Animal
{
    public string AnimalName = "animal";

    public void AnimalFunction()
    {
        Console.WriteLine("Im a Animal");
    }

    public void Sound()
    {
        Console.WriteLine("Animal Sound");
    }
}

class Dog : Animal
{
    public string DogName = "doggg";
    public void DogFunction()
    {
        Console.WriteLine("Im a Dog");
    }
    public void Sound()
    {
        Console.WriteLine("Dog Sound");
    }

}

class Program
{
    static void Main()
    {
        // Animal a1 = new Animal();
        // a1.AnimalFunction();
        // Console.WriteLine(a1.AnimalName);


        Animal a2 = new Dog();
        a2.AnimalFunction();
        a2.DogFunction();
        a2.Sound();

        // Dog dog = new Animal();
        // dog.AnimalFunction();
        // dog.AnimalName;
        // dog.DogFunction();
        // dog.DogName;
        // dog.Sound();
        
    }
}