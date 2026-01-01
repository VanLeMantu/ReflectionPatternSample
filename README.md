# 🇺🇸 **README — Reflection & Design Patterns Explained**

## 📌 Overview

This project demonstrates how **Reflection in C#** works together with common **object-oriented design patterns**, including:

- Reflection Pattern
- Dependency Injection (Constructor Injection)
- Strategy Pattern
- Simple Factory Pattern (via Reflection)

The goal is to show how reflection enables dynamic behavior at runtime, while design patterns provide structure and maintainability.

---

## 🧠 Reflection Pattern — Core Idea

Reflection allows the program to:

✔ Inspect types at runtime
✔ Read constructors and parameters
✔ Dynamically create instances
✔ Invoke methods without compile-time knowledge

This happens inside the `Create<T>()` method.

---

## 🏗 Meta-Level vs Base-Level

### **Base-Level (Application Logic)**

These are your normal business-logic classes:

- `Notification`
- `IMessageService`
- `SmsService`
- `EmailService`

They define **what the program does**.

---

### **Meta-Level (Reflection Logic)**

This is the code that **inspects and manipulates** the base-level:

```csharp
var type = typeof(T);
var ctor = type.GetConstructors().First();
var parameters = ctor.GetParameters()
    .Select(p => Activator.CreateInstance(typeof(SmsService)))
    .ToArray();
return (T)ctor.Invoke(parameters);
```

Here the program treats its own structure as **data**.

---

## 🔍 Introspection vs 🛠 Intercession

### **Introspection — observing structure**

```csharp
typeof(T)
GetConstructors()
GetParameters()
```

The program is _only reading_ metadata — no behavior is changed yet.

---

### **Intercession — changing behavior**

```csharp
Activator.CreateInstance(...)
ctor.Invoke(...)
```

Now the program **acts on that metadata**, dynamically creating and wiring dependencies at runtime.

---

## 🎯 Design Patterns in This Project

### ✅ **Strategy Pattern**

`IMessageService` defines behavior.
`SmsService` and `EmailService` implement it.
`Notification` uses the interface — not a concrete type.

➡ Behavior can change without modifying `Notification`.

---

### ✅ **Dependency Injection (Constructor Injection)**

`Notification` receives its dependency via constructor:

```csharp
Notification(IMessageService service)
```

➡ Improves testability & decoupling.

---

### ✅ **Factory Pattern via Reflection**

`Create<T>()` acts as a factory, dynamically creating objects instead of using `new`.

➡ Useful for plugin systems & extensibility.

---

### ✅ **Reflection Pattern**

The program uses metadata to drive runtime behavior instead of compile-time wiring.

➡ Enables _self-aware_ architecture.

---

## ⭐ Why These Matter?

- Flexibility for evolving business needs
- Runtime configuration and discovery
- Reduced compile-time coupling
- Cleaner modular architecture
- Testability & maintainability
- Foundation for framework-level design

---

## 🚀 Summary

This project is a real-world demonstration of how **Reflection + Design Patterns** enable:

✔ Dynamic runtime behavior
✔ Elegant architecture
✔ Extensible systems

---

# 🇺🇸 **README — Applying SOLID & OOP Principles**

## 📌 Introduction

This project is a practical showcase of how **SOLID principles and fundamental OOP concepts** can be naturally embedded into everyday application code. Instead of focusing on runtime mechanics, the codebase emphasizes **clean structure, clear responsibilities, and sustainable architecture**.

---

## 🧠 SOLID Principles Demonstrated

### **1. Single Responsibility Principle (SRP)**

Each type is responsible for only one area of concern. This prevents unrelated logic from becoming tangled together, reducing maintenance complexity and improving readability.

---

### **2. Open/Closed Principle (OCP)**

The system is structured so that behavior can be extended by introducing new components — rather than rewriting existing ones. This reduces modification risk while still supporting growth.

```csharp
public interface IMessageService
{
    void Send(string msg);
}
```

---

### **3. Liskov Substitution Principle (LSP)**

Any implementation of the shared contract can replace another without breaking expected behavior — ensuring true, reliable polymorphism.

```csharp
public class SmsService : IMessageService
{
    public void Send(string msg) { /* ... */ }
}
```

