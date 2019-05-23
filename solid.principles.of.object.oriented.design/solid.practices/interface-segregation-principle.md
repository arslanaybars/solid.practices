# Interface Segregation Principle

States that Clients should no be forced to depend on methods they do not use

no client code object should be forced to depend on methods it does not use.  Basically, each code object should only implement what it needs, and not be required to implement anything else

!! Prefer small, cohesive interfaces to "fat" interfaces
!! Break up large interfaces into the smaller ones

![Interface Segregation Principle](https://www.tomdalling.com/images/posts/isp.jpg)

``` csharp
public interface IProduct
{
    int ID { get; set; }
    double Weight { get; set; }
    int Stock { get; set; }
    int Inseam { get; set; }
    int WaistSize { get; set; }
}

public class Jeans : IProduct
{
    public int ID { get; set; }
    public double Weight { get; set; }
    public int Stock { get; set; }
    public int Inseam { get; set; }
    public int WaistSize { get; set; }
}

// WTF!!
// Why does a baseball cap have an inseam or waist size? Those properties don't make sense for a baseball cap, 
// but because they were defined in IProduct, BaseballCap must implement them.
// solution is in the second code pieces
public class BaseballCap : IProduct
{
    public int ID { get; set; }
    public double Weight { get; set; }
    public int Stock { get; set; }
    public int Inseam { get; set; }
    public int WaistSize { get; set; }
    public int HatSize { get; set; }
}
```

Refactor!
``` csharp
public interface IProduct
{
    int ID { get; set; }
    double Weight { get; set; }
    int Stock { get; set; }
}

public interface IPants
{
    public int Inseam { get; set; }
    public int WaistSize { get; set; }
}

public interface IHat
{
    public int HatSize { get; set; }
}

public class Jeans : IProduct, IPants
{
    public int ID { get; set; }
    public double Weight { get; set; }
    public int Stock { get; set; }
    public int Inseam { get; set; }
    public int WaistSize { get; set; }
}

public class BaseballCap : IProduct, IHat
{
    public int ID { get; set; }
    public double Weight { get; set; }
    public int Stock { get; set; }
    public int HatSize { get; set; }
}
```
Each class now has only properties that they need. Now we are upholding the Interface Segregation Principle

Related Fundamentals
- Facade Pattern