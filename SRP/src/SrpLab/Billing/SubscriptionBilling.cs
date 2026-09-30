namespace SrpLab.Billing;

public sealed class SubscriptionBilling
{
    public string CustomerId { get; }

    public decimal MonthlyPrice { get; }

    public DateOnly PeriodStart { get; }

    public DateOnly PeriodEnd { get; }

    public int FailedPayments { get; private set; }

    private readonly SubscriptionProrator _prorator = new();
    private readonly InvoiceNumberGenerator _invoiceNumberGenerator = new();
    private readonly DunningEmailBuilder _dunningEmailBuilder = new();
    private readonly LedgerJournalLineBuilder _ledgerJournalLineBuilder = new();

    public SubscriptionBilling(
        string customerId,
        decimal monthlyPrice,
        DateOnly periodStart,
        DateOnly periodEnd)
    {
        CustomerId = customerId;
        MonthlyPrice = monthlyPrice;
        PeriodStart = periodStart;
        PeriodEnd = periodEnd;
    }

    public decimal Prorate(DateOnly activeFrom)
    {
        return _prorator.Calculate(
            MonthlyPrice,
            PeriodStart,
            PeriodEnd,
            activeFrom);
    }

    public string NextInvoiceNumber()
    {
        return _invoiceNumberGenerator.Generate(
            PeriodStart);
    }

    public void RegisterFailedPayment()
    {
        FailedPayments++;
    }

    public string DunningEmail(
        string customerName,
        DateOnly asOf)
    {
        var amount = Prorate(PeriodStart);

        var invoice = NextInvoiceNumber();

        return _dunningEmailBuilder.Build(
            customerName,
            asOf,
            FailedPayments,
            amount,
            invoice);
    }

    public string LedgerJournalLine(
        DateOnly activeFrom)
    {
        var invoice = NextInvoiceNumber();
        var amount = Prorate(activeFrom);

        return _ledgerJournalLineBuilder.Build(
            CustomerId,
            invoice,
            amount);
    }
}
