using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories;

/// <summary>
/// Interface for managing Sale persistence operations.
/// </summary>
public interface ISaleRepository
{
    /// <summary>
    /// Adds a new sale asynchronously.
    /// </summary>
    /// <param name="sale">The sale entity to add.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task AddAsync(Sale sale, CancellationToken cancellationToken);

    /// <summary>
    /// Retrieves a sale by its ID.
    /// </summary>
    /// <param name="id">The sale ID.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The sale entity, or null if not found.</returns>
    Task<Sale?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

    /// <summary>
    /// Deletes a sale by its ID.
    /// </summary>
    /// <param name="id">The ID of the sale to delete.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task DeleteAsync(Guid id, CancellationToken cancellationToken);

    /// <summary>
    /// Updates an existing sale.
    /// </summary>
    /// <param name="sale">The updated sale entity.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task UpdateAsync(Sale sale, CancellationToken cancellationToken);
}
