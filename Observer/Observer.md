The **Observer Design Pattern** is a behavioral pattern where an object (the **subject**) maintains a list of its dependents (the **observers**) and notifies them of any state changes, typically by calling one of their methods.

### **Real-Time Example: Stock Market Notification System**
Let’s say we have a stock market system where investors (observers) want to be notified whenever the stock price changes.

---

## **Implementation in C#**

### **Step 1: Create the Observer Interface**
Each observer (subscriber) must implement this interface.
```csharp
public interface IInvestor
{
    void Update(string stockSymbol, double price);
}
```

---

### **Step 2: Create the Subject (Stock)**
The subject maintains a list of observers and notifies them when its state (stock price) changes.

```csharp
using System;
using System.Collections.Generic;

public class Stock
{
    private readonly List<IInvestor> _investors = new();
    private string _symbol;
    private double _price;

    public Stock(string symbol, double price)
    {
        _symbol = symbol;
        _price = price;
    }

    public void Attach(IInvestor investor)
    {
        _investors.Add(investor);
    }

    public void Detach(IInvestor investor)
    {
        _investors.Remove(investor);
    }

    public void Notify()
    {
        foreach (var investor in _investors)
        {
            investor.Update(_symbol, _price);
        }
    }

    public double Price
    {
        get => _price;
        set
        {
            if (_price != value)
            {
                _price = value;
                Notify();  // Notify all observers when price changes
            }
        }
    }
}
```

---

### **Step 3: Create Concrete Observers (Investors)**
```csharp
public class Investor : IInvestor
{
    private string _name;

    public Investor(string name)
    {
        _name = name;
    }

    public void Update(string stockSymbol, double price)
    {
        Console.WriteLine($"Investor {_name} notified: {stockSymbol} new price is {price:C}");
    }
}
```

---

### **Step 4: Test the Observer Pattern**
```csharp
class Program
{
    static void Main()
    {
        // Create stock
        Stock googleStock = new Stock("GOOGL", 1500);

        // Create investors (observers)
        Investor investor1 = new Investor("Alice");
        Investor investor2 = new Investor("Bob");

        // Attach investors to the stock
        googleStock.Attach(investor1);
        googleStock.Attach(investor2);

        // Change stock price (this triggers notifications)
        googleStock.Price = 1520; 
        googleStock.Price = 1535; 

        // Detach an investor and change price again
        googleStock.Detach(investor1);
        googleStock.Price = 1550; 
    }
}
```

---

### **Output**
```
Investor Alice notified: GOOGL new price is $1,520.00
Investor Bob notified: GOOGL new price is $1,520.00
Investor Alice notified: GOOGL new price is $1,535.00
Investor Bob notified: GOOGL new price is $1,535.00
Investor Bob notified: GOOGL new price is $1,550.00
```

---

## **Key Takeaways**
- The **Stock** class (subject) maintains a list of **Investors** (observers).
- When the stock price changes, all observers are notified.
- Observers can be dynamically added or removed.

This pattern is useful in event-driven architectures like UI event listeners, logging systems, and real-time notifications.