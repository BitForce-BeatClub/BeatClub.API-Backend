﻿using System;

namespace BeatClub.API.Learning.Domain.Models
{
    public class SongList
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public string Description { get; set; }
        
        //public DateTime CreateAt { get; set; }
        
        public int UserId { get; set; }
        public User User { get; set; }
        
    }
}