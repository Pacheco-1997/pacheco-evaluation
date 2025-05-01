namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.Dtos
{
    public class SaleItemCreateRequestDto
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
