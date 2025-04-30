using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation;

public class UserValidator : AbstractValidator<User>
{
    public UserValidator()
    {
        RuleFor(user => user.Email).SetValidator(new EmailValidator());

        RuleFor(user => user.Username)
            .NotEmpty()
            .MinimumLength(3).WithMessage("Username must be at least 3 characters long.")
            .MaximumLength(50).WithMessage("Username cannot be longer than 50 characters.");
        
        RuleFor(user => user.Password).SetValidator(new PasswordValidator());
        
        RuleFor(user => user.Phone)
            .Matches(@"^\+[1-9]\d{10,14}$")
            .WithMessage("Phone number must start with '+' followed by 11-15 digits.");
        
        RuleFor(user => user.Status)
            .NotEqual(UserStatus.Unknown)
            .WithMessage("User status cannot be Unknown.");
        
        RuleFor(user => user.Role)
            .NotEqual(UserRole.None)
            .WithMessage("User role cannot be None.");

        RuleFor(u => u.Name.Firstname)
        .NotEmpty().WithMessage("Firstname must not be empty.");

        RuleFor(u => u.Name.Lastname)
            .NotEmpty().WithMessage("Lastname must not be empty.");

        RuleFor(u => u.Address.City)
            .NotEmpty().WithMessage("City must not be empty.");

        RuleFor(u => u.Address.Street)
            .NotEmpty().WithMessage("Street must not be empty.");

        RuleFor(u => u.Address.Number)
            .GreaterThan(0).WithMessage("Number must be greater than zero.");

        RuleFor(u => u.Address.Zipcode)
            .NotEmpty().WithMessage("Zipcode must not be empty.");

        RuleFor(u => u.Address.Geolocation.Lat)
            .NotEmpty().WithMessage("Latitude must not be empty.");

        RuleFor(u => u.Address.Geolocation.Long)
            .NotEmpty().WithMessage("Longitude must not be empty.");
    }
}
