using System;
using System.Collections.Generic;

namespace GymDiaryAPI.DTOs
{
    public class MemberDto
    {
        public int Id { get; set; }
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public string UserName { get; set; }
        
        public DateTime DateBirth { get; set; }
        
        public string DiaryName { get; set; }
        
        public ICollection<DiaryDto> Diaries { get; set; }
        
        public DateTime Created { get; set; }
        
        public DateTime LastActivities { get; set; } 
        
        public string Gender { get; set; }
    }
}
