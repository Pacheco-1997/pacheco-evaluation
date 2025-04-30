using System;

namespace Ambev.DeveloperEvaluation.Application.Products.CreateProduct
{
    /// <summary>
    /// Represents the response returned after successfully creating a new product.
    /// </summary>
    /// <remarks>
    /// This result contains the unique identifier of the newly created product,
    /// along with its key details for reference.
    /// </remarks>
    public class CreateProductResult
    {
        /// <summary>
        /// Gets or sets the unique identifier of the newly created product.
        /// </summary>
        /// <value>A GUID that uniquely identifies the created product in the system.</value>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the product title.
        /// </summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the product price.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the product description.
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the product category.
        /// </summary>
        public string Category { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the URL of the product image.
        /// </summary>
        public string Image { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the average rating value of the product.
        /// </summary>
        public decimal RatingRate { get; set; }

        /// <summary>
        /// Gets or sets the count of ratings the product has received.
        /// </summary>
        public int RatingCount { get; set; }
    }
}
