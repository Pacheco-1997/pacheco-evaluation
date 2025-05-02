using System;
using System.Collections.Generic;


namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale
{
    /// <summary>
    /// API response model for UpdateSale operation
    /// </summary>
    public class UpdateSaleResponse
    {
        /// <summary>
        /// The unique identifier of the updated sale
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The date and time when the sale was made
        /// </summary>
        public DateTime SaleDate { get; set; }

        /// <summary>
        /// External identifier of the customer
        /// </summary>
        public Guid CustomerId { get; set; }

        /// <summary>
        /// Denormalized customer name
        /// </summary>
        public string CustomerName { get; set; } = string.Empty;

        /// <summary>
        /// External identifier of the branch
        /// </summary>
        public Guid BranchId { get; set; }

        /// <summary>
        /// Denormalized branch name
        /// </summary>
        public string BranchName { get; set; } = string.Empty;

        /// <summary>
        /// Gross total before discounts
        /// </summary>
        public decimal Subtotal { get; set; }

        /// <summary>
        /// Total after discounts
        /// </summary>
        public decimal Total { get; set; }

        /// <summary>
        /// Sum of item totals including discounts
        /// </summary>
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// Indicates whether the sale was cancelled
        /// </summary>
        public bool IsCancelled { get; set; }

        /// <summary>
        /// The list of items in the sale
        /// </summary>
        public List<UpdateSaleItemResponse> Items { get; set; } = new();
    }
}
