using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Application.Products.CreateProduct;
//using Ambev.DeveloperEvaluation.Application.Products.UpdateProduct;
//using Ambev.DeveloperEvaluation.Application.Products.GetProduct;
//using Ambev.DeveloperEvaluation.Application.Products.GetAllProducts;

namespace Ambev.DeveloperEvaluation.Application.Products
{
    /// <summary>
    /// Profile for mapping between Product entity and Application layer DTOs
    /// </summary>
    public class CreateProductProfile : Profile
    {
        /// <summary>
        /// Initializes the mappings for Product features
        /// </summary>
        public CreateProductProfile()
        {
            // Command -> Entity
            CreateMap<CreateProductCommand, Product>()
                .ConstructUsing(cmd => new Product(
                    cmd.Title,
                    cmd.Price,
                    cmd.Description,
                    cmd.Category,
                    cmd.Image,
                    cmd.RatingRate,
                    cmd.RatingCount
                ));

            // Entity -> Result
            CreateMap<Product, CreateProductResult>()
                .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.ImageUrl))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.UnitPrice));

            //// Update mapping: UpdateProductCommand -> existing Product (handled in handler)
            //CreateMap<UpdateProductCommand, Product>()
            //    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            //    .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
            //    .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
            //    .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            //    .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category))
            //    .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.Image));

            //// Entity -> GetProductResult
            //CreateMap<Product, GetProductResult>();

            //// Entity list -> GetAllProductsResult
            //CreateMap<Product, GetAllProductsResult>();
        }
    }
}
