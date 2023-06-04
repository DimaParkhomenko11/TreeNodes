using MediatR;
using TreeNode.Application.Trees.Results;

namespace TreeNode.Application.Trees.Query;

public record GetTreesQuery(int? Skip, int Take) : IRequest<ICollection<TreesQueryResult>>;