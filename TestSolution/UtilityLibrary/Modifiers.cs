using System;
using System.Threading.Tasks;

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

// Example of event declarations
public class EventsExample
{
    public event Action PublicEvent;
    private event EventHandler PrivateEvent;
    protected static event Func<int, string> StaticProtectedEvent;
    internal readonly event Action InternalReadonlyEvent;
}

public abstract class Animal
{
    // Abstract method - must be overridden by derived classes
    public abstract void Speak();

    // Virtual method - can be optionally overridden
    public virtual void Eat()
    {
        Console.WriteLine("The animal is eating.");
    }

    // Static method - belongs to the class itself
    public static void Describe()
    {
        Console.WriteLine("Animals are living creatures.");
    }

    // Async method - for asynchronous behavior
    public async Task SleepAsync()
    {
        Console.WriteLine("Animal is falling asleep...");
        await Task.Delay(500);
        Console.WriteLine("Animal is now asleep.");
    }

    // Protected method - accessible in derived classes
    protected void Breathe()
    {
        Console.WriteLine("The animal breathes.");
    }

    // Private method - internal helper
    private void Digest()
    {
        Console.WriteLine("The animal digests food.");
    }

    // Unsafe method - for low-level operations (not common, but valid)
    protected unsafe void DoUnsafeStuff()
    {
        int x = 10;
        int* p = &x;
        Console.WriteLine($"Pointer value: {*p}");
    }
}

public class PropertyExample
{
    // Public auto-property with get/set
    public string Name { get; set; }

    // Auto-property with init-only setter (C# 9+)
    public string Email { get; init; }

    // Required auto-property (C# 11+)
    public required int Age { get; init; }

    // Auto-property with private setter
    public int Id { get; private set; }

    // Auto-property with protected setter
    public int Score { get; protected set; }

    // Static auto-property
    public static int InstanceCount { get; set; }

    // Read-only calculated property (custom getter only)
    public int DoubleScore
    {
        get { return Score * 2; }
    }

    // Virtual property with custom get/set
    public virtual bool IsActive
    {
        get => _isActive;
        set => _isActive = value;
    }
    private bool _isActive;

    // Abstract property (must be implemented by derived classes)
    public abstract string AbstractData { get; set; }
}
