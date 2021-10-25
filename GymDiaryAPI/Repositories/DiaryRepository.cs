using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GymDiaryAPI.Entities;
using GymDiaryAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GymDiaryAPI.Repositories
{
    public class DiaryRepository : IDiaryRepository
    {
    private readonly ApplicationContext _context;

    public DiaryRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<Diary> CreateDiaryAsync(Diary diary)
        {
            _context.Add(diary);
            await _context.SaveChangesAsync();

            return diary;
        }

        public async Task<Diary> GetDiaryByIdAsync(int id)
        {
            return await _context.Diaries
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.UserId == id);
        }

        public async Task<Diary> UpdateDiaryAsync(Diary diary)
        {
            var entity = await _context.Diaries.FindAsync(diary.Id);

            if (entity != null)
            {
                _context.Diaries.Update(diary);
                await _context.SaveChangesAsync();
            }

            return entity;
        }

        public async Task<Diary> DeleteDiaryAsync(int id)
        {
            var entity = await _context.Diaries.FindAsync(id);

            if (entity != null)
            {
                _context.Remove(entity);
                await _context.SaveChangesAsync();
                
                return entity;
            }

            return null;
        }

        public async Task<IList<Diary>> GetDiariesByUserId(int id)
        {
            return await _context.Diaries
                .AsNoTracking()
                .Where(x => x.UserId == id)
                .ToListAsync();
        }
    }
}