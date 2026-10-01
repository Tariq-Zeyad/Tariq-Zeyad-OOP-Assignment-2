# Simulation Academy — .NET Diploma Cycle 1

This repository contains my work for **Simulation Academy .NET Diploma — Cycle 1**.

The main focus of this cycle was to practice writing cleaner and more maintainable C# code through:

* Single Responsibility Principle (SRP)
* Creational Design Patterns
* Inheritance and Polymorphism
* Encapsulation and validation
* Sliding Window algorithm
* Git and GitHub workflow

The goal was not only to make the code work, but also to understand **why each design decision is useful** and how these concepts can be applied in real projects.

---

## Repository Structure

```text
SRP, Patterns/
│
├── README.md
│
├── SRP/
│   ├── Responsibilities.md
│   │
│   └── src/
│       ├── SrpLab/
│       │   ├── Ward/
│       │   ├── Warehouse/
│       │   ├── Support/
│       │   ├── Billing/
│       │   ├── Loan/
│       │   ├── Kitchen/
│       │   ├── Grades/
│       │   ├── Enrollment/
│       │   ├── Checkout/
│       │   └── Appointments/
│       │
│       └── SrpLab.Runner/
│           └── Program.cs
│
├── DesignPatterns/
│   ├── linked.md
│   │
│   └── src/
│       ├── PatternsLab/
│       │   ├── BuilderDesign/
│       │   ├── PrototypeDesign/
│       │   └── SingletonDesign/
│       │
│       └── PatternsLab.Runner/
│           └── Program.cs
│
├── Inheritance/
│   ├── ClassDiagram.png
│   │
│   └── src/
│       ├── Person.cs
│       ├── Member.cs
│       ├── StudentMember.cs
│       ├── PremiumMember.cs
│       ├── Staff.cs
│       ├── Librarian.cs
│       ├── HeadLibrarian.cs
│       ├── Shelver.cs
│       ├── LibraryItem.cs
│       ├── Book.cs
│       ├── DVD.cs
│       ├── Magazine.cs
│       ├── Loan.cs
│       ├── LoanStatus.cs
│       └── Program.cs
│
└── LeetCode/
    └── 1456_MaxVowelsInSubstring/
        ├── Solution.cs
        ├── leetcode.md
        └── accepted_screenshot.png
```

---

# 1. SRP Refactoring

## Objective

The first part focused on the **Single Responsibility Principle**.

The original classes intentionally contained multiple responsibilities. The task was to identify those responsibilities and separate them into focused components without changing the expected behavior.

### What is SRP?

The Single Responsibility Principle means that a class should have **one reason to change**.

A class should not be responsible for unrelated concerns such as:

* business logic
* database access
* formatting
* notifications
* validation
* calculations

all at the same time.

## Refactoring Approach

The project contains several intentionally problematic examples, including:

* Ward management
* Warehouse operations
* Customer support
* Loan processing
* Course enrollment
* Kitchen tickets
* Billing
* Grades
* Checkout
* Appointments

Each example was analyzed to identify the different responsibilities inside the original class.

The responsibilities were documented in:

```text
SRP/Responsibilities.md
```

The refactored implementation is inside:

```text
SRP/src/SrpLab/
```

A separate runner project was used to verify that the refactored classes still behave correctly:

```text
SRP/src/SrpLab.Runner/
```

## Verification

The project builds successfully with:

```powershell
dotnet build .\SRP\src\SrpLab.Runner\SrpLab.Runner.csproj
```

It can be executed with:

```powershell
dotnet run --project .\SRP\src\SrpLab.Runner\SrpLab.Runner.csproj
```

The runner demonstrates the main behaviors after refactoring.

---

# 2. Creational Design Patterns

The second part focused on three creational design patterns:

1. Singleton
2. Prototype
3. Builder

The goal was to understand the problem each pattern solves and implement it in C# rather than simply copying a pattern structure.

---

## 2.1 Singleton Pattern

### Problem

Some applications need exactly one shared instance of a service or configuration object.

For example, application configuration should not be loaded repeatedly from disk whenever another part of the application needs it.

