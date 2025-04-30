using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

/// <summary>
/// Profile for mapping between Sale entity and CreateSaleResult
/// </summary>
public class CreateSaleProfile : Profile
{
    public CreateSaleProfile()
    {
        // Mapeia o comando principal
        CreateMap<CreateSaleCommand, Sale>();

        // Mapeia cada item de venda
        CreateMap<SaleItemCommand, SaleItem>()
        .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId))
        .ForMember(dest => dest.UnitPrice, opt => opt.MapFrom(src => src.UnitPrice))
        .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity));

        // Resultado
        CreateMap<Sale, CreateSaleResult>();
        CreateMap<SaleItem, CreateSaleItemResult>()
        .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId))
        .ForMember(dest => dest.UnitPrice, opt => opt.MapFrom(src => src.UnitPrice))
        .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity));
    }
}
