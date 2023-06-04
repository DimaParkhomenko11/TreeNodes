using AutoMapper;
using TreeNode.Application.ExceptionRecords.Results;
using TreeNode.Domain.Entities;

namespace TreeNode.Application.ExceptionRecords.MapperProfiles;

public class ExceptionRecordsProfile : Profile
{
    public ExceptionRecordsProfile()
    {
        #region Domain => Result

        CreateMap<ExceptionRecord, ExceptionRecordDetailsResult>(MemberList.None);

        #endregion
        
    }
}