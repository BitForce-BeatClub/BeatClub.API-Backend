using System;
using BeatClub.API.BeatClub.Domain.Models;

namespace BeatClub.API.BeatClub.Resources
{
    public class TrackResource
    {
        public int Id { get; set; }
        
        public string Title { get; set; }
        
        public string Privacy { get; set; }
        
        public string Genre { get; set; }
        
        public string Artist { get; set; }
        
        public string Cover { get; set; }
        
        public string Source { get; set; }
        
        public int UserId { get; set; }
        
        public DateTime PublishDate { get; set; }
       
    }
}