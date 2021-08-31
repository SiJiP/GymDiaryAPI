﻿using GymDiaryAPI.DTOs;
using GymDiaryAPI.Entities;
using GymDiaryAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GymDiaryAPI.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly ApplicationContext _context;

        public AccountController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register([FromBody] RegisterDto registedDto)
        {
            if (await IsUserExist(registedDto.Username)) 
            {
                return BadRequest("Username is taken");
            }

            using var hmac = new HMACSHA512();

            var user = new User
            {
                FirstName = registedDto.Firstname,
                LastName = registedDto.Lastname,
                UserName = registedDto.Username.ToLower(),
                DateBirth = registedDto.DateBirth,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registedDto.Password)),
                PasswordSalt = hmac.Key
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }

        [HttpPost("login")]
        public async Task<ActionResult<User>> Login([FromBody] LoginDto loginDto)
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

            return user;
        }

        private async Task<bool> IsUserExist(string username)
        {
            return await _context.Users.AnyAsync(user => user.UserName == username.ToLower());
        }
    }
}