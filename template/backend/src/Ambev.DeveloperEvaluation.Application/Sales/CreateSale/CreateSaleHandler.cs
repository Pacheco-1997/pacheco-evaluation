using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

public class CreateSaleHandler : IRequestHandler<CreateSaleCommand, CreateSaleResult>
{
    private readonly ISaleRepository _saleRepository;
    private readonly IUserRepository _userRepository;
    private readonly IBranchRepository _branchRepository;
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public CreateSaleHandler(
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

    public async Task<CreateSaleResult> Handle(CreateSaleCommand command, CancellationToken cancellationToken)
    {
        // 1) validação
        var validator = new CreateSaleCommandValidator();
        var validation = await validator.ValidateAsync(command, cancellationToken);
        if (!validation.IsValid)
            throw new ValidationException(validation.Errors);

        // 2) consulta cliente e filial
        var user = await _userRepository.GetByIdAsync(command.CustomerId, cancellationToken)
                   ?? throw new Exception($"User {command.CustomerId} not found.");

        var branch = await _branchRepository.GetByIdAsync(command.BranchId, cancellationToken)
                     ?? throw new Exception($"Branch {command.BranchId} not found.");

        // 3) para cada item do comando, busca no repositório o produto real
        var products = new List<(Guid productId, string productTitle, decimal unitPrice, int quantity)>();
        foreach (var item in command.Items)
        {
            var prod = await _productRepository.GetByIdAsync(item.ProductId, cancellationToken)
                       ?? throw new Exception($"Product {item.ProductId} not found.");

            products.Add((
                prod.Id,
                prod.Title,
                prod.UnitPrice,     // PEGA AQUI O PREÇO DO BANCO
                item.Quantity   // mantém a quantidade enviada
            ));
        }

        // 4) cria a entidade Sale usando o factory estático
        var sale = Sale.Create(
            command.CustomerId,
            $"{user.Name.Firstname} {user.Name.Lastname}",
            command.BranchId,
            branch.Name,
            command.SaleDate,
            products
        );

        // 5) persiste
        await _saleRepository.AddAsync(sale, cancellationToken);

        // 6) retorna o resultado
        return _mapper.Map<CreateSaleResult>(sale);
    }
}
