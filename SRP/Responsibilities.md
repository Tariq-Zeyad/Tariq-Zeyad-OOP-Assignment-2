# SRP Problems in Each Class

## What is SRP?

**SRP (Single Responsibility Principle)** means:

> A class should have one main job and one main reason to change.

A class has an SRP problem when it does many different jobs that can change for different reasons.

---

# 1. WardBoard

### What does it do?

`WardBoard` does many things:

* Assigns patients to beds
* Calculates the patient health score
* Decides when to send a pager alert
* Creates handoff notes
* Stores pager messages
* Exports data to CSV

### SRP problems

The problem is that these jobs are not really the same job.

For example:

* `ScoreAcuity()` can change if the medical rules change.
* The pager code can change if the hospital changes its alert policy.
* `BuildHandoffNote()` can change if the note format changes.
* `ExportCensusCsv()` can change if the CSV format changes.

So, `WardBoard` has **many different reasons to change**.

### Main problem

> `WardBoard` is doing patient management, medical calculations, alerts, formatting, and exporting all in one class.

---

# 2. WarehousePickList

### What does it do?

`WarehousePickList`:

* Stores items
* Decides how many items to allocate
* Decides the walking order
* Creates instructions for the worker
* Creates XML for the WMS system

### SRP problems

There are different jobs here:

* `Allocate()` handles stock allocation.
* `WalkingOrder()` handles the walking path.
* `PickerScript()` handles worker instructions.
* `WmsXmlBatch()` handles XML for another system.

Each one can change for a different reason.

### Main problem

> The class mixes stock rules, walking rules, user instructions, and system integration.

---

# 3. SupportTicket

### What does it do?

`SupportTicket`:

* Calculates ticket priority
* Calculates the SLA deadline
* Checks if the SLA was missed
* Creates a message for the customer
* Creates an internal escalation message

### SRP problems

For example:

* `RecalculatePriorityFromText()` can change when support priority rules change.
* `SlaDeadline()` can change when SLA rules change.
* `DraftPublicReply()` can change when the customer message style changes.
* `InternalEscalationBlurb()` can change when the internal message format changes.

### Main problem

> The class mixes priority rules, SLA rules, and different types of messages.

---

# 4. SubscriptionBilling

### What does it do?

`SubscriptionBilling`:

* Calculates the price for part of a month
* Creates invoice numbers
* Tracks failed payments
* Creates payment reminder emails
* Creates accounting lines

### SRP problems

Different parts can change for different reasons:

* `Prorate()` → billing rules
* `NextInvoiceNumber()` → invoice numbering rules
* `DunningEmail()` → email wording
* `LedgerJournalLine()` → accounting format

There is also a small problem in `DunningEmail()` because it calls `NextInvoiceNumber()` while creating the email.

That means creating an email can also change the invoice number.

### Main problem

> The class mixes billing calculations, invoice numbers, emails, and accounting data.

---

# 5. LoanDesk

### What does it do?

`LoanDesk`:

* Calculates risk
* Decides if a loan is allowed
* Decides which documents are needed
* Creates a decision letter
* Creates a CSV row

### SRP problems

Different rules are mixed together:

* `RiskScore()` → risk rules
* `IsEligible()` → loan decision rules
* `RequiredDocuments()` → compliance rules
* `DecisionLetter()` → customer/legal wording
* `UnderwriterCsvRow()` → export format

These things can all change separately.

### Main problem

> The class mixes loan calculations, compliance, communication, and exporting.

---

# 6. KitchenTicket

### What does it do?

`KitchenTicket`:

* Finds allergens
* Estimates cooking time
* Creates the printed ticket
* Decides which kitchen lane to use

### SRP problems

For example:

* `DetectAllergens()` can change when allergen rules change.
* `EstimatedReadyMinutes()` can change when kitchen timing rules change.
* `RenderThermalTicket()` can change when the printer format changes.
* `ExpoLaneHint()` can change when kitchen routing rules change.

