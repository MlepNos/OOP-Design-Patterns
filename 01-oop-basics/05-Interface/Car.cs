



namespace InterfaceDemo
{






public class Car
{
    private readonly IEngine _engine;
    // wheels omitted for brevity…

    public string Name { get; }
    public double OdometerKm { get; private set; }

    public Car(string name, IEngine engine)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        _engine = engine ?? throw new ArgumentNullException(nameof(engine));
    }

    public void TurnKeyOn() => _engine.Start();
    public void TurnKeyOff() => _engine.Stop();

    public void Drive(double km)
    {
        if (!_engine.Running) _engine.Start();
        _engine.Rev(300);
        OdometerKm += _engine.Drive(km);   // engine decides how far we actually go
    }

    public double Refill(double amount) => _engine.Refill(amount);
    public string Report() => $"Engine: {_engine.Status()} | Odometer: {OdometerKm:0.0} km";
}
}