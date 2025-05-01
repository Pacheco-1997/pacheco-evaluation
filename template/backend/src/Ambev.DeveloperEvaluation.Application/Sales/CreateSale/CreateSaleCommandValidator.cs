using FluentValidation;
using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

/// <summary>
/// Validator for CreateSaleCommand that defines validation rules for sale creation command.
/// </summary>
public class CreateSaleCommandValidator : AbstractValidator<CreateSaleCommand>
{
    /// <summary>
    /// Initializes a new instance of the CreateSaleCommandValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - CustomerId: Must be a valid GUID (not empty)
    /// - BranchId: Must be a valid GUID (not empty)
    /// - SaleDate: Must be a past or present date (not in the future)
    /// - Items: Must not be empty and each item must be valid
    ///     - ProductId: Must be valid
    ///     - Quantity: Must be greater than 0
    ///     - UnitPrice: Must be greater than 0
    /// </remarks>
    public CreateSaleCommandValidator()
    {
        RuleFor(sale => sale.CustomerId)
            .NotEmpty().WithMessage("CustomerId is required.");

        RuleFor(sale => sale.BranchId)
            .NotEmpty().WithMessage("BranchId is required.");

        RuleFor(sale => sale.SaleDate)
            .LessThanOrEqualTo(DateTime.UtcNow).WithMessage("Sale date cannot be in the future.");

        RuleFor(sale => sale.Items)
            .NotEmpty().WithMessage("At least one sale item is required.");

        RuleForEach(sale => sale.Items).ChildRules(items =>
        {
            items.RuleFor(i => i.ProductId)
                .NotEmpty().WithMessage("ProductId is required.");

            items.RuleFor(i => i.Quantity)
                .GreaterThan(0).WithMessage("Quantity must be greater than 0.");

         
        });
    }
}
