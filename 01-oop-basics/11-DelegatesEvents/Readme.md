## delegates (function types)

A delegate is a type-safe function pointer. It stores “a method I can call later.”
Built-ins:
 - Action<T1,..> → returns void
 - Func<T1,..,TReturn> → returns a value
 - Predicate<T> → returns bool
You can also declare your own: public delegate int MathOp(int x, int y);

You can assign methods (or lambdas) to a delegate, pass it around, and invoke it: op(2,3).

## events (Observer pattern)

An event is a restricted multicast delegate used for publish/subscribe:

- Publisher exposes event EventHandler<TEventArgs> SomethingHappened;
- Subscribers attach handlers: publisher.SomethingHappened += Handler;
- Only the publisher can raise it (invoke). Many listeners can subscribe/unsubscribe.
- This is the .NET flavor of the Observer design pattern.