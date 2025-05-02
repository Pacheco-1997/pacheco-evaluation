// WebApi/Features/Sales/DeleteSale/DeleteSaleWebApiProfile.cs
using AutoMapper;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.DeleteSale;
using Ambev.DeveloperEvaluation.Application.Sales.DeleteSale;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.DeleteSale
{
    /// <summary>
    /// Maps API layer DeleteSaleRequest → Application layer DeleteSaleCommand
    /// </summary>
    public class DeleteSaleWebApiProfile : Profile
    {
        public DeleteSaleWebApiProfile()
        {
            CreateMap<DeleteSaleRequest, DeleteSaleCommand>();
        }
    }
}
