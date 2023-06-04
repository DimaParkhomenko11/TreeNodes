using AutoMapper;
using TreeNode.Api.Trees.Responses;
using TreeNode.Application.Trees.Results;

namespace TreeNode.Api.Trees.MapperProfiles;

public class TreeProfile : Profile
{
    public TreeProfile()
    {
        #region Result => Response
        
        CreateMap<TreesQueryResult, TreesResponse>(MemberList.None);
        CreateMap<TreeDetailsQueryResult, TreeDetailsResponse>(MemberList.None);

        #endregion
    }
}