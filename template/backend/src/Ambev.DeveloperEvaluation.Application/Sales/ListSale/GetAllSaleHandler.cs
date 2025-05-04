
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using MediatR;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Entities;
using System.Reflection;

namespace Ambev.DeveloperEvaluation.Application.Sales.ListSale
{
    /// <summary>
    /// Handler for processing GetAllSaleQuery requests with pagination.
    /// </summary>
    public class GetAllSaleHandler : IRequestHandler<GetAllSaleQuery, PagedResult<GetAllSaleResult>>
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IMapper _mapper;

        public GetAllSaleHandler(ISaleRepository saleRepository, IMapper mapper)
        {
            _saleRepository = saleRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<GetAllSaleResult>> Handle(GetAllSaleQuery request, CancellationToken cancellationToken)
        {
            // 1) Validação
            var validator = new GetAllSaleQueryValidator();
            var validation = await validator.ValidateAsync(request, cancellationToken);
            if (!validation.IsValid)
                throw new ValidationException(validation.Errors);

            // 2) Carrega vendas
            var sales = (await _saleRepository.GetAllAsync(cancellationToken)).AsQueryable();

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

            // 4) Ordenação via reflection em memória
            if (!string.IsNullOrWhiteSpace(request.Order))
            {
                // Exemplo: "SaleDate desc" ou "CustomerName asc" ou apenas "desc"/"asc"
                var token = request.Order.Trim();
                var parts = token.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string propName;
                bool desc;
                // Se formatado só como "desc" ou "asc", use SaleDate como propriedade padrão
                if (parts.Length == 1 && (parts[0].Equals("desc", StringComparison.OrdinalIgnoreCase) || parts[0].Equals("asc", StringComparison.OrdinalIgnoreCase)))
                {
                    propName = nameof(Sale.SaleDate);
                    desc = parts[0].Equals("desc", StringComparison.OrdinalIgnoreCase);
                }
                else
                {
                    propName = parts[0];
                    desc = parts.Length > 1 && parts[1].Equals("desc", StringComparison.OrdinalIgnoreCase);
                }

                // Usa reflection para obter propriedade
                var propInfo = typeof(Sale).GetProperty(propName, BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);
                if (propInfo == null)
                    throw new InvalidOperationException($"Cannot sort by unknown property '{propName}'");

                sales = desc
                    ? sales.OrderByDescending(s => propInfo.GetValue(s, null))
                    : sales.OrderBy(s => propInfo.GetValue(s, null));
            }
            else
            {
                sales = sales.OrderBy(s => s.SaleDate);
            }

            // 5) Paginação
            var totalItems = sales.Count();
            var page = request.Page < 1 ? 1 : request.Page;
            var size = request.Size < 1 ? 10 : request.Size;
            var totalPages = (int)Math.Ceiling(totalItems / (double)size);

            var paged = sales.Skip((page - 1) * size)
                             .Take(size)
                             .ToList();

            // 6) Mapeia para DTO
            var items = _mapper.Map<List<GetAllSaleResult>>(paged);

            return new PagedResult<GetAllSaleResult>
            {
                Items = items,
                TotalItems = totalItems,
                CurrentPage = page,
                TotalPages = totalPages
            };
        }
    }
}

