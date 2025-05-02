using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using MediatR;
using Ambev.DeveloperEvaluation.Domain.Repositories;

namespace Ambev.DeveloperEvaluation.Application.Sales.ListSale
{
    /// <summary>
    /// Handler for processing GetAllSaleQuery requests.
    /// </summary>
    public class GetAllSaleHandler : IRequestHandler<GetAllSaleQuery, List<GetAllSaleResult>>
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IMapper _mapper;

        public GetAllSaleHandler(ISaleRepository saleRepository, IMapper mapper)
        {
            _saleRepository = saleRepository;
            _mapper = mapper;
        }

        public async Task<List<GetAllSaleResult>> Handle(GetAllSaleQuery request, CancellationToken cancellationToken)
        {
            // 1) Validação
            var validator = new GetAllSaleQueryValidator();
            var validation = await validator.ValidateAsync(request, cancellationToken);
            if (!validation.IsValid)
                throw new ValidationException(validation.Errors);

            // 2) Carrega vendas
            var sales = await _saleRepository.GetAllAsync(cancellationToken);

            // 3) Filtros
            if (request.StartDate.HasValue)
                sales = sales.Where(s => s.SaleDate >= request.StartDate.Value);

            if (request.EndDate.HasValue)
                sales = sales.Where(s => s.SaleDate <= request.EndDate.Value);

            if (request.CustomerId.HasValue)
                sales = sales.Where(s => s.CustomerId == request.CustomerId.Value);

            if (request.BranchId.HasValue)
                sales = sales.Where(s => s.BranchId == request.BranchId.Value);

            if (request.IsCancelled.HasValue)
                sales = sales.Where(s => s.IsCancelled == request.IsCancelled.Value);

            var filtered = sales.ToList();

            // 4) Map para DTO
            return _mapper.Map<List<GetAllSaleResult>>(filtered);
        }
    }
}
