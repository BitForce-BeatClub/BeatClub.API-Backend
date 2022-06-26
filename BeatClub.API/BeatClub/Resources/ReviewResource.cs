using System;
using BeatClub.API.BeatClub.Domain.Models;

namespace BeatClub.API.BeatClub.Resources
{
    public class ReviewResource
    {
        public int Id { get; set; }
        
        public string Description { get; set; }
        
        public int Qualification { get; set; }
        
        public DateTime CreateAt { get; set; }
        
        public string UserProducerId { get; set; }
       
        public string UserArtistId { get; set; }
        
    }
}