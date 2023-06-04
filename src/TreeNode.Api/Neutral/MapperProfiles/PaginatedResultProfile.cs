using AutoMapper;
using TreeNode.Application.Contracts.Pagination;
using TreeNode.Application.Interfaces;

namespace TreeNode.Api.Neutral.MapperProfiles;

public class PaginatedResultProfile : Profile
{
    public PaginatedResultProfile()
    {
        CreateMap(typeof(IPaginatedResult<>), typeof(IPaginatedResult<>));

        CreateMap(typeof(PaginatedResult<>), typeof(PaginatedResult<>));
    }
}