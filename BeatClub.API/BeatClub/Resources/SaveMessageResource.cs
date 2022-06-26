using System;
using System.ComponentModel.DataAnnotations;

namespace BeatClub.API.BeatClub.Resources
{
    public class SaveMessageResource
    {
        [Required]
        [MaxLength(120)]
        public string Content { get; set; }
        
        /*[MaxLength(20)]
        public DateTime CreatAt { get; set; }*/
        
        [Required]
        public string UserProducerId { get; set; }
        
        [Required]
        public string UserArtistId { get; set; }
        
        [Required]
        public DateTime CreateAt { get; set; }
    }
}