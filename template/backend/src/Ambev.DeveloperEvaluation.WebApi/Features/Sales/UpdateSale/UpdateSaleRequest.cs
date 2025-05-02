// UpdateSaleRequest.cs
using System;
using System.Collections.Generic;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale
{
    /// <summary>
    /// Represents a request to update an existing sale.
    /// </summary>
    public class UpdateSaleRequest
    {
        /// <summary>
        /// The unique identifier of the sale to update.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The date and time of the sale.
        /// </summary>
        public DateTime SaleDate { get; set; }

        /// <summary>
        /// External identifier of the customer.
        /// </summary>
        public Guid CustomerId { get; set; }

        /// <summary>
        /// External identifier of the branch.
        /// </summary>
        public Guid BranchId { get; set; }

        /// <summary>
        /// Whether the sale is cancelled.
        /// </summary>
        public bool IsCancelled { get; set; }

        /// <summary>
        /// The items associated with the sale.
        /// </summary>
        public List<UpdateSaleItemRequest> Items { get; set; } = new();
    }
}


