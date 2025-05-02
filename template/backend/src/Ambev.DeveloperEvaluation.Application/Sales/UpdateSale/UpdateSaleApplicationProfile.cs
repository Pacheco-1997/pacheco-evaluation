// UpdateSaleApplicationProfile.cs
using Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;
using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Mappings
{
    public class UpdateSaleApplicationProfile : Profile
    {
        public UpdateSaleApplicationProfile()
        {
            CreateMap<UpdateSaleCommand, UpdateSaleResult>();
            CreateMap<UpdateSaleItemCommand, UpdateSaleItemResult>();
            CreateMap<Sale, UpdateSaleResult>()
                .ForMember(dest => dest.TotalAmount, opt => opt.MapFrom(src => src.Items.Where(i => !i.IsCancelled).Sum(i => i.ItemTotalAfterDiscount)));
            CreateMap<SaleItem, UpdateSaleItemResult>()
                .ForMember(dest => dest.ItemTotal, opt => opt.MapFrom(src => src.ItemTotalAfterDiscount)); 
        }
    }
}
