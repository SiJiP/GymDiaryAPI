using System;
using System.ComponentModel.DataAnnotations;

namespace GymDiaryAPI.DTOs
{
    public class RegisterDto
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        [Required]
        public string Username { get; set; }
        public DateTime DateBirth { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
