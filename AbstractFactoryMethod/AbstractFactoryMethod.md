### **Abstract Factory Design Pattern in C# with a Real-Time Example**

#### **What is the Abstract Factory Pattern?**
The **Abstract Factory Pattern** is a creational design pattern that provides an interface for creating families of related or dependent objects without specifying their concrete classes. It helps in maintaining the dependency inversion principle by allowing client code to be decoupled from object creation.

---

### **Real-Time Example: UI Theme Factory**
#### **Scenario:**
Suppose you're developing a cross-platform UI application that supports **Light Theme** and **Dark Theme**. Each theme has different styles for **buttons** and **textboxes**. The **Abstract Factory Pattern** can help in dynamically selecting the correct theme and its UI components.

---

### **Step-by-Step Implementation in C#**

#### **Step 1: Create Abstract Product Interfaces**
Define abstract interfaces for UI elements (`IButton` and `ITextBox`).

```csharp
// Abstract Product - Button
public interface IButton
{
    void Render();
}

// Abstract Product - TextBox
public interface ITextBox
{
    void ShowText();
}
```

---

#### **Step 2: Create Concrete Products for Light and Dark Themes**
Each concrete class represents a specific UI component under a particular theme.

```csharp
// Concrete Product - Light Theme Button
public class LightButton : IButton
{
    public void Render()
    {
        Console.WriteLine("Rendering Light Theme Button");
    }
}

// Concrete Product - Dark Theme Button
public class DarkButton : IButton
{
    public void Render()
    {
        Console.WriteLine("Rendering Dark Theme Button");
    }
}

// Concrete Product - Light Theme TextBox
public class LightTextBox : ITextBox
{
    public void ShowText()
    {
        Console.WriteLine("Displaying text in Light Theme TextBox");
    }
}

// Concrete Product - Dark Theme TextBox
public class DarkTextBox : ITextBox
{
    public void ShowText()
    {
        Console.WriteLine("Displaying text in Dark Theme TextBox");
    }
}
```

---

#### **Step 3: Create Abstract Factory**
Define an abstract factory interface to create related products.

```csharp
// Abstract Factory
public interface IUIFactory
{
    IButton CreateButton();
    ITextBox CreateTextBox();
}
```

---

#### **Step 4: Create Concrete Factories**
Implement the abstract factory to produce themed UI elements.

```csharp
// Concrete Factory - Light Theme Factory
public class LightThemeFactory : IUIFactory
{
    public IButton CreateButton()
    {
        return new LightButton();
    }

    public ITextBox CreateTextBox()
    {
        return new LightTextBox();
    }
}

// Concrete Factory - Dark Theme Factory
public class DarkThemeFactory : IUIFactory
{
    public IButton CreateButton()
    {
        return new DarkButton();
    }

    public ITextBox CreateTextBox()
    {
        return new DarkTextBox();
    }
}
```

---

#### **Step 5: Implement the Client Code**
The client uses the factory interface and remains decoupled from concrete implementations.

```csharp
public class Application
{
    private readonly IButton _button;
    private readonly ITextBox _textBox;

    public Application(IUIFactory factory)
    {
        _button = factory.CreateButton();
        _textBox = factory.CreateTextBox();
    }

    public void Run()
    {
        _button.Render();
        _textBox.ShowText();
    }
}
```

---

#### **Step 6: Testing the Implementation**
Dynamically selecting the theme at runtime.

```csharp
class Program
{
    static void Main()
    {
        Console.WriteLine("Select Theme: 1. Light  2. Dark");
        string choice = Console.ReadLine();

        IUIFactory factory = choice == "1" ? new LightThemeFactory() : new DarkThemeFactory();

        Application app = new Application(factory);
        app.Run();
    }
}
```

---

### **Output**
If the user selects **1 (Light Theme):**
```
Rendering Light Theme Button
Displaying text in Light Theme TextBox
```
If the user selects **2 (Dark Theme):**
```
Rendering Dark Theme Button
Displaying text in Dark Theme TextBox
```

---

### **Key Takeaways**
1. **Decouples object creation**: The client does not need to know the exact class names of the UI elements.
2. **Ensures consistency**: All objects created by a factory belong to the same theme (family).
3. **Scalable**: If a new theme is introduced (e.g., "Blue Theme"), we just need to create a new factory without modifying existing code.