---

### **4. Interface Segregation Principle (ISP)**

Interfaces are intentionally compact, so consumers only depend on what they actually use — improving clarity and lowering coupling.

```csharp
public interface IMessageService
{
    void Send(string msg);
}
```

---

### **5. Dependency Inversion Principle (DIP)**

High-level logic is aligned toward abstractions rather than concrete implementations. This makes dependencies replaceable, test-friendly, and evolution-ready.

```csharp
public class Notification
{
    private readonly IMessageService _service;
    public Notification(IMessageService service)
    {
        _service = service;
    }
}
```

---

## 🎯 Core OOP Concepts Reflected

- **Encapsulation** — internal behavior is hidden within service classes
- **Abstraction** — contracts express shared behavior cleanly
- **Polymorphism** — behavior varies depending on supplied implementations
- **DRY** — shared logic is centralized instead of duplicated

```csharp
IMessageService service = new SmsService();
Notification notification = new Notification(service);
```

---

## 📊 Summary Table

| Principle     | How It Appears in Code                      |
| ------------- | ------------------------------------------- |
| SRP           | One purpose per class                       |
| OCP           | New message services added safely           |
| LSP           | Implementations swap without breaking logic |
| ISP           | Small, focused interfaces                   |
| DIP           | Logic depends on abstractions               |
| Encapsulation | Logic hidden inside services                |
| Abstraction   | Shared contracts                            |
| Polymorphism  | Runtime-selectable behavior                 |
| DRY           | Centralized notification handling           |

---

## 🌟 Why This Matters

A codebase shaped by these principles becomes:

- easier to reason about
- safer to evolve
- friendlier for new contributors
- more resilient to change

Ultimately supporting **long-term software quality and scalability.**

---

# 🇻🇳 **README — Giải thích Reflection & Design Patterns**

## 📌 Tổng quan

Project này minh hoạ cách **Reflection trong C#** hoạt động cùng với các **design pattern hướng đối tượng**, bao gồm:

- Reflection Pattern
- Dependency Injection (Constructor Injection)
- Strategy Pattern
- Simple Factory Pattern (thông qua Reflection)

Mục tiêu là giúp bạn thấy rằng reflection cho phép chương trình thay đổi động tại runtime, trong khi design pattern giữ kiến trúc gọn gàng và dễ bảo trì.

---

## 🧠 Reflection Pattern — Ý tưởng cốt lõi

Reflection cho phép chương trình:

✔ Kiểm tra type tại runtime
✔ Đọc constructor và tham số
✔ Tạo instance động
✔ Gọi method mà không cần biết trước kiểu tại compile-time

Tất cả xảy ra trong hàm `Create<T>()`.

---

## 🏗 Meta-Level và Base-Level

### **Base-Level (Logic ứng dụng)**

Bao gồm:

- `Notification`
- `IMessageService`
- `SmsService`
- `EmailService`

Chúng định nghĩa **chương trình làm gì**.

---

### **Meta-Level (Reflection logic)**

Đây là phần code **quan sát và thao tác** trên base-level:

```csharp
var type = typeof(T);
var ctor = type.GetConstructors().First();
var parameters = ctor.GetParameters()
    .Select(p => Activator.CreateInstance(typeof(SmsService)))
    .ToArray();
return (T)ctor.Invoke(parameters);
```

Tức là chương trình **xem cấu trúc của chính nó như dữ liệu**.

---

## 🔍 Introspection vs 🛠 Intercession

### **Introspection — chỉ quan sát**

```csharp
typeof(T)
GetConstructors()
GetParameters()
```

Chỉ đọc metadata — **chưa thay đổi hành vi**.

---

### **Intercession — can thiệp thay đổi hành vi**

```csharp
Activator.CreateInstance(...)
ctor.Invoke(...)
```

Lúc này chương trình **thay đổi cách nó chạy tại runtime**.

---

## 🎯 Các Design Pattern trong project

### ✅ **Strategy Pattern**

`IMessageService` là chiến lược.
`SmsService`, `EmailService` là các chiến lược cụ thể.
`Notification` chỉ biết interface — không biết implementation.

