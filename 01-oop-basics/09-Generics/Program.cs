using System;

namespace GenericsBasicsDemo
{
    class Program
    {
        static void Main()
        {
            // --- Generic class (Box<T>) ---
            var intBox = new Box<int>(42);
            var strBox = new Box<string>("hello");
            Console.WriteLine(intBox);
            Console.WriteLine(strBox);
            Console.WriteLine(new string('-', Math.Max(0, Console.WindowWidth - 1)));


            // --- Generic class with constraint (Repository<T> where T : Animal) ---
            var dogs = new Repository<Dog>();
            dogs.Add(new Dog("Rex"));
            dogs.Add(new Dog("Buddy"));


            var cats = new Repository<Cat>();
            cats.Add(new Cat("Mittens"));


            foreach (var d in dogs.All()) Console.WriteLine(d);
            foreach (var c in cats.All()) Console.WriteLine(c);

            // --- Generic method (independent of T above) ---
            var bigger = Repository<Dog>.Max(10, 7);               // U inferred as int
            var alpha  = Repository<Dog>.Max("beta", "alpha");     // U inferred as string
            Console.WriteLine($"Max(10,7)={bigger}, Max(beta,alpha)={alpha}");
        }
    }
}
