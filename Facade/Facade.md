## **Facade Design Pattern in C# with Real-Time Example**

### **What is the Facade Design Pattern?**
The **Facade Design Pattern** is a structural pattern that provides a simplified interface to a complex subsystem. Instead of exposing the internal complexities of a system, a **Facade** class provides a unified and easy-to-use API for clients.

### **Key Features of the Facade Pattern:**
- Hides the complexity of the system.
- Provides a simple interface to the client.
- Improves maintainability and readability.
- Decouples the client from complex subsystems.

---

## **Real-Time Example: Online Order Processing System**
Imagine you have an **online shopping system** where multiple subsystems handle different aspects like **inventory, payment, and notifications**. Instead of making the client interact with each subsystem directly, we create a **Facade** class to provide a simple interface.

### **Step 1: Subsystems (Complex Parts)**
#### **1. Inventory System**
```csharp
public class InventoryService
{
    public bool CheckStock(string productId)
    {
        Console.WriteLine($"Checking stock for product {productId}...");
        return true; // Assume product is available
    }
}
```

#### **2. Payment Service**
```csharp
public class PaymentService
{
    public bool MakePayment(string accountNumber, double amount)
    {
        Console.WriteLine($"Processing payment of {amount} from account {accountNumber}...");
        return true; // Assume payment is successful
    }
}
```

#### **3. Notification Service**
```csharp
public class NotificationService
{
    public void SendOrderConfirmation(string email)
    {
        Console.WriteLine($"Sending order confirmation email to {email}...");
    }
}
```

---

### **Step 2: Create the Facade Class**
The **Facade** class simplifies interaction with multiple subsystems.

```csharp
public class OrderFacade
{
    private InventoryService _inventory;
    private PaymentService _payment;
    private NotificationService _notification;

    public OrderFacade()
    {
        _inventory = new InventoryService();
        _payment = new PaymentService();
        _notification = new NotificationService();
    }

    public void PlaceOrder(string productId, string accountNumber, double amount, string email)
    {
        Console.WriteLine("Placing order...");

        if (!_inventory.CheckStock(productId))
        {
            Console.WriteLine("Product is out of stock.");
            return;
        }

        if (!_payment.MakePayment(accountNumber, amount))
        {
            Console.WriteLine("Payment failed.");
            return;
        }

        _notification.SendOrderConfirmation(email);
        Console.WriteLine("Order placed successfully.");
    }
}
```

---

### **Step 3: Client Code (Using Facade)**
The client interacts with the **Facade** instead of dealing with individual subsystems.

```csharp
class Program
{
    static void Main()
    {
        OrderFacade orderFacade = new OrderFacade();

        // Place an order
        orderFacade.PlaceOrder("P123", "ACC456", 100.50, "customer@example.com");

        Console.ReadLine();
    }
}
```

---

## **Benefits of Using the Facade Pattern**
1. **Simplifies Client Interaction**  
   - The client only interacts with `OrderFacade`, instead of calling multiple services separately.

2. **Encapsulation of Complexity**  
   - Changes in subsystems do not affect the client.

3. **Improved Maintainability**  
   - If subsystems change, you only need to modify the Facade without affecting client code.

4. **Reduces Dependencies**  
   - Clients are loosely coupled with subsystems.

---

## **When to Use the Facade Pattern?**
- When you have a complex system with multiple subsystems.
- When you want to provide a **simplified API** to clients.
- When you need to **decouple** clients from subsystem implementations.
- When you want to **improve readability** and maintainability.

---

## **Conclusion**
The **Facade Pattern** is a great way to provide a simple interface to complex systems. In our **real-time example of an online order processing system**, the `OrderFacade` class hides the complexity of inventory checking, payment processing, and notification sending. This makes the system **easier to use, maintain, and extend**.