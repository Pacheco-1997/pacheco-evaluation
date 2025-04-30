namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.Dtos
{
    public class SaleItemRequestDto
    {
        /// <summary>
        /// The unique identifier of the product being sold.
        /// </summary>
        public Guid ProductId { get; set; }

        /// <summary>
        /// The quantity of this product in the sale.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// The unit price at which this product was sold.
        /// </summary>
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// Any discount applied to this item (absolute value).
        /// </summary>
        public decimal Discount { get; set; }

        /// <summary>
        /// Indicates whether this item has been cancelled.
        /// </summary>
        public bool Cancelled { get; set; } = false;
    }
}
