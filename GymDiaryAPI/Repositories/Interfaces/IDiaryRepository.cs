using System.Collections.Generic;
using System.Threading.Tasks;
using GymDiaryAPI.Entities;

namespace GymDiaryAPI.Repositories.Interfaces
{
    public interface IDiaryRepository
    {
        void Update(Diary diary);
        Task<Diary> GetDiaryByIdAsync(int id);

        Task<Diary> CreateDiaryAsync (Diary diary);
    }
}