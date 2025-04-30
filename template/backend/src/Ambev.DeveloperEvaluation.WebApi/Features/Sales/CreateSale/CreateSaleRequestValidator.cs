using Ambev.DeveloperEvaluation.WebApi.Features.Sales.Dtos;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale
{
    /// <summary>
    /// Validator for CreateSaleRequest that defines validation rules for sale creation.
    /// </summary>
    public class CreateSaleRequestValidator : AbstractValidator<CreateSaleRequest>
    {
        /// <summary>
        /// Initializes a new instance of the CreateSaleRequestValidator with defined validation rules.
        /// </summary>
        /// <remarks>
        /// Validation rules include:
        /// - SaleNumber: Required, maximum length of 50 characters
        /// - Date: Must not be in the future
        /// - CustomerId: Required
        /// - BranchId: Required
        /// - Items: Must contain at least one item
        /// - Each item must have valid ProductId, Quantity, UnitPrice, and Discount
        /// </remarks>
        public CreateSaleRequestValidator()
        {
            RuleFor(sale => sale.SaleNumber)
                .NotEmpty().WithMessage("Sale number is required.")
                .MaximumLength(50).WithMessage("Sale number must not exceed 50 characters.");

            RuleFor(sale => sale.Date)
                .NotEmpty().WithMessage("Sale date is required.")
                .LessThanOrEqualTo(DateTime.UtcNow).WithMessage("Sale date cannot be in the future.");

            RuleFor(sale => sale.CustomerId)
                .NotEmpty().WithMessage("Customer ID is required.");

            RuleFor(sale => sale.BranchId)
                .NotEmpty().WithMessage("Branch ID is required.");

            RuleFor(sale => sale.Items)
                .NotEmpty().WithMessage("At least one sale item is required.");

            RuleForEach(sale => sale.Items).SetValidator(new SaleItemRequestValidator());
        }
    }

    /// <summary>
    /// Validator for SaleItemRequestDto that defines validation rules for individual sale items.
    /// </summary>
    public class SaleItemRequestValidator : AbstractValidator<SaleItemRequestDto>
    {
        /// <summary>
        /// Initializes a new instance of the SaleItemRequestValidator with defined validation rules.
        /// </summary>
        /// <remarks>
        /// Validation rules include:
        /// - ProductId: Required
        /// - Quantity: Must be greater than zero
        /// - UnitPrice: Must be greater than zero
        /// - Discount: Must be zero or positive and not exceed the total price (Quantity * UnitPrice)
        /// </remarks>
        public SaleItemRequestValidator()
        {
            RuleFor(item => item.ProductId)
                .NotEmpty().WithMessage("Product ID is required.");

            RuleFor(item => item.Quantity)
                .GreaterThan(0).WithMessage("Quantity must be greater than zero.");

            RuleFor(item => item.UnitPrice)
                .GreaterThan(0).WithMessage("Unit price must be greater than zero.");

            RuleFor(item => item.Discount)
                .GreaterThanOrEqualTo(0).WithMessage("Discount cannot be negative.")
                .LessThanOrEqualTo(item => item.Quantity * item.UnitPrice)
                .WithMessage("Discount cannot exceed the total price of the item.");
        }
    }
}