### Implementation

The `AppConfig` class provides a single shared configuration instance.

The implementation ensures:

* only one instance exists
* external code cannot create another instance
* configuration is loaded only once
* the same values are visible to different services
* the implementation is thread-safe

The runner also verifies that the same instance is being used.

One of the important checks is equivalent to:

```csharp
ReferenceEquals(config1, config2)
```

which confirms that both references point to the same object.

### Demonstrated behavior

The runner demonstrates:

```text
[AppConfig] Loading settings from disk... (load #1)
```

The important point is that the configuration is loaded once rather than once per consumer.

---

# 2.2 Prototype Pattern

## Problem

Creating a complex object from scratch can sometimes be expensive.

The Prototype pattern solves this by allowing an existing object to be copied instead of rebuilding it every time.

In the lab, enemy objects contain model data and other state that should be copied efficiently.

### Prototype approach

Instead of repeatedly creating an enemy and reloading its model, an existing enemy can be cloned.

The implementation also considers the difference between:

### Shallow Copy

A shallow copy duplicates the outer object but may keep references to the same nested objects.

For example:

```text
Enemy A
 └── Weapon ──┐
              │
Enemy B       ┘
```

Both enemies may reference the same weapon instance.

### Deep Copy

A deep copy creates independent nested objects:

```text
Enemy A
 └── Weapon A

Enemy B
 └── Weapon B
```

Changes to one object do not unintentionally affect the other.

The implementation makes sure that the required private model data and nested state are copied appropriately.

---

# 2.3 Builder Pattern

## Problem

`CourseRegistration` originally required many constructor parameters.

Long constructors make code harder to read and increase the chance of passing arguments in the wrong order.

For example:

```csharp
new CourseRegistration(
    studentEmail,
    courseCode,
    accessMode,
    groupCode,
    discountCode,
    whatsappEnabled,
    emailWelcome,
    mentorNote,
    startDate);
```

This becomes difficult to understand as the number of options grows.

## Builder Solution

The Builder pattern allows the object to be created step by step using meaningful method names.

The builder separates:

* required information
* optional information
* validation
* final object creation

The design also handles different registration types.

For example:

* `LiveGroup` requires a group code.
* `VideosOnly` must not have a group code.

The `Build()` method performs the final validation before creating the registration object.

### Example result

The runner demonstrates the created registration and prints values such as:

```text
Student: ahmad@gmail.com
Course: CS101
Access Mode: Online
Group: G1
Discount: DISC10
WhatsApp: True
Email Welcome: True
Mentor Note: Student prefers evening
Start Date: 01/10/2026
```

---

# 3. LinkedIn Posts

As part of the Design Patterns section, three LinkedIn posts were prepared.

The posts explain the practical lessons from:

* Singleton
* Prototype
* Builder

The posts focus on:

* the problem
* the solution
* what changed in the lab
* when the pattern can be useful
* important limitations or caveats

They are stored in:

```text
DesignPatterns/linked.md
```

The file contains the required public links.

---

# 4. Library System — Inheritance & Polymorphism

The third major part is a small Library System designed around **inheritance, encapsulation, polymorphism, and business rules**.

The UML/class diagram was created before implementing the classes and is stored here:

```text
Inheritance/ClassDiagram.png
```

The system models:

* People
* Members
* Staff
* Library items
* Loans

---

## 4.1 Person Hierarchy

`Person` contains the common identity information:

```text
Person
├── Member
│   ├── StudentMember
│   └── PremiumMember
│
└── Staff
    ├── Librarian
    ├── Shelver
    └── HeadLibrarian
```

The common properties include:

* ID
* Full Name
* Phone

These values are read-only after construction.

`Person` itself is intentionally not directly instantiated.

---

# 4.2 Members

There are two member types.

### StudentMember

Rules:

* maximum 3 active loans
* no discount

### PremiumMember

Rules:

* maximum 10 active loans
* fixed discount percentage
* receives 5 reading points for every returned loan

The `Member` class keeps the complete loan history internally.

The collection is exposed as:

