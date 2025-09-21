using System;

namespace DelegatesEventsDemo
{
    // A subscriber that logs every price change
    public class PriceLogger
    {
        public void Handle(object? sender, PriceChangedEventArgs e)
        {
            Console.WriteLine($"[LOG] {e.Symbol}: {e.OldPrice} -> {e.NewPrice} ({e.Change:+0.00;-0.00;0.00})");
        }
    }

    // A subscriber that alerts on big moves
    public class PriceAlarm
    {
        private readonly decimal _thresholdPct;
        public PriceAlarm(decimal thresholdPct) => _thresholdPct = thresholdPct;

        public void Handle(object? sender, PriceChangedEventArgs e)
        {
            if (Math.Abs(e.ChangePct) >= _thresholdPct)
                Console.WriteLine($"[ALARM] {e.Symbol} moved {e.ChangePct:0.##}%!");
        }
    }
}
