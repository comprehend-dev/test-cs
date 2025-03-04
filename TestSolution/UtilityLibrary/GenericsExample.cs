using System;
using System.Collections.Generic;

namespace GenericsExample
{
    // Generic interface with a constraint
    public interface IRepository<T> where T : class
    {
        void Add(T item);
        T Get(int id);
    }

    // Covariant interface (supports `out` for return types)
    public interface IReadOnlyRepository<out T>
    {
        T Get(int id);
    }

    // Contravariant interface (supports `in` for parameter types)
    public interface IWriter<in T>
    {
        void Write(T item);
    }

    // Generic base class
    public class BaseRepository<T> where T : class
    {
        protected readonly List<T> items = new();

        public virtual void Add(T item) => items.Add(item);

        public virtual T Get(int index) => items[index];
    }

    // Generic class that inherits from a generic base class and implements a generic interface
    public class Repository<T> : BaseRepository<T>, IRepository<T> where T : class
    {
        public override void Add(T item)
        {
            Console.WriteLine($"Adding {item} to repository.");
            base.Add(item);
        }
    }

    // Generic class with multiple type parameters and constraints
    public class Pair<TKey, TValue>
        where TKey : notnull // Ensures TKey is never null
    {
        public TKey Key { get; }
        public TValue Value { get; }

        public Pair(TKey key, TValue value)
        {
            Key = key;
            Value = value;
        }

        public override string ToString() => $"[{Key} - {Value}]";
    }

    // Generic method example
    public class GenericMethods
    {
        public static T GetDefault<T>() => default!;

        public static void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }
    }

    // Class with a nested generic field and method
    public class NestedGenerics<T>
    {
        private readonly Dictionary<T, List<T>> _data = new();

        public void AddValue(T key, T value)
        {
            if (!_data.ContainsKey(key))
            {
                _data[key] = new List<T>();
            }
            _data[key].Add(value);
        }

        public List<T> GetValues(T key) => _data.ContainsKey(key) ? _data[key] : new List<T>();
    }

    // Generic delegate
    public delegate T Factory<T>();

    // Using covariance (`out`) in a factory delegate
    public delegate TResult FactoryWithCovariance<out TResult>();

    // Using contravariance (`in`) in an action delegate
    public delegate void ActionWithContravariance<in T>(T input);

    // Class to demonstrate usage
    public class GenericsDemo
    {
        public static void Run()
        {
            // Using the generic repository
            IRepository<string> stringRepo = new Repository<string>();
            stringRepo.Add("Hello");
            Console.WriteLine(stringRepo.Get(0));

            // Using a class with multiple generic parameters
            var pair = new Pair<int, string>(1, "One");
            Console.WriteLine(pair);

            // Calling generic methods
            int x = 5, y = 10;
            GenericMethods.Swap(ref x, ref y);
            Console.WriteLine($"Swapped: x = {x}, y = {y}");

            string defaultString = GenericMethods.GetDefault<string>();
            Console.WriteLine($"Default string: {defaultString}");

            // Using nested generics
            var nested = new NestedGenerics<string>();
            nested.AddValue("Category1", "ItemA");
            nested.AddValue("Category1", "ItemB");
            nested.AddValue("Category2", "ItemC");

            Console.WriteLine("Nested Generics:");
            foreach (var item in nested.GetValues("Category1"))
            {
                Console.WriteLine(item);
            }

            // Using a generic delegate
            Factory<int> intFactory = () => 42;
            Console.WriteLine($"Factory created: {intFactory()}");

            // Covariance: Derived → Base works
            FactoryWithCovariance<string> strFactory = () => "Hello Covariance!";
            FactoryWithCovariance<object> objFactory = strFactory;
            Console.WriteLine($"Covariant factory result: {objFactory()}");

            // Contravariance: Base → Derived works
            ActionWithContravariance<object> printObject = obj => Console.WriteLine($"Object: {obj}");
            ActionWithContravariance<string> printString = printObject;
            printString("Contravariant Test");
        }
    }
}
