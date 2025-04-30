using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories
{
    /// <summary>
    /// Repository interface for Branch entity operations
    /// </summary>
    public interface IBranchRepository
    {
        /// <summary>
        /// Creates a new branch in the repository
        /// </summary>
        /// <param name="branch">The branch to create</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The created branch</returns>
        Task<Branch> CreateAsync(Branch branch, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a branch by its unique identifier
        /// </summary>
        /// <param name="id">The unique identifier of the branch</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The branch if found, null otherwise</returns>
        Task<Branch?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves all branches in the repository
        /// </summary>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Collection of all branches</returns>
        Task<IEnumerable<Branch>> GetAllAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a branch by its name
        /// </summary>
        /// <param name="name">The branch name to search for</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The branch if found, null otherwise</returns>
        Task<Branch?> GetByNameAsync(string name, CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates an existing branch
        /// </summary>
        /// <param name="branch">The branch with updated data</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>True if the branch was updated, false otherwise</returns>
        Task<bool> UpdateAsync(Branch branch, CancellationToken cancellationToken = default);

        /// <summary>
        /// Deletes a branch from the repository
        /// </summary>
        /// <param name="id">The unique identifier of the branch to delete</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>True if the branch was deleted, false if not found</returns>
        Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
