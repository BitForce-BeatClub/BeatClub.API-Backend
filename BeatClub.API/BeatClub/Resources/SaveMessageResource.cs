using System;
using System.ComponentModel.DataAnnotations;

namespace BeatClub.API.BeatClub.Resources
{
    public class SaveMessageResource
    {
        [Required]
        [MaxLength(120)]
        public string Content { get; set; }
        
        [Required]
        public int UserIdTo { get; set; }
        
        [Required]
        public int UserIdFrom { get; set; }
        
        [Required]
        public DateTime MessageDate { get; set; }
        
    }
}