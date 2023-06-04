using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TreeNode.Application.Exceptions;
using TreeNode.Application.Trees.Query;
using TreeNode.Application.Trees.Results;
using TreeNode.Persistence.Contexts;

namespace TreeNode.Application.Trees.Handlers;

public class GetTreeDetailsQueryHandler : IRequestHandler<GetTreeDetailsQuery, TreeDetailsQueryResult>
{
    private readonly TreeNodeDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetTreeDetailsQueryHandler(TreeNodeDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<TreeDetailsQueryResult> Handle(GetTreeDetailsQuery request, CancellationToken cancellationToken)
    {
        var node = await _dbContext.Nodes
                       .FirstOrDefaultAsync(t =>
                           t.ParentNodeId == null &&
                           t.Id == request.Id, cancellationToken)
                   ?? throw new SecureException("Tree not found");

        return _mapper.Map<TreeDetailsQueryResult>(node);
    }
}