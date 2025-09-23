// Program.cs
using System;

namespace ExceptionsDemo
{
    class Program
    {
        static void Main()
        {
            // try/catch/finally
            var acc = new BankAccount("Ada", 100m);
            try
            {
                Console.WriteLine($"Start balance = {acc.Balance}");
                acc.Withdraw(150m); // will throw
                Console.WriteLine("This line won't run");
            }
            catch (InsufficientFundsException ex)
            {
                Console.WriteLine($"[Handled] {ex.Message}");
                // rethrow pattern (if you want caller to know): throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Unexpected] {ex}");
            }
            finally
            {
                Console.WriteLine("[finally] runs no matter what");
            }

            // throw vs return style
            Console.WriteLine($"TryWithdraw(50) -> {acc.TryWithdraw(50m)} (Balance={acc.Balance})");
            Console.WriteLine($"TryWithdraw(200) -> {acc.TryWithdraw(200m)} (Balance={acc.Balance})");

            // try/finally cleanup (or prefer using/IDisposable)
            var conn = new FakeConnection();
            try
            {
                conn.Open();
                // do work...
            }
            finally
            {
                conn.Close(); // guaranteed cleanup
            }
        }
    }
}
