using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale
{
    /// <summary>
    /// Validator for UpdateSaleCommand that defines validation rules for sale updates.
    /// </summary>
    public class UpdateSaleCommandValidator : AbstractValidator<UpdateSaleCommand>
    {
        public UpdateSaleCommandValidator()
        {
            RuleFor(sale => sale.Id)
                .NotEmpty().WithMessage("Sale Id is required.");

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
}
