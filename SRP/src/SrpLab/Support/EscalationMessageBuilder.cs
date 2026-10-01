namespace SrpLab.Support;

public sealed class EscalationMessageBuilder
{
    public string Build(
        string ticketId,
        string priority,
        DateTimeOffset slaDeadline)
    {
        return
            $"ESCALATE {ticketId} " +
            $"priority={priority} " +
            $"breachAt={slaDeadline:u} " +
            $"keywords-scanned=yes";
    }
}
