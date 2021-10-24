using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GymDiaryAPI.Entities;
using GymDiaryAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GymDiaryAPI.Repositories
{
  public class ExerciseRepository : IExerciseRepository
  {
    private readonly ApplicationContext _context;
    private readonly IMapper _mapper;

    public ExerciseRepository(ApplicationContext context, IMapper mapper)
    {
      _context = context;
      _mapper = mapper;
    }

    public async Task<Exercise> CreateExerciseAsync(Exercise exercise)
    {
       _context.Exercises.Add(exercise);
      await _context.SaveChangesAsync();

      return exercise;
    }

    public async Task<string> DeleteExerciseAsync(int id)
    {
        Exercise exerciseToDelete = await _context.Exercises.SingleOrDefaultAsync(x => x.Id == id);
        
        if (exerciseToDelete != null) {
            _context.Exercises.Remove(exerciseToDelete);
            await _context.SaveChangesAsync();

            return "Deleted successful";
        }

        return "Somethings wrong happened";

    }

    public async Task<Exercise> GetExerciseByIdAsync(int id)
    { 
        var selectedExercise = await _context.Exercises.SingleOrDefaultAsync(x => x.Id == id);

        if (selectedExercise == null)
        {
            return default;
        }

        return selectedExercise;
    }

    public async Task<IEnumerable<Exercise>> GetExercisesAsync(int userId)
    {
        return await _context.Exercises.ToListAsync();
    }

    public async Task<IEnumerable<Exercise>> GetExercisesByDiaryIdAsync(int diaryId)
    {
        return await _context.Exercises.Where(x => x.DiaryId == diaryId)
            .OrderBy(x => x.Name)
            .ToListAsync();
    }

    public async Task<Exercise> UpdateExerciseAsync(Exercise exercise)
    {
        var elementForUpdate = await _context.Exercises.SingleOrDefaultAsync(x => x.Id == exercise.Id);

        if (elementForUpdate != null)
        {
            _context.Exercises.Update(exercise);
            _context.SaveChangesAsync();

            return exercise;
        }

        return null;

    }
  }
}