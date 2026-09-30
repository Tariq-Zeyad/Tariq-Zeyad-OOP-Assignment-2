using System;
using System.Collections.Generic;
using System.Linq;

namespace SrpLab.Warehouse;

// Decides the order in which the picker should visit aisles and bins 
public sealed class PickRoutePlanner
{
    public IReadOnlyList<(string Aisle, int Bin, string Sku, int Qty)> CreateWalkingOrder(
        IReadOnlyList<(string Sku, string Aisle, int Bin, int QtyNeeded, int QtyOnHand)> lines)
    {
        return lines
            .OrderBy(l => l.Aisle)
            .ThenBy(l => l.Bin)
            .Select(l => (
                l.Aisle,
                l.Bin,
                l.Sku,
                Math.Min(l.QtyNeeded, l.QtyOnHand)))
            .Where(x => x.Item4 > 0)
            .ToList();
    }
}
