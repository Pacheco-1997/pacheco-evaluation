using System;
using System.Collections.Generic;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.Dtos;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale
{
    /// <summary>
    /// Represents a request to create a new sale in the system.
    /// </summary>
    public class CreateSaleRequest
    {
        /// <summary>
        /// The sale number, e.g. invoice or receipt identifier.
        /// </summary>
        public string SaleNumber { get; set; } = string.Empty;

        /// <summary>
        /// The date and time when the sale was made.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// The unique identifier of the customer making the purchase.
        /// </summary>
        public Guid CustomerId { get; set; }

        /// <summary>
        /// The unique identifier of the branch where the sale occurred.
        /// </summary>
        public Guid BranchId { get; set; }

        /// <summary>
        /// The list of items included in this sale.
        /// </summary>
        public List<SaleItemRequestDto> Items { get; set; } = new List<SaleItemRequestDto>();

        /// <summary>
        /// Indicates whether the sale is already cancelled at creation time.
        /// </summary>
        public bool Cancelled { get; set; } = false;
    }

 

}
