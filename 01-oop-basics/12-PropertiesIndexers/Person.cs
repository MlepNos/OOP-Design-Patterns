// Person.cs
namespace PropertiesIndexersDemo
{
    // Shows: init-only props, private setter, computed property
    class Person
    {
        // Can be set only during object initialization (immutable afterward)
        public string FirstName { get; init; } = "";
        public string LastName  { get; init; } = "";

        // Private setter: only this class can change it
        public int Age { get; private set; }

        // Computed read-only property (no setter)
        public string FullName => $"{FirstName} {LastName}".Trim();

        public Person(string first, string last, int age = 0)
        {
            FirstName = first;
            LastName  = last;
            Age       = age;
        }

        public void HaveBirthday() => Age++;
        public override string ToString() => $"{FullName} ({Age})";
    }
}
