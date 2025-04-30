using System;
using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Value_Objects;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Branches.CreateBranch
{
    /// <summary>
    /// Command for creating a new branch.
    /// </summary>
    /// <remarks>
    /// This command captures the required data for creating a branch,
    /// including its name and address value object. It implements
    /// <see cref="IRequest{CreateBranchResult}"/> to initiate the request
    /// and returns a <see cref="CreateBranchResult"/>.
    /// 
    /// Validation is performed through <see cref="CreateBranchCommandValidator"/>,
    /// ensuring all fields follow the required rules.
    /// </remarks>
    public class CreateBranchCommand : IRequest<CreateBranchResult>
    {
        /// <summary>
        /// Gets or sets the branch name.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the branch address value object.
        /// </summary>
        public Address Address { get; set; } = default!;

        /// <summary>
        /// Validates this command using the CreateBranchCommandValidator.
        /// </summary>
        /// <returns>A <see cref="ValidationResultDetail"/> with validation results.</returns>
        public ValidationResultDetail Validate()
        {
            var validator = new CreateBranchCommandValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(e => (ValidationErrorDetail)e)
            };
        }
    }
}
