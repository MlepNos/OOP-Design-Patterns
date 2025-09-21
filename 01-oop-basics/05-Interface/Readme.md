Abstract class when:
- You have a natural single family (e.g., LivingThing → Animal/Plant).
- You want to share fields/logic (Name, Eat, Sleep) and keep it in one place.
- You don’t want the base instantiated (abstract).
- You’re ok with single inheritance limitation.

Interface when:
- You’re modeling a role/capability that many unrelated types may have (IPhotosynthesize, IMove, IEngine).
- You want swappable implementations (great for testing & DI).
- You may need a class to have multiple roles at once.

Combine them:
- Use an abstract base for the family’s shared behavior and implement interfaces for cross-cutting abilities.
e.g., abstract class Animal : LivingThing, IMove, IEat.