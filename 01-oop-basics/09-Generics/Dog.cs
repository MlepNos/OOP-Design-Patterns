namespace GenericsBasicsDemo
{
    class Dog : Animal
    {
        public Dog(string name) : base(name) { }
        public override string Speak() => "Woof!";
    }
}
