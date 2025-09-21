using System;

namespace AccessModifiersDemo
{
    class Program
    {
        static void Main()
        {
            var b = new Base();
            Console.WriteLine("Base.ReadPrivate(): " + b.ReadPrivate());
            Console.WriteLine("Base.ReadAllForSelf(): " + b.ReadAllForSelf());



            Console.WriteLine("-------------------------------------------------------------------------");

            

            var d = new Derived();
            Console.WriteLine("Derived.ReadFromDerived(): " + d.ReadFromDerived());

            var u = new Unrelated();
            Console.WriteLine("Unrelated.ReadFromUnrelated(): " + u.ReadFromUnrelated());

            // These would NOT compile (kept as reminders):
            // Console.WriteLine(b.ProtectedInfo);
            // Console.WriteLine(b.PrivateProtectedInfo);
            // Console.WriteLine(b.PrivateInfo);
        }
    }
}
