using System;
using System.Collections.Generic;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale
{
    /// <summary>
    /// Represents a request to create a new sale in the system.
    /// </summary>
    public class CreateSaleRequest
    {
        /// <summary>
        /// The date and time when the sale was made.
        /// </summary>
        public DateTime SaleDate { get; set; }

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
        public List<CreateSaleItemRequest> Items { get; set; } = new List<CreateSaleItemRequest>();

    
        
    }

 

}
