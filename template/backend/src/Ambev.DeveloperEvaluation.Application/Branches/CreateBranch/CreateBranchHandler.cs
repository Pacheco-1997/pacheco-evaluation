using AutoMapper;
using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Common.Validation;

namespace Ambev.DeveloperEvaluation.Application.Branches.CreateBranch
{
    /// <summary>
    /// Handler for processing CreateBranchCommand requests
    /// </summary>
    public class CreateBranchHandler : IRequestHandler<CreateBranchCommand, CreateBranchResult>
    {
        private readonly IBranchRepository _branchRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of CreateBranchHandler
        /// </summary>
        /// <param name="branchRepository">The branch repository</param>
        /// <param name="mapper">The AutoMapper instance</param>
        public CreateBranchHandler(IBranchRepository branchRepository, IMapper mapper)
        {
            _branchRepository = branchRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Handles the CreateBranchCommand request
        /// </summary>
        /// <param name="command">The CreateBranch command</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The created branch details</returns>
        public async Task<CreateBranchResult> Handle(CreateBranchCommand command, CancellationToken cancellationToken)
        {
            // Validate the command
            var validator = new CreateBranchCommandValidator();
            var validationResult = await validator.ValidateAsync(command, cancellationToken);
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            // Optionally check for existing branch by name
            var existing = await _branchRepository.GetByNameAsync(command.Name, cancellationToken);
            if (existing != null)
                throw new InvalidOperationException($"Branch with name '{command.Name}' already exists.");

            // Map to domain entity and persist
            var branch = new Branch(command.Name, command.Address);
            var createdBranch = await _branchRepository.CreateAsync(branch, cancellationToken);

            // Map to result DTO
            var result = _mapper.Map<CreateBranchResult>(createdBranch);
            return result;
        }
    }
}