using MediatR;

namespace TreeNode.Application.Nodes.Commands;

public record DeleteNodeCommand(int Id) : IRequest;