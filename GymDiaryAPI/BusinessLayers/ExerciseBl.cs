using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GymDiaryAPI.BusinessLayers.Interfaces;
using GymDiaryAPI.Repositories.Interfaces;

namespace GymDiaryAPI.BusinessLayers
{
    public class ExerciseBl : BaseBl ,IExerciseBl
    {
        private ExerciseBl(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

    }
}
