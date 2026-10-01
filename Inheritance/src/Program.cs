using System;
using System.Collections.Generic;
using SRP__Patterns.Inheritance.src;

// These lines must NOT compile if uncommented:
//
// Person person = new Person("P1", "Person", "0590000000");
// Member member = new Member("M1", "Member", "0590000000", 3, 0);
// Staff staff = new Staff("S1", "Staff", "0590000000", DateTime.Today, 1000, 0);
// LibraryItem item = new LibraryItem("I1", "Item", 10, 7, 1);
//
// student.FullName = "New Name";
// student.Loans.Add(loan);
// book1.IsOnLoan = true;

partial class Program
{
    static void Main()
    {
        Console.WriteLine("=== Library System Demo ===");

        var student = new StudentMember(
            "M001",
            "Ahmad Ali",
            "0599000000");

        var premium = new PremiumMember(
            "M002",
            "Sara Khaled",
            "0599111111",
            10);

        var librarian = new Librarian(
            "S001",
            "Lina Ahmad",
            "0599222222",
            new DateTime(2025, 1, 10),
            1200);

        var headLibrarian = new HeadLibrarian(
            "S002",
            "Omar Hassan",
            "0599333333",
            new DateTime(2024, 6, 1),
            1800);

        var shelver = new Shelver(
            "S003",
            "Rami Saleh",
            "0599444444",
            new DateTime(2025, 3, 15),
            1000,
            "History");

        var book1 = new Book(
            "B001",
            "Clean Code",
            2);

        var book2 = new Book(
            "B002",
            "Design Patterns",
            2);

        var dvd = new DVD(
            "D001",
            "C# Fundamentals",
            3);

        var magazine = new Magazine(
            "M001",
            "Tech Monthly",
            1);

        var extraBook = new Book(
            "B003",
            "Software Architecture",
            2);

        Console.WriteLine();
        Console.WriteLine("=== Staff Monthly Pay ===");

        var staffMembers = new List<Staff>
        {
            librarian,
            headLibrarian,
            shelver
        };

        foreach (Staff staff in staffMembers)
        {
            Console.WriteLine(
                $"{staff.FullName}: Monthly pay = {staff.MonthlyPay}");
        }

        Console.WriteLine();
        Console.WriteLine("=== Library Item Loan Rules ===");

        var libraryItems = new List<LibraryItem>
        {
            book1,
            dvd,
            magazine
        };

        foreach (LibraryItem item in libraryItems)
        {
            Console.WriteLine(
                $"{item.Title}: " +
                $"Loan period = {item.LoanPeriod} days, " +
                $"Daily late fee = {item.DailyLateFee}");
        }

        Console.WriteLine();
        Console.WriteLine("=== Withdraw / Restore ===");

        headLibrarian.WithdrawItem(magazine);

        Console.WriteLine(
            $"Magazine withdrawn: {magazine.IsWithdrawn}");

        try
        {
            student.BorrowItem(
                magazine,
                "L001",
                new DateTime(2026, 9, 1));
        }
        catch (Exception ex)
        {
            Console.WriteLine(
                $"Rejected withdrawn item: {ex.Message}");
        }

        headLibrarian.RestoreItem(magazine);

        Console.WriteLine(
            $"Magazine restored: {magazine.IsWithdrawn}");

        Console.WriteLine();
        Console.WriteLine("=== Already On Loan Rejection ===");

        Loan premiumLoan = premium.BorrowItem(
            dvd,
            "L002",
            new DateTime(2026, 9, 1));

        Console.WriteLine(
            $"Loan status: {premiumLoan.Status}");

        Console.WriteLine(
            $"DVD on loan: {dvd.IsOnLoan}");

        try
        {
            student.BorrowItem(
                dvd,
                "L003",
                new DateTime(2026, 9, 1));
        }
        catch (Exception ex)
        {
            Console.WriteLine(
                $"Rejected already-on-loan item: {ex.Message}");
        }

        Console.WriteLine();
        Console.WriteLine("=== Student Maximum Loan Limit ===");

        student.BorrowItem(
            book1,
            "L004",
            new DateTime(2026, 9, 1));

        student.BorrowItem(
            book2,
            "L005",
            new DateTime(2026, 9, 1));

        student.BorrowItem(
            extraBook,
            "L006",
            new DateTime(2026, 9, 1));

        Console.WriteLine(
            $"Student active loans: {student.Loans.Count}");

        try
        {
            student.BorrowItem(
                new Book(
                    "B004",
                    "Refactoring",
                    2),
                "L007",
                new DateTime(2026, 9, 1));
        }
        catch (Exception ex)
        {
            Console.WriteLine(
                $"Rejected fourth item: {ex.Message}");
        }

        Console.WriteLine();
        Console.WriteLine("=== Premium Member Late Return ===");

        DateTime expectedReturnDate =
            premiumLoan.DueDate.AddDays(5);

        Console.WriteLine(
            $"Due date: {premiumLoan.DueDate:d}");

        Console.WriteLine(
            $"Return date: {expectedReturnDate:d}");

        librarian.ProcessReturn(
            premiumLoan,
            expectedReturnDate);

        Console.WriteLine(
            $"Loan status after return: {premiumLoan.Status}");

        Console.WriteLine(
            $"Return date recorded: {premiumLoan.ReturnDate:d}");

        Console.WriteLine(
            $"Late fee after discount: {premiumLoan.LateFee}");

        Console.WriteLine(
            $"Premium reading points: {premium.ReadingPoints}");

        Console.WriteLine(
            $"DVD on loan after return: {dvd.IsOnLoan}");

        Console.WriteLine();
        Console.WriteLine("=== Returning The Same Loan Twice ===");

        try
        {
            librarian.ProcessReturn(
                premiumLoan,
                expectedReturnDate.AddDays(1));
        }
        catch (Exception ex)
        {
            Console.WriteLine(
                $"Rejected: {ex.Message}");
        }

        Console.WriteLine();
        Console.WriteLine("=== Marking A Returned Loan As Lost ===");

        try
        {
            librarian.MarkItemAsLost(
                premiumLoan);
        }
        catch (Exception ex)
        {
            Console.WriteLine(
                $"Rejected: {ex.Message}");
        }

        Console.WriteLine();
        Console.WriteLine("=== Marking A Borrowed Loan As Lost ===");

        Loan lostLoan = student.Loans[0];

        Console.WriteLine(
            $"Loan status before lost: {lostLoan.Status}");

        try
        {
            librarian.MarkItemAsLost(
                lostLoan);

            Console.WriteLine(
                $"Loan status after lost: {lostLoan.Status}");

            Console.WriteLine(
                $"Lost item on loan: {lostLoan.Item.IsOnLoan}");
        }
        catch (Exception ex)
        {
            Console.WriteLine(
                $"Rejected: {ex.Message}");
        }

        Console.WriteLine();
        Console.WriteLine("=== Raise And Reassignment ===");

        librarian.GiveRaise(10);

        shelver.Reassign("Science");

        Console.WriteLine(
            $"{librarian.FullName} " +
            $"new monthly salary: " +
            $"{librarian.MonthlySalary}");

        Console.WriteLine(
            $"{shelver.FullName} " +
            $"new section: " +
            $"{shelver.Section}");

        Console.WriteLine();
        Console.WriteLine("=== Head Librarian Allowance ===");

        Console.WriteLine(
            $"Head librarian salary: " +
            $"{headLibrarian.MonthlySalary}");

        Console.WriteLine(
            $"Head librarian monthly pay: " +
            $"{headLibrarian.MonthlyPay}");

        Console.WriteLine();
        Console.WriteLine("=== Late Fee Change ===");

        headLibrarian.ChangeLateFee(
            book1,
            4);

        Console.WriteLine(
            $"{book1.Title}: " +
            $"new daily late fee = " +
            $"{book1.DailyLateFee}");

        Console.WriteLine();
        Console.WriteLine("=== Validation Rejections ===");

        try
        {
            librarian.GiveRaise(0);
        }
        catch (Exception ex)
        {
            Console.WriteLine(
                $"Rejected invalid raise: {ex.Message}");
        }

        try
        {
            headLibrarian.ChangeLateFee(
                book1,
                0);
        }
        catch (Exception ex)
        {
            Console.WriteLine(
                $"Rejected invalid late fee: {ex.Message}");
        }

    }
}

