# Strategy Pattern

The Strategy pattern (aka Policy) defines a family of interchangeable algorithms (strategies), encapsulates each one, and makes them interchangeable at runtime. It lets the algorithm vary independently from clients that use it.

## Intent
- Encapsulate algorithms inside separate strategy objects.
- Make algorithms interchangeable without changing the client code.
- Avoid large conditional statements selecting behavior.

## Participants
- Strategy (interface): declares an operation common to all supported strategies.
- ConcreteStrategy: implements the Strategy interface with a specific algorithm.
- Context: is configured with a Strategy object and delegates work to it.

## Example (C#)
```csharp
public interface IStrategy
{
	int Execute(int a, int b);
}

public class AddStrategy : IStrategy
{
	public int Execute(int a, int b) => a + b;
}

public class MultiplyStrategy : IStrategy
{
	public int Execute(int a, int b) => a * b;
}

public class Context
{
	private IStrategy _strategy;

	public Context(IStrategy strategy)
	{
		_strategy = strategy;
	}

	public void SetStrategy(IStrategy strategy) => _strategy = strategy;

	public int ExecuteStrategy(int a, int b) => _strategy.Execute(a, b);
}
```

Usage: create a Context with a chosen ConcreteStrategy and call ExecuteStrategy. You can swap strategies at runtime via SetStrategy.

## When to use
- When you have multiple variants of an algorithm and want to choose one at runtime.
- When you want to avoid conditional logic that selects behavior.
- When algorithms share a common interface but differ in implementation.

## Benefits
- Single Responsibility: algorithms are isolated in separate classes.
- Open/Closed: new strategies can be added without modifying clients.
- Runtime switching of behavior.

## Drawbacks
- Increased number of small classes.
- Clients must be aware of different strategies or a factory to select them.

## Related patterns
- Strategy vs State: both use similar structure; State changes object behavior by changing internal state while Strategy usually is chosen by the client.
- Template Method: Strategy delegates entire algorithm to strategies, Template Method varies steps by subclassing.

