# Equality in C# — `Equals`, `GetHashCode`, `ToString`, `==`/`!=`, and `IEquatable<T>`

A practical, beginner-friendly guide to **value equality** vs **reference equality**, how to implement them correctly, and common pitfalls.

---

## TL;DR

- **Reference equality** = same object in memory → `ReferenceEquals(a, b)`
- **Value (logical) equality** = same data/meaning → implement `Equals` (+ `GetHashCode`)
- If you override `Equals`, you **must** also override `GetHashCode` using the **same fields**
- Prefer implementing `IEquatable<T>` for performance and correctness
- If you overload `==`/`!=`, make them match `Equals`
- For data types, consider **records** — they give value equality automatically

---

## 1) Two kinds of “equal”

```csharp
var a = new StringBuilder("hi");
var b = new StringBuilder("hi");

object.ReferenceEquals(a, b); // false (different objects)
a.Equals(b);                  // true? Only if the type *implements* value equality
```

Reference equality: default for classes (unless overridden)
Value equality: you define what “equal” means (same fields) by implementing Equals

## 2) The equality contract (what Equals must obey)
## TL;DR

For any x, y, z:
- Reflexive: x.Equals(x) is true
- Symmetric: x.Equals(y) == y.Equals(x)
- Transitive: if x==y and y==z ⇒ x==z
- Consistent: result doesn’t change unless data changes
- Null: x.Equals(null) is false

If two objects are equal, they must return the same GetHashCode()


## 3) Safe template for a value-equality class
```csharp

using System;

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

    // 1) Typed equality (fast path for generics)
    public bool Equals(Person? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;

        return FirstName == other.FirstName
            && LastName  == other.LastName
            && BirthDate == other.BirthDate;
    }

    // 2) Object equality delegates to typed equality
    public override bool Equals(object? obj) => Equals(obj as Person);

    // 3) Hash code uses the SAME fields as Equals
    public override int GetHashCode() => HashCode.Combine(FirstName, LastName, BirthDate);

    // 4) Operators mirror Equals
    public static bool operator ==(Person? a, Person? b) =>
        a is null ? b is null : a.Equals(b);
    public static bool operator !=(Person? a, Person? b) => !(a == b);

    // 5) Nice display (optional but helpful)
    public override string ToString() => $"{FirstName} {LastName} ({BirthDate:yyyy-MM-dd})";
}
```

## TL;DR
Why this template?

- IEquatable<T> avoids boxing and speeds up comparisons in HashSet<T>, Dictionary<TKey, TValue>, LINQ, etc.
- Equals(object) is still required (polymorphism)
- GetHashCode() must use the same fields as Equals
- Operator overloads keep ==/!= consistent with Equals



## 4) Hash-based collections depend on equality
```csharp
var p1 = new Person("Ada", "Lovelace", new DateTime(1815,12,10));
var p2 = new Person("Ada", "Lovelace", new DateTime(1815,12,10));

var set = new HashSet<Person> { p1, p2 };
Console.WriteLine(set.Count); // 1 — p2 treated as duplicate

var dict = new Dictionary<Person, string> { [p1] = "first" };
dict[p2] = "second";          // replaces same logical key
Console.WriteLine(dict[p1]);  // "second"

```

If you override Equals but not GetHashCode, these break.


## 5) Records: value equality for free

## TL;DR
- value-based equality (compares contents, not references)
- a nice ToString()
- immutability by default (via init setters)
- easy copy-with-changes syntax (with)
- optional deconstruction (var (x, y) = point;)
- It’s perfect for data carriers and domain value objects (e.g., Money, Email, Point, Person).


```csharp
public record PersonRec(string FirstName, string LastName, DateTime BirthDate);

var r1 = new PersonRec("Ada", "Lovelace", new DateTime(1815,12,10));
var r2 = new PersonRec("Ada", "Lovelace", new DateTime(1815,12,10));

Console.WriteLine(r1 == r2);  // true (records compare by value)
Console.WriteLine(r1);        // PersonRec { FirstName = Ada, LastName = Lovelace, BirthDate = 1815-12-10 }


```

Use records for “data carrier” types where value semantics are desired.


## Record superpowers you get for free

## 1) Copy with changes (with)

```csharp  

var p1 = new PersonRec("Ada", "Lovelace", new DateTime(1815,12,10));
var p2 = p1 with { Last = "Byron" }; // p1 unchanged; p2 is a copy with one change


```

## 2) Immutability by default

```csharp  

p1.First = "Grace"; // ❌ cannot set (init-only)


```

## 3) Deconstruction

```csharp  

var (first, last, birth) = p2;


```

## 4) Inheritance (record → record)

```csharp  

public record Animal(string Name);
public record Bird(string Name, bool CanFly) : Animal(Name);


```

## When a class is better
- You need identity (two objects with same data are not “the same”).
- You need mutable state that changes often.
- You want to participate in non-record inheritance hierarchies.