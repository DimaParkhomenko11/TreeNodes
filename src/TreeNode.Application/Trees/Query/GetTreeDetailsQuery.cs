using MediatR;
using TreeNode.Application.Trees.Results;

namespace TreeNode.Application.Trees.Query;

public record GetTreeDetailsQuery(int Id) : IRequest<TreeDetailsQueryResult>;