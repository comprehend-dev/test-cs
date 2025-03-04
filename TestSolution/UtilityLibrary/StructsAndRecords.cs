using System;

namespace StructsAndRecords
{
    public interface IExample
    {
        void PrintMessage();
        void DefaultMethod() => Console.WriteLine("This is a default interface method");
    }

    public struct MyStruct
    {
        public readonly int X;
        public MyStruct(int x) => X = x;

        public void Show() => Console.WriteLine($"Struct Value: {X}");
    }

    public record MyRecord(string Name, int Age);

    public class MyImplementation : IExample
    {
        public void PrintMessage() => Console.WriteLine("Interface method implemented.");
    }
}