### Main problem

> The class mixes food safety rules, kitchen timing, printing, and kitchen routing.

---

# 7. GradeBook

### What does it do?

`GradeBook`:

* Stores student scores
* Calculates averages
* Gives letter grades
* Checks the honor roll
* Creates a transcript
* Exports data to CSV

### SRP problems

Different parts have different reasons to change:

* `Average()` → average calculation
* `Letter()` → grading rules
* `MeetsHonorRoll()` → honor roll rules
* `TranscriptPlain()` → transcript format
* `ExportCsv()` → CSV format

### Main problem

> The class mixes storing grades, calculating grades, school rules, and document/export formatting.

---

# 8. CourseEnrollmentDesk

### What does it do?

`CourseEnrollmentDesk`:

* Registers students
* Manages the waitlist
* Finds a student's waitlist position
* Creates a welcome message
* Creates a tuition invoice line
* Moves students from the waitlist

### SRP problems

For example:

* `Register()` → registration rules
* `WaitlistPosition()` → waitlist rules
* `PromoteFromWaitlist()` → waitlist promotion rules
* `WelcomePacketMarkdown()` → student communication
* `TuitionInvoiceLine()` → finance rules

### Main problem

> The class mixes student registration, waitlist management, messages, and money-related logic.

---

# 9. CheckoutBasket

### What does it do?

`CheckoutBasket`:

* Adds products
* Calculates the subtotal
* Reads coupon codes
* Calculates discounts
* Calculates the final price
* Creates a gift message
* Creates a payment authorization code

### SRP problems

Different parts have different jobs:

* `SubTotal()` → price calculation
* `DiscountAmount()` → coupon rules
* `GrandTotal()` → total calculation
* `GiftMessageCard()` → customer message
* `AuthorizePaymentStub()` → payment logic

### Main problem

> The class mixes shopping cart logic, coupon rules, messages, and payment logic.

---

# 10. AppointmentDesk

### What does it do?

`AppointmentDesk`:

* Checks business hours
* Finds available slots
* Books appointments
* Creates an ICS calendar file
* Creates an SMS reminder

### SRP problems

For example:

* `IsWithinBusinessHours()` → business hour rules
* `FindNextSlot()` → appointment search
* `TryBook()` → booking rules
* `ToIcs()` → calendar format
* `SmsReminder()` → SMS message

### Main problem

> The class mixes appointment scheduling, calendar integration, and messaging.

---

# Quick Review

| Class                  | SRP Problem                                              |
| ---------------------- | -------------------------------------------------------- |
| `WardBoard`            | Patient management + medical rules + pager + notes + CSV |
| `WarehousePickList`    | Stock + walking path + instructions + XML                |
| `SupportTicket`        | Priority + SLA + customer message + internal message     |
| `SubscriptionBilling`  | Billing + invoice numbers + emails + accounting          |
| `LoanDesk`             | Risk + eligibility + documents + letters + CSV           |
| `KitchenTicket`        | Allergens + cooking time + printing + routing            |
| `GradeBook`            | Grades + school rules + transcript + CSV                 |
| `CourseEnrollmentDesk` | Registration + waitlist + messages + finance             |
| `CheckoutBasket`       | Cart + coupons + pricing + gift message + payment        |
| `AppointmentDesk`      | Scheduling + calendar + SMS                              |

---

# Easy Way to Find an SRP Problem

When you see a class, ask:

### 1. What jobs does this class do?

Write them down.

### 2. Can these jobs change separately?

If yes, there is probably an SRP problem.

### 3. How many different reasons can make me change this class?

For example:

```text
Change medical rules
Change email text
Change CSV format
Change payment system
```

If there are many unrelated reasons:

> **The class probably violates SRP.**

## Easy sentence to use in an exam

> **This class violates SRP because it has multiple responsibilities with different reasons to change.**

Then mention the different responsibilities.

**The important thing is not to memorize the classes. Understand how to find the different responsibilities.**
