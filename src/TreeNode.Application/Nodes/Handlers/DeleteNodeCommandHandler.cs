using MediatR;
using Microsoft.EntityFrameworkCore;
using TreeNode.Application.Exceptions;
using TreeNode.Application.Nodes.Commands;
using TreeNode.Persistence.Contexts;

namespace TreeNode.Application.Nodes.Handlers;

public class DeleteNodeCommandHandler : IRequestHandler<DeleteNodeCommand>
{
    private readonly TreeNodeDbContext _dbContext;

    public DeleteNodeCommandHandler(TreeNodeDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Handle(DeleteNodeCommand request, CancellationToken cancellationToken)
    {
        var node = await _dbContext.Nodes
                       .FirstOrDefaultAsync(n =>
                           n.Id == request.Id && 
                           n.ParentNodeId != null, cancellationToken)
                   ?? throw new SecureException("Node not found");

        if (node.Children.Any())
            throw new SecureException("You have to delete all children nodes first");

        _dbContext.Remove(node);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}