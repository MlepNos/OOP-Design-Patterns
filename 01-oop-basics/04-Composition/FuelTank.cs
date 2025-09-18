namespace CompositionDemo
{
    class FuelTank
    {
        public double FuelAmount { get; set; }

        public double FuelCapacity { get; }

        public FuelTank(double fuelCapacity)
        {
            FuelCapacity = fuelCapacity;
            FuelAmount = 0;
        }

    }
}
