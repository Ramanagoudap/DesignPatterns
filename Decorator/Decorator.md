The **Decorator Design Pattern** is a structural pattern used to extend the functionality of objects dynamically at runtime. It allows you to wrap objects with additional behaviors without modifying their structure.

---

## **Real-time Example: Logging in a File Processing System**
Imagine you have a file processing system that reads data from a file. You want to add logging functionality dynamically, without modifying the existing file reader class.

---

### **Step 1: Create the Component Interface**
This interface defines the common behavior for all file readers.
```csharp
public interface IFileReader
{
    void ReadFile();
}
```

---

### **Step 2: Implement the Concrete Component**
This is the base implementation that performs the actual file reading.
```csharp
public class FileReader : IFileReader
{
    public void ReadFile()
    {
        Console.WriteLine("Reading file contents...");
    }
}
```

---

### **Step 3: Create the Decorator Base Class**
The decorator class implements the same interface and holds a reference to an `IFileReader` instance.
```csharp
public class FileReaderDecorator : IFileReader
{
    protected IFileReader _fileReader;

    public FileReaderDecorator(IFileReader fileReader)
    {
        _fileReader = fileReader;
    }

    public virtual void ReadFile()
    {
        _fileReader.ReadFile();
    }
}
```

---

### **Step 4: Implement a Concrete Decorator (Logging)**
This decorator adds logging behavior before and after reading the file.
```csharp
public class LoggingFileReader : FileReaderDecorator
{
    public LoggingFileReader(IFileReader fileReader) : base(fileReader)
    {
    }

    public override void ReadFile()
    {
        Console.WriteLine("Logging: File reading started...");
        base.ReadFile();
        Console.WriteLine("Logging: File reading finished...");
    }
}
```

---

### **Step 5: Use the Decorator**
Now, let's use our decorator to wrap the `FileReader` and add logging dynamically.
```csharp
class Program
{
    static void Main(string[] args)
    {
        // Normal file reading
        IFileReader fileReader = new FileReader();
        fileReader.ReadFile();

        Console.WriteLine("\nApplying Logging Decorator...\n");

        // File reading with logging
        IFileReader loggedFileReader = new LoggingFileReader(fileReader);
        loggedFileReader.ReadFile();
    }
}
```

---

### **Output**
```
Reading file contents...

Applying Logging Decorator...

Logging: File reading started...
Reading file contents...
Logging: File reading finished...
```

---

## **When to Use the Decorator Pattern?**
1. When you need to **add responsibilities to objects dynamically** without modifying their class.
2. When **subclassing is not feasible** due to too many combinations of behaviors.
3. When you want to follow **Open-Closed Principle (OCP)**—allowing new functionality without modifying existing code.

---

### **Other Real-world Scenarios**
- **Adding encryption** to a data stream (e.g., `Stream` in .NET).
- **Adding caching** to a database query execution.
- **Adding authentication** to a web request handler.