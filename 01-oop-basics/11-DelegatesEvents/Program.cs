using System;

namespace DelegatesEventsDemo
{
    class Program
    {
        static void Main()
        {
            // 1) Delegates – warm-up
            DelegatesBasics.Run();
            Console.WriteLine(new string('-', 65));

            // 2) Events – Observer pattern
            var ticker = new StockTicker("ACME", 100m);

            var logger = new PriceLogger();
            var alarm = new PriceAlarm(thresholdPct: 5m);

            // Subscribe via instance methods
            ticker.PriceChanged += logger.Handle;
            ticker.PriceChanged += alarm.Handle;

            // Also subscribe with an inline lambda
            ticker.PriceChanged += (s, e) =>
                Console.WriteLine($"[UI] {e.Symbol} @ {e.NewPrice} ({e.ChangePct:0.##}%)");

            // Simulate
            ticker.UpdatePrice(101m);   // small move
            ticker.UpdatePrice(110m);   // big move -> alarm
            ticker.UpdatePrice(104m);   // down move

            Console.WriteLine(new string('-', 65));

            // Unsubscribe example (remove logger)
            ticker.PriceChanged -= logger.Handle;
            ticker.UpdatePrice(120m);   // no logger now, others still receive

            // NOTE:
            // - Only StockTicker can *raise* PriceChanged.
            // - Any number of subscribers can *listen*.
            // - This is exactly the Observer pattern in .NET style.


            Console.WriteLine(new string('-', 65));
            Console.WriteLine(new string('-', 65));



            var bell = new Doorbell();
            var alice = new Resident();
            var rex = new Dog();

            // Subscribe (+= adds handlers to the event’s invocation list)
            bell.Rang += alice.OnDoorbellRang;
            bell.Rang += rex.OnDoorbellRang;

            // Also works with a lambda
            bell.Rang += (s, e) => Console.WriteLine("SmartLight: Porch light ON");

            Console.WriteLine("Press #1:");
            bell.Press(); // calls all three handlers

            // Unsubscribe one
            bell.Rang -= rex.OnDoorbellRang;

            Console.WriteLine("\nPress #2:");
            bell.Press(); // now only Resident + SmartLight
        }
    }
    



    class Doorbell
    {
        // Anyone can listen; only Doorbell can raise it
        public event EventHandler? Rang;

        public void Press()
            => Rang?.Invoke(this, EventArgs.Empty); // "ring!"
    }

    class Resident
    {
        public void OnDoorbellRang(object? sender, EventArgs e)
            => Console.WriteLine("Resident: Coming!");
    }

    class Dog
    {
        public void OnDoorbellRang(object? sender, EventArgs e)
            => Console.WriteLine("Dog: WOOF! WOOF!");
    }
}
