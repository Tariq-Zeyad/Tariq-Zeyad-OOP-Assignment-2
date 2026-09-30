using System;
using System.Collections.Generic;
using System.Text;

namespace SRP__Patterns.Inheritance.src
{
    public class Member : Person
    {
        private readonly List<Loan> _loans = new List<Loan>();

        public IReadOnlyList<Loan> Loans => _loans;
        public int MaxLoans { get; }
        public decimal DiscountPercentage { get; }

        protected Member(string personId,string fullName,string phone,int maxLoans,decimal discountPercentage)
            : base(personId, fullName, phone)
        {
            MaxLoans = maxLoans;
            DiscountPercentage = discountPercentage;
        }

        public Loan BorrowItem(
            LibraryItem item,
            string loanId,
            DateTime borrowDate)
        {
            int activeLoans = 0;

            foreach (Loan loan in _loans)
            {
                if (loan.Status == LoanStatus.Borrowed)
                    activeLoans++;
            }

            if (activeLoans >= MaxLoans)
                throw new InvalidOperationException( "Member has reached the maximum number of active loans.");

            if (item.IsWithdrawn)
                throw new InvalidOperationException("A withdrawn item cannot be borrowed.");

            if (item.IsOnLoan)
                throw new InvalidOperationException( "Item is already on loan.");
            Loan newLoan = new Loan(
                loanId,
                borrowDate,
                this,
                item);

            _loans.Add(newLoan);
            item.SetOnLoan();

            return newLoan;
        }
    }
}
