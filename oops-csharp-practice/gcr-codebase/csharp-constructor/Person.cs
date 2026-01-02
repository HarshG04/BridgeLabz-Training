class Person
{
    private string name;
    private int age;


    public Person(){}
    public Person(string name,int age)
    {
        this.name = name;
        this.age = age;
    }
    public Person(Person oldPerson)
    {
        this.name = oldPerson.name;
        this.age = oldPerson.age;
    }
    public void ShowPerson()
    {
        Console.WriteLine(this.name);
        Console.WriteLine(this.age);
    }

    static void Main()
    {
        Person p1 = new Person("harsh",21);
        p1.ShowPerson();
        Person p2 = new Person(p1);
        p2.ShowPerson();
    }
}

