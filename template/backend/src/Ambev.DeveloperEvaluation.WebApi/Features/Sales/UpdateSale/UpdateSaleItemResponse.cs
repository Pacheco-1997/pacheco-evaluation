// UpdateSaleItemResponse.cs
using System;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale
{
    /// <summary>
    /// DTO for updated sale item in UpdateSaleResponse
    /// </summary>
    public class UpdateSaleItemResponse
    {
        /// <summary>
        /// Identifier of the product sold
        /// </summary>
        public Guid ProductId { get; set; }

        /// <summary>
        /// Denormalized product title
        /// </summary>
        public string ProductTitle { get; set; } = string.Empty;

        /// <summary>
        /// Unit price at time of sale
        /// </summary>
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// Quantity sold
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Discount applied to this line
        /// </summary>
        public decimal Discount { get; set; }

        /// <summary>
        /// Total after discount for this line
        /// </summary>
        public decimal ItemTotal { get; set; }

        /// <summary>
        /// Whether this item was cancelled
        /// </summary>
        public bool IsCancelled { get; set; }
    }
}
