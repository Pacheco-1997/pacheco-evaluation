using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

/// <summary>
/// Result returned after creating a new sale.
/// </summary>
/// <remarks>
/// This result contains the sale's ID, associated customer and branch,
/// sale date, and the list of items included in the transaction.
/// </remarks>
public class CreateSaleResult
{
    /// <summary>
    /// Gets or sets the unique identifier of the created sale.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier of the customer.
    /// </summary>
    public Guid CustomerId { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier of the branch.
    /// </summary>
    public Guid BranchId { get; set; }

    /// <summary>
    /// Gets or sets the date and time of the sale.
    /// </summary>
    public DateTime SaleDate { get; set; }

    /// <summary>
    /// Gets or sets the list of items included in the sale.
    /// </summary>
    public List<CreateSaleItemResult> Items { get; set; } = new();
}



