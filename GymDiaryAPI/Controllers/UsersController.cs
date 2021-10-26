using GymDiaryAPI.DTOs;
using GymDiaryAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using GymDiaryAPI.BusinessLayers.Interfaces;

namespace GymDiaryAPI.Controllers
{
    [Authorize]
    public class UsersController : BaseApiController
    {
        private readonly IUserBl _userBl;

        public IUnitOfWork _unitOfWork { get; }

    public UsersController(IUnitOfWork unitOfWork, IUserBl userBl)
    {
        _userBl = userBl;
        _unitOfWork = unitOfWork;
    }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsersAsync() 
        {
            IEnumerable<MemberDto> members = await _userBl.GetMembersAsync();

            return Ok(members);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MemberDto>> GetUserById(int id)
        {
            var user = await _unitOfWork.UserRepository.GetMemberByIdAsync(id);

            return user;
        }
    }

}