```csharp
IReadOnlyList<Loan>
```

This prevents outside code from directly adding or removing loans.

Loans are added only through the member's borrowing behavior.

---

# 4.3 Staff

The staff hierarchy contains:

### Librarian

Responsible for:

* processing returns
* marking borrowed items as lost

### Shelver

Responsible for a library section.

The section can only be changed through:

```csharp
Reassign(...)
```

### HeadLibrarian

Responsible for:

* changing late fees
* withdrawing items
* restoring items

The Head Librarian also receives a fixed monthly allowance.

---

# 4.4 Monthly Pay

All staff share the same salary calculation mechanism.

The base staff salary is:

```text
MonthlySalary
```

The monthly pay is calculated using the common staff behavior.

For the Head Librarian:

```text
Monthly Pay = Monthly Salary + 400
```

This allows the program to use:

```csharp
List<Staff>
```

while still working with different staff subclasses.

This demonstrates **polymorphism**.

---

# 4.5 Library Items

The library item hierarchy is:

```text
LibraryItem
├── Book
├── DVD
└── Magazine
```

There is no plain `LibraryItem` instance.

Each item type has its own loan rules.

| Item     | Loan Period | Late Fee Multiplier |
| -------- | ----------: | ------------------: |
| Book     |     21 days |                   1 |
| DVD      |      7 days |                   2 |
| Magazine |      3 days |                 0.5 |

The caller works with `LibraryItem` rather than checking the concrete type.

There is intentionally no code such as:

```csharp
if (item is Book)
```

or:

```csharp
switch (item)
```

The behavior is defined by the item itself.

---

# 4.6 Late Fees

Every library item has a base late fee.

The daily late fee is calculated according to the item type.

Conceptually:

```text
Daily Late Fee =
Base Late Fee × Item Multiplier
```

Examples:

```text
Book      → Base Fee × 1
DVD       → Base Fee × 2
Magazine  → Base Fee × 0.5
```

The base fee cannot be changed directly.

It can only be changed through the dedicated pricing behavior used by the Head Librarian.

---

# 4.7 Withdrawn Items

A withdrawn item cannot be borrowed.

The Head Librarian can:

```text
Withdraw → item becomes unavailable
Restore  → item becomes available again
```

The `IsWithdrawn` property cannot be modified directly from outside the class.

---

# 4.8 Loans

The `Loan` class represents a borrowing transaction.

Each loan contains:

* unique loan ID
* borrow date
* member
* item
* status
* automatic due date
* optional return date
* calculated late fee

The loan keeps references to the actual:

```text
Member
LibraryItem
```

objects involved in the transaction.

---

# 4.9 Loan Status

The system uses:

```csharp
enum LoanStatus
{
    Borrowed,
    Returned,
    Lost
}
```

Only valid state transitions are allowed.

```text
Borrowed
   │
   ├──→ Returned
   │
   └──→ Lost
```

Invalid transitions are rejected.

For example:

```text
Returned → Returned   ❌
Returned → Lost       ❌
Lost → Returned       ❌
Lost → Lost           ❌
```

This prevents invalid library states.

---

# 4.10 Borrowing Rules

Before creating a loan, the system validates:

* member has not reached the active loan limit
* item is not withdrawn
* item is not already on loan

If any rule fails, an exception is thrown immediately.

When borrowing succeeds:

```text
Member gets Loan
        ↓
Loan status = Borrowed
        ↓
Item.IsOnLoan = true
```

---

# 4.11 Returning Rules

A borrowed loan can be returned only once.

The return date must not be earlier than the borrow date.

When returned:

```text
Loan.Status = Returned
Loan.ReturnDate = actual return date
Item.IsOnLoan = false
```

Trying to return the same loan again is rejected.

---

# 4.12 Lost Items

A borrowed loan can be marked as lost.

After that:

```text
Loan.Status = Lost
Item.IsOnLoan = false
```

A returned loan cannot later be marked as lost.

---

# 4.13 Premium Late Return

The demo includes a Premium Member returning a DVD five days after its due date.

The program demonstrates:

