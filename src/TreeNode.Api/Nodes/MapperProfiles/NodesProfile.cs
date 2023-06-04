using AutoMapper;
using TreeNode.Api.Nodes.Requests;
using TreeNode.Application.Nodes.Commands;

namespace TreeNode.Api.Nodes.MapperProfiles;

public class NodesProfile : Profile
{
    public NodesProfile()
    {
        #region Request => Command
        
        CreateMap<CreateNodeRequest, CreateNodeCommand>(MemberList.None);
        
        #endregion
    }
}