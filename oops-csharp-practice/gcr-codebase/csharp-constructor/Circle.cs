class Circle
{
    private float radius;

    public Circle(){}
    private Circle(float radius)
    {
        this.radius = radius;
    }

    public void SetRadius()
    {
        Console.WriteLine("Enter Radius: ");
        float radius = float.Parse(Console.ReadLine());
        Circle(radius);
        
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