using System;

namespace EncapsulationDemo
{
    public class BankAccount
    {
        // Private backing field: cannot be touched from outside
        private decimal _balance;

        // Public, read-only property: safe way to show state
        public decimal Balance => _balance;

        public void SetBalance(decimal amount)
        {
            if (amount <= 0) throw new ArgumentException("amount must be positive.");
            _balance = amount;
        }

        public BankAccount(decimal openingBalance = 0m)
        {
            if (openingBalance < 0) throw new ArgumentException("Opening balance cannot be negative.");
            _balance = openingBalance;
        }

        public void Deposit(decimal amount)
        {
            if (amount <= 0) throw new ArgumentException("Deposit amount must be positive.");
            _balance += amount;
        }

        // Return bool instead of throwing when funds are insufficient
        public bool Withdraw(decimal amount)
        {
            if (amount <= 0) throw new ArgumentException("Withdraw amount must be positive.");
            if (amount > _balance) return false;
            _balance -= amount;
            return true;
        }
    }
}
