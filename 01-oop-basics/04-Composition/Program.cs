// 01-oop-basics/05-Composition/Program.cs
using System;

namespace CompositionDemo
{
    class Program
    {
        static void Main()
        {
            var car = new Car("mercedes");

            Console.WriteLine(car.Report());
            car.TurnKeyOn();
            Console.WriteLine(car.Report());

            car.Drive(5);
            Console.WriteLine(car.Report());

            car.InflateAll(3);
            Console.WriteLine(car.Report());

            car.TurnKeyOff();
            Console.WriteLine(car.Report());



            Console.WriteLine("-------------------------------------------------------------------------");
            //Console.WriteLine(car.Fuel(200));
            Console.WriteLine("-------------------------------------------------------------------------");
            //Console.WriteLine(car.Fuel(200));
            //Console.WriteLine(car.Fuel(200));
            //Console.WriteLine(car.Fuel(200));




            Console.WriteLine("-------------------------------------------------------------------------");


            var car_audi = new Car("audi");
            var dashboard = new Dashboard(car_audi);
            dashboard.Status();

            car_audi.TurnKeyOn();
            car_audi.Fuel(200);
            car_audi.Drive(50);   
            dashboard.Status();


        }
    }
}
