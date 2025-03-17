using System;

// `file` class (C# 11+) - This class is restricted to this file only.
file class FileScopedClass
{
    public void DisplayMessage() => Console.WriteLine("This is a file-scoped class.");
}

// `partial` class - split across multiple files (simulated here with another partial declaration below)
public partial class PartialExample
{
    public void FirstMethod() => Console.WriteLine("First part of PartialExample.");
}

// Another `partial` declaration of the same class
public partial class PartialExample
{
    public void SecondMethod() => Console.WriteLine("Second part of PartialExample.");
}

// `abstract` class - cannot be instantiated directly
public abstract class AbstractClass
{
    // `protected` member - only accessible in derived classes
    protected string ProtectedMessage = "This is a protected member.";

    // `abstract` method - must be implemented by derived classes
    public abstract void AbstractMethod();
}

// `sealed` class - cannot be inherited from
public sealed class SealedClass
{
    public void SealedMethod() => Console.WriteLine("Sealed class method.");
}

// `static` class - cannot be instantiated, only contains static members
public static class StaticClass
{
    public static void StaticMethod() => Console.WriteLine("This is a static method.");
}

// Regular public class with various modifiers
public class ExampleClass : AbstractClass
{
    // `private` field - accessible only within this class
    private int _privateField = 42;

    // `readonly` field - can only be assigned in constructor or inline
    private readonly string _readonlyField = "Readonly value";

    // `const` field - compile-time constant
    private const string ConstantValue = "Constant Value";

    // `static` field - shared across all instances
    private static int _staticCounter = 0;

    // Public property
    public string Name { get; set; }

    // Constructor
    public ExampleClass(string name)
    {
        Name = name;
        _staticCounter++;
    }

    // `override` method to implement abstract method
    public override void AbstractMethod()
    {
        Console.WriteLine("Abstract method implemented.");
    }

    // `private` nested class - only accessible within ExampleClass
    private class PrivateNestedClass
    {
        public void NestedMethod() => Console.WriteLine("Inside private nested class.");
    }

    // `protected` nested class - accessible in derived classes
    protected class ProtectedNestedClass
    {
        public void ProtectedNestedMethod() => Console.WriteLine("Inside protected nested class.");
    }

    // Method demonstrating nested class usage
    public void UseNestedClasses()
    {
        var privateNested = new PrivateNestedClass();
        privateNested.NestedMethod();

        var protectedNested = new ProtectedNestedClass();
        protectedNested.ProtectedNestedMethod();
    }
}

// Derived class demonstrating `protected` access
public class DerivedClass : ExampleClass
{
    public DerivedClass(string name) : base(name) { }

    public void ShowProtectedMessage()
    {
        Console.WriteLine(ProtectedMessage); // Accessible because it's `protected`
    }
}
