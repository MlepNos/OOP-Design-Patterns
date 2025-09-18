using System;
using System.Collections.Generic;

namespace InheritancePolymorphism
{
    class Program
    {
        static void Main()
        {
            // Derived-typed variable: override runs, but this alone isn't the "polymorphism" part yet.
            // Each object has a specific type
            Dog dog = new Dog("Rex");
            Cat cat = new Cat("Mittens");
            Bird bird = new Bird("Tweety");
            Bird bird_with_type = new Bird("Tweety", "Cardinal");

            // ✅ Direct calls
            Console.WriteLine($"{dog.Name} says {dog.Speak()}");
            Console.WriteLine($"{cat.Name} says {cat.Speak()}");
            Console.WriteLine($"{bird.Name} says {bird.Speak()}");
            Console.WriteLine($"{bird_with_type.Name} says {bird_with_type.Speak("I am a Cardinal")}\n");



            Console.WriteLine("-------------------------------------------------------------------------");
            Animal animal = new Animal("base class animal");  //wont work if the class is abstract 

            if (dog is Animal) Console.WriteLine($"{dog.Name} is an animal\n");
            Console.WriteLine("-------------------------------------------------------------------------");
            // Upcast to base type: NOW you it is runtime polymorphism.
            Animal a2 = dog;
            Console.WriteLine(a2.Speak());             // -> "Chirp!" (polymorphic dispatch)

;

            // ✅ Polymorphism: treat them all as Animal
            List<Animal> animals = new List<Animal> { dog, cat, bird };
            foreach (var a in animals)
            {
                Console.WriteLine($"{a.Name} (as Animal) says {a.Speak()}");
            }

            // ❌ This does NOT work:
            // a.Fly();   // Animal doesn't know about Fly()

            // ✅ Casting to Bird
            //Bird b = (Bird)animals[2];
            //b.Fly(); // Now we can use Fly()
        }
    }
}
