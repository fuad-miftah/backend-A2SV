using System;

public class Shape
{
    private string name;
    
    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    
    public virtual double CalculateArea()
    {
        return 0.0;
    }
}

public class Circle : Shape
{
    private double radius;
    
    public double Radius
    {
        get { return radius; }
        set { radius = value; }
    }
    
    public override double CalculateArea()
    {
        return Math.PI * radius * radius;
    }
}

public class Rectangle : Shape
{
    private double width;
    private double height;
    
    public double Width
    {
        get { return width; }
        set { width = value; }
    }
    
    public double Height
    {
        get { return height; }
        set { height = value; }
    }
    
    public override double CalculateArea()
    {
        return width * height;
    }
}

public class Triangle : Shape
{
    private double triangleBase;
    private double height;
    
    public double Base
    {
        get { return triangleBase; }
        set { triangleBase = value; }
    }
    
    public double Height
    {
        get { return height; }
        set { height = value; }
    }
    
    public override double CalculateArea()
    {
        return (triangleBase * height) / 2.0;
    }
}

public class Program
{
    public static void PrintShapeArea(Shape shape)
    {
        Console.WriteLine("Name: " + shape.Name);
        Console.WriteLine("Area: " + shape.CalculateArea());
        Console.WriteLine();
    }
    
    static void Main(string[] args)
    {
        Circle circle = new Circle();
        circle.Name = "Circle";
        circle.Radius = 5.0;
        
        Rectangle rectangle = new Rectangle();
        rectangle.Name = "Rectangle";
        rectangle.Width = 10.0;
        rectangle.Height = 5.0;
        
        Triangle triangle = new Triangle();
        triangle.Name = "Triangle";
        triangle.Base = 8.0;
        triangle.Height = 4.0;
        
        PrintShapeArea(circle);
        PrintShapeArea(rectangle);
        PrintShapeArea(triangle);
        
    }
}