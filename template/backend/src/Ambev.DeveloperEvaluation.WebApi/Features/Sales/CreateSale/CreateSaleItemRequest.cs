namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale
{
    public class CreateSaleItemRequest
    {
        /// <summary>
        /// The unique identifier of the product being sold.
        /// </summary>
        public Guid ProductId { get; set; }

        /// <summary>
        /// The quantity of this product in the sale.
        /// </summary>
        public int Quantity { get; set; }

    }
}
