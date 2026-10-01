namespace SRP__Patterns.Inheritance.src
{
    public class Loan
    {
        public string LoanId { get; }

        public DateTime BorrowDate { get; }

        public Member Member { get; }

        public LibraryItem Item { get; }

        public LoanStatus Status { get; private set; }

        public DateTime DueDate =>
            BorrowDate.AddDays(Item.LoanPeriod);

        public DateTime? ReturnDate { get; private set; }

        public decimal LateFee
        {
            get
            {
                if (!ReturnDate.HasValue)
                    return 0;

                if (ReturnDate.Value <= DueDate)
                    return 0;

                int lateDays =
                    (ReturnDate.Value - DueDate).Days;

                decimal fee =
                    lateDays * Item.DailyLateFee;

                decimal discount =
                    fee * Member.DiscountPercentage / 100;

                return fee - discount;
            }
        }

        internal Loan(
            string loanId,
            DateTime borrowDate,
            Member member,
            LibraryItem item)
        {
            if (string.IsNullOrWhiteSpace(loanId))
                throw new ArgumentException(
                    "Loan ID cannot be empty.");

            LoanId = loanId;
            BorrowDate = borrowDate;
            Member = member;
            Item = item;
            Status = LoanStatus.Borrowed;
        }

        public void Return(DateTime returnDate)
        {
            if (Status != LoanStatus.Borrowed)
                throw new InvalidOperationException(
                    "Only borrowed loans can be returned.");

            if (returnDate < BorrowDate)
                throw new ArgumentException(
                    "Return date cannot be earlier than borrow date.");

            ReturnDate = returnDate;
            Status = LoanStatus.Returned;

            Item.SetReturned();
        }

        public void MarkAsLost()
        {
            if (Status != LoanStatus.Borrowed)
                throw new InvalidOperationException(
                    "Only borrowed loans can be marked as lost.");

            Status = LoanStatus.Lost;

            Item.SetReturned();
        }
    }
}