namespace SrpLab.Checkout;

public sealed class GiftWrapCalculator
{
    private const decimal GiftWrapFee = 4.99m;

    public decimal Calculate(bool enabled)
    {
        return enabled ? GiftWrapFee : 0m;
    }
}
