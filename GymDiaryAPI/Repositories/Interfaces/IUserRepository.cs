using GymDiaryAPI.DTOs;
using GymDiaryAPI.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GymDiaryAPI.Repositories.Interfaces
{
    public interface IUserRepository
    {
        void Update(User user);

        Task<User> CreateUser(User user);

        Task<IEnumerable<User>> GetUsersAsync();
        
        Task<User> GetUserByIdAsync(int id);
        
        Task<User> GetUserByUsernameAsync(string username);
        
        Task<IEnumerable<MemberDto>> GetMembersAsync();
        
        Task<MemberDto> GetMemberByIdAsync(int id);
    }
}
