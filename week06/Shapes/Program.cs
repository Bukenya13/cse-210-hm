using System;
using System.Collections.Generic;

// Base Shape Class
public abstract class Shape
{
    protected string _color;

    public Shape(string color)
    {
        _color = color;
    }

    public string GetColor()
    {
        return _color;
    }

    public void SetColor(string color)
    {
        _color = color;
    }

    public abstract double GetArea();
    
    public abstract double GetPerimeter();
    
    public virtual string GetDescription()
    {
        return $"A {_color} shape";
    }
}

// Square Class
public class Square : Shape
{
    private double _side;

    public Square(string color, double side) : base(color)
    {
        _side = side;
    }

    public override double GetArea()
    {
        return _side * _side;
    }

    public override double GetPerimeter()
    {
        return 4 * _side;
    }

    public override string GetDescription()
    {
        return $"A {_color} square with side {_side}";
    }
}

// Rectangle Class
public class Rectangle : Shape
{
    private double _length;
    private double _width;

    public Rectangle(string color, double length, double width) : base(color)
    {
        _length = length;
        _width = width;
    }

    public override double GetArea()
    {
        return _length * _width;
    }

    public override double GetPerimeter()
    {
        return 2 * (_length + _width);
    }

    public override string GetDescription()
    {
        return $"A {_color} rectangle with length {_length} and width {_width}";
    }
}

// Circle Class
public class Circle : Shape
{
    private double _radius;

    public Circle(string color, double radius) : base(color)
    {
        _radius = radius;
    }

    public override double GetArea()
    {
        return Math.PI * _radius * _radius;
    }

    public override double GetPerimeter()
    {
        return 2 * Math.PI * _radius;
    }

    public override string GetDescription()
    {
        return $"A {_color} circle with radius {_radius}";
    }
}

// Triangle Class
public class Triangle : Shape
{
    private double _side1;
    private double _side2;
    private double _side3;

    public Triangle(string color, double side1, double side2, double side3) : base(color)
    {
        _side1 = side1;
        _side2 = side2;
        _side3 = side3;
    }

    public override double GetArea()
    {
        // Using Heron's formula
        double s = (_side1 + _side2 + _side3) / 2;
        return Math.Sqrt(s * (s - _side1) * (s - _side2) * (s - _side3));
    }

    public override double GetPerimeter()
    {
        return _side1 + _side2 + _side3;
    }

    public override string GetDescription()
    {
        return $"A {_color} triangle with sides {_side1}, {_side2}, {_side3}";
    }
}

// Shape Manager Class
public class ShapeManager
{
    private List<Shape> _shapes;

    public ShapeManager()
    {
        _shapes = new List<Shape>();
    }

