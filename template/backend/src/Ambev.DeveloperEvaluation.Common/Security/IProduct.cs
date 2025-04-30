using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Common.Security
{
    /// <summary>
    /// Defines the contract for a product entity in the system.
    /// </summary>
    public interface IProduct
    {
        /// <summary>
        /// Gets the unique identifier of the product.
        /// </summary>
        string Id { get; }

        /// <summary>
        /// Gets the product title.
        /// </summary>
        string Title { get; }

        /// <summary>
        /// Gets the product description.
        /// </summary>
        string? Description { get; }

        /// <summary>
        /// Gets the product category.
        /// </summary>
        string Category { get; }

        /// <summary>
        /// Gets the URL of the product image.
        /// </summary>
        string ImageUrl { get; }

        /// <summary>
        /// Gets the unit price of the product.
        /// </summary>
        decimal UnitPrice { get; }

        /// <summary>
        /// Gets the average rating of the product.
        /// </summary>
        decimal RatingRate { get; }

        /// <summary>
        /// Gets the total count of ratings.
        /// </summary>
        int RatingCount { get; }

        /// <summary>
        /// Gets the creation timestamp of the product.
        /// </summary>
        DateTime CreatedAt { get; }

        /// <summary>
        /// Gets the last update timestamp of the product.
        /// </summary>
        DateTime? UpdatedAt { get; }
    }
}
