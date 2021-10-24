using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GymDiaryAPI.BusinessLayers.Interfaces;
using GymDiaryAPI.Common.Interfaces;
using GymDiaryAPI.DTOs;
using GymDiaryAPI.Entities;
using GymDiaryAPI.Repositories.Interfaces;

namespace GymDiaryAPI.BusinessLayers
{
    public class UserBl : BaseBl, IUserBl
    {
        private UserBl(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<IEnumerable<MemberDto>> GetMembersAsync()
        {
            IEnumerable<User> users = await UnitOfWork.UserRepository.GetUsersAsync();

            IList<MemberDto> mappedUsers = Mapper.Map<IEnumerable<User>, IList<MemberDto>>(users);

            return mappedUsers;
        }

        public Task<MemberDto> GetMemberByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<IResponseObjectMessage<MemberDto>> IUserBl.UpdateMember(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IResponseMessage> DeleteMember(int id)
        {
            throw new NotImplementedException();
        }

        public Task<MemberDto> UpdateUser(int id)
        {
            throw new NotImplementedException();
        }
    }
}
