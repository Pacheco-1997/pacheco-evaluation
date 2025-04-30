using AutoMapper;
using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Common.Validation;

namespace Ambev.DeveloperEvaluation.Application.Products.CreateProduct
{
    /// <summary>
    /// Handler for processing CreateProductCommand requests
    /// </summary>
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, CreateProductResult>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of CreateProductHandler
        /// </summary>
        /// <param name="productRepository">The product repository</param>
        /// <param name="mapper">The AutoMapper instance</param>
        public CreateProductHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Handles the CreateProductCommand request
        /// </summary>
        /// <param name="command">The CreateProduct command</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The created product details</returns>
        public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            // Validate command
            var validator = new CreateProductCommandValidator();
            var validationResult = await validator.ValidateAsync(command, cancellationToken);
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            // Optionally check for existing product by title
            var existing = await _productRepository.GetByTitleAsync(command.Title, cancellationToken);
            if (existing != null)
                throw new InvalidOperationException($"Product with title '{command.Title}' already exists.");

            // Map to domain entity and persist
            var product = _mapper.Map<Product>(command);
            var created = await _productRepository.CreateAsync(product, cancellationToken);

            // Map to result DTO
            var result = _mapper.Map<CreateProductResult>(created);
            return result;
        }
    }
}
