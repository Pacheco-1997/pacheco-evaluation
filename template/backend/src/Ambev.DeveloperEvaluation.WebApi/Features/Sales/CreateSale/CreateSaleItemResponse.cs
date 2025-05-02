namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale
{
    public class CreateSaleItemResponse
    {
        /// <summary>
        /// The identifier of the product
        /// </summary>
        public Guid ProductId { get; set; }

        /// <summary>
        /// The quantity sold
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// The unit price of the product
        /// </summary>
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// The discount applied to this item
        /// </summary>
        public decimal Discount { get; set; }

        /// <summary>
        /// Total amount for this item (after discount)
        /// </summary>
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// Indicates whether this item was cancelled
        /// </summary>
        public bool Cancelled { get; set; }
    }
}
