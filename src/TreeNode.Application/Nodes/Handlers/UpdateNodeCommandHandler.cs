using MediatR;
using Microsoft.EntityFrameworkCore;
using TreeNode.Application.Exceptions;
using TreeNode.Application.Nodes.Commands;
using TreeNode.Persistence.Contexts;

namespace TreeNode.Application.Nodes.Handlers;

public class UpdateNodeCommandHandler : IRequestHandler<UpdateNodeCommand>
{
    private readonly TreeNodeDbContext _dbContext;

    public UpdateNodeCommandHandler(TreeNodeDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Handle(UpdateNodeCommand request, CancellationToken cancellationToken)
    {
        var node = await _dbContext.Nodes
                       .FirstOrDefaultAsync(n =>
                           n.Id == request.NodeId &&
                           n.ParentNodeId != null, cancellationToken)
                   ?? throw new SecureException("Node not found");

        node.Name = request.Name;
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}