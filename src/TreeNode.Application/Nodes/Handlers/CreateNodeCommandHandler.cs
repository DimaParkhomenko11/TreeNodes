using MediatR;
using Microsoft.EntityFrameworkCore;
using TreeNode.Application.Exceptions;
using TreeNode.Application.Nodes.Commands;
using TreeNode.Domain.Entities;
using TreeNode.Persistence.Contexts;

namespace TreeNode.Application.Nodes.Handlers;

public class CreateNodeCommandHandler : IRequestHandler<CreateNodeCommand, int>
{
    private readonly TreeNodeDbContext _dbContext;

    public CreateNodeCommandHandler(TreeNodeDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int> Handle(CreateNodeCommand request, CancellationToken cancellationToken)
    {
        var parentNode = await _dbContext.Nodes
                             .FirstOrDefaultAsync(n =>
                                 n.Id == request.ParentNodeId, cancellationToken)
                         ?? throw new SecureException("Node not found");

        var tree = await _dbContext.Nodes
                       .FirstOrDefaultAsync(n =>
                           n.ParentNodeId == null &&
                           n.Name == request.TreeName, cancellationToken)
                   ?? throw new SecureException("Tree not found");

        if (parentNode.Id != tree.Id)
            if (!IsChildElementExists(tree, parentNode.Id))
                throw new SecureException("Requested node was found, but it doesn't belong your tree");

        if (parentNode.Children.Any(n => n.Name == request.NodeName))
            throw new SecureException("Duplicate name");


        var newNode = await _dbContext.Nodes.AddAsync(new Node
        {
            Name = request.NodeName,
            ParentNodeId = parentNode.Id
        }, cancellationToken);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return newNode.Entity.Id;
    }

    private bool IsChildElementExists(Node parentNode, int childId)
    {
        if (parentNode.Children == null)
            return false;

        foreach (var childNode in parentNode.Children)
        {
            if (childNode.Id == childId)
                return true;

            if (IsChildElementExists(childNode, childId))
                return true;
        }

        return false;
    }
}