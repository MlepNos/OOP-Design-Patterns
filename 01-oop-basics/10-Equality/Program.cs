using System;
using System.Collections.Generic;

namespace EqualityDemo
{
    class Program
    {
        static void Main()
        {
            var p1 = new Person("Ada", "Lovelace", new DateTime(1815, 12, 10));
            var p2 = new Person("Ada", "Lovelace", new DateTime(1815, 12, 10));
            var p3 = p1; // same reference

            Console.WriteLine(p1); // ToString()

            // Value equality vs reference equality
            Console.WriteLine($"p1 == p2 : {p1 == p2}");                    // true (operators)
            Console.WriteLine($"p1.Equals(p2): {p1.Equals(p2)}");           // true
            Console.WriteLine($"ReferenceEquals(p1,p2): {ReferenceEquals(p1, p2)}"); // false
            Console.WriteLine($"ReferenceEquals(p1,p3): {ReferenceEquals(p1, p3)}"); // true

            // Hash-based collections depend on GetHashCode/Equals
            var set = new HashSet<Person> { p1, p2 }; // p2 considered duplicate
            Console.WriteLine($"HashSet count: {set.Count}"); // 1

            var dict = new Dictionary<Person, string> { [p1] = "first" };
            dict[p2] = "second"; // replaces same logical key
            Console.WriteLine($"Dictionary value by p1: {dict[p1]}"); // "second"

            Console.WriteLine(new string('-', Math.Max(0, Console.WindowWidth - 1)));








            // --- Record-based PersonRec (equality for free) ---
            var r1 = new PersonRec("Ada", "Lovelace", new DateTime(1815, 12, 10));
            var r2 = new PersonRec("Ada", "Lovelace", new DateTime(1815, 12, 10));


            Console.WriteLine("== RECORD (value equality by default) ==");
            Console.WriteLine($"r1 == r2:      {r1 == r2}");                 // true (value equality)
            Console.WriteLine($"r1.Equals(r2): {r1.Equals(r2)}");            // true
            Console.WriteLine($"RefEq:         {ReferenceEquals(r1, r2)}");  // false



            Console.WriteLine(new string('-', Math.Max(0, Console.WindowWidth - 1)));

            // --- with-expressions: copy with one change (records are init-only by default) ---
            var r3 = r1 with { LastName = "Byron" };
            Console.WriteLine($"r1: {r1}");
            Console.WriteLine($"r3: {r3}");                                  // different last name
            Console.WriteLine($"r1 == r3: {r1 == r3}");                      // false

        }
    }
}
