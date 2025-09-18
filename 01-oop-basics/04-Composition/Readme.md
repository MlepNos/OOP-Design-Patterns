# 05 – Composition (C# OOP Basics)

**Goal:** Understand *composition* (a “has-a” relationship) and how to build bigger objects by combining smaller, focused parts.

> **Composition**: `Car` **has an** `Engine` and **has** `Wheel`s.  
> **Inheritance**: `Dog` **is an** `Animal`.

---

## Why composition?

- **Encapsulation & clarity** – each class owns just its concern (`Engine` handles RPM; `Wheel` handles pressure; `Car` orchestrates).
- **Reuse** – the same `Engine` or `Wheel` could be reused by different vehicles.
- **Flexibility** – you can swap parts later (e.g., `ElectricEngine` vs `CombustionEngine`).
- **Testability** – test parts in isolation; test `Car` behavior by checking how it delegates.

> Heuristic: **Prefer composition over inheritance** when you’re assembling behavior from parts and don’t need a type hierarchy.

---

## Folder layout


---

## What each class does

### `Engine`
- **State:** `Running`, `Rpm`
- **Behavior:** `Start()`, `Stop()`, `Rev(int delta)`, `Status()`
- **Notes:** Keeps engine-specific rules (idle RPM, cannot rev when stopped, etc.)

### `Wheel`
- **State:** `PressurePsi`
- **Behavior:** `Inflate(double psi)`, `Deflate(double psi)`, `Status()`
- **Notes:** Knows nothing about the engine; it only manages tire pressure.

### `Car`
- **Has:** one `Engine`, four `Wheel`s
- **State:** `OdometerKm`
- **Behavior:** 
  - `TurnKeyOn()` / `TurnKeyOff()` → delegate to engine
  - `Drive(double km)` → checks engine running, revs a bit, updates odometer
  - `InflateAll(double psi)` → delegates to each wheel
  - `Report()` → aggregates component statuses into one string
- **Notes:** The **coordinator** that ties parts together (delegation).

---

## Quick mental model

