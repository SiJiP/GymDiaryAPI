using GymDiaryAPI.Common.Interfaces;

namespace GymDiaryAPI.Common.Messages
{
    public class ResponseMessage : IResponseMessage
    {
        public string Message { get; set; }
    }
}