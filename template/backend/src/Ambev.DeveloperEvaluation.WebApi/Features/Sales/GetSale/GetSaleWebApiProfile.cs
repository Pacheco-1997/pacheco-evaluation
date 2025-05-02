using AutoMapper;
using Ambev.DeveloperEvaluation.Application.Sales.GetSale;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSale;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSale
{
    public class GetSaleWebApiProfile : Profile
    {
        public GetSaleWebApiProfile()
        {
            CreateMap<GetSaleRequest, GetSaleQuery>();
            CreateMap<GetSaleResult, GetSaleResponse>();
            CreateMap<GetSaleItemResult, GetSaleItemResponse>();
        }
    }
}
