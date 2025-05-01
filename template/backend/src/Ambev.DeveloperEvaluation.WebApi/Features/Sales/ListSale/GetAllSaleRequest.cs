using Ambev.DeveloperEvaluation.Application.Sales.ListSale;
using MediatR;
using System;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.ListSale;


    public class GetAllSaleRequest : IRequest<List<GetAllSaleResponse>>
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public Guid? CustomerId { get; set; }
        public Guid? BranchId { get; set; }

        public bool? IsCancelled { get; set; }
    }

