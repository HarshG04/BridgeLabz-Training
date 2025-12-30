using System.Reflection.Metadata.Ecma335;

class Circle
{
    private float radius;

    public void SetRadius(float radius)
    {
        this.radius = radius;
    }
    public float Area()
    {
        return ((float)Math.PI)*radius*radius;
    }

    public float Circumference()
    {
        return 2*((float)Math.PI)*radius;
    } 
}

class Program
{
    static void Main()
    {
        Circle c1 = new Circle();
        c1.SetRadius(10f);
        Console.WriteLine("Area: " + c1.Area());
        Console.WriteLine("Circumference : " + c1.Circumference());
    }
}