using System;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale
{
    /// <summary>
    /// DTO for updating a line item within a sale.
    /// </summary>
    public class UpdateSaleItemRequest
    {
        /// <summary>
        /// Identifier of the product.
        /// </summary>
        public Guid ProductId { get; set; }

        /// <summary>
        /// Quantity of the product to sell.
        /// </summary>
        public int Quantity { get; set; }

        public bool IsCancelled { get; set; }
    }
}