// ElectricEngine.cs




namespace InterfaceDemo
{
    public class ElectricEngine : IEngine
    {
        private double _kWh;                 // charge
        private readonly double _capacityKWh;
        private readonly double _kWhPerKm;   // e.g., 0.15 kWh/km

        public bool Running { get; private set; }
        public int Rpm { get; private set; }

        public ElectricEngine(double capacityKWh, double kWhPerKm = 0.15)
        {
            _capacityKWh = capacityKWh;
            _kWhPerKm = kWhPerKm;
        }

        public void Start() { Running = true; Rpm = 1000; }
        public void Stop() { Running = false; Rpm = 0; }
        public void Rev(int delta) { if (Running) Rpm = Math.Max(1000, Rpm + delta); }

        public double Drive(double km)
        {
            if (!Running || km <= 0 || _kWh <= 0) return 0;
            double need = km * _kWhPerKm;
            if (_kWh >= need) { _kWh -= need; return km; }
            double possible = _kWh / _kWhPerKm;
            _kWh = 0;
            return possible;
        }

        public double Refill(double amount)
        {
            if (amount <= 0) throw new ArgumentException("positive");
            _kWh = Math.Min(_kWh + amount, _capacityKWh);
            return _kWh;
        }

        public string Status() => Running ? $"running @ {Rpm} rpm" : "stopped";
    }



}