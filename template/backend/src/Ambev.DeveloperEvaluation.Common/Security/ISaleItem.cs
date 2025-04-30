using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Common.Security
{
    public interface ISaleItem
    {
        Guid Id { get; }
        Guid SaleId { get; }
        Guid ProductId { get; }
        string ProductTitle { get; }
        decimal UnitPrice { get; }
        int Quantity { get; }
        decimal Discount { get; }
        decimal TotalItemAmount { get; }
        decimal ItemTotalAfterDiscount { get; }
        bool IsCancelled { get; }
    }
}
