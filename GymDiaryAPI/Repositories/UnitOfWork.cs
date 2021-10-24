using System.Threading.Tasks;
using AutoMapper;
using GymDiaryAPI.Repositories.Interfaces;

namespace GymDiaryAPI.Repositories
{
  public class UnitOfWork : IUnitOfWork
  {
    private readonly ApplicationContext _context;
    private readonly IMapper _mapper;

    public UnitOfWork(ApplicationContext context, IMapper mapper)
    {
      _context = context;
      _mapper = mapper;
    }

    public IUserRepository UserRepository => new UserRepository(_context, _mapper);

    public IDiaryRepository DiaryRepository => new DiaryRepository(_context, _mapper);

    public IExerciseRepository ExerciseRepository => new ExerciseRepository(_context, _mapper);

    public async Task<bool> Complete()
    {
      return await _context.SaveChangesAsync() > 0;
    }

    public bool HasChanges()
    {
      return _context.ChangeTracker.HasChanges();
    }
  }
}