using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Common.Security
{
    public interface ISale
    {
        Guid Id { get; }
        DateTime SaleDate { get; }
        Guid CustomerId { get; }
        string CustomerName { get; }
        Guid BranchId { get; }
        string BranchName { get; }
        decimal Subtotal { get; }
        decimal Total { get; }
        IReadOnlyCollection<ISaleItem> Items { get; }
        bool IsCancelled { get; }
    }
}
