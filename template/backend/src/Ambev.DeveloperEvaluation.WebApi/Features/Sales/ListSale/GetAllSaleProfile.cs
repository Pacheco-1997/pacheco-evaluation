using Ambev.DeveloperEvaluation.Application.Sales.ListSale;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.ListSale;
public class GetAllSaleProfile : Profile
{
    public GetAllSaleProfile()
    {
       
        CreateMap<GetAllSaleRequest, GetAllSaleQuery>();
        CreateMap<GetAllSaleResult, GetAllSaleResponse>();
        CreateMap<GetAllSaleItemResult, GetAllSaleItemResponse>();
    }
}
