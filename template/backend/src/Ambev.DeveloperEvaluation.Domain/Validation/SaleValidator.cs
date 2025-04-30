using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Validation
{
    public class SaleValidator : AbstractValidator<Sale>
    {
        public SaleValidator()
        {
            RuleFor(s => s.CustomerId)
                .NotEmpty().WithMessage("CustomerId must not be empty.");

            RuleFor(s => s.CustomerName)
                .NotEmpty().WithMessage("CustomerName must not be empty.");

            RuleFor(s => s.BranchId)
                .NotEmpty().WithMessage("BranchId must not be empty.");

            RuleFor(s => s.BranchName)
                .NotEmpty().WithMessage("BranchName must not be empty.");

            RuleFor(s => s.Items)
                .NotEmpty().WithMessage("Sale must contain at least one item.");

            RuleForEach(s => s.Items).ChildRules(item =>
            {
                item.RuleFor(i => i.Quantity)
                    .GreaterThan(0).WithMessage("Quantity must be at least 1.");

                item.RuleFor(i => i.Quantity)
                    .LessThanOrEqualTo(20).WithMessage("Quantity cannot exceed 20.");

                item.RuleFor(i => i.UnitPrice)
                    .GreaterThanOrEqualTo(0).WithMessage("UnitPrice must be non-negative.");

                item.RuleFor(i => i.ProductTitle)
                    .NotEmpty().WithMessage("ProductTitle must not be empty.");
            });

            RuleFor(s => s.Total)
                .GreaterThanOrEqualTo(0).WithMessage("Total must be non-negative.");

            RuleFor(s => s.Subtotal)
                .GreaterThan(0).WithMessage("Subtotal must be greater than zero when items exist.");

            RuleFor(s => s)
                .Must(s => s.Total <= s.Subtotal).WithMessage("Total must not exceed Subtotal.");
        }
    }
}
