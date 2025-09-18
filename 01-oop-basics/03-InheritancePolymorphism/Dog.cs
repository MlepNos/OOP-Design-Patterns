namespace InheritancePolymorphism
{
    // Derived class (child)
    class Dog : Animal
    {
        public Dog(string name) : base(name) { }

        // Override = replace base implementation
        public override string Speak() => "Woof!";
    }
}
