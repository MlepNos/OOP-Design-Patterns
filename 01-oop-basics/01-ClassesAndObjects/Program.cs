namespace ClassesAndObjects
{
    class Program
    {
        static void Main()
        {
            var Character_Ada = new Person("Ada", "Lovelace");
            var greeter = new Greeter();
            greeter.Greet(Character_Ada);
        }
    }
}