* automatic due date
* return date
* daily late fee
* member discount
* final late fee
* reading points

The reading points are updated based on returned loans rather than being manually assigned.

---

# 4.14 Encapsulation

The Library System intentionally protects its internal state.

Examples include:

```csharp
public string FullName { get; }
```

instead of a public setter.

Also:

```csharp
public IReadOnlyList<Loan> Loans => _loans;
```

instead of exposing the internal mutable list.

Other protected state includes:

* salary
* loan status
* item withdrawal state
* item loan state
* shelving section
* late fee

Changes happen through dedicated methods.

This keeps the business rules inside the domain objects instead of allowing arbitrary external changes.

---

# 4.15 Validation

The system validates invalid input immediately.

Examples include:

* empty identity values
* invalid salary
* non-positive raise
* invalid late fee
* invalid loan period
* withdrawn item borrowing
* already borrowed item
* exceeding loan limit
* invalid loan status transition
* invalid return date

The console application catches these exceptions and prints the rejection messages.

---

# 4.16 Console Demonstration

The Library System runner demonstrates the main requirements through real executions.

The demo covers:

```text
Staff Monthly Pay
Library Item Loan Rules
Withdraw / Restore
Already On Loan Rejection
Student Maximum Loan Limit
Premium Member Late Return
Returning The Same Loan Twice
Marking A Returned Loan As Lost
Marking A Borrowed Loan As Lost
Raise And Reassignment
Head Librarian Allowance
Late Fee Change
Validation Rejections
```

The project builds with:

```powershell
dotnet build .\Inheritance\src\LibrarySystem.csproj
```

And runs with:

```powershell
dotnet run --project .\Inheritance\src\LibrarySystem.csproj
```

---

# 5. LeetCode — Problem 1456

## Maximum Number of Vowels in a Substring of Given Length

The final algorithmic task is LeetCode problem **1456**.

The goal is to find the maximum number of vowels in any substring of length `k`.

The vowels are:

```text
a, e, i, o, u
```

---

## Approach: Sliding Window

Instead of counting the vowels in every substring from scratch, the solution uses a **sliding window**.

The initial window contains the first `k` characters.

Then the window moves one character at a time.

When the window moves:

1. Remove the character leaving the window.
2. Add the character entering the window.
3. Update the current vowel count.
4. Keep track of the maximum count.

Conceptually:

```text
[a b c d]
 ↑     ↑

move →

[b c d e]
   ↑     ↑
```

Only two characters need to be considered at each step.

This avoids repeatedly scanning the whole substring.

---

## Complexity

Let `n` be the length of the string.

### Time

```text
O(n)
```

Each character is processed a constant number of times.

### Space

```text
O(1)
```

Only a few variables are needed.

The solution is stored in:

```text
LeetCode/1456_MaxVowelsInSubstring/Solution.cs
```

The explanation is stored in:

```text
LeetCode/1456_MaxVowelsInSubstring/leetcode.md
```

The accepted submission screenshot is stored in:

```text
LeetCode/1456_MaxVowelsInSubstring/accepted_screenshot.png
```

---

# 6. How to Build and Run

Each project is intentionally kept as a separate .NET project.

This avoids treating the whole repository as one C# project.

## SRP

Build:

```powershell
dotnet build .\SRP\src\SrpLab.Runner\SrpLab.Runner.csproj
```

Run:

```powershell
dotnet run --project .\SRP\src\SrpLab.Runner\SrpLab.Runner.csproj
```

---

## Design Patterns

The main `PatternsLab` project is a class library, so it is built rather than run directly.

Build:

```powershell
dotnet build .\DesignPatterns\src\PatternsLab\PatternsLab.csproj
```

Run the runner:

```powershell
dotnet run --project .\DesignPatterns\src\PatternsLab.Runner\PatternsLab.Runner.csproj
```

---

## Inheritance

Build:

```powershell
dotnet build .\Inheritance\src\LibrarySystem.csproj
```

Run:

```powershell
dotnet run --project .\Inheritance\src\LibrarySystem.csproj
```

