using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TreeNode.Application.Trees.Query;
using TreeNode.Application.Trees.Results;
using TreeNode.Persistence.Contexts;

namespace TreeNode.Application.Trees.Handlers;

public class GetTreesQueryHandler : IRequestHandler<GetTreesQuery, ICollection<TreesQueryResult>>
{
    private readonly TreeNodeDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetTreesQueryHandler(TreeNodeDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<ICollection<TreesQueryResult>> Handle(GetTreesQuery request, CancellationToken cancellationToken)
    {
        return await _dbContext.Nodes
            .Where(t =>
                t.ParentNodeId == null)
            .Skip(request.Skip.GetValueOrDefault())
            .Take(request.Take)
            .ProjectTo<TreesQueryResult>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
    }
}