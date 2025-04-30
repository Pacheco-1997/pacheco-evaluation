using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Enums;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale
{
    /// <summary>
    /// Command for creating a new sale.
    /// </summary>
    /// <remarks>
    /// This command is used to capture the required data for creating a sale,
    /// including customer ID, branch ID, sale date, and a list of sale items.
    /// It implements <see cref="IRequest{TResponse}"/> to initiate the request
    /// that returns a <see cref="CreateSaleResult"/>.
    /// 
    /// The data provided in this command is validated using the
    /// <see cref="CreateSaleCommandValidator"/> which extends
    /// <see cref="AbstractValidator{T}"/> to ensure that the fields are correctly
    /// populated and follow the required rules.
    /// </remarks>
    public class CreateSaleCommand : IRequest<CreateSaleResult>
    {
        /// <summary>
        /// Gets or sets the unique identifier of the customer.
        /// </summary>
        public Guid CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the branch where the sale occurred.
        /// </summary>
        public Guid BranchId { get; set; }

        /// <summary>
        /// Gets or sets the date and time of the sale.
        /// </summary>
        public DateTime SaleDate { get; set; }

        /// <summary>
        /// Gets or sets the list of items included in the sale.
        /// </summary>
        public List<SaleItemCommand> Items { get; set; } = new();

        /// <summary>
        /// Validates the command data using the CreateSaleCommandValidator.
        /// </summary>
        /// <returns>A validation result indicating whether the data is valid.</returns>
        public ValidationResultDetail Validate()
        {
            var validator = new CreateSaleCommandValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
        }
    }

    /// <summary>
    /// Represents an individual item within a sale.
    /// </summary>
    public class SaleItemCommand
    {
        /// <summary>
        /// Gets or sets the unique identifier of the product.
        /// </summary>
        public Guid ProductId { get; set; }

        /// <summary>
        /// Gets or sets the quantity of the product sold.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the unit price of the product at the time of sale.
        /// </summary>
        public decimal UnitPrice { get; set; }
    }
}
