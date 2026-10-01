namespace SRP__Patterns.Inheritance.src
{
    public class LibraryItem
    {
        public string CatalogNumber { get; }
        public string Title { get; }

        public decimal BaseLateFee { get; private set; }

        public bool IsWithdrawn { get; private set; }

        public bool IsOnLoan { get; private set; }

        public int LoanPeriod { get; }

        protected decimal LateFeeMultiplier { get; }

        public decimal DailyLateFee =>
            BaseLateFee * LateFeeMultiplier;

        protected LibraryItem(
            string catalogNumber,
            string title,
            decimal baseLateFee,
            int loanPeriod,
            decimal lateFeeMultiplier)
        {
            if (string.IsNullOrWhiteSpace(catalogNumber))
                throw new ArgumentException(
                    "Catalog number cannot be empty.");

            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException(
                    "Title cannot be empty.");

            if (baseLateFee <= 0)
                throw new ArgumentException(
                    "Late fee must be greater than zero.");

            if (loanPeriod <= 0)
                throw new ArgumentException(
                    "Loan period must be greater than zero.");

            if (lateFeeMultiplier <= 0)
                throw new ArgumentException(
                    "Late fee multiplier must be greater than zero.");

            CatalogNumber = catalogNumber;
            Title = title;
            BaseLateFee = baseLateFee;
            LoanPeriod = loanPeriod;
            LateFeeMultiplier = lateFeeMultiplier;
        }

        public void SetLateFee(decimal newFee)
        {
            if (newFee <= 0)
                throw new ArgumentException(
                    "Late fee must be greater than zero.");

            BaseLateFee = newFee;
        }

        public void Withdraw()
        {
            IsWithdrawn = true;
        }

        public void Restore()
        {
            IsWithdrawn = false;
        }

        internal void SetOnLoan()
        {
            IsOnLoan = true;
        }

        internal void SetReturned()
        {
            IsOnLoan = false;
        }
    }
}