using System.Collections.Generic;
using System.Threading.Tasks;
using GymDiaryAPI.Entities;

namespace GymDiaryAPI.Repositories.Interfaces
{
    public interface IExerciseRepository
    {
        Task<IEnumerable<Exercise>> GetExercisesAsync(int userId);
        
        Task<Exercise> GetExerciseByIdAsync(int id);
        
        Task<IEnumerable<Exercise>> GetExercisesByDiaryIdAsync(int diaryId);
        
        Task<Exercise> CreateExerciseAsync(Exercise exercise);
        
        Task<Exercise> UpdateExerciseAsync(Exercise exercise);
        
        Task<string> DeleteExerciseAsync(int id);
    }
}