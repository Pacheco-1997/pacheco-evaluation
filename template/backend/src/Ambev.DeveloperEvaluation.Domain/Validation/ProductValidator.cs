using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.Title)
                .NotEmpty().WithMessage("Title must not be empty.")
                .MaximumLength(255).WithMessage("Title cannot exceed 255 characters.");

            RuleFor(p => p.Description)
                .MaximumLength(1000).WithMessage("Description cannot exceed 1000 characters.");

            RuleFor(p => p.Category)
                .NotEmpty().WithMessage("Category must not be empty.")
                .MaximumLength(100).WithMessage("Category cannot exceed 100 characters.");

            RuleFor(p => p.ImageUrl)
                .NotEmpty().WithMessage("ImageUrl must not be empty.")
                .MaximumLength(2048).WithMessage("ImageUrl cannot exceed 2048 characters.")
                .Must(uri => Uri.IsWellFormedUriString(uri, UriKind.Absolute))
                .WithMessage("ImageUrl must be a valid absolute URL.");

            RuleFor(p => p.UnitPrice)
                .GreaterThanOrEqualTo(0).WithMessage("UnitPrice must be non-negative.");

            RuleFor(p => p.RatingRate)
                .InclusiveBetween(0m, 5m).WithMessage("RatingRate must be between 0.0 and 5.0.");

            RuleFor(p => p.RatingCount)
                .GreaterThanOrEqualTo(0).WithMessage("RatingCount must be non-negative.");
        }
    }
}
