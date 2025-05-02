using AutoMapper;
using Ambev.DeveloperEvaluation.Application.Products.CreateProduct;
//using Ambev.DeveloperEvaluation.Application.Products.UpdateProduct;
//using Ambev.DeveloperEvaluation.Application.Products.GetAllProducts;
//using Ambev.DeveloperEvaluation.Application.Products.GetProduct;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.Dtos;
//using Ambev.DeveloperEvaluation.WebApi.Features.Products.UpdateProduct;
//using Ambev.DeveloperEvaluation.WebApi.Features.Products.GetAllProducts;
//using Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProduct;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products
{
    /// <summary>
    /// Profile for mapping between API models and Application layer for Product features
    /// </summary>
    public class CreateProductsProfile : Profile
    {
        public CreateProductsProfile()
        {
            //CreateMap<CreateProductResult, RatingDto>()
            //    .ForMember(dest => dest.Rate, opt => opt.MapFrom(src => src.RatingRate))
            //    .ForMember(dest => dest.Count, opt => opt.MapFrom(src => src.RatingCount));

            // Create
            CreateMap<CreateProductRequest, CreateProductCommand>();
            CreateMap<CreateProductResult, CreateProductResponse>()
                .ForPath(dest => dest.Rating.Rate, opt => opt.MapFrom(src => src.RatingRate))
                .ForPath(dest => dest.Rating.Count, opt => opt.MapFrom(src => src.RatingCount));

            //CreateMap<CreateProductResult, CreateProductResponse>()
            //    .ForMember(dest => dest.Rating, opt => opt.MapFrom(src => src));

            //// Update
            //CreateMap<UpdateProductRequest, UpdateProductCommand>();
            //CreateMap<UpdateProductResult, UpdateProductResponse>();

            //// Get single
            //CreateMap<GetProductQueryResult, GetProductResponse>();

            //// Get all / list
            //CreateMap<IEnumerable<GetProductQueryResult>, List<GetProductResponse>>()
            //    .ConvertUsing((src, dest, ctx) =>
            //        src.Select(item => ctx.Mapper.Map<GetProductResponse>(item)).ToList()
            //    );
        }
    }
}
