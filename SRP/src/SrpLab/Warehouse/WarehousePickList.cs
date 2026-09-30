using System.Collections.Generic;

namespace SrpLab.Warehouse;



//Stores the items needed for picking
public sealed class WarehousePickList
{
    private readonly List<(string Sku, string Aisle, int Bin, int QtyNeeded, int QtyOnHand)> _lines = new();

    public void AddNeed(
        string sku,
        string aisle,
        int bin,
        int qtyNeeded,
        int qtyOnHand)
    {
        _lines.Add((sku, aisle, bin, qtyNeeded, qtyOnHand));
    }

    public IReadOnlyList<(string Sku, string Aisle, int Bin, int QtyNeeded, int QtyOnHand)> Lines
        => _lines;
}
