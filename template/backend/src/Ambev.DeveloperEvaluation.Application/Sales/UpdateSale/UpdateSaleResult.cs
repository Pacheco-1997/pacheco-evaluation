// UpdateSaleResult.cs
using System;
using System.Collections.Generic;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale
{
    public class UpdateSaleResult
    {
        public Guid Id { get; set; }
        public DateTime SaleDate { get; set; }
        public Guid CustomerId { get; set; }
        public string CustomerName { get; set; }
        public Guid BranchId { get; set; }
        public string BranchName { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Total { get; set; }
        public decimal TotalAmount { get; set; }
        public bool IsCancelled { get; set; }
        public List<UpdateSaleItemResult> Items { get; set; } = new();
    }
}
