using AutoMapper;
using TreeNode.Application.Trees.Results;
using TreeNode.Domain.Entities;

namespace TreeNode.Application.Trees.MapperProfiles;

public class TreeProfile : Profile
{
    public TreeProfile()
    {
        #region Domain => Result

        CreateMap<Node, TreesQueryResult>(MemberList.None);
        CreateMap<Node, TreeDetailsQueryResult>(MemberList.None);

        #endregion
    }
}