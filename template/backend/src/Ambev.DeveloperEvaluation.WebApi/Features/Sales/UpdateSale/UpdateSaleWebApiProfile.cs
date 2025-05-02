// UpdateSaleWebApiProfile.cs
using AutoMapper;
using Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale;


namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale
{
    /// <summary>
    /// Web API AutoMapper profile for UpdateSale feature
    /// </summary>
    public class UpdateSaleWebApiProfile : Profile
    {
        public UpdateSaleWebApiProfile()
        {
            // Map incoming API request DTO to application command
            CreateMap<UpdateSaleRequest, UpdateSaleCommand>();

            // Map each item DTO to application item command
            CreateMap<UpdateSaleItemRequest, UpdateSaleItemCommand>();

            // Map application result back to API response
            CreateMap<UpdateSaleResult, UpdateSaleResponse>();

            // Map each item result to API item response
            CreateMap<UpdateSaleItemResult, UpdateSaleItemResponse>();
        }
    }
}
