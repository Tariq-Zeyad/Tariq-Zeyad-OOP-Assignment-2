namespace SrpLab.Support;

public sealed class SupportTicket
{
    private readonly TicketPriorityCalculator _priorityCalculator = new();
    private readonly SlaCalculator _slaCalculator = new();
    private readonly PublicReplyBuilder _publicReplyBuilder = new();
    private readonly EscalationMessageBuilder _escalationMessageBuilder = new();

    public string Id { get; }

    public string Subject { get; private set; }

    public string Body { get; private set; }

    public DateTimeOffset OpenedAt { get; }

    public string Priority { get; private set; } = "P3";

    public SupportTicket(
        string id,
        string subject,
        string body,
        DateTimeOffset openedAt)
    {
        Id = id;
        Subject = subject;
        Body = body;
        OpenedAt = openedAt;

        RecalculatePriorityFromText();
    }

    public void AppendCustomerMessage(string text)
    {
        Body += "\n---\n" + text;

        RecalculatePriorityFromText();
    }

    public void RecalculatePriorityFromText()
    {
        Priority = _priorityCalculator.Calculate(
            Subject,
            Body);
    }

    public DateTimeOffset SlaDeadline()
    {
        return _slaCalculator.CalculateDeadline(
            Priority,
            OpenedAt);
    }

    public bool IsBreached(DateTimeOffset now)
    {
        return _slaCalculator.IsBreached(
            Priority,
            OpenedAt,
            now);
    }

    public string DraftPublicReply(string agentName)
    {
        return _publicReplyBuilder.Build(
            Id,
            agentName,
            Priority,
            SlaDeadline());
    }

    public string InternalEscalationBlurb()
    {
        return _escalationMessageBuilder.Build(
            Id,
            Priority,
            SlaDeadline());
    }
}
