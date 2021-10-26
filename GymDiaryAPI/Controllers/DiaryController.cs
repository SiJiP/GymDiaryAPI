using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GymDiaryAPI.BusinessLayers.Constants;
using GymDiaryAPI.BusinessLayers.Interfaces;
using GymDiaryAPI.Common.Interfaces;
using GymDiaryAPI.Common.Messages;
using GymDiaryAPI.DTOs;
using GymDiaryAPI.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GymDiaryAPI.Controllers
{
    [Authorize]
    public class DiaryController : BaseApiController
    {
        private readonly IDiaryBl _diaryBl;

        public DiaryController(IDiaryBl diaryBl)
        {
            _diaryBl = diaryBl;
        }

        [HttpGet("id/Diary")]
        public async Task<ActionResult<DiaryDto>> GetDiaryByIdAsync(int id)
        {
            DiaryDto diary = await _diaryBl.GetDiaryById(id); 

            return Ok(diary);
        }

        [HttpGet("id/ByUser")]
        public async Task<ActionResult<DiaryDto>> GetDiariesByUserIdAsync(int id)
        {
            IList<DiaryDto> diaries = await _diaryBl.GetDiariesByUserId(id);

            return Ok(diaries);
        }

        [HttpPost]
        public async Task<ActionResult<IResponseMessage>> CreateDiary([FromBody] DiaryDto diaryDto)
        {
            var res = await _diaryBl.CreateDiary(diaryDto);

            if (res != null)
            {
                return Ok(res);
            }

            return BadRequest(new ResponseMessage { Message = Messages.EntityNotFound(nameof(Diary)) });
        }

        [HttpPut]
        public async Task<ActionResult<IResponseMessage>> UpdateDiary([FromBody] DiaryDto diaryDto)
        {
            var res = await _diaryBl.UpdateDiary(diaryDto);

            if (res != null)
            {
                return Ok(res);
            }

            return BadRequest(new ResponseMessage { Message = Messages.EntityNotFound(nameof(Diary)) });
        }
    }
}