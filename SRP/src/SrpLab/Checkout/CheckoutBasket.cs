namespace SrpLab.Checkout;

public sealed class CheckoutBasket
{
    private readonly List<(string Sku, decimal Price, int Qty)> _lines = new();

    private string? _couponRaw;
    private bool _giftWrap;

    private readonly CouponDiscountCalculator _discountCalculator = new();
    private readonly GiftWrapCalculator _giftWrapCalculator = new();
    private readonly GiftMessageBuilder _giftMessageBuilder = new();
    private readonly PaymentAuthorizationStub _paymentAuthorization = new();

    public void AddLine(
        string sku,
        decimal price,
        int qty)
    {
        if (qty <= 0)
            throw new ArgumentOutOfRangeException(nameof(qty));

        _lines.Add((sku, price, qty));
    }

    public void ApplyCouponText(string? couponText)
    {
        _couponRaw = couponText;
    }

    public void EnableGiftWrap()
    {
        _giftWrap = true;
    }

    public decimal SubTotal()
    {
        return _lines.Sum(
            l => l.Price * l.Qty);
    }

    public decimal DiscountAmount()
    {
        return _discountCalculator.Calculate(
            _couponRaw,
            SubTotal());
    }

    public decimal GrandTotal()
    {
        var total =
            SubTotal() -
            DiscountAmount();

        total += _giftWrapCalculator.Calculate(
            _giftWrap);

        return Math.Max(0m, total);
    }

    public string GiftMessageCard(string fromName)
    {
        var items =
            _lines
                .Select(l => l.Sku)
                .ToList();

        return _giftMessageBuilder.Build(
            fromName,
            items,
            GrandTotal());
    }

    public string AuthorizePaymentStub(string cardLast4)
    {
        return _paymentAuthorization.Authorize(
            GrandTotal(),
            cardLast4,
            _lines.Count);
    }
}
