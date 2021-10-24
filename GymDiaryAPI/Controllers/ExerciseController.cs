using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GymDiaryAPI.DTOs;
using GymDiaryAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GymDiaryAPI.Controllers
{
  [Authorize]
  public class ExerciseController : BaseApiController
  {
    public IUnitOfWork _unitOfWork { get; }
    public ExerciseController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    public Task<ActionResult<IEnumerable<ExerciseDto>>> GetUserExercisesAsync(int id)
    {
        return null;
    }
  }
}