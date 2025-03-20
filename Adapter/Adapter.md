## Adapter Design Pattern in C# with a Real-Time Example

### **What is the Adapter Pattern?**
The **Adapter Pattern** is a structural design pattern that allows incompatible interfaces to work together. It acts as a bridge between two different interfaces so that they can communicate.

It is useful when you have:
1. An existing class whose interface does not match the required one.
2. A need to integrate with a third-party library or legacy system.

---

## **Real-World Example: Payment Gateway Integration**
### **Scenario:**
You are developing an e-commerce application that supports multiple payment gateways. The system currently uses a `PayPalPaymentProcessor`, but you need to integrate `StripePaymentProcessor` as well.

Both payment gateways have different method names and signatures, and you need a uniform interface to work with them.

---

### **Step 1: Define a Common Interface**
```csharp
public interface IPaymentProcessor
{
    void ProcessPayment(decimal amount);
}
```

---

### **Step 2: Implement an Existing Payment Processor (PayPal)**
```csharp
public class PayPalPaymentProcessor : IPaymentProcessor
{
    public void ProcessPayment(decimal amount)
    {
        Console.WriteLine($"Processing payment of ${amount} via PayPal.");
    }
}
```

---

### **Step 3: Create an Incompatible Payment System (Stripe)**
```csharp
public class StripePaymentProcessor
{
    public void MakePayment(decimal amount)
    {
        Console.WriteLine($"Processing payment of ${amount} via Stripe.");
    }
}
```
**Problem:**  
`StripePaymentProcessor` has a method `MakePayment(decimal amount)` instead of `ProcessPayment(decimal amount)`, so it does not match our `IPaymentProcessor` interface.

---

### **Step 4: Create an Adapter for Stripe**
We create an adapter that implements `IPaymentProcessor` and internally calls `MakePayment()` of `StripePaymentProcessor`.

```csharp
public class StripePaymentAdapter : IPaymentProcessor
{
    private readonly StripePaymentProcessor _stripePaymentProcessor;

    public StripePaymentAdapter(StripePaymentProcessor stripePaymentProcessor)
    {
        _stripePaymentProcessor = stripePaymentProcessor;
    }

    public void ProcessPayment(decimal amount)
    {
        // Call the incompatible method inside the adapter
        _stripePaymentProcessor.MakePayment(amount);
    }
}
```

---

### **Step 5: Using the Adapter**
Now, we can use both payment gateways interchangeably without modifying existing code.

```csharp
class Program
{
    static void Main(string[] args)
    {
        // Using PayPal directly
        IPaymentProcessor paypalProcessor = new PayPalPaymentProcessor();
        paypalProcessor.ProcessPayment(100);

        // Using Stripe through an Adapter
        StripePaymentProcessor stripeProcessor = new StripePaymentProcessor();
        IPaymentProcessor stripeAdapter = new StripePaymentAdapter(stripeProcessor);
        stripeAdapter.ProcessPayment(200);
    }
}
```

---

### **Output:**
```
Processing payment of $100 via PayPal.
Processing payment of $200 via Stripe.
```

---

## **Benefits of the Adapter Pattern**
✅ Allows integration of legacy or third-party classes without modifying their code.  
✅ Promotes code reusability and flexibility.  
✅ Helps achieve a consistent interface for multiple implementations.  

---

## **When to Use the Adapter Pattern?**
- When you need to make an existing class compatible with a new interface.
- When integrating with third-party or legacy systems with incompatible interfaces.
- When working with multiple libraries that provide similar functionality but have different APIs.