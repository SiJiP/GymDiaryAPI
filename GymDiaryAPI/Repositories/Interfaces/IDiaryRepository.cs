using System.Collections.Generic;
using System.Threading.Tasks;
using GymDiaryAPI.Entities;

namespace GymDiaryAPI.Repositories.Interfaces
{
    public interface IDiaryRepository
    {
        Task<Diary> UpdateDiaryAsync(Diary diary);
        
        Task<Diary> GetDiaryByIdAsync(int id);

        Task<IList<Diary>> GetDiariesByUserId(int id);

        Task<Diary> CreateDiaryAsync (Diary diary);

        Task<Diary> DeleteDiaryAsync(int id);
    }
}