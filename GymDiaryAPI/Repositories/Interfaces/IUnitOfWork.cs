using System;
using System.Threading.Tasks;

namespace GymDiaryAPI.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        
        IDiaryRepository DiaryRepository { get; }

        IExerciseRepository ExerciseRepository { get; }

        Task<bool> Complete();
        
        bool HasChanges();
    }
}