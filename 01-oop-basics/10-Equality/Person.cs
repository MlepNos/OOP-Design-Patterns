using System;

namespace EqualityDemo
{
    // Immutable value-like type
    public sealed class Person : IEquatable<Person>
    {
        public string FirstName { get; }
        public string LastName  { get; }
        public DateTime BirthDate { get; }

        public Person(string first, string last, DateTime birthDate)
        {
            FirstName = first ?? throw new ArgumentNullException(nameof(first));
            LastName  = last  ?? throw new ArgumentNullException(nameof(last));
            BirthDate = birthDate;
        }

        // Strongly-typed equality
        public bool Equals(Person? other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return FirstName == other.FirstName
                && LastName  == other.LastName
                && BirthDate == other.BirthDate;
        }

        // Object equality must agree with IEquatable<Person>
        public override bool Equals(object? obj) => Equals(obj as Person);

        // Hash code must use same fields as Equals
        public override int GetHashCode() => HashCode.Combine(FirstName, LastName, BirthDate);

        // Optional: operator overloads delegate to Equals
        public static bool operator ==(Person? a, Person? b) =>
            a is null ? b is null : a.Equals(b);
        public static bool operator !=(Person? a, Person? b) => !(a == b);

        // Nice display
        public override string ToString() => $"{FirstName} {LastName} ({BirthDate:yyyy-MM-dd})";
    }
}
