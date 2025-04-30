using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    /// <summary>
    /// Implementation of IProductRepository using Entity Framework Core
    /// </summary>
    public class ProductRepository : IProductRepository
    {
        private readonly DefaultContext _context;

        /// <summary>
        /// Initializes a new instance of ProductRepository
        /// </summary>
        /// <param name="context">The database context</param>
        public ProductRepository(DefaultContext context)
        {
            _context = context;
        }

        /// <inheritdoc />
        public async Task<Product> CreateAsync(Product product, CancellationToken cancellationToken = default)
        {
            await _context.Products.AddAsync(product, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return product;
        }

        /// <inheritdoc />
        public async Task<Product?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Products
                .FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
        }

        /// <inheritdoc />
        public async Task<Product?> GetByTitleAsync(string title, CancellationToken cancellationToken = default)
        {
            return await _context.Products
                .FirstOrDefaultAsync(p => p.Title == title, cancellationToken);
        }

        /// <inheritdoc />
        public async Task<IEnumerable<Product>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Products.ToListAsync(cancellationToken);
        }

        /// <inheritdoc />
        public async Task<bool> UpdateAsync(Product product, CancellationToken cancellationToken = default)
        {
            var existing = await GetByIdAsync(product.Id, cancellationToken);
            if (existing == null)
                return false;

            existing.Update(
                product.Title,
                product.UnitPrice,
                product.Description,
                product.Category,
                product.ImageUrl,
                product.RatingRate,
                product.RatingCount);

            _context.Products.Update(existing);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        /// <inheritdoc />
        public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var product = await GetByIdAsync(id, cancellationToken);
            if (product == null)
                return false;

            _context.Products.Remove(product);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
