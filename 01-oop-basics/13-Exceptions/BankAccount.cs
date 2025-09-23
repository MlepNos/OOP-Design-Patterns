// BankAccount.cs
using System;

namespace ExceptionsDemo
{
    public class BankAccount
    {
        public string Owner { get; }
        public decimal Balance { get; private set; }

        public BankAccount(string owner, decimal initial = 0m)
        { Owner = owner; Balance = initial; }

        // Throwing version: fail fast with a custom exception
        public void Withdraw(decimal amount)
        {
            if (amount <= 0) throw new ArgumentException("Amount must be positive.", nameof(amount));
            if (Balance < amount) throw new InsufficientFundsException(amount, Balance);
            Balance -= amount;
        }

        // Returning version: return bool instead of throwing
        public bool TryWithdraw(decimal amount)
        {
            if (amount <= 0) return false;
            if (Balance < amount) return false;
            Balance -= amount;
            return true;
        }

        public void Deposit(decimal amount)
        {
            if (amount <= 0) throw new ArgumentException("Amount must be positive.");
            Balance += amount;
        }
    }
}
