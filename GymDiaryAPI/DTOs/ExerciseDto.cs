using System;

namespace GymDiaryAPI.DTOs
{
    public class ExerciseDto
    {
        public int Id { get; set; }
        
        public int NumberOfApproaches { get; set; }
        
        public int NumberOfRepetitions { get; set; }
        
        public int Weight { get; set; }
        
        public DateTime CreateDate { get; set; }
        
        public int DiaryId { get; set; }
        
        public int UserId { get; set; }
    }
}