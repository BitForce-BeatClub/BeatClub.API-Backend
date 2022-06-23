using System.ComponentModel.DataAnnotations;

namespace BeatClub.API.BeatClub.Resources
{
    public class SaveReviewResource
    {
        [Required]
        [MaxLength(120)]
        public string Description { get; set; }
        
        [Required]
        public int Qualification { get; set; }
        
        [Required]
        public int UserProducerId { get; set; }
        
        [Required]
        public int UserArtistId { get; set; }
        
    }
}