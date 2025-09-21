using System;

namespace EqualityDemo
{
    // Record: value-based equality out of the box (by constructor parameters)
    public record PersonRec(string FirstName, string LastName, DateTime BirthDate);
}
