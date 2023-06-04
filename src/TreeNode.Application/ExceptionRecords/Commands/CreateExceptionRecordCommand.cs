using MediatR;

namespace TreeNode.Application.ExceptionRecords.Commands;

public record CreateExceptionRecordCommand(
    Guid EventId,
    DateTime Timestamp,
    string? Path,
    string? Message,
    string? QueryParameters,
    string? BodyParameters, 
    string? ExceptionStackTrace) : IRequest;