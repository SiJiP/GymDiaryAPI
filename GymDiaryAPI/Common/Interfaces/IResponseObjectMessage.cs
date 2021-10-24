namespace GymDiaryAPI.Common.Interfaces
{
    public interface IResponseObjectMessage<TEntity> : IResponseMessage
    {
        TEntity Result { get; set; }
    }
}