
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Branches.CreateBranch
{
    /// <summary>
    /// Validator for CreateBranchRequest that defines validation rules for branch creation.
    /// </summary>
    public class CreateBranchRequestValidator : AbstractValidator<CreateBranchRequest>
    {
        /// <summary>
        /// Initializes a new instance of the CreateBranchRequestValidator with defined validation rules.
        /// </summary>
        public CreateBranchRequestValidator()
        {
            // Name: required, length 3-100
            RuleFor(b => b.Name)
                .NotEmpty().WithMessage("Branch name must not be empty.")
                .MinimumLength(3).WithMessage("Branch name must be at least 3 characters long.")
                .MaximumLength(100).WithMessage("Branch name cannot exceed 100 characters.");

            // Address fields
            RuleFor(b => b.Address.City)
                .NotEmpty().WithMessage("City must not be empty.")
                .MaximumLength(100).WithMessage("City cannot exceed 100 characters.");

            RuleFor(b => b.Address.Street)
                .NotEmpty().WithMessage("Street must not be empty.")
                .MaximumLength(150).WithMessage("Street cannot exceed 150 characters.");

            RuleFor(b => b.Address.Number)
                .GreaterThan(0).WithMessage("Number must be greater than zero.");

            RuleFor(b => b.Address.Zipcode)
                .NotEmpty().WithMessage("Zipcode must not be empty.")
                .MinimumLength(5).WithMessage("Zipcode must have at least 5 characters.")
                .MaximumLength(20).WithMessage("Zipcode cannot exceed 20 characters.");

            RuleFor(b => b.Address.Geolocation.Lat)
                .NotEmpty().WithMessage("Latitude must not be empty.")
                .Must(lat => double.TryParse(lat, out _))
                .WithMessage("Latitude must be a valid decimal number.");

            RuleFor(b => b.Address.Geolocation.Long)
                .NotEmpty().WithMessage("Longitude must not be empty.")
                .Must(lng => double.TryParse(lng, out _))
                .WithMessage("Longitude must be a valid decimal number.");
        }
    }
}