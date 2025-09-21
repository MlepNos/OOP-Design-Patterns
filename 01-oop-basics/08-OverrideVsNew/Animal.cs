namespace OverrideVsNewDemo
{
    class Animal
    {
        public virtual string Speak() => "(base) ..."; // virtual -> can be overridden (polymorphic)
        public string Info() => "(base) info";         // non-virtual -> NOT polymorphic
    }

    class LoudDog : Animal
    {
        public override string Speak() => "WOOF!";     // overrides -> polymorphism works

        // `new` HIDES the base method (because base is non-virtual). Not polymorphic.
        public new string Info() => "(loud dog) info";
    }

    class Puppy : LoudDog
    {
        public override string Speak() => "yip!";      // can still override
    }

    class GuardDog : LoudDog
    {
        // `sealed override` stops further overrides down the chain
        public sealed override string Speak() => "BARK!";
    }

    class SuperGuardDog : GuardDog
    {
        // Can't override Speak (it's sealed). This HIDES it instead:
        public new string Speak() => "SUPER-BARK!";    // not polymorphic
    }
}
