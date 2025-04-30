using Ambev.DeveloperEvaluation.WebApi.Features.Products.Dtos;
using System;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct
{
    /// <summary>
    /// API response model for CreateProduct operation
    /// </summary>
    public class CreateProductResponse
    {
        /// <summary>
        /// The unique identifier of the created product
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The title of the product
        /// </summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// The price of the product
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// The product description
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// The category of the product
        /// </summary>
        public string Category { get; set; } = string.Empty;

        /// <summary>
        /// The URL of the product image
        /// </summary>
        public string Image { get; set; } = string.Empty;

        /// <summary>
        /// The rating of the product
        /// </summary>
        public RatingDto Rating { get; set; } = new RatingDto();
    }

    /// <summary>
    /// DTO for product rating information
    /// </summary>

}
