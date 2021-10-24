using System;
using System.Threading.Tasks;
using GymDiaryAPI.DTOs;
using GymDiaryAPI.Entities;
using GymDiaryAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GymDiaryAPI.Controllers
{
    [Authorize]
    public class DiaryController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public DiaryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("id")]
        public async Task<ActionResult<DiaryDto>> GetDiaryByIdAsync(int id)
        {
            var diary = await _unitOfWork.DiaryRepository.GetDiaryByIdAsync(id);

            return Ok(diary);
        }

        [HttpPost]
        public async Task<ActionResult<Diary>> CreateDiary([FromBody] DiaryDto diaryDto)
        {
            var diary = new Diary 
            {
                DiaryName = diaryDto.DiaryName,
                UserId = diaryDto.UserId,
                OwnerId = diaryDto.OwnerId,
                IsPrimary = diaryDto.IsPrimary,
                LastUpdateDate = DateTime.Now
            };

            return await _unitOfWork.DiaryRepository.CreateDiaryAsync(diary);
        } 
    }
}