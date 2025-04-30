using Ambev.DeveloperEvaluation.WebApi.Features.Products.Dtos;
using System.ComponentModel.DataAnnotations;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct
{
    /// <summary>
    /// Represents a request to create a new product in the system.
    /// </summary>
    public class CreateProductRequest
    {
        /// <summary>
        /// The title of the product.
        /// </summary>
        [Required]
        [StringLength(200, MinimumLength = 1)]
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// The price of the product.
        /// </summary>
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than zero.")]
        public decimal Price { get; set; }

        /// <summary>
        /// The description of the product.
        /// </summary>
        [Required]
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// The category to which the product belongs.
        /// </summary>
        [Required]
        [StringLength(100)]
        public string Category { get; set; } = string.Empty;

        /// <summary>
        /// The URL of the product image.
        /// </summary>
        [Url]
        public string Image { get; set; } = string.Empty;

        /// <summary>
        /// The initial rating of the product.
        /// </summary>
        public RatingDto Rating { get; set; } = new RatingDto();
    }


}
