using MediatR;

namespace TreeNode.Application.Nodes.Commands;

public sealed record CreateNodeCommand(int ParentNodeId, string TreeName, string NodeName) : IRequest<int>;