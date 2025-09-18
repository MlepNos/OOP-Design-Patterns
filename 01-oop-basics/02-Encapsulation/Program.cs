using System;

namespace EncapsulationDemo
{
    class Program
    {
        static void Main()
        {
            var account = new BankAccount(openingBalance: 50m);
            Console.WriteLine($"Opening balance: {account.Balance:C}");

            var service = new BankService();
            service.PaySalary(account, 25m); // 75

            // Valid controlled update
            var ok = account.Withdraw(60m);  // true
            Console.WriteLine($"Withdraw 60 ok? {ok}. Balance: {account.Balance:C}");

            ok = account.Withdraw(100m);     // false
            Console.WriteLine($"Withdraw 100 ok? {ok}. Balance: {account.Balance:C}");

            // Uncommenting the next line will not compile, proving encapsulation:
            //account.Balance = 999m;

            account.setBalance(20m);
        }
    }
}
