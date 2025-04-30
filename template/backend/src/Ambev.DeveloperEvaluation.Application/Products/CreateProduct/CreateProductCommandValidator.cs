using System;
using FluentValidation;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Ambev.DeveloperEvaluation.Application.Products.CreateProduct
{
    /// <summary>
    /// Validator for CreateProductCommand that defines validation rules for product creation command.
    /// </summary>
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            // Title: required, length 1–200
            RuleFor(cmd => cmd.Title)
            .NotEmpty().WithMessage("Title must not be empty.")
                .MaximumLength(200).WithMessage("Title cannot exceed 200 characters."); 

            // Price: required, greater than zero
            RuleFor(cmd => cmd.Price)
                .GreaterThan(0).WithMessage("Price must be greater than zero."); 

            // Description: required, reasonable length
            RuleFor(cmd => cmd.Description)
                .NotEmpty().WithMessage("Description must not be empty.")
                .MaximumLength(1000).WithMessage("Description cannot exceed 1000 characters.");

            // Category: required, length 1–100
            RuleFor(cmd => cmd.Category)
                .NotEmpty().WithMessage("Category must not be empty.")
                .MaximumLength(100).WithMessage("Category cannot exceed 100 characters.");

            // Image: required, must be a valid URL
            RuleFor(cmd => cmd.Image)
                .NotEmpty().WithMessage("Image URL must not be empty.")
                .Must(uri => Uri.TryCreate(uri, UriKind.Absolute, out _))
                .WithMessage("Image must be a valid absolute URL."); 

            // Rating: nested object rules
            RuleFor(cmd => cmd.RatingRate)
            .InclusiveBetween(0.0m, 5.0m)
                .WithMessage("Rating rate must be between 0.0 and 5.0."); 

            RuleFor(cmd => cmd.RatingCount)
            .GreaterThanOrEqualTo(0)
                .WithMessage("Rating count must be zero or a positive integer."); 
        }
    }
}
