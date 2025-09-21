using System.Collections.Generic;

namespace GenericsBasicsDemo
{
    // Generic repository that only accepts Animals (constraint)
    // Other common constraints:
    //   where T : class           // reference type
    //   where T : struct          // value type
    //   where T : new()           // needs public parameterless ctor
    //   where T : BaseType        // must inherit from BaseType
    class Repository<T> where T : Animal
    {
        private readonly List<T> _items = new();

        public void Add(T item) => _items.Add(item);
        public IEnumerable<T> All() => _items;

        // Generic method example with its own type parameter U
        public static U Max<U>(U a, U b) where U : System.IComparable<U>
            => a.CompareTo(b) >= 0 ? a : b;
    }
}
