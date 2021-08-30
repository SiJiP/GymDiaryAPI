using System;

namespace GymDiaryAPI.Entities
{
    public class Diary
    {
        public int Id { get; set; }
        public string DiaryName { get; set; }
        public int UserId { get; set; }
        public int OwnerId { get; set; }
        public bool IsPrimary { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
    }
}
