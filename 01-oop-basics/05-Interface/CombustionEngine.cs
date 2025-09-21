// CombustionEngine.cs




namespace InterfaceDemo
{  public class CombustionEngine : IEngine
{
    private double _fuelL;           // liters
    private readonly double _capacityL;
    private readonly double _litersPerKm; // e.g., 0.08 = 8L/100km

    public bool Running { get; private set; }
    public int Rpm { get; private set; }

    public CombustionEngine(double capacityL, double litersPerKm = 0.08)
    {
        _capacityL = capacityL;
        _litersPerKm = litersPerKm;
    }

    public void Start() { Running = true; Rpm = 800; }
    public void Stop() { Running = false; Rpm = 0; }
    public void Rev(int delta) { if (Running) Rpm = Math.Max(800, Rpm + delta); }

    public double Drive(double km)
    {
        if (!Running || km <= 0 || _fuelL <= 0) return 0;
        double need = km * _litersPerKm;
        if (_fuelL >= need) { _fuelL -= need; return km; }
        double possible = _fuelL / _litersPerKm;
        _fuelL = 0;
        return possible;
    }

    public double Refill(double amount)
    {
        if (amount <= 0) throw new ArgumentException("positive");
        _fuelL = Math.Min(_fuelL + amount, _capacityL);
        return _fuelL;
    }

    public string Status() => Running ? $"running @ {Rpm} rpm" : "stopped";
}
 }
