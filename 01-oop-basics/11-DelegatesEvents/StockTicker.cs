using System;

namespace DelegatesEventsDemo
{
    // Event payload class (recommended pattern)
    public sealed class PriceChangedEventArgs : EventArgs
    {
        public string Symbol { get; }
        public decimal OldPrice { get; }
        public decimal NewPrice { get; }
        public decimal Change => NewPrice - OldPrice;
        public decimal ChangePct => OldPrice == 0 ? 0 : (NewPrice - OldPrice) / OldPrice * 100m;

        public PriceChangedEventArgs(string symbol, decimal oldPrice, decimal newPrice)
        {
            Symbol = symbol; OldPrice = oldPrice; NewPrice = newPrice;
        }
    }

    // Publisher = the thing that raises events (observable)
    public class StockTicker
    {
        public string Symbol { get; }
        public decimal Price { get; private set; }

        // Standard .NET event pattern: EventHandler<TEventArgs>
        public event EventHandler<PriceChangedEventArgs>? PriceChanged;

        public StockTicker(string symbol, decimal startPrice = 0m)
        {
            Symbol = symbol;
            Price = startPrice;
        }

        public void UpdatePrice(decimal newPrice)
        {
            if (newPrice == Price) return;
            var old = Price;
            Price = newPrice;
            OnPriceChanged(new PriceChangedEventArgs(Symbol, old, newPrice));
        }

        // Only the publisher can raise (invoke) the event
        protected virtual void OnPriceChanged(PriceChangedEventArgs e)
            => PriceChanged?.Invoke(this, e);
    }
}
