using GymDiaryAPI.Common.Interfaces;

namespace GymDiaryAPI.Common.Messages
{
    public class ResponseObjectMessage<TEntity> : ResponseMessage, IResponseObjectMessage<TEntity>
    {
        public TEntity Result { get; set; }
    }
}