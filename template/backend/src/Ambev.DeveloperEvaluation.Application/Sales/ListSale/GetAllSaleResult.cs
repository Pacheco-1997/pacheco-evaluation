using System;
using System.Collections.Generic;

namespace Ambev.DeveloperEvaluation.Application.Sales.ListSale;

    /// <summary>
    /// Represents a single sale in the result of a GetAllSalesQuery.
    /// </summary>
    public class GetAllSaleResult
    {
        /// <summary>
        /// The unique identifier of the sale.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The date and time when the sale took place.
        /// </summary>
        public DateTime SaleDate { get; set; }

        /// <summary>
        /// External identifier of the customer.
        /// </summary>
        public Guid CustomerId { get; set; }

        /// <summary>
        /// Denormalized name of the customer.
        /// </summary>
        public string CustomerName { get; set; } = string.Empty;

        /// <summary>
        /// External identifier of the branch.
        /// </summary>
        public Guid BranchId { get; set; }

        /// <summary>
        /// Denormalized name of the branch.
        /// </summary>
        public string BranchName { get; set; } = string.Empty;

        /// <summary>
        /// Gross total before any discounts.
        /// </summary>
        public decimal Subtotal { get; set; }

        /// <summary>
        /// Net total after all discounts.
        /// </summary>
        public decimal Total { get; set; }

        /// <summary>
        /// Indicates whether the sale has been cancelled.
        /// </summary>
        public bool IsCancelled { get; set; }

        /// <summary>
        /// The collection of items included in this sale.
        /// </summary>
        public IEnumerable<GetAllSaleItemResult> Items { get; set; } = new List<GetAllSaleItemResult>();
    }

