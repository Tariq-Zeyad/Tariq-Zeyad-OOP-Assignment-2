namespace SrpLab.Billing;

public sealed class LedgerJournalLineBuilder
{
    public string Build(
        string customerId,
        string invoiceNumber,
        decimal amount)
    {
        return
            $"{customerId},{invoiceNumber},{amount:0.00},AR-SUB";
    }
}
