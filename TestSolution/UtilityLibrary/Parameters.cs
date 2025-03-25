using System;

public static class ParameterExamples
{
    // Regular parameter
    public static void Regular(int x)
    {
        Console.WriteLine($"Regular: {x}");
    }

    // Default parameter
    public static void WithDefault(int x = 42)
    {
        Console.WriteLine($"With default: {x}");
    }

    // Params parameter (must be last)
    public static void WithParams(params string[] values)
    {
        Console.WriteLine("Params:");
        foreach (var v in values)
            Console.WriteLine($" - {v}");
    }

    // Ref parameter
    public static void WithRef(ref int count)
    {
        count++;
        Console.WriteLine($"With ref: {count}");
    }

    // Out parameter
    public static void WithOut(out bool success)
    {
        success = true;
        Console.WriteLine("With out: set success to true");
    }

    // In parameter
    public static void WithIn(in int value)
    {
        Console.WriteLine($"With in: {value}");
        // value++; // ❌ Would cause a compile error: in parameters are readonly
    }

    // This parameter (extension method)
    public static void PrintUpper(this string input)
    {
        Console.WriteLine(input.ToUpper());
    }
}
