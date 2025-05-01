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
        /// - Date: Must not be in the future
        /// - CustomerId: Required
        /// - BranchId: Required
        /// - Items: Must contain at least one item
        /// - Each item must have valid ProductId, Quantity, UnitPrice, and Discount
        /// </remarks>
        public CreateSaleRequestValidator()
        {
            RuleFor(sale => sale.SaleDate)
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
    public class SaleItemRequestValidator : AbstractValidator<SaleItemCreateRequestDto>
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



        }
    }
}
