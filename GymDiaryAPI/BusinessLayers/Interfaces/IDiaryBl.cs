using GymDiaryAPI.Common.Interfaces;
using GymDiaryAPI.DTOs;
using GymDiaryAPI.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GymDiaryAPI.BusinessLayers.Interfaces
{
    public interface IDiaryBl
    {
        Task<Diary> CreateDiary(DiaryDto diaryDto);

        Task<IList<DiaryDto>> GetDiariesByUserId(int userId);

        Task<DiaryDto> GetDiaryById(int id);

        Task<Diary> UpdateDiary(DiaryDto diaryDto);

        Task<Diary> DeleteDiary(int id);
    }
}