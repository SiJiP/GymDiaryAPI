using GymDiaryAPI.Entities;

namespace GymDiaryAPI.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}
