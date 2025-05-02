using AutoMapper;
using Ambev.DeveloperEvaluation.Application.Sales.GetSale;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Common.Mappings
{
    public class GetSaleApplicationProfile : Profile
    {
        public GetSaleApplicationProfile()
        {
            CreateMap<Sale, GetSaleResult>()
                .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.CustomerName))
                .ForMember(dest => dest.BranchName, opt => opt.MapFrom(src => src.BranchName))
                .ForMember(dest => dest.TotalAmount, opt => opt.MapFrom(src =>
                    src.Items.Where(i => !i.IsCancelled).Sum(i => i.ItemTotalAfterDiscount)))
                .ForMember(dest => dest.Subtotal, opt => opt.MapFrom(src =>
                    src.Items.Where(i => !i.IsCancelled).Sum(i => i.TotalItemAmount)))
                .ForMember(dest => dest.Total, opt => opt.MapFrom(src =>
                    src.Items.Where(i => !i.IsCancelled).Sum(i => i.ItemTotalAfterDiscount)))
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items));

            CreateMap<SaleItem, GetSaleItemResult>()
                .ForMember(dest => dest.ItemTotal, opt => opt.MapFrom(src => src.ItemTotalAfterDiscount));
        }
    }
}
