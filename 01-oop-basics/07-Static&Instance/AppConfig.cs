using System;

namespace StaticVsInstanceDemo
{
    // STATIC CLASS: cannot be instantiated; only static members allowed
    static class AppConfig
    {
        public const string AppName = "StaticDemo";     // compile-time constant
        public static readonly Guid AppId = Guid.NewGuid(); // runtime-initialized once

        public static string Mode { get; private set; } = "dev";

        public static void SetMode(string mode)
        {
            if (string.IsNullOrWhiteSpace(mode)) throw new ArgumentException("mode required");
            Mode = mode.Trim().ToLowerInvariant();
        }
    }
}
