using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;


namespace Ambev.DeveloperEvaluation.Application.Sales.ListSale;

    /// <summary>
    /// Profile for mapping Sale and SaleItem entities
    /// to GetAllSaleResult and GetAllSaleItemResult DTOs.
    /// </summary>
    public class GetAllSaleApplicationProfile : Profile
    {
        public GetAllSaleApplicationProfile()
        {
            // Map Sale → GetAllSaleResult
            CreateMap<Sale, GetAllSaleResult>()
                .ForMember(dest => dest.Subtotal,
                           opt => opt.MapFrom(src => src.Subtotal))
                .ForMember(dest => dest.Total,
                           opt => opt.MapFrom(src => src.Total))
                .ForMember(dest => dest.IsCancelled,
                           opt => opt.MapFrom(src => src.IsCancelled))
                .ForMember(dest => dest.Items,
                           opt => opt.MapFrom(src => src.Items))
                .ForMember(dest => dest.TotalAmount, opt => opt.MapFrom(src =>
                            src.Items != null ? src.Items.Sum(i => i.ItemTotalAfterDiscount) : 0
                ));

        // Map SaleItem → GetAllSaleItemResult
        CreateMap<SaleItem, GetAllSaleItemResult>()
                .ForMember(dest => dest.ProductId,
                           opt => opt.MapFrom(src => src.ProductId))
                .ForMember(dest => dest.ProductTitle,
                           opt => opt.MapFrom(src => src.ProductTitle))
                .ForMember(dest => dest.UnitPrice,
                           opt => opt.MapFrom(src => src.UnitPrice))
                .ForMember(dest => dest.Quantity,
                           opt => opt.MapFrom(src => src.Quantity))
                .ForMember(dest => dest.Discount,
                           opt => opt.MapFrom(src => src.Discount))
                .ForMember(dest => dest.IsCancelled,
                           opt => opt.MapFrom(src => src.IsCancelled));

   
    }
    }

