using System;

namespace DelegatesEventsDemo
{
    // A delegate is a *type-safe function pointer*
    public delegate int MathOp(int x, int y);

    static class DelegatesBasics
    {
        public static int Add(int a, int b) => a + b;
        public static int Mul(int a, int b) => a * b;

        public static void Run()
        {
            // Using our custom delegate type
            MathOp op = Add;                  // method group
            Console.WriteLine(op(2, 3));      // 5
            op = Mul;
            Console.WriteLine(op(2, 3));      // 6

            // Built-in delegates
            Action<string> log = Console.WriteLine;            // takes T, returns void
            Action<int> logInt = Console.WriteLine;
            Func<int, int, int> max = (a, b) => a > b ? a : b; // takes (T1,T2), returns TR
            Predicate<int> isEven = n => n % 2 == 0;           // returns bool

            log($"max(10,7) = {max(10, 7)}");
            log($"isEven(4) = {isEven(4)}");

            // Multicast delegates: combine many void-returning handlers
            Action pipe = () => log("first");
            pipe += () => log("second");
            pipe += () => log("third");
            pipe(); // invokes both in order


            Action pipe2 = () => logInt(op(2, 3));
            pipe2 += () => log("second");
            pipe2();
        }
    }
}
