using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using GymDiaryAPI.BusinessLayers.Interfaces;
using GymDiaryAPI.DTOs;
using GymDiaryAPI.Entities;
using GymDiaryAPI.Interfaces;
using GymDiaryAPI.Repositories.Interfaces;

namespace GymDiaryAPI.BusinessLayers
{
    public class AccountBl : BaseBl, IAccountBl
    {
        private readonly ITokenService _tokenService;

        public AccountBl(IUnitOfWork unitOfWork, IMapper mapper, ITokenService tokenService) : base(unitOfWork, mapper)
        {
            _tokenService = tokenService;
        }

        public async Task<UserDto> CreateUser(RegisterDto registerDto)
        {
            using var hmac = new HMACSHA512();

            var user = new User
            {
                FirstName = registerDto.Firstname,
                LastName = registerDto.Lastname,
                UserName = registerDto.Username.ToLower(),
                DateBirth = registerDto.DateBirth,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
                PasswordSalt = hmac.Key
            };

            await UnitOfWork.UserRepository.CreateUser(user);

            var userDto = new UserDto
            {
                UserName = user.UserName,
                Token = _tokenService.CreateToken(user)
            };

            return userDto;

        }

        public Task<UserDto> SignIn(LoginDto loginDto)
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> IsUserExist(string username)
        {
            var user = await UnitOfWork.UserRepository.GetUserByUsernameAsync(username);

            return user != null;
        }
    }
}