using MediatR;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.Branches.CreateBranch;
//using Ambev.DeveloperEvaluation.WebApi.Features.Branches.GetBranch;
//using Ambev.DeveloperEvaluation.WebApi.Features.Branches.GetAllBranches;
//using Ambev.DeveloperEvaluation.WebApi.Features.Branches.UpdateBranch;
//using Ambev.DeveloperEvaluation.WebApi.Features.Branches.DeleteBranch;
using Ambev.DeveloperEvaluation.Application.Branches.CreateBranch;
//using Ambev.DeveloperEvaluation.Application.Branches.GetBranch;
//using Ambev.DeveloperEvaluation.Application.Branches.GetAllBranches;
//using Ambev.DeveloperEvaluation.Application.Branches.UpdateBranch;
//using Ambev.DeveloperEvaluation.Application.Branches.DeleteBranch;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Branches
{
    /// <summary>
    /// Controller for managing branch operations
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class BranchesController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public BranchesController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        /// <summary>
        /// Retrieves all branches
        /// </summary>
        //[HttpGet]
        //[ProducesResponseType(typeof(ApiResponseWithData<GetAllBranchesResponse>), StatusCodes.Status200OK)]
        //public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        //{
        //    var query = new GetAllBranchesRequest();
        //    var validator = new GetAllBranchesRequestValidator();
        //    var validationResult = await validator.ValidateAsync(query, cancellationToken);
        //    if (!validationResult.IsValid)
        //        return BadRequest(validationResult.Errors);

        //    var command = _mapper.Map<GetAllBranchesQuery>(query);
        //    var response = await _mediator.Send(command, cancellationToken);

        //    return Ok(new ApiResponseWithData<GetAllBranchesResponse>
        //    {
        //        Success = true,
        //        Message = "Branches retrieved successfully",
        //        Data = _mapper.Map<GetAllBranchesResponse>(response)
        //    });
        //}

        /// <summary>
        /// Retrieves a branch by ID
        /// </summary>
        //[HttpGet("{id}")]
        //[ProducesResponseType(typeof(ApiResponseWithData<GetBranchResponse>), StatusCodes.Status200OK)]
        //[ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        //public async Task<IActionResult> GetById([FromRoute] Guid id, CancellationToken cancellationToken)
        //{
        //    var request = new GetBranchRequest { Id = id };
        //    var validator = new GetBranchRequestValidator();
        //    var validationResult = await validator.ValidateAsync(request, cancellationToken);
        //    if (!validationResult.IsValid)
        //        return BadRequest(validationResult.Errors);

        //    var command = _mapper.Map<GetBranchQuery>(request);
        //    var response = await _mediator.Send(command, cancellationToken);

        //    if (response == null)
        //        return NotFound(new ApiResponse { Success = false, Message = "Branch not found" });

        //    return Ok(new ApiResponseWithData<GetBranchResponse>
        //    {
        //        Success = true,
        //        Message = "Branch retrieved successfully",
        //        Data = _mapper.Map<GetBranchResponse>(response)
        //    });
        //}

        /// <summary>
        /// Creates a new branch
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(ApiResponseWithData<CreateBranchResponse>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateBranchRequest request, CancellationToken cancellationToken)
        {
            var validator = new CreateBranchRequestValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var command = _mapper.Map<CreateBranchCommand>(request);
            var response = await _mediator.Send(command, cancellationToken);

            return Created(string.Empty, new ApiResponseWithData<CreateBranchResponse>
            {
                Success = true,
                Message = "Branch created successfully",
                Data = _mapper.Map<CreateBranchResponse>(response)
            });
        }

        /// <summary>
        /// Updates an existing branch
        /// </summary>
        //[HttpPut("{id}")]
        //[ProducesResponseType(typeof(ApiResponseWithData<UpdateBranchResponse>), StatusCodes.Status200OK)]
        //[ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        //public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateBranchRequest request, CancellationToken cancellationToken)
        //{
        //    request.Id = id;
        //    var validator = new UpdateBranchRequestValidator();
        //    var validationResult = await validator.ValidateAsync(request, cancellationToken);
        //    if (!validationResult.IsValid)
        //        return BadRequest(validationResult.Errors);

        //    var command = _mapper.Map<UpdateBranchCommand>(request);
        //    var response = await _mediator.Send(command, cancellationToken);

        //    return Ok(new ApiResponseWithData<UpdateBranchResponse>
        //    {
        //        Success = true,
        //        Message = "Branch updated successfully",
        //        Data = _mapper.Map<UpdateBranchResponse>(response)
        //    });
        //}

        /// <summary>
        /// Deletes a branch by ID
        /// </summary>
        //[HttpDelete("{id}")]
        //[ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
        //[ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        //public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken cancellationToken)
        //{
        //    var request = new DeleteBranchRequest { Id = id };
        //    var validator = new DeleteBranchRequestValidator();
        //    var validationResult = await validator.ValidateAsync(request, cancellationToken);
        //    if (!validationResult.IsValid)
        //        return BadRequest(validationResult.Errors);

        //    var command = _mapper.Map<DeleteBranchCommand>(request);
        //    await _mediator.Send(command, cancellationToken);

        //    return Ok(new ApiResponse { Success = true, Message = "Branch deleted successfully" });
        //}
    }
}
