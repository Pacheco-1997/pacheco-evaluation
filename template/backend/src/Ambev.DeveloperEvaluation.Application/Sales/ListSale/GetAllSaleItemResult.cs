using System;

namespace Ambev.DeveloperEvaluation.Application.Sales.ListSale;

/// <summary>
/// Represents a single item within a sale in the result of a GetAllSalesQuery.
/// </summary>
public class GetAllSaleItemResult
{
    /// <summary>
    /// The unique identifier of the sale item.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// External identifier of the product.
    /// </summary>
    public Guid ProductId { get; set; }

    /// <summary>
    /// Denormalized title of the product.
    /// </summary>
    public string ProductTitle { get; set; } = string.Empty;

    /// <summary>
    /// Unit price of the product at time of sale.
    /// </summary>
    public decimal UnitPrice { get; set; }

    /// <summary>
    /// Quantity of this product sold.
    /// </summary>
    public int Quantity { get; set; }

    /// <summary>
    /// Discount applied to this item.
    /// </summary>
    public decimal Discount { get; set; }

    /// <summary>
    /// Indicates whether this item was cancelled.
    /// </summary>
    public bool IsCancelled { get; set; }
}

