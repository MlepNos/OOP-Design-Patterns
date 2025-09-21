// A tiny generic container. Works for any T.
namespace GenericsBasicsDemo
{
    class Box<T>
    {
        public T Value { get; }
        public Box(T value) => Value = value;
        public override string ToString() => $"Box<{typeof(T).Name}>: {Value}";
    }
}
