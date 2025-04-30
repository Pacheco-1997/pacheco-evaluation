using System;
using Ambev.DeveloperEvaluation.Common.Validation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.CreateProduct
{
    /// <summary>
    /// Command for creating a new product.
    /// </summary>
    /// <remarks>
    /// This command captures all necessary data for creating a product,
    /// including title, price, description, category, image URL, and initial rating.
    /// It implements <see cref="IRequest{CreateProductResult}"/> to initiate the
    /// request and return a <see cref="CreateProductResult"/>.
    ///
    /// Validation is performed by <see cref="CreateProductCommandValidator"/>.
    /// </remarks>
    public class CreateProductCommand : IRequest<CreateProductResult>
    {
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
        /// Gets or sets the initial average rating.
        /// </summary>
        public decimal RatingRate { get; set; }

        /// <summary>
        /// Gets or sets the initial number of ratings.
        /// </summary>
        public int RatingCount { get; set; }

        /// <summary>
        /// Performs validation of this command using the CreateProductCommandValidator.
        /// </summary>
        public ValidationResultDetail Validate()
        {
            var validator = new CreateProductCommandValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(e => (ValidationErrorDetail)e)
            };
        }
    }
}
