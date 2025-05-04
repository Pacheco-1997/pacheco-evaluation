using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Common.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Value_Objects;
using Ambev.DeveloperEvaluation.Domain.Validation;


namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    /// <summary>
    /// Represents a branch (filial) in the system with location information.
    /// This entity follows domain-driven design principles and includes business rules validation.
    /// </summary>
    public class Branch : BaseEntity, IBranch
    {
        /// <summary>
        /// Gets the branch name.
        /// Must not be null or empty and should contain a meaningful name up to 100 characters.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets the branch address.
        /// Includes city, street, number, zipcode, and geolocation value objects.
        /// </summary>
        public Address Address { get; set; }

        /// <summary>
        /// Gets the date and time when the branch was created.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Gets the date and time of the last update to the branch information.
        /// </summary>
        public DateTime? UpdatedAt { get; set; }

        /// <inheritdoc />
        public Guid Id { get;  set; }

        /// <summary>
        /// Initializes a new instance of the Branch class.
        /// </summary>
        public Branch()
        {
            CreatedAt = DateTime.UtcNow;
        }

        public Branch(string name, Address address)
        {
            Name = name;
            Address = address;
            CreatedAt = DateTime.UtcNow;
        }

        /// <summary>
        /// Performs validation of the branch entity using the BranchValidator rules.
        /// </summary>
        /// <returns>
        /// A <see cref="ValidationResultDetail"/> containing:
        /// - IsValid: Indicates whether all validation rules passed
        /// - Errors: Collection of validation errors if any rules failed
        /// </returns>
        public ValidationResultDetail Validate()
        {
            var validator = new BranchValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(e => (ValidationErrorDetail)e)
            };
        }

        /// <summary>
        /// Updates the branch information with new name and/or address.
        /// </summary>
        /// <param name="name">New branch name.</param>
        /// <param name="address">New address value object.</param>
        public void Update(string name, Address address)
        {
            Name = name;
            Address = address;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
