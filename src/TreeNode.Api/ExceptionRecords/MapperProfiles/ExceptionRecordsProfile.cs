using AutoMapper;
using TreeNode.Api.ExceptionRecords.Filters;
using TreeNode.Api.ExceptionRecords.Responses;
using TreeNode.Application.ExceptionRecords.Query;
using TreeNode.Application.ExceptionRecords.Results;

namespace TreeNode.Api.ExceptionRecords.MapperProfiles;

public class ExceptionRecordsProfile : Profile
{
    public ExceptionRecordsProfile()
    {
        #region Result => Response
        
        CreateMap<ExceptionRecordsResult, ExceptionRecordsResponse>(MemberList.None);
        CreateMap<ExceptionRecordDetailsResult, ExceptionRecordDetailsResponse>(MemberList.None);

        #endregion
        
        #region Filter => Query
        
        CreateMap<ExceptionRecordsFilter, GetExceptionRecordsQuery>(MemberList.None);

        #endregion
    }
}