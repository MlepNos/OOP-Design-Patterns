


// 01-oop-basics/05-Composition/Program.cs
using System;

namespace InterfaceDemo
{
    class Program
    {
        static void Main()
        {
         var petrol = new Car("Mercedes", new CombustionEngine(capacityL: 50));
        petrol.Refill(20);
        petrol.TurnKeyOn();
        petrol.Drive(100);
        Console.WriteLine(petrol.Report());

        var ev = new Car("Model 3", new ElectricEngine(capacityKWh: 60));
        ev.Refill(30);
        ev.TurnKeyOn();
        ev.Drive(100);
        Console.WriteLine(ev.Report());



        }
    }
}
