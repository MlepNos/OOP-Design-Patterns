using System;

namespace ClassesAndObjects
{
    class Greeter
    {
        public void Greet(Person person)
        {
            Console.WriteLine("Hello, " + person.FullName());
        }
    }
}
