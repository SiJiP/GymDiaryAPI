using System.Threading.Tasks;
using GymDiaryAPI.DTOs;
using GymDiaryAPI.Entities;

namespace GymDiaryAPI.BusinessLayers.Interfaces
{
    public interface IAccountBl
    {
        Task<UserDto> CreateUser(RegisterDto registerDto);

        Task<bool> IsUserExist(string username);

        Task<User> GetUserByUserName(string username);
    }
}