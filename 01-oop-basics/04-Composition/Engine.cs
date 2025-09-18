// 01-oop-basics/05-Composition/Engine.cs
namespace CompositionDemo
{
    // Car HAS-A Engine (composition)
    class Engine
    {
        public bool Running { get; private set; }
        public int Rpm { get; private set; }

        public void Start()
        {
            Running = true;
            Rpm = 800; // idle
        }

        public void Stop()
        {
            Running = false;
            Rpm = 0;
        }

        public void Rev(int delta)
        {
            if (!Running) return;
            Rpm = System.Math.Max(800, Rpm + delta);
        }

        public string Status() => Running ? $"running @ {Rpm} rpm" : "stopped";
    }
}
