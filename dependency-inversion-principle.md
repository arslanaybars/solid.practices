# Dependency Inversion Principle

High-level modules should not depend on low-level modules. Both should depend on abstractions.

Abstractions should not depend in details. Details should depend on abstractions

What are dependencies?
----
- Framework
- Third party libraries
- Database
- File System
- Email
- Web Services
- System Resources (Clock)
- Configuration
- The *new* Keyword
- Static methods

![Dependency Inversion Principle](https://mkatkoot.files.wordpress.com/2013/06/dependency_inversion_principle.jpg?w=800)

*Dependency Injection* is a technique that is used to allow calling ode to inject dependencies a class needs when it is instantiated

!!! Do not call us; we will call you

There are three primary techniques
----
- Constructor Injection
- Property injection
- Parameter Injection
-----

# Constructor Injection
Dependencies are passed in via consturctor !! Strategy Pattern !!

Pros
----
- Classes self document what they need to perform theirs work\
- Works well with or without container
- Classes are always in valid state once constructed

Cons
----
- Constructors can have many parameters/dependencies (design smell)
- Some features (Serialization) may require a default constructor
- Some methods in the class may not require things other methods require (design smell)

-----

# Property Injection

Dependencies are passed in via property
Also known as "setter injection"

Pros
----
- Dependency can be changed at any time during object lifetime
- Very flexible

Cons
----
- Objects may be in an invalid state between construction and setting of dependencies via setters
- Less intuitive
-----

# Parameter Injection
Dependencies are passed in via parameter

Pros
----
- Most granular
- Very flexible
- Requires no change to rest of class

Cons
----
- Breaks methods signature
- Can result in many paramters (design smell)

----
# Refactoring

- Extract dependencies into interfaces
- Injectt implementations of interfaces into Main
- Reduce Main claas's responsibilities


## Related Fundamentals
- Facade Pattern
- Inversion of Control Containers