using MediatR;

namespace TreeNode.Application.Nodes.Commands;

public record UpdateNodeCommand(int NodeId, string Name) : IRequest;