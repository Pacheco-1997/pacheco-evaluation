using System;
using Ambev.DeveloperEvaluation.Domain.Value_Objects;


namespace Ambev.DeveloperEvaluation.Application.Branches.CreateBranch
{
    /// <summary>
    /// Represents the response returned after successfully creating a new branch.
    /// </summary>
    /// <remarks>
    /// This result contains the unique identifier of the newly created branch,
    /// along with its name and address, which can be used for subsequent operations or reference.
    /// </remarks>
    public class CreateBranchResult
    {
        /// <summary>
        /// Gets or sets the unique identifier of the newly created branch.
        /// </summary>
        /// <value>A GUID that uniquely identifies the created branch in the system.</value>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the branch name.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the address value object for the branch.
        /// </summary>
        public Address Address { get; set; } = default!;
    }
}
