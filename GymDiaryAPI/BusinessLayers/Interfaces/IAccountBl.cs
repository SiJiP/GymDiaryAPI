using System.Threading.Tasks;
using GymDiaryAPI.DTOs;

namespace GymDiaryAPI.BusinessLayers.Interfaces
{
    public interface IAccountBl
    {
        Task<UserDto> CreateUser(RegisterDto registerDto);

        Task<UserDto> SignIn(LoginDto loginDto);

        Task<bool> IsUserExist(string username);
    }
}