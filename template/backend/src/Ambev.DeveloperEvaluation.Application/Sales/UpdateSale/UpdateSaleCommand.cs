// File: UpdateSaleCommand.cs
using MediatR;
using System;
using System.Collections.Generic;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale
{
    /// <summary>
    /// Command for updating an existing sale.
    /// </summary>
    public class UpdateSaleCommand : IRequest<UpdateSaleResult>
    {
        /// <summary>
        /// The ID of the sale to update.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The date and time of the sale.
        /// </summary>
        public DateTime SaleDate { get; set; }

        /// <summary>
        /// The customer ID for the sale.
        /// </summary>
        public Guid CustomerId { get; set; }

        /// <summary>
        /// The branch ID where the sale occurred.
        /// </summary>
        public Guid BranchId { get; set; }

        public bool IsCancelled { get; set; }

        /// <summary>
        /// The collection of items in the sale.
        /// </summary>
        public List<UpdateSaleItemCommand> Items { get; set; } = new();
    }
}