namespace SrpLab.Warehouse;

public sealed class PickerInstructionBuilder
{
    private readonly PickRoutePlanner _routePlanner;
    private readonly StockAllocator _stockAllocator;

    public PickerInstructionBuilder(
        PickRoutePlanner routePlanner,
        StockAllocator stockAllocator)
    {
        _routePlanner = routePlanner;
        _stockAllocator = stockAllocator;
    }

    public string Build(
        IReadOnlyList<(string Sku, string Aisle, int Bin, int QtyNeeded, int QtyOnHand)> lines)
    {
        var walkingOrder = _routePlanner.CreateWalkingOrder(lines);

        var steps = walkingOrder
            .Select((s, i) =>
                $"{i + 1}. Go aisle {s.Aisle} bin {s.Bin}: pick {s.Qty} x {s.Sku}");

        var allocations = _stockAllocator.Allocate(lines);

        var shortfalls = allocations.Where(a =>
        {
            var line = lines.First(l => l.Sku == a.Sku);
            return a.Allocated < line.QtyNeeded;
        });

        var warning = shortfalls.Any()
            ? "SHORTAGES: " + string.Join(", ", shortfalls.Select(s => s.Sku))
            : "SHORTAGES: none";

        return string.Join('\n', steps) + "\n" + warning;
    }
}
