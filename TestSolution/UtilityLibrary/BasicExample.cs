using System;

namespace BasicExample
{
    /* Test multi-line comment. */
    public class BaseClass
    {
        protected int baseValue = 42; // Test comment

        public virtual void Display() => Console.WriteLine("BaseClass Display");
    }

    // Test single line comment
    public class MyClass : BaseClass
    {
        private int _field;
        public static int StaticValue { get; set; } = 100;

        public MyClass(int field)
        {
            _field = field;
        }

        public int MyProperty { get; set; } = 10;

        public override void Display()
        {
            Console.WriteLine($"MyClass Display: {_field}, {baseValue}");
        }

        public static void StaticMethod() => Console.WriteLine("Static Method Called");
    }
}
