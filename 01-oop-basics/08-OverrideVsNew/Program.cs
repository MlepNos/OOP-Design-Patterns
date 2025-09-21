using System;

namespace OverrideVsNewDemo
{
    class Program
    {
        static void Main()
        {
            Animal a1 = new LoudDog();
            Console.WriteLine(a1.Speak());  // WOOF!   (override -> polymorphic)
            Console.WriteLine(a1.Info());   // (base) info  (non-virtual -> base version)
            Console.WriteLine("-------------------------------------------------------------------------");


            var d = new LoudDog();
            Console.WriteLine(d.Info());    // (loud dog) info  (hiding shows only via derived ref)
            Console.WriteLine("-------------------------------------------------------------------------");


            Animal a2 = new Puppy();
            Console.WriteLine(a2.Speak());  // yip! (most-derived override wins)
            Console.WriteLine(a2.Info());   // (base) info
            Console.WriteLine("-------------------------------------------------------------------------");


            Animal a3 = new GuardDog();
            Console.WriteLine(a3.Speak());  // BARK! (sealed override)
            Console.WriteLine("-------------------------------------------------------------------------");


            var sg = new SuperGuardDog();
            Console.WriteLine(sg.Speak());  // SUPER-BARK! (hiding via derived ref)
            Animal a4 = sg;
            Console.WriteLine(a4.Speak());  // BARK! (still GuardDog’s sealed override; 'new' is NOT polymorphic)
        }
    }
}
