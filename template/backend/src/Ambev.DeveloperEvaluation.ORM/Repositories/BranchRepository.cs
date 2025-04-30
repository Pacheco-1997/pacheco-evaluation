﻿using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    /// <summary>
    /// Implementation of IBranchRepository using Entity Framework Core
    /// </summary>
    public class BranchRepository : IBranchRepository
    {
        private readonly DefaultContext _context;

        /// <summary>
        /// Initializes a new instance of BranchRepository
        /// </summary>
        /// <param name="context">The database context</param>
        public BranchRepository(DefaultContext context)
        {
            _context = context;
        }

        /// <inheritdoc />
        public async Task<Branch> CreateAsync(Branch branch, CancellationToken cancellationToken = default)
        {
            await _context.Branches.AddAsync(branch, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return branch;
        }

        /// <inheritdoc />
        public async Task<Branch?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Branches
                .FirstOrDefaultAsync(b => b.Id == id, cancellationToken);
        }

        /// <inheritdoc />
        public async Task<IEnumerable<Branch>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Branches
                .ToListAsync(cancellationToken);
        }

        /// <inheritdoc />
        public async Task<Branch?> GetByNameAsync(string name, CancellationToken cancellationToken = default)
        {
            return await _context.Branches
                .FirstOrDefaultAsync(b => b.Name == name, cancellationToken);
        }

        /// <inheritdoc />
        public async Task<bool> UpdateAsync(Branch branch, CancellationToken cancellationToken = default)
        {
            var existing = await GetByIdAsync(branch.Id, cancellationToken);
            if (existing == null)
                return false;

            existing.Update(branch.Name, branch.Address);
            _context.Branches.Update(existing);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        /// <inheritdoc />
        public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var branch = await GetByIdAsync(id, cancellationToken);
            if (branch == null)
                return false;

            _context.Branches.Remove(branch);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
