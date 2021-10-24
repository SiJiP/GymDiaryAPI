using System.Collections.Generic;
using System.Threading.Tasks;
using GymDiaryAPI.Common.Interfaces;
using GymDiaryAPI.DTOs;

namespace GymDiaryAPI.BusinessLayers.Interfaces
{
    public interface IUserBl
    {
        Task<IEnumerable<MemberDto>> GetMembersAsync();

        Task<MemberDto> GetMemberByIdAsync(int id);

        Task<IResponseObjectMessage<MemberDto>> UpdateMember(int id);

        Task<IResponseMessage> DeleteMember(int id);
    }
}