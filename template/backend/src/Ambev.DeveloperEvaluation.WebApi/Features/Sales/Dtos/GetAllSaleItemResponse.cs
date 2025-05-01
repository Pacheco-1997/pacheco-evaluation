public class GetAllSaleItemResponse
{
    public Guid ProductId { get; set; }
    public string ProductTitle { get; set; }

    public decimal UnitPrice { get; set; }
    public int Quantity { get; set; }
    public decimal Discount { get; set; }

    public decimal ItemTotal => (UnitPrice * Quantity) - Discount;

    public bool IsCancelled { get; set; }
}
