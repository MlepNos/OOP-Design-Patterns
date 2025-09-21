




namespace InterfaceDemo
{
    

public interface IEngine
{
    bool Running { get; }
    int Rpm { get; }
    void Start();
    void Stop();
    void Rev(int delta);
    double Drive(double requestedKm);
    double Refill(double amount);
    string Status();
}

}







