using System;
using System.Collections.Generic;

namespace GymDiaryAPI.Entities
{
    public class Diary
    {
        public int Id { get; set; }
        public string DiaryName { get; set; }
        public int UserId { get; set; }
        public int OwnerId { get; set; }
        public bool IsPrimary { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime LastUpdateDate { get; set; }
        public ICollection<Exercise> Exercises { get; set; }
    }
}
