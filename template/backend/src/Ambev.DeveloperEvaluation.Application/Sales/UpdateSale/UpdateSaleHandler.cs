using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale
{
    public class UpdateSaleHandler : IRequestHandler<UpdateSaleCommand, UpdateSaleResult>
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IUserRepository _userRepository;
        private readonly IBranchRepository _branchRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public UpdateSaleHandler(
            ISaleRepository saleRepository,
            IUserRepository userRepository,
            IBranchRepository branchRepository,
            IProductRepository productRepository,
            IMapper mapper)
        {
            _saleRepository = saleRepository;
            _userRepository = userRepository;
            _branchRepository = branchRepository;
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<UpdateSaleResult> Handle(UpdateSaleCommand command, CancellationToken cancellationToken)
        {
            // 1) Validação
            var validator = new UpdateSaleCommandValidator();
            var validationResult = await validator.ValidateAsync(command, cancellationToken);
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            // 2) Busca venda existente
            var existingSale = await _saleRepository.GetByIdAsync(command.Id, cancellationToken)
                               ?? throw new Exception($"Sale {command.Id} not found.");

            // 3) Verifica cliente e filial
            var user = await _userRepository.GetByIdAsync(command.CustomerId, cancellationToken)
                       ?? throw new Exception($"User {command.CustomerId} not found.");

            var branch = await _branchRepository.GetByIdAsync(command.BranchId, cancellationToken)
                         ?? throw new Exception($"Branch {command.BranchId} not found.");

            // 4) Atualiza itens da venda com produtos do banco
            var products = new List<(Guid productId, string productTitle, decimal unitPrice, int quantity, bool isCancelled)>();
            foreach (var item in command.Items)
            {
                var product = await _productRepository.GetByIdAsync(item.ProductId, cancellationToken)
                              ?? throw new Exception($"Product {item.ProductId} not found.");

                products.Add((
                    product.Id,
                    product.Title,
                    product.UnitPrice,
                    item.Quantity,
                    item.IsCancelled
                ));
            }

            // 5) Atualiza entidade
            existingSale.Update(
                command.CustomerId,
                $"{user.Name.Firstname} {user.Name.Lastname}",
                command.BranchId,
                branch.Name,
                command.SaleDate,
                command.IsCancelled,
                products
            );

            // 6) Persiste
            await _saleRepository.UpdateAsync(existingSale, cancellationToken);

            // 7) Retorna resultado
            UpdateSaleResult result = _mapper.Map<UpdateSaleResult>(existingSale);
            return result;
        }
    }
}
