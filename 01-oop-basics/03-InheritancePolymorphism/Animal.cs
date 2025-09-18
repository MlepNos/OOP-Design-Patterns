namespace InheritancePolymorphism
{
    // Base class (parent)
    class Animal   // we could make it abstract by using "abstract class Animal" insteadd
    {
        public string Name { get; set; }
        public string Type { get; set; } = "Unknown";


        public Animal(string name)
        {
            Name = name;
            // Type stays "Unknown"
        }


        public Animal(string name, string type) //Constructor Overloading
        {
            Name = name;
            Type = type;
        }

        // Virtual = enables polymorphism
        // Virtual method = can be overridden
        public virtual string Speak() => "...";
        public virtual string Speak(string sound) => sound;
    }
}
