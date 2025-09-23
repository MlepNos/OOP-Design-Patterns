// InsufficientFundsException.cs
using System;

namespace ExceptionsDemo
{
    public class InsufficientFundsException : Exception
    {
        public decimal Requested { get; }
        public decimal Available { get; }

        public InsufficientFundsException(decimal requested, decimal available)
            : base($"Insufficient funds. Requested: {requested}, Available: {available}")
        { Requested = requested; Available = available; }
    }
}
