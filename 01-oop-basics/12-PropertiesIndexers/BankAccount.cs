// BankAccount.cs
namespace PropertiesIndexersDemo
{
    // Shows: backing field + validation inside the setter
    class BankAccount
    {
        private decimal _balance; // backing field

        public string Owner { get; }

        public BankAccount(string owner, decimal initial = 0m)
        {
            Owner = owner;
            Balance = initial; // goes through setter (validation)
        }

        public decimal Balance
        {
            get => _balance;
            private set
            {
                if (value < 0) throw new ArgumentOutOfRangeException(nameof(Balance), "Balance cannot be negative.");
                _balance = value;
            }
        }

        public void Deposit(decimal amount)
        {
            if (amount <= 0) throw new ArgumentException("Amount must be positive.", nameof(amount));
            Balance += amount; // uses setter
        }

        public bool Withdraw(decimal amount)
        {
            if (amount <= 0) throw new ArgumentException("Amount must be positive.", nameof(amount));
            if (amount > Balance) return false;
            Balance -= amount; // uses setter
            return true;
        }

        public override string ToString() => $"{Owner}'s balance: {Balance:C}";
    }
}
