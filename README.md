# 🇺🇸 **README — Reflection & Design Patterns Explained**

## 📌 Overview

This project demonstrates how **Reflection in C#** works together with common **object-oriented design patterns**, including:

* Reflection Pattern
* Dependency Injection (Constructor Injection)
* Strategy Pattern
* Simple Factory Pattern (via Reflection)

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

* `Notification`
* `IMessageService`
* `SmsService`
* `EmailService`

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

The program is *only reading* metadata — no behavior is changed yet.

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

➡ Enables *self-aware* architecture.

---

## ⭐ Why These Matter?

* Flexibility for evolving business needs
* Runtime configuration and discovery
* Reduced compile-time coupling
* Cleaner modular architecture
* Testability & maintainability
* Foundation for framework-level design

---

## 🚀 Summary

This project is a real-world demonstration of how **Reflection + Design Patterns** enable:

✔ Dynamic runtime behavior
✔ Elegant architecture
✔ Extensible systems

---

# 🇻🇳 **README — Giải thích Reflection & Design Patterns**

## 📌 Tổng quan

Project này minh hoạ cách **Reflection trong C#** hoạt động cùng với các **design pattern hướng đối tượng**, bao gồm:

* Reflection Pattern
* Dependency Injection (Constructor Injection)
* Strategy Pattern
* Simple Factory Pattern (thông qua Reflection)

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

* `Notification`
* `IMessageService`
* `SmsService`
* `EmailService`

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

* Linh hoạt
* Mở rộng tốt
* Giảm coupling
* Hỗ trợ test
* Kiến trúc rõ ràng
* Sẵn sàng cho scale

---

## 🚀 Kết luận

Project này thể hiện rõ cách **Reflection kết hợp Design Pattern** giúp:

✔ Thay đổi động tại runtime
✔ Vẫn giữ cấu trúc tốt
✔ Tăng khả năng mở rộng
