// Program.cs
using System;
using System.Collections.Generic;

namespace ExtensionsDemo
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Hello World".Truncate(5)); // Hello
            Console.WriteLine("  A  B  ".IsNullOrBlank()); // False
            Console.WriteLine("C# OOP & Design Patterns".ToSlug()); // c-oop-design-patterns

            var names = new List<string?> { "Ada", null, "Ada", "Grace" };
            foreach (var n in names.WhereNotNull().DistinctBy(x => x))
                Console.WriteLine(n); // Ada, Grace
        }
    }
}
