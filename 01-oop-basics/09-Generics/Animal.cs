namespace GenericsBasicsDemo
{
    abstract class Animal
    {
        public string Name { get; }
        protected Animal(string name) => Name = name;
        public abstract string Speak();
        public override string ToString() => $"{Name} says {Speak()}";
    }
}
