// 01-oop-basics/05-Composition/Wheel.cs
namespace CompositionDemo
{
    class Wheel
    {
        public double PressurePsi { get; private set; }

        public Wheel(double initialPsi = 32) => PressurePsi = initialPsi;

        public void Inflate(double psi) => PressurePsi += psi;
        public void Deflate(double psi) => PressurePsi = System.Math.Max(0, PressurePsi - psi);

        public string Status() => $"{PressurePsi:0.#} psi";
    }
}
