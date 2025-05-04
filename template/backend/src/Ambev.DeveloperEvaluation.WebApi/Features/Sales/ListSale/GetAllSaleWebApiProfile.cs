using Ambev.DeveloperEvaluation.Application.Sales.ListSale;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.ListSale
{ 
public class GetAllSaleWebApiProfile : Profile
{
    public GetAllSaleWebApiProfile()
    {

        CreateMap<GetAllSaleRequest, GetAllSaleQuery>()
            .ForMember(dest => dest.Page, opt => opt.MapFrom(src => src.Page))
            .ForMember(dest => dest.Size, opt => opt.MapFrom(src => src.Size))
            .ForMember(dest => dest.Order, opt => opt.MapFrom(src => src.Order));
        CreateMap<GetAllSaleResult, GetAllSaleResponse>();
        CreateMap<GetAllSaleItemResult, GetAllSaleItemResponse>();
    }
}
}