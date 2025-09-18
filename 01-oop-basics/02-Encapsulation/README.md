# Encapsulation (C#) – Tiny Demo

**What is Encapsulation?**  
Keep internal state **private** and expose it safely via **methods** or **properties** so the object can't be put into an invalid state.

### Key ideas in this example
- `BankAccount` keeps `_balance` private.
- You **cannot** modify the balance directly from outside.
- `Deposit` and `Withdraw` validate inputs.
- `Balance` is a read-only property so you can *see* it but not randomly change it.
- `BankService` uses the public methods — it can't cheat and change private fields.

### Run
```bash
dotnet run
```

### Try
- Change deposit/withdraw amounts
- Uncomment the line that tries to set `Balance` directly (it won't compile)
- Add a rule (e.g., block withdrawals below $5)
