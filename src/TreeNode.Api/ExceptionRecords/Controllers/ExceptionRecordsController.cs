using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TreeNode.Api.ExceptionRecords.Filters;
using TreeNode.Api.ExceptionRecords.Responses;
using TreeNode.Application.Contracts.Pagination;
using TreeNode.Application.ExceptionRecords.Query;
using TreeNode.Application.Exceptions;

namespace TreeNode.Api.ExceptionRecords.Controllers;

/// <summary>
///     Controller for exception records management
/// </summary>
[ApiController]
[Route("api/exceptions")]
public class ExceptionRecordsController : ControllerBase
{
    private readonly ISender _sender;
    private readonly IMapper _mapper;
    
    /// <summary>
    ///     Constructor for exception records management
    /// </summary>
    public ExceptionRecordsController(ISender sender, IMapper mapper)
    {
        _sender = sender;
        _mapper = mapper;
    }
    
    #region GET

    /// <summary>
    ///     Gets exception records
    /// </summary>
    [HttpGet]
    [SwaggerResponse(StatusCodes.Status200OK, "Exception records", typeof(PaginatedResult<ExceptionRecordsResponse>))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "Error data", typeof(ErrorDetails))]
    public async Task<IActionResult> GetAllExceptionRecordsAsync([FromQuery] ExceptionRecordsFilter filter, CancellationToken token)
    {
        var result = await _sender.Send(_mapper.Map<GetExceptionRecordsQuery>(filter), token);

        var response = _mapper.Map<PaginatedResult<ExceptionRecordsResponse>>(result);

        return Ok(response);
    }


    /// <summary>
    ///     Gets exception record by id
    /// </summary>
    [HttpGet("{id:int}")]
    [SwaggerResponse(StatusCodes.Status200OK, "Exception record details", typeof(ExceptionRecordDetailsResponse))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "Error data", typeof(ErrorDetails))]
    public async Task<IActionResult> GetExceptionRecordDetails([FromRoute] int id, CancellationToken token)
    {
        var result = await _sender.Send(new GetExceptionRecordDetailsQuery(id), token);

        var response = _mapper.Map<ExceptionRecordDetailsResponse>(result);

        return Ok(response);
    }

    #endregion
}