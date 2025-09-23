// FakeConnection.cs
using System;

namespace ExceptionsDemo
{
    // Just to show try/finally cleanup
    public sealed class FakeConnection : IDisposable
    {
        public bool Opened { get; private set; }
        public void Open()  { Opened = true;  Console.WriteLine("[conn] opened"); }
        public void Close() { Opened = false; Console.WriteLine("[conn] closed"); }
        public void Dispose() => Close();
    }
}
