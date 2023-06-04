using MediatR;
using Microsoft.EntityFrameworkCore;
using TreeNode.Application.Exceptions;
using TreeNode.Application.Trees.Commands;
using TreeNode.Domain.Entities;
using TreeNode.Persistence.Contexts;

namespace TreeNode.Application.Trees.Handlers;

public class CreateTreeCommandHandler : IRequestHandler<CreateTreeCommand, int>
{
    private readonly TreeNodeDbContext _dbContext;

    public CreateTreeCommandHandler(TreeNodeDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int> Handle(CreateTreeCommand request, CancellationToken cancellationToken)
    {
        if (await _dbContext.Nodes
                .AnyAsync(t =>
                    t.Name == request.Name &&
                    t.ParentNodeId == null, cancellationToken))
            throw new SecureException("Tree already exist");

        var newTree = await _dbContext.Nodes.AddAsync(new Node
        {
            Name = request.Name
        }, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);


        return newTree.Entity.Id;
    }
}