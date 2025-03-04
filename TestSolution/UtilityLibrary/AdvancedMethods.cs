using System;
using System.Threading.Tasks;

namespace AdvancedMethods
{
    public static class Extensions
    {
        public static int Square(this int number) => number * number;
    }

    public class MethodExamples
    {
        public async Task<int> FetchDataAsync()
        {
            await Task.Delay(500);
            return 42;
        }

        public (int, string) GetTupleData() => (100, "Hello");

        public ref int GetRef(ref int value) => ref value;

        public void LocalFunctionExample()
        {
            int LocalSum(int x, int y) => x + y;
            Console.WriteLine($"Local Function Sum: {LocalSum(3, 4)}");
        }
    }

    public class OperatorOverloading
    {
        public int Value { get; }

        public OperatorOverloading(int value) => Value = value;

        public static OperatorOverloading operator +(OperatorOverloading a, OperatorOverloading b) =>
            new(a.Value + b.Value);

        public static bool operator >(OperatorOverloading a, OperatorOverloading b) => a.Value > b.Value;

        public static bool operator <(OperatorOverloading a, OperatorOverloading b) => a.Value < b.Value;

        public override string ToString() => $"Value: {Value}";
    }

    public class IndexedCollection
    {
        private readonly int[] _data = new int[5];

        public int this[int index]
        {
            get => _data[index];
            set => _data[index] = value;
        }
    }
}
