using FluentValidation;


namespace Ambev.DeveloperEvaluation.Application.Branches.CreateBranch
{
    /// <summary>
    /// Validator for CreateBranchCommand that defines validation rules for branch creation command.
    /// </summary>
    public class CreateBranchCommandValidator : AbstractValidator<CreateBranchCommand>
    {
        public CreateBranchCommandValidator()
        {
            // Name: required, between 3 and 100 characters
            RuleFor(cmd => cmd.Name)
                .NotEmpty().WithMessage("Branch name must not be empty.")
                .MinimumLength(3).WithMessage("Branch name must be at least 3 characters long.")
                .MaximumLength(100).WithMessage("Branch name cannot exceed 100 characters.");

            // Address.City: required, max length 100
            RuleFor(cmd => cmd.Address.City)
                .NotEmpty().WithMessage("City must not be empty.")
                .MaximumLength(100).WithMessage("City cannot exceed 100 characters.");

            // Address.Street: required, max length 150
            RuleFor(cmd => cmd.Address.Street)
                .NotEmpty().WithMessage("Street must not be empty.")
                .MaximumLength(150).WithMessage("Street cannot exceed 150 characters.");

            // Address.Number: must be a positive integer
            RuleFor(cmd => cmd.Address.Number)
                .GreaterThan(0).WithMessage("Number must be greater than zero.");

            // Address.ZipCode: required, between 5 and 20 characters
            RuleFor(cmd => cmd.Address.Zipcode)
                .NotEmpty().WithMessage("Zip code must not be empty.")
                .MinimumLength(5).WithMessage("Zip code must have at least 5 characters.")
                .MaximumLength(20).WithMessage("Zip code cannot exceed 20 characters.");

            // Address.Geolocation.Lat: required and a valid decimal string
            RuleFor(cmd => cmd.Address.Geolocation.Lat)
                .NotEmpty().WithMessage("Latitude must not be empty.")
                .Must(lat => double.TryParse(lat, out _))
                .WithMessage("Latitude must be a valid decimal number.");

            // Address.Geolocation.Long: required and a valid decimal string
            RuleFor(cmd => cmd.Address.Geolocation.Long)
                .NotEmpty().WithMessage("Longitude must not be empty.")
                .Must(lng => double.TryParse(lng, out _))
                .WithMessage("Longitude must be a valid decimal number.");
        }
    }
}
