The **Singleton** design pattern ensures that a class has only one instance and provides a global point of access to it. This is useful when exactly one object is needed to coordinate actions across a system, such as in logging, database connections, or caching.

## **Implementing Singleton in C#**
### **1. Basic Singleton Implementation**
```csharp
public class Singleton
{
    private static Singleton _instance;

    // Private constructor to prevent instantiation
    private Singleton() { }

    public static Singleton GetInstance()
    {
        if (_instance == null)
        {
            _instance = new Singleton();
        }
        return _instance;
    }
}
```
### **2. Thread-Safe Singleton (Lazy Initialization)**
```csharp
public class Singleton
{
    private static Singleton _instance;
    private static readonly object _lock = new object();

    private Singleton() { }

    public static Singleton GetInstance()
    {
        if (_instance == null)
        {
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = new Singleton();
                }
            }
        }
        return _instance;
    }
}
```
### **3. Using `Lazy<T>` (Best Practice)**
```csharp
public class Singleton
{
    private static readonly Lazy<Singleton> _instance = new Lazy<Singleton>(() => new Singleton());

    private Singleton() { }

    public static Singleton Instance => _instance.Value;
}
```
This approach ensures that the instance is created only when needed and is thread-safe by default.

---

## **Real-Time Examples of Singleton Pattern in C#**
### **1. Logging Service**
A logging service should be a singleton to ensure that all components write logs to a single source.

```csharp
public class Logger
{
    private static readonly Lazy<Logger> _instance = new Lazy<Logger>(() => new Logger());

    private Logger() { }

    public static Logger Instance => _instance.Value;

    public void Log(string message)
    {
        Console.WriteLine($"Log: {message}");
    }
}

// Usage:
Logger.Instance.Log("Application Started");
```

---

### **2. Database Connection**
A database connection should be managed as a singleton to prevent multiple unnecessary connections.

```csharp
using System.Data.SqlClient;

public class DatabaseConnection
{
    private static readonly Lazy<DatabaseConnection> _instance = new Lazy<DatabaseConnection>(() => new DatabaseConnection());
    private SqlConnection _connection;

    private DatabaseConnection()
    {
        _connection = new SqlConnection("Your_Connection_String_Here");
    }

    public static DatabaseConnection Instance => _instance.Value;

    public SqlConnection GetConnection() => _connection;
}

// Usage:
SqlConnection connection = DatabaseConnection.Instance.GetConnection();
```

---

### **3. Configuration Manager**
A singleton can be used to load configuration settings once and share them across the application.

```csharp
public class ConfigurationManager
{
    private static readonly Lazy<ConfigurationManager> _instance = new Lazy<ConfigurationManager>(() => new ConfigurationManager());

    public Dictionary<string, string> Settings { get; private set; }

    private ConfigurationManager()
    {
        // Simulating loading from a config file
        Settings = new Dictionary<string, string>
        {
            { "AppName", "My Application" },
            { "Version", "1.0.0" }
        };
    }

    public static ConfigurationManager Instance => _instance.Value;
}

// Usage:
string appName = ConfigurationManager.Instance.Settings["AppName"];
```

---

## **When to Use Singleton?**
✅ When you need a single instance for global state management.  
✅ When you need a shared resource like logging, caching, or a configuration manager.  
✅ When object creation is expensive (e.g., database connections).  

🚫 **Avoid Singleton** when:  
- It introduces **global state** and makes testing difficult.  
- It leads to **hidden dependencies** and tight coupling.  
- Multiple instances are actually required for scalability (e.g., in microservices).