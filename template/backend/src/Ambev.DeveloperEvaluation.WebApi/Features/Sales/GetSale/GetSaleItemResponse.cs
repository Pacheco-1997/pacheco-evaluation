namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSale
{
    public class GetSaleItemResponse
    {
        public Guid ProductId { get; set; }
        public string ProductTitle { get; set; } = string.Empty;
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal Discount { get; set; }
        public decimal ItemTotal { get; set; }
        public bool IsCancelled { get; set; }
    }
}
