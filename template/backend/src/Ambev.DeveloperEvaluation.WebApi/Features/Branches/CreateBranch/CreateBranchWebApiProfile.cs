using AutoMapper;
using Ambev.DeveloperEvaluation.WebApi.Features.Branches.CreateBranch;
using Ambev.DeveloperEvaluation.Application.Branches.CreateBranch;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Branches.CreateBranch
{
    /// <summary>
    /// Profile for mapping between Application and API CreateBranch requests and responses
    /// </summary>
    public class CreateBranchWebApiProfile : Profile
    {
        /// <summary>
        /// Initializes the mappings for CreateBranch feature
        /// </summary>
        public CreateBranchWebApiProfile()
        {
            // Map API request to application command
            CreateMap<CreateBranchRequest, CreateBranchCommand>();
            // Map application result to API response
            CreateMap<CreateBranchResult, CreateBranchResponse>();
        }
    }
}
