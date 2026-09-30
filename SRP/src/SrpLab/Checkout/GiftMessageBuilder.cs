namespace SrpLab.Checkout;

public sealed class GiftMessageBuilder
{
    public string Build(
        string fromName,
        IReadOnlyList<string> skus,
        decimal total)
    {
        var items = string.Join(", ", skus);

        return
            $"Dear friend,\n" +
            $"A gift from {fromName} awaits ({items}).\n" +
            $"Total surprise value: {total:C}\n";
    }
}
