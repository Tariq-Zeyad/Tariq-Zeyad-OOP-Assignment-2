using System;
using System.Collections.Generic;
using System.Text;

namespace SrpLab.Warehouse
{
    // Calculates how many items can be allocated from available stock
    public sealed class StockAllocator
    {
        public IReadOnlyList<(string Sku, int Allocated)> Allocate(
            IReadOnlyList<(string Sku, string Aisle, int Bin, int QtyNeeded, int QtyOnHand)> lines)
        {
            var result = new List<(string, int)>();

            foreach (var line in lines)
            {
                var allocated = Math.Min(line.QtyNeeded, line.QtyOnHand);
                result.Add((line.Sku, allocated));
            }

            return result;
        }
    }
}

