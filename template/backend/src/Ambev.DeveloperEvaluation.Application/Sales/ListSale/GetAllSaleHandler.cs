using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Application.Sales.ListSale;

namespace Ambev.DeveloperEvaluation.Application.Sales.ListSale;

    /// <summary>
    /// Handler for processing GetAllSaleQuery requests.
    /// </summary>
    public class GetAllSaleHandler : IRequestHandler<GetAllSaleQuery, List<GetAllSaleResult>>
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of <see cref="GetAllSaleHandler"/>.
        /// </summary>
        /// <param name="saleRepository">Repository for querying sales.</param>
        /// <param name="mapper">AutoMapper instance.</param>
        public GetAllSaleHandler(ISaleRepository saleRepository, IMapper mapper)
        {
            _saleRepository = saleRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Handles the GetAllSaleQuery by retrieving, filtering, and mapping sales.
        /// </summary>
        public async Task<List<GetAllSaleResult>> Handle(
            GetAllSaleQuery request,
            CancellationToken cancellationToken)
        {
            // 1) load all sales from repository
            var sales = await _saleRepository.GetAllAsync(cancellationToken);

            // 2) apply filters
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

            // 3) map to result DTOs
            return _mapper.Map<List<GetAllSaleResult>>(filtered);
        }
    }