➡ Có thể thay đổi hành vi mà không sửa `Notification`.

---

### ✅ **Dependency Injection**

Constructor nhận dependency:

```csharp
Notification(IMessageService service)
```

➡ Dễ test — giảm phụ thuộc.

---

### ✅ **Factory Pattern qua Reflection**

`Create<T>()` đóng vai trò factory.

➡ Phù hợp kiến trúc plugin.

---

### ✅ **Reflection Pattern**

Hệ thống dùng metadata để điều khiển runtime.

➡ Hướng tới hệ thống “tự nhận thức”.

---

## ⭐ Vì sao quan trọng?

- Linh hoạt
- Mở rộng tốt
- Giảm coupling
- Hỗ trợ test
- Kiến trúc rõ ràng
- Sẵn sàng cho scale

---

# 🇻🇳 **README — Ứng dụng SOLID & Nguyên Lý Lập Trình Hướng Đối Tượng**

## 📌 Giới thiệu

Project này là ví dụ thực tế về cách **SOLID và các khái niệm OOP cốt lõi** có thể được áp dụng tự nhiên trong code hằng ngày. Thay vì tập trung vào cơ chế runtime, cấu trúc code hướng đến **tính rõ ràng, tách bạch trách nhiệm và kiến trúc bền vững**.

---

## 🧠 Các nguyên tắc SOLID được áp dụng

### **1. Single Responsibility Principle (SRP)**

Mỗi class chỉ đảm nhiệm **một vai trò duy nhất**, tránh việc gom nhiều logic không liên quan vào cùng một nơi.

---

### **2. Open/Closed Principle (OCP)**

Hệ thống cho phép **mở rộng bằng cách thêm code mới**, thay vì sửa code cũ — nhờ đó giảm rủi ro phát sinh lỗi.

```csharp
public interface IMessageService
{
    void Send(string msg);
}
```

---

### **3. Liskov Substitution Principle (LSP)**

Mọi class triển khai interface đều có thể thay thế cho nhau mà hệ thống vẫn hoạt động đúng.

```csharp
public class SmsService : IMessageService
{
    public void Send(string msg) { /* ... */ }
}
```

---

### **4. Interface Segregation Principle (ISP)**

Interface được thiết kế **ngắn gọn và đúng mục đích**, không ép người dùng phải implement những chức năng không cần.

```csharp
public interface IMessageService
{
    void Send(string msg);
}
```

---

### **5. Dependency Inversion Principle (DIP)**

Logic cốt lõi phụ thuộc vào **abstraction thay vì concrete class**, giúp hệ thống linh hoạt và dễ test.

```csharp
public class Notification
{
    private readonly IMessageService _service;
    public Notification(IMessageService service)
    {
        _service = service;
    }
}
```

---

## 🎯 Các đặc tính OOP nổi bật

- **Encapsulation** — nội dung xử lý được giấu trong class service
- **Abstraction** — hành vi chung được mô tả bằng interface
- **Polymorphism** — hành vi cụ thể phụ thuộc implementation được truyền vào
- **DRY** — logic chung chỉ tồn tại một nơi duy nhất

```csharp
IMessageService service = new SmsService();
Notification notification = new Notification(service);
```

---

## 📊 Bảng tóm tắt

| Nguyên tắc    | Ý nghĩa trong code                                  |
| ------------- | --------------------------------------------------- |
| SRP           | Mỗi class — một nhiệm vụ                            |
| OCP           | Thêm loại service mới mà không sửa code cũ          |
| LSP           | Thay thế implementation không làm hỏng chương trình |
| ISP           | Interface gọn và đúng chức năng                     |
| DIP           | Phụ thuộc abstraction                               |
| Encapsulation | Giấu logic bên trong class                          |
| Abstraction   | Dùng interface chung                                |
| Polymorphism  | Thay đổi hành vi tại runtime                        |
| DRY           | Không lặp lại logic                                 |

---

## 🌟 Lợi ích

Khi tuân thủ các nguyên tắc này, hệ thống sẽ:

- dễ đọc — dễ hiểu
- dễ mở rộng — ít rủi ro
- phù hợp phát triển lâu dài
- hỗ trợ test tốt hơn
