// Ambev.DeveloperEvaluation.Application.Sales.DeleteSale/DeleteSaleCommandValidator.cs
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.DeleteSale
{
    /// <summary>
    /// Validator for <see cref="DeleteSaleCommand"/>, 
    /// ensuring that the sale ID is provided.
    /// </summary>
    public class DeleteSaleCommandValidator : AbstractValidator<DeleteSaleCommand>
    {
        public DeleteSaleCommandValidator()
        {
            RuleFor(cmd => cmd.Id)
                .NotEmpty()
                .WithMessage("Sale ID is required for deletion.");
        }
    }
}
