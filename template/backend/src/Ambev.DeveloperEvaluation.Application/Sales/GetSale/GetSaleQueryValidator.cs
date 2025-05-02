using FluentValidation;
using Ambev.DeveloperEvaluation.Application.Sales.GetSale;

namespace Ambev.DeveloperEvaluation.Application.Validators.Sales
{
    public class GetSaleQueryValidator : AbstractValidator<GetSaleQuery>
    {
        public GetSaleQueryValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("O ID da venda é obrigatório.");
        }
    }
}
