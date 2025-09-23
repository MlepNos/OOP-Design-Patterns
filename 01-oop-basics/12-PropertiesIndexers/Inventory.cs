// Inventory.cs
using System.Collections.Generic;

namespace PropertiesIndexersDemo
{
    // Shows: single-parameter indexer `this[string key]`
    class Inventory
    {
        private readonly Dictionary<string, int> _stock = new(StringComparer.OrdinalIgnoreCase);

        public int this[string item]
        {
            get => _stock.TryGetValue(item, out var qty) ? qty : 0;
            set
            {
                if (string.IsNullOrWhiteSpace(item)) throw new ArgumentException("Item name required.", nameof(item));
                if (value < 0) throw new ArgumentOutOfRangeException(nameof(value), "Quantity cannot be negative.");
                _stock[item] = value;
            }
        }

        public override string ToString() => string.Join(", ", _stock);
    }
}
