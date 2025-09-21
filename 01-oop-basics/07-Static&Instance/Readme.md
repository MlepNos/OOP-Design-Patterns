Instances is static → shared count across all Counter objects.
Value is instance → each Counter has its own number.
Static ctor runs once; instance ctor runs per object.

const vs static readonly:
- const = compile-time; baked into callers.
- static readonly = runtime-initialized once; safer to change later.