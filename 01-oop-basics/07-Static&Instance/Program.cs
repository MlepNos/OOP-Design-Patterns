using System;

namespace StaticVsInstanceDemo
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine($"App: {AppConfig.AppName} | AppId: {AppConfig.AppId}");
            Console.WriteLine($"Start Mode: {AppConfig.Mode}");
            AppConfig.SetMode("PROD");
            Console.WriteLine($"New Mode:   {AppConfig.Mode}");
            Console.WriteLine();

            Console.WriteLine($"Now: {Counter.TimestampUtc()}");
            var a = new Counter();       // Instances -> 1
            var b = new Counter(10);     // Instances -> 2
            var c = new Counter(20);     // Instances -> 3

            a.Increment();               // a.Value = 1
            b.Increment();               // b.Value = 11

            Console.WriteLine($"a.Value = {a.Value}");
            Console.WriteLine($"b.Value = {b.Value}");
            Console.WriteLine($"Counter.Instances (shared) = {Counter.Instances}");

            // NOTE: you call static members on the TYPE:
            // var x = Counter.Instances;           // ✅
            // var y = a.Instances;                 // ❌ discouraged (still compiles but confusing)
            // var z = new AppConfig();             // ❌ cannot new a static class
        }
    }
}
