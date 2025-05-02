using System;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.ListSale
{ 

    /// <summary>
    /// Validator for GetAllSalesRequest, defining rules for filtering parameters.
    /// </summary>
    public class GetAllSaleRequestValidator : AbstractValidator<GetAllSaleRequest>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllSaleRequestValidator"/>.
        /// </summary>
        public GetAllSaleRequestValidator()
        {
            // StartDate, if specified, cannot be in the future
            RuleFor(x => x.StartDate)
                .LessThanOrEqualTo(DateTime.UtcNow)
                .When(x => x.StartDate.HasValue)
                .WithMessage("StartDate cannot be in the future.");

            // EndDate, if specified, cannot be in the future
            RuleFor(x => x.EndDate)
                .LessThanOrEqualTo(DateTime.UtcNow)
                .When(x => x.EndDate.HasValue)
                .WithMessage("EndDate cannot be in the future.");

            // When both dates are provided, StartDate must be on or before EndDate
            RuleFor(x => x)
                .Must(x =>
                    !x.StartDate.HasValue
                    || !x.EndDate.HasValue
                    || x.StartDate.Value <= x.EndDate.Value)
                .WithMessage("StartDate must be earlier than or equal to EndDate.");

            // If CustomerId is provided, it must be a non-empty GUID
            RuleFor(x => x.CustomerId)
                .NotEqual(Guid.Empty)
                .When(x => x.CustomerId.HasValue)
                .WithMessage("CustomerId must be a valid GUID.");

            // If BranchId is provided, it must be a non-empty GUID
            RuleFor(x => x.BranchId)
                .NotEqual(Guid.Empty)
                .When(x => x.BranchId.HasValue)
                .WithMessage("BranchId must be a valid GUID.");
        }
    }
}
