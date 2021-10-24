using System.Threading.Tasks;
using AutoMapper;
using GymDiaryAPI.Entities;
using GymDiaryAPI.Repositories.Interfaces;

namespace GymDiaryAPI.Repositories
{
    public class DiaryRepository : IDiaryRepository
    {
    private readonly ApplicationContext _context;
    private readonly IMapper _mapper;

    public DiaryRepository(ApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Diary> CreateDiaryAsync(Diary diary)
        {
            _context.Add(diary);
            await _context.SaveChangesAsync();

            return diary;
        }

         public Task<Diary> GetDiaryByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Diary diary)
        {
            throw new System.NotImplementedException();
        }
  }
}