using System;

namespace GymDiaryAPI.DTOs
{
    public class DiaryDto
    {
        public int Id { get; set; }
        
        public string DiaryName { get; set; }
        
        public int UserId { get; set; }
        
        public int OwnerId { get; set; }
        
        public bool IsPrimary { get; set; }

        public DateTime CreatedDate { get; set; } = new DateTime();

        public DateTime LastUpdateDate { get; set; } = new DateTime();
    }
}