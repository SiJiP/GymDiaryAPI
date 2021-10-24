using GymDiaryAPI.DTOs;
using GymDiaryAPI.Entities;
using GymDiaryAPI.Interfaces;
using GymDiaryAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using GymDiaryAPI.BusinessLayers.Interfaces;
using GymDiaryAPI.Common.Messages;

namespace GymDiaryAPI.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly ITokenService _tokenService;
        private readonly IAccountBl _accountBl;
        private readonly ApplicationContext _context;

        public AccountController(ApplicationContext context, ITokenService tokenService, IAccountBl accountBl)
        {
            _context = context;
            _tokenService = tokenService;
            _accountBl = accountBl;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register([FromBody] RegisterDto registerDto)
        {
            if (await _accountBl.IsUserExist(registerDto.Username)) 
            {
                return BadRequest("Username is taken");
            }

            Task<UserDto> userDto = _accountBl.CreateUser(registerDto);

            return Ok(new ResponseObjectMessage<Task<UserDto>>
                {
                    Result = userDto,
                    Message = $"User { registerDto.Username } successfully created"
                });
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login([FromBody] LoginDto loginDto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.UserName == loginDto.Username);

            if (user == null) 
            {
                return Unauthorized("Invalid username");
            }

            using var hmac = new HMACSHA512(user.PasswordSalt);

            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.PasswordHash[i])
                {
                    return Unauthorized("Invalid password");
                }
            }

            return new UserDto
            {
                UserName = user.UserName,
                Token = _tokenService.CreateToken(user)
            };
        }

        private async Task<bool> IsUserExist(string username)
        {
            return await _context.Users.AnyAsync(user => user.UserName == username.ToLower());
        }
    }
}
