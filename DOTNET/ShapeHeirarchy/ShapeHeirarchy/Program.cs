using System;
using System.Collections.Generic;

public abstract class Shape
{
    public abstract double CalculateArea();
    public abstract double CalculatePerimeter();
    public virtual void DisplayInfo()
    {
        Console.WriteLine("Shape information:");
    }
}

public class Circle : Shape
{
    public double Radius { get; }

    public Circle(double radius)
    {
        Radius = radius;
    }

    public override double CalculateArea()
    {
        return Math.PI * Radius * Radius;
    }

    public override double CalculatePerimeter()
    {
        return 2 * Math.PI * Radius;
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Circle - Radius: {Radius}");
        Console.WriteLine($"Area: {CalculateArea():F2}, Perimeter: {CalculatePerimeter():F2}");
    }
}

public class Rectangle : Shape
{
    public double Width { get; }
    public double Height { get; }

    public Rectangle(double width, double height)
    {
        Width = width;
        Height = height;
    }

    public override double CalculateArea()
    {
        return Width * Height;
    }

    public override double CalculatePerimeter()
    {
        return 2 * (Width + Height);
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Rectangle - Width: {Width}, Height: {Height}");
        Console.WriteLine($"Area: {CalculateArea():F2}, Perimeter: {CalculatePerimeter():F2}");
    }
}

public class Triangle : Shape
{
    public double SideA { get; }
    public double SideB { get; }
    public double SideC { get; }

    public Triangle(double sideA, double sideB, double sideC)
    {
        SideA = sideA;
        SideB = sideB;
        SideC = sideC;
    }

    public override double CalculateArea()
    {
        double s = (SideA + SideB + SideC) / 2;
        return Math.Sqrt(s * (s - SideA) * (s - SideB) * (s - SideC));
    }

    public override double CalculatePerimeter()
    {
        return SideA + SideB + SideC;
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Triangle - Sides: {SideA}, {SideB}, {SideC}");
        Console.WriteLine($"Area: {CalculateArea():F2}, Perimeter: {CalculatePerimeter():F2}");
    }
}

public class ShapeManager
{
    private List<Shape> shapes = new List<Shape>();

    public void AddShape(Shape shape)
    {
        shapes.Add(shape);
    }

    public double CalculateTotalArea()
    {
        double totalArea = 0;
        foreach (var shape in shapes)
        {
            totalArea += shape.CalculateArea();
        }
        return totalArea;
    }

    public void DisplayAllShapes()
    {
        foreach (var shape in shapes)
        {
            shape.DisplayInfo();
            Console.WriteLine();
        }
    }
}

class Program
{
    static void Main()
    {
        Circle circle = new Circle(5);
        Rectangle rectangle = new Rectangle(4, 6);
        Triangle triangle = new Triangle(3, 4, 5);

        ShapeManager manager = new ShapeManager();
        manager.AddShape(circle);
        manager.AddShape(rectangle);
        manager.AddShape(triangle);

        manager.DisplayAllShapes();

        Console.WriteLine($"Total area of all shapes: {manager.CalculateTotalArea():F2}");
    }
}
