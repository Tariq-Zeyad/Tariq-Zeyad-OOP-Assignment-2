namespace SrpLab.Billing;

public sealed class DunningEmailBuilder
{
    public string Build(
        string customerName,
        DateOnly asOf,
        int failedPayments,
        decimal amount,
        string invoice)
    {
        var severity = failedPayments switch
        {
            <= 1 => "friendly reminder",
            2 => "second notice",
            _ => "final notice before suspension"
        };

        return
            $"Subject: {severity} {invoice}\n" +
            $"Hi {customerName},\n" +
            $"Balance {amount:C} as of {asOf:o} " +
            $"({failedPayments} failures).\n";
    }
}
