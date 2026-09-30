using System.Collections.Generic;
using System.Linq;

namespace SrpLab.Warehouse;

//Converts allocation data into WMS XML format 
public sealed class WmsXmlExporter
{
    private readonly StockAllocator _stockAllocator;

    public WmsXmlExporter(StockAllocator stockAllocator)
    {
        _stockAllocator = stockAllocator;
    }

    public string Export(
        string batchId,
        IReadOnlyList<(string Sku, string Aisle, int Bin, int QtyNeeded, int QtyOnHand)> lines)
    {
        var allocations = _stockAllocator.Allocate(lines);

        var parts = allocations
            .Select(a => $"<line sku=\"{a.Sku}\" qty=\"{a.Allocated}\" />");

        return $"<batch id=\"{batchId}\">{string.Join("", parts)}</batch>";
    }
}