    public void Run()
    {
        Console.WriteLine("Welcome to the Shape Calculator!");
        Console.WriteLine("===============================\n");

        while (true)
        {
            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("  1. Create New Shape");
            Console.WriteLine("  2. List All Shapes");
            Console.WriteLine("  3. Calculate Total Area");
            Console.WriteLine("  4. Calculate Total Perimeter");
            Console.WriteLine("  5. Quit");
            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateShape();
                    break;
                case "2":
                    ListShapes();
                    break;
                case "3":
                    CalculateTotalArea();
                    break;
                case "4":
                    CalculateTotalPerimeter();
                    break;
                case "5":
                    Console.WriteLine("Goodbye! Thanks for using Shape Calculator!");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    private void CreateShape()
    {
        Console.WriteLine("\nAvailable Shapes:");
        Console.WriteLine("  1. Square");
        Console.WriteLine("  2. Rectangle");
        Console.WriteLine("  3. Circle");
        Console.WriteLine("  4. Triangle");
        Console.Write("Which shape would you like to create? ");

        string shapeType = Console.ReadLine();
        Console.Write("What color is the shape? ");
        string color = Console.ReadLine();

        switch (shapeType)
        {
            case "1":
                Console.Write("Enter the side length: ");
                double side = double.Parse(Console.ReadLine());
                _shapes.Add(new Square(color, side));
                Console.WriteLine("Square created successfully!");
                break;

            case "2":
                Console.Write("Enter the length: ");
                double length = double.Parse(Console.ReadLine());
                Console.Write("Enter the width: ");
                double width = double.Parse(Console.ReadLine());
                _shapes.Add(new Rectangle(color, length, width));
                Console.WriteLine("Rectangle created successfully!");
                break;

            case "3":
                Console.Write("Enter the radius: ");
                double radius = double.Parse(Console.ReadLine());
                _shapes.Add(new Circle(color, radius));
                Console.WriteLine("Circle created successfully!");
                break;

            case "4":
                Console.Write("Enter side 1: ");
                double side1 = double.Parse(Console.ReadLine());
                Console.Write("Enter side 2: ");
                double side2 = double.Parse(Console.ReadLine());
                Console.Write("Enter side 3: ");
                double side3 = double.Parse(Console.ReadLine());
                _shapes.Add(new Triangle(color, side1, side2, side3));
                Console.WriteLine("Triangle created successfully!");
                break;

            default:
                Console.WriteLine("Invalid shape type.");
                break;
        }
    }

    private void ListShapes()
    {
        if (_shapes.Count == 0)
        {
            Console.WriteLine("\nNo shapes available. Create some shapes first!");
            return;
        }

        Console.WriteLine("\nYour Shapes:");
        for (int i = 0; i < _shapes.Count; i++)
        {
            Shape shape = _shapes[i];
            Console.WriteLine($"{i + 1}. {shape.GetDescription()}");
            Console.WriteLine($"   Area: {shape.GetArea():F2}, Perimeter: {shape.GetPerimeter():F2}");
        }
    }

    private void CalculateTotalArea()
    {
        if (_shapes.Count == 0)
        {
            Console.WriteLine("\nNo shapes available. Create some shapes first!");
            return;
        }

        double totalArea = 0;
        foreach (Shape shape in _shapes)
        {
            totalArea += shape.GetArea();
        }

        Console.WriteLine($"\nTotal Area of all shapes: {totalArea:F2}");
    }

    private void CalculateTotalPerimeter()
    {
        if (_shapes.Count == 0)
        {
            Console.WriteLine("\nNo shapes available. Create some shapes first!");
            return;
        }

        double totalPerimeter = 0;
        foreach (Shape shape in _shapes)
        {
            totalPerimeter += shape.GetPerimeter();
        }

        Console.WriteLine($"\nTotal Perimeter of all shapes: {totalPerimeter:F2}");
    }
}

// Main Program
class Program
{
    static void Main(string[] args)
    {
        /*
        DEMONSTRATES OOP PRINCIPLES:
        
        1. ABSTRACTION: Each shape encapsulates its specific properties and calculations
        2. ENCAPSULATION: All member variables are private/protected
        3. INHERITANCE: All shapes inherit from base Shape class
        4. POLYMORPHISM: Same method calls (GetArea, GetPerimeter) produce different results
        
        This program complements the Eternal Quest program by showing:
        - Different domain (geometry vs goal tracking)
        - Same OOP principles applied consistently
        - Clear inheritance hierarchy
        - Method overriding in action
        */

        // Example of polymorphism in action
        Console.WriteLine("=== Polymorphism Demo ===");
        
        List<Shape> shapes = new List<Shape>
        {
            new Square("Red", 5),
            new Rectangle("Blue", 4, 6),
            new Circle("Green", 3),
            new Triangle("Yellow", 3, 4, 5)
        };

        Console.WriteLine("\nIndividual Shape Calculations:");
        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"{shape.GetDescription()}");
            Console.WriteLine($"  Area: {shape.GetArea():F2}, Perimeter: {shape.GetPerimeter():F2}");
        }

        // Demonstrate polymorphic behavior
        Console.WriteLine("\n=== Using Polymorphism ===");
        double totalArea = 0;
        double totalPerimeter = 0;
        
        foreach (Shape shape in shapes)
        {
            totalArea += shape.GetArea();      // Calls appropriate GetArea for each shape
            totalPerimeter += shape.GetPerimeter(); // Calls appropriate GetPerimeter for each shape
        }
        
        Console.WriteLine($"Total Area: {totalArea:F2}");
        Console.WriteLine($"Total Perimeter: {totalPerimeter:F2}");

        Console.WriteLine("\n=== Starting Shape Manager ===");
        ShapeManager manager = new ShapeManager();
        manager.Run();
    }
}