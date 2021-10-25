using AutoMapper;
using AutoMapper.QueryableExtensions;
using GymDiaryAPI.DTOs;
using GymDiaryAPI.Entities;
using GymDiaryAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymDiaryAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;

        public UserRepository(ApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<User> CreateUser(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _context.Users
                .Include(p => p.Diaries)
                .ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User> GetUserByUsernameAsync(string username)
        {
            var user = await _context.Users
                .SingleOrDefaultAsync(x => x.UserName.ToLower() == username.ToLower());
            
            return user;
        }

        public void Update(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
        }

        public async Task<IEnumerable<MemberDto>> GetMembersAsync()
        {
            return await _context.Users
                .ProjectTo<MemberDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<MemberDto> GetMemberByIdAsync(int id)
        {

            // One of possible variants to map properties manually from database
            // return await _context.Users
            //     .Where(x => x.Id == id)
            //     .Select(user => new MemberDto{
            //         Id = user.Id,
            //         UserName = user.UserName
            //     }).SingleOrDefaultAsync();

            return await _context.Users
                .Where(x => x.Id == id)
                .Include(x => x.Diaries)
                .ProjectTo<MemberDto>(_mapper.ConfigurationProvider) // ProjectTo gets from database only necessary columns what was defined in dto
                .SingleOrDefaultAsync();
        }
  }
}
