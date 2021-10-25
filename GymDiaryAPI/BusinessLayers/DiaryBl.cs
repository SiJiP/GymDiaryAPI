using AutoMapper;
using GymDiaryAPI.BusinessLayers.Interfaces;
using GymDiaryAPI.DTOs;
using GymDiaryAPI.Entities;
using GymDiaryAPI.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymDiaryAPI.BusinessLayers
{
    public class DiaryBl : BaseBl, IDiaryBl
    {
        protected DiaryBl(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<Diary> CreateDiary(DiaryDto diaryDto)
        {
            var diary = Mapper.Map<DiaryDto, Diary>(diaryDto);
            var res = await UnitOfWork.DiaryRepository.CreateDiaryAsync(diary);

            return res;
        }

        public async Task<Diary> DeleteDiary(int id)
        {
            var diary = await UnitOfWork.DiaryRepository.DeleteDiaryAsync(id);


            return diary;
        }

        public async Task<DiaryDto> GetDiaryById(int id)
        {
            Diary diary = await UnitOfWork.DiaryRepository.GetDiaryByIdAsync(id);

            return Mapper.Map<Diary, DiaryDto>(diary);
        }

        public async Task<IList<DiaryDto>> GetDiariesByUserId(int userId)
        {
            IList<Diary> diaries = await UnitOfWork.DiaryRepository.GetDiariesByUserId(userId);

            return Mapper.Map<IList<Diary>, IList<DiaryDto>>(diaries)
                .OrderBy(x => x.LastUpdateDate)
                .ToList();
        }

        public async Task<Diary> UpdateDiary(DiaryDto diaryDto)
        {
            var diaryFromDto = Mapper.Map<DiaryDto, Diary>(diaryDto);
            var res = await UnitOfWork.DiaryRepository.UpdateDiaryAsync(diaryFromDto);


            return res;
        }
    }
}
