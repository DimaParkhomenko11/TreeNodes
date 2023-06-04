using MediatR;
using TreeNode.Application.ExceptionRecords.Commands;
using TreeNode.Domain.Entities;
using TreeNode.Persistence.Contexts;

namespace TreeNode.Application.ExceptionRecords.Handlers;

public class CreateExceptionRecordCommandHandler : IRequestHandler<CreateExceptionRecordCommand>
{
    private readonly TreeNodeDbContext _dbContext;

    public CreateExceptionRecordCommandHandler(TreeNodeDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Handle(CreateExceptionRecordCommand request, CancellationToken cancellationToken)
    {
        await _dbContext.ExceptionRecords.AddAsync(new ExceptionRecord
        {
            EventId = request.EventId,
            CreatedAt = request.Timestamp,
            Text = $"Request ID = {request.EventId} Path = {request.Path} Message = {request.Message} " +
                   $"QueryParameters = {request.QueryParameters} BodyParameters = {request.BodyParameters} " +
                   $"ExceptionStackTrace = {request.ExceptionStackTrace}"
            
        },cancellationToken);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}