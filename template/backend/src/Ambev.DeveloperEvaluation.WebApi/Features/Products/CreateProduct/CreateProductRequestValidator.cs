using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct
{
    /// <summary>
    /// Validator for CreateProductRequest that defines validation rules for product creation.
    /// </summary>
    public class CreateProductRequestValidator : AbstractValidator<CreateProductRequest>
    {
        public CreateProductRequestValidator()
        {
            // Title: required, length 1–200
            RuleFor(p => p.Title)
                .NotEmpty().WithMessage("Title must not be empty.")
                .MaximumLength(200).WithMessage("Title cannot exceed 200 characters.");

            // Price: required, greater than zero
            RuleFor(p => p.Price)
                .GreaterThan(0).WithMessage("Price must be greater than zero.");

            // Description: required, reasonable length
            RuleFor(p => p.Description)
                .NotEmpty().WithMessage("Description must not be empty.")
                .MaximumLength(1000).WithMessage("Description cannot exceed 1000 characters.");

            // Category: required, length 1–100
            RuleFor(p => p.Category)
                .NotEmpty().WithMessage("Category must not be empty.")
                .MaximumLength(100).WithMessage("Category cannot exceed 100 characters.");

            // Image: required, must be a valid URL
            RuleFor(p => p.Image)
                .NotEmpty().WithMessage("Image URL must not be empty.")
                .Must(uri => Uri.TryCreate(uri, UriKind.Absolute, out _))
                .WithMessage("Image must be a valid absolute URL.");

            // Rating: nested object rules
            RuleFor(p => p.Rating).NotNull().WithMessage("Rating must not be null.");

            When(p => p.Rating != null, () =>
            {
                RuleFor(p => p.Rating.Rate)
                    .InclusiveBetween(0.0m, 5.0m)
                    .WithMessage("Rate must be between 0.0 and 5.0.");

                RuleFor(p => p.Rating.Count)
                    .GreaterThanOrEqualTo(0)
                    .WithMessage("Count must be zero or a positive integer.");
            });
        }
    }
}
