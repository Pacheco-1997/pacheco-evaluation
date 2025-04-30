using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Application.Branches.CreateBranch;

namespace Ambev.DeveloperEvaluation.Application.Branches.CreateBranch
{
    /// <summary>
    /// Profile for mapping between CreateBranchCommand, Branch entity and CreateBranchResult
    /// </summary>
    public class CreateBranchProfile : Profile
    {
        /// <summary>
        /// Initializes the mappings for CreateBranch operation
        /// </summary>
        public CreateBranchProfile()
        {
            // Map from application command to domain entity
            CreateMap<CreateBranchCommand, Branch>()
                .ConstructUsing(cmd => new Branch(cmd.Name, cmd.Address));

            // Map from domain entity to application result
            CreateMap<Branch, CreateBranchResult>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address));
        }
    }
}
