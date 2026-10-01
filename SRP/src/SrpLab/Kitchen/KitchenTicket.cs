namespace SrpLab.Kitchen;

public sealed class KitchenTicket
{
    private readonly List<(string Item, List<string> Ingredients, int PrepMinutes)> _items = new();

    private readonly AllergenDetector _allergenDetector = new();
    private readonly KitchenReadyTimeCalculator _readyTimeCalculator;
    private readonly ThermalTicketRenderer _thermalTicketRenderer = new();
    private readonly ExpoLaneSelector _expoLaneSelector = new();

    public KitchenTicket()
    {
        _readyTimeCalculator =
            new KitchenReadyTimeCalculator(
                _allergenDetector);
    }

    public void AddItem(
        string item,
        IEnumerable<string> ingredients,
        int prepMinutes)
    {
        _items.Add((
            item,
            ingredients
                .Select(i => i.Trim().ToLowerInvariant())
                .ToList(),
            prepMinutes));
    }

    public IReadOnlyList<string> DetectAllergens()
    {
        return _allergenDetector.Detect(_items);
    }

    public int EstimatedReadyMinutes(int openStations)
    {
        return _readyTimeCalculator.Calculate(
            _items,
            openStations);
    }

    public string RenderThermalTicket(int orderNumber)
    {
        var allergens = DetectAllergens();

        var estimatedMinutes =
            EstimatedReadyMinutes(2);

        return _thermalTicketRenderer.Render(
            orderNumber,
            _items,
            estimatedMinutes,
            allergens);
    }

    public string ExpoLaneHint()
    {
        var allergens = DetectAllergens();

        var estimatedMinutes =
            EstimatedReadyMinutes(2);

        return _expoLaneSelector.Select(
            allergens,
            estimatedMinutes);
    }
}
