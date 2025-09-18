// 01-oop-basics/05-Composition/Wheel.cs
namespace CompositionDemo
{
    class Dashboard
    {

        private readonly Car _car;
        public Dashboard(Car car)
        {
            _car = car ?? throw new ArgumentNullException(nameof(car));
        }        public void Status()
        {

             Console.WriteLine("-------------------------------------------------------------------------");
            Console.WriteLine($"Name:     {_car.Name}");
            Console.WriteLine($"Odometer: {_car.OdometerKm:0.0} km");
            Console.WriteLine($"Fuel:     {_car.CurrentFuel:0.0}");
            Console.WriteLine(_car.Report());
        



        }

      
    }
}
