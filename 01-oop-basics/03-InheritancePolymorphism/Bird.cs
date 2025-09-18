namespace InheritancePolymorphism
{
    // Can override Speak, but also add new behavior (unique to Bird)
    class Bird : Animal //inheritance = “is-a” relationship.
    {
        public Bird(string name) : base(name) { }
        public Bird(string name, string type) : base(name, type) { }

        public override string Speak() => "Chirp!";

        //public override string Speak(string sound) => sound;


        // Bird-specific method
        public void Fly()
        {
            System.Console.WriteLine($"{Name} is flying!");
        }
    }
}
