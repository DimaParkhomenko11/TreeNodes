using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TreeNode.Api.Nodes.Requests;
using TreeNode.Application.Exceptions;
using TreeNode.Application.Nodes.Commands;

namespace TreeNode.Api.Nodes.Controllers;

/// <summary>
///     Controller for nodes management
/// </summary>
[ApiController]
[Route("api/nodes")]
public class NodesController : ControllerBase
{
    private readonly ISender _sender;
    private readonly IMapper _mapper;

    /// <summary>
    ///     Constructor for nodes management
    /// </summary>
    public NodesController(ISender sender, IMapper mapper)
    {
        _sender = sender;
        _mapper = mapper;
    }
    
    
    #region POST

    /// <summary>
    ///     Creates new node
    /// </summary>
    [HttpPost]
    [SwaggerResponse(StatusCodes.Status201Created, "New node id", typeof(int))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "Error data", typeof(ErrorDetails))]
    public async Task<IActionResult> CreateNodeAsync([FromQuery] CreateNodeRequest request, CancellationToken token)
    {
        var result = await _sender.Send(_mapper.Map<CreateNodeCommand>(request), token);
        return StatusCode(StatusCodes.Status201Created, result);
    }

    #endregion

    #region PUT

    /// <summary>
    ///     Updates node
    /// </summary>
    [HttpPut("{id:int}")]
    [SwaggerResponse(StatusCodes.Status200OK, "Node updated")]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "Error data", typeof(ErrorDetails))]
    public async Task<IActionResult> 
        UpdateNodeAsync([FromRoute] int id, [FromBody] UpdateNodeRequest request, CancellationToken token)
    {
        var command = new UpdateNodeCommand(id, request.Name);

        await _sender.Send(command, token);

        return Ok();
    }

    #endregion
    
    #region DELETE

    /// <summary>
    ///     Deletes node
    /// </summary>
    [HttpDelete("{id:int}")]
    [SwaggerResponse(StatusCodes.Status204NoContent, "Node deleted")]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "Error data", typeof(ErrorDetails))]
    public async Task<IActionResult> DeleteNodeAsync([FromRoute] int id, CancellationToken token)
    {
        await _sender.Send(new DeleteNodeCommand(id), token);
        return NoContent();
    }

    #endregion
    
}