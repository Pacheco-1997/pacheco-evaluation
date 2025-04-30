using System;
using Ambev.DeveloperEvaluation.Domain.Value_Objects;


namespace Ambev.DeveloperEvaluation.WebApi.Features.Branches.CreateBranch
{
    /// <summary>
    /// API response model for CreateBranch operation
    /// </summary>
    public class CreateBranchResponse
    {
        /// <summary>
        /// The unique identifier of the created branch
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The branch name
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// The branch address value object
        /// </summary>
        public Address Address { get; set; } = default!;
    }
}
