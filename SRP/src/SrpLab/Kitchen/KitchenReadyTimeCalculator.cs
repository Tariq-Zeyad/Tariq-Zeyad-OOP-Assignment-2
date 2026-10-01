namespace SrpLab.Kitchen;

public sealed class KitchenReadyTimeCalculator
{
    private readonly AllergenDetector _allergenDetector;

    public KitchenReadyTimeCalculator(
        AllergenDetector allergenDetector)
    {
        _allergenDetector = allergenDetector;
    }

    public int Calculate(
        IReadOnlyList<(string Item, List<string> Ingredients, int PrepMinutes)> items,
        int openStations)
    {
        if (openStations <= 0)
            openStations = 1;

        var sequential = items.Sum(i => i.PrepMinutes);

        var parallel =
            (int)Math.Ceiling(
                sequential / (double)openStations);

        if (_allergenDetector.Detect(items).Count > 0)
            parallel += 3;

        var longest =
            items.Count == 0
                ? 0
                : items.Max(i => i.PrepMinutes);

        return Math.Max(parallel, longest);
    }
}
