using System;

namespace StaticVsInstanceDemo
{
    class Counter
    {
        // STATIC = one copy per TYPE (shared by all Counter objects)
        public static int Instances { get; private set; }

        // INSTANCE = each object has its own copy
        public int Value { get; private set; }

        // Static constructor: runs ONCE, before the first use of the type
        static Counter()
        {
            Instances = 0;
            Console.WriteLine("[Counter] static ctor ran once");
        }

        // Instance constructor: runs on every new object
        public Counter(int start = 0)
        {
            Value = start;
            Instances++; // increments the shared counter
        }

        // Instance method: needs an object (`this`)
        public void Increment() => Value++;

        // Static method: belongs to the type; no `this`
        public static string TimestampUtc() => DateTime.UtcNow.ToString("u");
    }
}