---

# 7. Important Design Principles Practiced

Throughout the project, several important C# and OOP concepts were applied.

## Single Responsibility

Classes should focus on one responsibility instead of mixing unrelated concerns.

## Encapsulation

Internal state should be protected and changed through controlled operations.

## Inheritance

Common behavior is placed in base classes while specialized behavior belongs to child classes.

## Polymorphism

The program can work with base types such as:

```csharp
List<Staff>
```

and:

```csharp
List<LibraryItem>
```

while still using the behavior of the actual derived objects.

## Composition

Objects such as `Loan` keep references to the related `Member` and `LibraryItem`.

## Validation

Invalid state is rejected as soon as it is detected.

## Immutability

Values that should not change after creation are exposed using get-only properties.

## Separation of Concerns

Different responsibilities are kept in different classes and projects where appropriate.

---

# 8. What I Learned

This cycle helped connect the theory of object-oriented programming with actual code.

The most important lessons for me were:

### 1. Clean code is more than making the program work

A program can produce the correct output while still having poor structure.

The SRP section showed how separating responsibilities can make a system easier to understand and maintain.

### 2. Design patterns are solutions to problems

Singleton, Prototype, and Builder are not patterns that should be used automatically.

The important question is:

> What problem does this pattern solve?

Using a pattern without understanding the problem can make code more complicated rather than simpler.

### 3. Inheritance should represent real relationships

The Library System helped demonstrate relationships such as:

```text
StudentMember is a Member
PremiumMember is a Member
Librarian is a Staff member
Book is a LibraryItem
DVD is a LibraryItem
```

This makes polymorphism useful and meaningful.

### 4. Encapsulation protects business rules

Instead of allowing code outside the object to directly modify state, the object controls how its state changes.

For example:

```text
GiveRaise()
Reassign()
Withdraw()
Restore()
Return()
MarkAsLost()
BorrowItem()
```

These methods make the allowed operations explicit.

### 5. Algorithms can often be improved by avoiding repeated work

The LeetCode problem demonstrated how the Sliding Window technique reduces repeated calculations and produces an `O(n)` solution.

---

# 9. Verification Checklist

Before submitting the repository, the following areas should be checked.

## SRP

* [x] Responsibilities identified
* [x] Classes refactored
* [x] Runner created
* [x] Runner builds
* [x] Runner runs successfully

## Design Patterns

* [x] Singleton implemented
* [x] Singleton loaded once
* [x] Shared configuration demonstrated
* [x] Prototype researched and implemented
* [x] Shallow/deep copy considered
* [x] Builder implemented
* [x] Required/optional values handled
* [x] Builder validation implemented
* [x] Three LinkedIn posts prepared

## Inheritance

* [x] UML/class diagram created
* [x] Person hierarchy implemented
* [x] Member hierarchy implemented
* [x] Staff hierarchy implemented
* [x] Library item hierarchy implemented
* [x] Loan implemented
* [x] Loan status implemented
* [x] Encapsulation applied
* [x] Loan limits validated
* [x] Withdraw/restore implemented
* [x] Late fees calculated automatically
* [x] Premium discount demonstrated
* [x] Reading points demonstrated
* [x] Invalid state transitions rejected
* [x] Console demonstration implemented

## LeetCode

* [x] Problem 1456 solved
* [x] Sliding Window used
* [x] Complexity documented
* [x] Accepted screenshot included

## Repository

* [x] README included
* [x] Class diagram included
* [x] LeetCode screenshot included
* [x] LinkedIn links included
* [ ] Final Git status checked
* [ ] Final commit created
* [ ] Changes pushed
* [ ] Pull Request opened according to the academy requirements

---

# 10. Final Note

This repository represents the practical work completed during **Simulation Academy .NET Diploma — Cycle 1**.

The main goal was not simply to complete the exercises, but to practice thinking about:

* responsibility
* object boundaries
* maintainability
* validation
* abstraction
* inheritance
* polymorphism
* reusable design
* algorithm efficiency

The projects are intentionally small, but the same principles can be applied to larger real-world applications.
