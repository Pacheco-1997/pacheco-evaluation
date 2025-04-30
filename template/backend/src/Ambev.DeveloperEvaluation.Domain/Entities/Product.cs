using Ambev.DeveloperEvaluation.Common.Security;
using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    /// <summary>
    /// Represents a product in the system with catalog and pricing information.
    /// This entity follows domain-driven design principles and includes business rules validation.
    /// </summary>
    public class Product : BaseEntity, IProduct
    {
        /// <summary>
        /// Gets the product title.
        /// Must not be null or empty and has a maximum length of 255 characters.
        /// </summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Gets the product description.
        /// Can be null or empty; supports longer text.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Gets the product category.
        /// Must not be null or empty and has a maximum length of 100 characters.
        /// </summary>
        public string Category { get; set; } = string.Empty;

        /// <summary>
        /// Gets the URL of the product image.
        /// Must be a valid URL and has a maximum length of 2048 characters.
        /// </summary>
        public string ImageUrl { get; set; } = string.Empty;

        /// <summary>
        /// Gets the unit price of the product.
        /// Must be a non-negative decimal with two decimal places.
        /// </summary>
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// Gets the average rating of the product (0.0 to 5.0 scale).
        /// </summary>
        public decimal RatingRate { get; set; }

        /// <summary>
        /// Gets the total count of ratings received.
        /// </summary>
        public int RatingCount { get; set; }

        /// <summary>
        /// Gets the date and time when the product was created.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Gets the date and time of the last update to the product information.
        /// </summary>
        public DateTime? UpdatedAt { get; set; }

        /// <summary>
        /// Gets the unique identifier of the product.
        /// </summary>
        /// <returns>The product's ID as a string.</returns>
        string IProduct.Id => Id.ToString();

        /// <summary>
        /// Initializes a new instance of the Product class.
        /// </summary>
        public Product()
        {
            CreatedAt = DateTime.UtcNow;
        }

        public Product(string title, decimal price, string description, string category, string image, decimal ratingRate, int ratingCount)
        {
            Title = title;
            Description = description;
            Category = category;
            ImageUrl = image;
            UnitPrice = price;
            RatingRate = ratingRate;
            RatingCount = ratingCount;
            CreatedAt = DateTime.UtcNow;
        }

        /// <summary>
        /// Performs validation of the product entity using the ProductValidator rules.
        /// </summary>
        /// <returns>
        /// A <see cref="ValidationResultDetail"/> containing:
        /// - IsValid: Indicates if all validation rules passed
        /// - Errors: Collection of validation errors if any rules failed
        /// </returns>
        public ValidationResultDetail Validate()
        {
            var validator = new ProductValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(e => (ValidationErrorDetail)e)
            };
        }

        /// <summary>
        /// Atualiza os dados mutáveis deste produto.
        /// </summary>
        public void Update(
            string title,
            decimal unitPrice,
            string description,
            string category,
            string imageUrl,
            decimal ratingRate,
            int ratingCount)
        {
            Title = title;
            UnitPrice = unitPrice;
            Description = description;
            Category = category;
            ImageUrl = imageUrl;
            RatingRate = ratingRate;
            RatingCount = ratingCount;
            UpdatedAt = DateTime.UtcNow;  
        }
    }
}
