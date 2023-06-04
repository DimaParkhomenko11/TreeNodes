using MediatR;
using Microsoft.EntityFrameworkCore;
using TreeNode.Application.Contracts.Pagination;
using TreeNode.Application.ExceptionRecords.Query;
using TreeNode.Application.ExceptionRecords.Results;
using TreeNode.Application.Interfaces;
using TreeNode.Persistence.Contexts;

namespace TreeNode.Application.ExceptionRecords.Handlers;

public class GetExceptionRecordsQueryHandler : 
    IRequestHandler<GetExceptionRecordsQuery, IPaginatedResult<ExceptionRecordsResult>>
{
    private readonly TreeNodeDbContext _dbContext;

    public GetExceptionRecordsQueryHandler(TreeNodeDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IPaginatedResult<ExceptionRecordsResult>> 
        Handle(GetExceptionRecordsQuery request, CancellationToken cancellationToken)
    {
        var exceptionRecordsQuery = _dbContext.ExceptionRecords
            .Where(e =>
                e.EventId.ToString() == request.Search ||
                request.Search == null);
        if (request.From.HasValue)
        {
            exceptionRecordsQuery = exceptionRecordsQuery.Where(e => e.CreatedAt >= request.From);
        }
        if (request.To.HasValue)
        {
            exceptionRecordsQuery = exceptionRecordsQuery.Where(e => e.CreatedAt <= request.To);
        }

        var exceptionRecords = await exceptionRecordsQuery
            .Skip(request.Skip.GetValueOrDefault())
            .Take(request.Take)
            .Select(e => new ExceptionRecordsResult
            {
                Id = e.Id,
                CreatedAt = e.CreatedAt,
                EventId = e.EventId.ToString()
            })
            .ToListAsync(cancellationToken);

        return new PaginatedResult<ExceptionRecordsResult>
        {
            Items = exceptionRecords,
            Count = exceptionRecords.Count,
            Skip = request.Skip.GetValueOrDefault()
        };
    }
}