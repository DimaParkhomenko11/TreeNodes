using MediatR;
using TreeNode.Application.ExceptionRecords.Results;

namespace TreeNode.Application.ExceptionRecords.Query;

public record GetExceptionRecordDetailsQuery(int Id) : IRequest<ExceptionRecordDetailsResult>;