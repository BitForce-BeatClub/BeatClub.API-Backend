using BeatClub.API.BeatClub.Domain.Models;

namespace BeatClub.API.BeatClub.Resources
{
    public class ReviewResource
    {
        public int Id { get; set; }
        
        public string Description { get; set; }
        
        public int Qualification { get; set; }
        
        //public DateTime CreateAt { get; set; }
        
        public int UserProducerId { get; set; }
       
        public int UserArtistId { get; set; }
        
    }
}