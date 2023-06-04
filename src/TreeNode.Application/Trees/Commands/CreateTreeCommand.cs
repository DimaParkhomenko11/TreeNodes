using MediatR;

namespace TreeNode.Application.Trees.Commands;

public record CreateTreeCommand(string Name) : IRequest<int>;