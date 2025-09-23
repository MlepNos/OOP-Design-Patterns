// StringExtensions.cs
using System;
using System.Text.RegularExpressions;

namespace ExtensionsDemo
{
    public static class StringExtensions
    {
        public static bool IsNullOrBlank(this string? s)
            => string.IsNullOrWhiteSpace(s);

        public static string Truncate(this string s, int max)
            => s.Length <= max ? s : s.Substring(0, Math.Max(0, max));

        public static string ToSlug(this string s)
            => Regex.Replace(s.ToLowerInvariant().Trim(), @"[^a-z0-9]+", "-").Trim('-');
    }
}
