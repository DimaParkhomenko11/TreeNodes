using MediatR;
using TreeNode.Application.ExceptionRecords.Results;
using TreeNode.Application.Interfaces;

namespace TreeNode.Application.ExceptionRecords.Query;

public record GetExceptionRecordsQuery(
    int? Skip,
    int Take,
    DateTime? From,
    DateTime? To,
    string? Search) : IRequest<IPaginatedResult<ExceptionRecordsResult>>;