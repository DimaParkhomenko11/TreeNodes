using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TreeNode.Api.Trees.Filters;
using TreeNode.Api.Trees.Requests;
using TreeNode.Api.Trees.Responses;
using TreeNode.Application.Exceptions;
using TreeNode.Application.Trees.Commands;
using TreeNode.Application.Trees.Query;

namespace TreeNode.Api.Trees.Controllers;

/// <summary>
///     Controller for trees management
/// </summary>
[ApiController]
[Route("api/trees")]
public class TreesController : ControllerBase
{
    private readonly ISender _sender;
    private readonly IMapper _mapper;

    /// <summary>
    ///     Constructor for trees management
    /// </summary>
    public TreesController(ISender sender, IMapper mapper)
    {
        _sender = sender;
        _mapper = mapper;
    }

    #region GET

    /// <summary>
    ///     Gets trees
    /// </summary>
    [HttpGet]
    [SwaggerResponse(StatusCodes.Status200OK, "Trees", typeof(ICollection<TreesResponse>))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "Error data", typeof(ErrorDetails))]
    public async Task<IActionResult> GetTreesAsync([FromQuery] TreesFilter filter, CancellationToken token)
    {
        var result = await _sender.Send(new GetTreesQuery(filter.Skip, filter.Take), token);

        var response = _mapper.Map<ICollection<TreesResponse>>(result);

        return Ok(response);
    }


    /// <summary>
    ///     Gets tree by id
    /// </summary>
    [HttpGet("{id:int}")]
    [SwaggerResponse(StatusCodes.Status200OK, "Tree details", typeof(TreeDetailsResponse))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "Error data", typeof(ErrorDetails))]
    public async Task<IActionResult> GetTreeDetailsAsync([FromRoute] int id, CancellationToken token)
    {
        var result = await _sender.Send(new GetTreeDetailsQuery(id), token);

        var response = _mapper.Map<TreeDetailsResponse>(result);

        return Ok(response);
    }

    #endregion

    #region POST

    /// <summary>
    ///     Creates new tree
    /// </summary>
    [HttpPost]
    [SwaggerResponse(StatusCodes.Status201Created, "New tree id", typeof(int))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "Error data", typeof(ErrorDetails))]
    public async Task<IActionResult> CreateTreeAsync([FromBody] CreateTreeRequest request, CancellationToken token)
    {
        var result = await _sender.Send(new CreateTreeCommand(request.Name), token);
        return StatusCode(StatusCodes.Status201Created, result);
    }

    #endregion
}