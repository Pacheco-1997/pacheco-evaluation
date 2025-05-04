using System;
using System.Collections.Generic;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.ListSale;

/// <summary>
/// Query for retrieving a filtered list of sales.
/// </summary>
public class GetAllSaleQuery : IRequest<PagedResult<GetAllSaleResult>>
{
    /// <summary>
    /// Optional start of the date range filter.
    /// Only sales on or after this date will be returned.
    /// </summary>
    public DateTime? StartDate { get; set; }

    /// <summary>
    /// Optional end of the date range filter.
    /// Only sales on or before this date will be returned.
    /// </summary>
    public DateTime? EndDate { get; set; }

    /// <summary>
    /// Optional filter by customer identifier.
    /// </summary>
    public Guid? CustomerId { get; set; }

    /// <summary>
    /// Optional filter by branch identifier.
    /// </summary>
    public Guid? BranchId { get; set; }

    /// <summary>
    /// Optional filter by cancellation status.
    /// If true, only cancelled sales; if false, only non-cancelled.
    /// If null, both are included.
    /// </summary>
    public bool? IsCancelled { get; set; }

    public int Page { get; set; } = 1;
    public int Size { get; set; } = 10;
    public string? Order { get; set; }
}
