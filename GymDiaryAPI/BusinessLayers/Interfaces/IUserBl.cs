using System.Collections.Generic;
using System.Threading.Tasks;
using GymDiaryAPI.Common.Interfaces;
using GymDiaryAPI.DTOs;

namespace GymDiaryAPI.BusinessLayers.Interfaces
{
    public interface IUserBl
    {
        Task<IEnumerable<MemberDto>> GetMembersAsync();
    }
}