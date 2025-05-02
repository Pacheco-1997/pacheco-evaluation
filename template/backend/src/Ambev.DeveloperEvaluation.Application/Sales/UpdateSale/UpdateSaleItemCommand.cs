using System;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale
{
    /// <summary>
    /// Command for updating a single sale item within a sale.
    /// </summary>
    public class UpdateSaleItemCommand
    {
        /// <summary>
        /// The ID of the sale item (existing) to update.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The ID of the product for this sale item.
        /// </summary>
        public Guid ProductId { get; set; }

        /// <summary>
        /// The unit price of the product.
        /// </summary>
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// The quantity of the product sold.
        /// </summary>
        public int Quantity { get; set; }

        public bool IsCancelled { get; set; }
    }
}