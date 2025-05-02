using Ambev.DeveloperEvaluation.Application.Sales.ListSale;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.ListSale
{ 
public class GetAllSaleWebApiProfile : Profile
{
    public GetAllSaleWebApiProfile()
    {
       
        CreateMap<GetAllSaleRequest, GetAllSaleQuery>();
        CreateMap<GetAllSaleResult, GetAllSaleResponse>();
        CreateMap<GetAllSaleItemResult, GetAllSaleItemResponse>();
    }
}
}