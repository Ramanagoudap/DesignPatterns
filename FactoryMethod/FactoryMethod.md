The **Factory Method** is a **creational design pattern** that provides an interface for creating objects but allows subclasses to alter the type of objects that will be created. It helps in achieving **loose coupling** and **abstraction** by delegating the instantiation of objects to a method instead of calling the constructor directly.

---

## **Real-Time Example: Logger System**
### **Scenario:**
Suppose we have a **Logger System** where we need different types of loggers (e.g., **File Logger, Database Logger, and Console Logger**). Instead of directly instantiating objects using `new`, we use a **Factory Method** to create appropriate logger instances dynamically.

---

### **Step 1: Define the Logger Interface**
```csharp
public interface ILogger
{
    void Log(string message);
}
```

---

### **Step 2: Implement Concrete Loggers**
```csharp
public class FileLogger : ILogger
{
    public void Log(string message)
    {
        Console.WriteLine($"Logging to File: {message}");
    }
}

public class DatabaseLogger : ILogger
{
    public void Log(string message)
    {
        Console.WriteLine($"Logging to Database: {message}");
    }
}

public class ConsoleLogger : ILogger
{
    public void Log(string message)
    {
        Console.WriteLine($"Logging to Console: {message}");
    }
}
```

---

### **Step 3: Create the Logger Factory**
```csharp
public static class LoggerFactory
{
    public static ILogger GetLogger(string loggerType)
    {
        return loggerType.ToLower() switch
        {
            "file" => new FileLogger(),
            "database" => new DatabaseLogger(),
            "console" => new ConsoleLogger(),
            _ => throw new ArgumentException("Invalid Logger Type")
        };
    }
}
```

---

### **Step 4: Use the Factory Method in the Application**
```csharp
class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter Logger Type (File/Database/Console): ");
        string loggerType = Console.ReadLine();

        ILogger logger = LoggerFactory.GetLogger(loggerType);
        logger.Log("Factory Method Pattern Example");
    }
}
```

---

## **Advantages of Factory Method Pattern**
1. **Encapsulation of Object Creation**: The client code doesn't need to know about the instantiation logic.
2. **Loose Coupling**: The client code depends on the interface, not concrete classes.
3. **Easy Maintenance**: Adding new loggers requires minimal changes.

---

## **When to Use Factory Method?**
- When the exact type of object to be created is determined at runtime.
- When we want to **decouple object creation** from the main business logic.
- When the object creation process is complex and involves multiple steps.