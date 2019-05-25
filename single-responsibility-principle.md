# Single Responsibility Principle

*Robert C. "Unle Bob" Martin* saying is Each software module should have **one and only one** reason to change. 

According to *Wikipedia*; The Single Responsibility Principle states that every object shoul have a single responsiblity, and that responsibility should be entirely encapsulated by class

Do one thing
Do that thing only
Do that thing well

![Single Responsility Principle](http://i0.wp.com/www.devtec.com/wp-content/uploads/2013/04/SRP.jpg)

- **STRIVE FOR** low coupling and high cohesion!
- Follow Iterface Segregation Principle (ISP) can helpt to achieve Single Responsibility principle

It  is not fulfill with the SRP.
It is doing two things namely. Greeting the user if they can join, or rejecting them if they cannot. 
``` csharp
public void UserJoin(User user)
{
    if (verify.CanJoin(user))
    {
        messages.Greeting(user);
    }
    else
    {
        this.kick(user);
    }
}
```
It might be better to reorganize the method

``` csharp
public void UserJoin(User user)
{
  user.CanJoin ? GreetUser(user) : RejectUser(user);
}

public void Greetuser(User user)
{
  messages.Greeting(user);
}

public void RejectUser(User user)
{
  messages.Reject(user);
  this.kick(user);
}
```

One more example that is class based

Bad design
``` csharp
public class Order
{
    public void SaveOrder()
	{
		// runs
	}
	public void SaveAddress()
	{
		// runs
	}
	public void SendNotification()
	{
		// runs
	}
}
```
This should be more cleaner and understandable for sure

``` csharp

public class Order
{
    public void SaveOrder()
	{
		// runs
	}
}

public class Address
{
    public void SaveAdress()
	{
		// runs
	}
}

public class Notification
{
    public void SendNotification()
	{
		// runs
	}
}
```