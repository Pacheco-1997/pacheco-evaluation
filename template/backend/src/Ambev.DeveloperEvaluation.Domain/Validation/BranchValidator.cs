using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation
{
    /// <summary>
    /// Validador para a entidade Branch, garantindo que
    /// todas as regras de negócio do domínio sejam respeitadas.
    /// </summary>
    public class BranchValidator : AbstractValidator<Branch>
    {
        public BranchValidator()
        {
            // Nome da filial: obrigatório, 3–100 caract.
            RuleFor(b => b.Name)
                .NotEmpty().WithMessage("Branch name must not be empty.")
                .MinimumLength(3).WithMessage("Branch name must be at least 3 characters long.")
                .MaximumLength(100).WithMessage("Branch name cannot exceed 100 characters.");

            // Address.City: obrigatório
            RuleFor(b => b.Address.City)
                .NotEmpty().WithMessage("City must not be empty.")
                .MaximumLength(100).WithMessage("City cannot exceed 100 characters.");

            // Address.Street: obrigatório
            RuleFor(b => b.Address.Street)
                .NotEmpty().WithMessage("Street must not be empty.")
                .MaximumLength(150).WithMessage("Street cannot exceed 150 characters.");

            // Address.Number: > 0
            RuleFor(b => b.Address.Number)
                .GreaterThan(0).WithMessage("Number must be greater than zero.");

            // Address.ZipCode: obrigatório, padrão mínimo de 5 caracteres
            RuleFor(b => b.Address.Zipcode)
                .NotEmpty().WithMessage("Zip code must not be empty.")
                .MinimumLength(5).WithMessage("Zip code must have at least 5 characters.")
                .MaximumLength(20).WithMessage("Zip code cannot exceed 20 characters.");

            // Geolocation.Lat e Geolocation.Long: obrigatórios e formato básico
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
