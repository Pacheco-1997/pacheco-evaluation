using Ambev.DeveloperEvaluation.Domain.Value_Objects;
using System;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Branches.CreateBranch
{
    /// <summary>
    /// Represents a request to create a new branch in the system.
    /// </summary>
    public class CreateBranchRequest
    {
        /// <summary>
        /// Gets or sets the branch name. Must not be null or empty.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the branch address, including city, street, number, zipcode, and geolocation.
        /// </summary>
        public Address Address { get; set; } = default!;
    }
}
