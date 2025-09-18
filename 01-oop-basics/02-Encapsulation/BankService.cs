using System;

namespace EncapsulationDemo
{
    // Example "service" that can only interact through the public API
    public class BankService
    {
        public void PaySalary(BankAccount account, decimal amount)
        {
            // This has to use Deposit; it cannot (and should not) set account.Balance directly
            account.Deposit(amount);
            Console.WriteLine($"Salary paid: {amount:C}. New balance: {account.Balance:C}");
        }
    }
}
