// Program.cs
using System;

namespace PropertiesIndexersDemo
{
    class Program
    {
        static void Main()
        {
            // --- Properties basics ---
            var p = new Person("Ada", "Lovelace", age: 20)
            {
                // init-only props can also be set here (already set via ctor in this case)
            };
            Console.WriteLine(p);
            p.HaveBirthday();
            Console.WriteLine($"After birthday: {p}");

            var acct = new BankAccount("Ada", 100m);
            acct.Deposit(50m);
            Console.WriteLine(acct);
            Console.WriteLine($"Withdraw 200 success? {acct.Withdraw(200m)}");
            Console.WriteLine($"Withdraw 90 success?  {acct.Withdraw(90m)}");
            Console.WriteLine(acct);

            Console.WriteLine(new string('-', 60));

            // --- Indexer (by key) ---
            var inv = new Inventory();
            inv["Apple"] = 10;
            inv["Banana"] = inv["Banana"] + 5; // reading missing key returns 0
            Console.WriteLine($"Apples: {inv["Apple"]}, Bananas: {inv["Banana"]}");
            Console.WriteLine(inv);

            Console.WriteLine(new string('-', 60));

            // --- Indexer (by row, col) ---
            var m = new Matrix(2, 3);
            m[0, 0] = 1; m[0, 1] = 2; m[0, 2] = 3;
            m[1, 0] = 4; m[1, 1] = 5; m[1, 2] = 6;
            Console.WriteLine($"IsSquare? {m.IsSquare}");
            Console.WriteLine(m);




            /*
            var inv = new Inventory();
            inv["Apples"] = 5;          // calls the set accessor
            int qty = inv["Apples"];    // calls the get accessor (returns 5)
            int missing = inv["Pears"]; // returns 0 because key not present    
            */
        }
    }
}
