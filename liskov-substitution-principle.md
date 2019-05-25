# Liskov Substitution Principle

States that Subtypes must be substitutable for their base types.

![Liskov Substitution Principle](https://www.tomdalling.com/images/posts/lsp.jpg)

Liskov substitution principle suggests that *IS-A* should be replaced with *IS-SUBSTITUTABLE-FOR*

LSP Vialation Smells
----------

``` csharp
public abstract class Base
{
    public abstract void Method1();
    public abstract void Method2();
}

public class Child : Base
{
    public override void Method1()
    {
        // FOLLOW ISP!
        // Use small interfaces so you ont require classes to implement more than they need
        throw nee NotImplementedException(); // BOOM!!
    }
    
    public override void Method2()
    {
        // Codes running
    }
}
```

Bad design that violate LSP
``` csharp
    public abstract class Car
    {
        public string Run()
        {
            return "Araba çalıştırıldı.";
        }
        public abstract string OpenAirConditioning();
    }

    public class Ferrari : Car
    {
        public override string OpenAirConditioning()
        {
            return "Klima açıldı.";
        }
    }
 
    public class Murat131 : Car
    {
        public override string OpenAirConditioning()
        {
            throw new NotImplementedException();
 
            //return null;
        }
    }
    
    static void Main(string[] args)
    {
        Car car = new Ferrari();
        car.Run();
        car.OpenAirConditioning();
        // All is well
        
        car = new Murat131();
       car.Run();
       car.OpenAirConditioning(); // ???
    }
```
Let's solve the problem, abides by the Liskov Subsutitution Principle

``` csharp
    public interface IAirConditionable
    {
        string OpenAirConditioning();
    }
 
    public abstract class Car
    {
        public string Run()
        {
            return "Araba çalıştırıldı.";
        }
    }
 
    public class Ferrari : Car, IAirConditionable
    {
        public string OpenAirConditioning()
        {
            return "Klima açıldı.";
        }
    }
 
    public class Murat131 : Car
    {
    }
```