using System;
using AutoMapper;
using GymDiaryAPI.Repositories.Interfaces;

namespace GymDiaryAPI.BusinessLayers
{
    public class BaseBl
    {
        protected readonly IUnitOfWork UnitOfWork;
        protected readonly IMapper Mapper;

        protected BaseBl(IUnitOfWork unitOfWork, IMapper mapper)
        {
            UnitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            Mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
    }
}
