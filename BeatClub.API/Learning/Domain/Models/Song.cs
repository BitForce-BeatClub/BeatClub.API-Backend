using System;

namespace BeatClub.API.Learning.Domain.Models
{
    public class Song
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public string Gender { get; set; }
        
        public string Description { get; set; }
        
        //public DateTime CreateAt { get; set; }
        
        public int SongListId { get; set; }
        public SongList SongList { get; set; }
    }
}