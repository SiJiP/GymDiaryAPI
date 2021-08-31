using System;
using System.Collections.Generic;

namespace GymDiaryAPI.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public DateTime DateBirth { get; set; }
        public ICollection<Diary> Diaries { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}
