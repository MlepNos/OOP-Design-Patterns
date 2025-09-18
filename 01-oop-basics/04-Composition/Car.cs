// 01-oop-basics/05-Composition/Car.cs
using System.Collections.Generic;
using System.Linq;

namespace CompositionDemo
{
    class Car
    {
        private readonly Engine _engine = new Engine();                 // HAS-A Engine
        private readonly List<Wheel> _wheels = new() {                  // HAS 4 Wheels
            new Wheel(), new Wheel(), new Wheel(), new Wheel()
        };

        private readonly FuelTank _fuelTank = new FuelTank(500);

        public  double CurrentFuel => _fuelTank.FuelAmount;

        public double OdometerKm { get; private set; }

        public void TurnKeyOn() => _engine.Start();
        public void TurnKeyOff() => _engine.Stop();

        public string Name { get;  set;}
        public Car(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

       public void Drive(double km)
        {
            if (!_engine.Running || _fuelTank.FuelAmount <= 0) return;

            _engine.Rev(300);

            // 1 unit fuel per 1 km
            double needed = km;
            double used   = Math.Min(needed, _fuelTank.FuelAmount);

            _fuelTank.FuelAmount -= used;
            OdometerKm += used;                 // ✅ move only as far as fuel allows
        }

        public void InflateAll(double psi)
        {
            foreach (var w in _wheels) w.Inflate(psi);
        }

        public string Report()
        {
            var tires = string.Join(", ", _wheels.Select((w, i) => $"T{i + 1}:{w.Status()}"));
            return $"Engine: {_engine.Status()} | Odometer: {OdometerKm:0.0} km | Tires: [{tires}]";
        }


        public double Fuel(double amount)
        {
            if (amount <= 0) throw new ArgumentException("amount must be positive.");
            _fuelTank.FuelAmount = Math.Min(_fuelTank.FuelAmount + amount, _fuelTank.FuelCapacity);
            return _fuelTank.FuelAmount;
        }
    }
}
