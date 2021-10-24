using System.Linq;
using AutoMapper;
using GymDiaryAPI.DTOs;
using GymDiaryAPI.Entities;

namespace GymDiaryAPI.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, MemberDto>()
                .ForMember(dest => dest.DiaryName, opt => opt.MapFrom(src => 
                    src.Diaries.FirstOrDefault(x => x.IsPrimary).DiaryName));
            CreateMap<Diary, DiaryDto>();
            CreateMap<Exercise, ExerciseDto>();
        }
    }
}
