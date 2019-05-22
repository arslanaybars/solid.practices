# Open Closed Principle

According to *Wikipedia*; The Open Closed Principle states that software entities (classes, modules, functions, etc.) shoul be open for extension, but closed for modification

![Open Closed Principle](https://www.gokhan-gokalp.com/wp-content/uploads/2014/12/ocp.jpg)

- Open To Extension
--  New behavior can be added in the future
- Closed to Modification
--  Changes to source or binary code are not required

Change behavior without changin code!!
Rely on **abstractions!** No limit to variety of implementations of each **abstraction**
Abstractions includes in Interfaces and Abstract Base Classes

Let's make better following method with using ocp 
famous example AreaCalculator..

Two code pieces return same and true. so I am happy! but After a week later if they wanted extend area calculater then one more then one more. It raise complexity and violete ocp
AreaCalculator isn’t **closed for modification** as we need to change it in order to extend it. Or in other words: it isn’t **open for extension.**
``` csharp
public class Rectangle
{
    public double Width { get; set; }
    public double Height { get; set; }
}

public class AreaCalculator
{
    public double Area(Rectangle[] shapes)
    {
        double area = 0;
        foreach (var shape in shapes)
        {
            area += shape.Width*shape.Height;
        }

        return area;
    }
}

public double Area(object[] shapes)
{
    double area = 0;
    foreach (var shape in shapes)
    {
        if (shape is Rectangle)
        {
            Rectangle rectangle = (Rectangle) shape;
            area += rectangle.Width*rectangle.Height;
        }
        else
        {
            Circle circle = (Circle)shape;
            area += circle.Radius * circle.Radius * Math.PI;
        }
    }

    return area;
}
```
Let's solve the problem, abides by the Open Closed Principle.

``` csharp
public abstract class Shape
{
    public abstract double Area();
}

public class Rectangle : Shape
{
    public double Width { get; set; }
    public double Height { get; set; }
    public override double Area()
    {
        return Width*Height;
    }
}

public class Circle : Shape
{
    public double Radius { get; set; }
    public override double Area()
    {
        return Radius*Radius*Math.PI;
    }
}

public double Area(Shape[] shapes)
{
    double area = 0;
    foreach (var shape in shapes)
    {
        area += shape.Area();
    }

    return area;
}
```

we’ve closed it for modification by opening it up for extension.

	> Fool me once, shame on you; fool me twice, shame on me
	- Don't apply OCP if you could not imagine at first
	- If the module changes once, accept it!
	- If it changes a second time, refactor to achieve OCP
