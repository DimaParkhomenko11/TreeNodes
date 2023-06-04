using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TreeNode.Application.ExceptionRecords.Query;
using TreeNode.Application.ExceptionRecords.Results;
using TreeNode.Application.Exceptions;
using TreeNode.Persistence.Contexts;

namespace TreeNode.Application.ExceptionRecords.Handlers;

public class
    GetExceptionRecordDetailsQueryHandler : IRequestHandler<GetExceptionRecordDetailsQuery,
        ExceptionRecordDetailsResult>
{
    private readonly TreeNodeDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetExceptionRecordDetailsQueryHandler(TreeNodeDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<ExceptionRecordDetailsResult> Handle(GetExceptionRecordDetailsQuery request,
        CancellationToken cancellationToken)
    {
        return await _dbContext.ExceptionRecords
                   .ProjectTo<ExceptionRecordDetailsResult>(_mapper.ConfigurationProvider)
                   .FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken)
               ?? throw new SecureException("Exception record not found");
    }
}