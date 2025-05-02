using System;
using System.Collections.Generic;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale
{
    /// <summary>
    /// API response model for CreateSale operation
    /// </summary>
    public class CreateSaleResponse
    {
        /// <summary>
        /// The unique identifier of the created sale
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The date when the sale was made
        /// </summary>
        public DateTime SaleDate { get; set; }

        /// <summary>
        /// The identifier of the customer
        /// </summary>
        public Guid CustomerId { get; set; }

        /// <summary>
        /// The identifier of the branch where the sale was made
        /// </summary>
        public Guid BranchId { get; set; }

        /// <summary>
        /// The total amount of the sale
        /// </summary>
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// Indicates whether the sale was cancelled
        /// </summary>
        public bool Cancelled { get; set; }

        /// <summary>
        /// The list of items included in this sale
        /// </summary>
        public List<CreateSaleItemResponse> Items { get; set; } = new List<CreateSaleItemResponse>();
    }


    
}
