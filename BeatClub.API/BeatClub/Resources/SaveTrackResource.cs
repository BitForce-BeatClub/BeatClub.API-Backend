using System;
using System.ComponentModel.DataAnnotations;

namespace BeatClub.API.BeatClub.Resources
{
    public class SaveTrackResource
    {
        
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }
        [Required]
        [MaxLength(50)]
        public string Privacy { get; set; }
        [Required]
        [MaxLength(50)]
        public string Artist { get; set; }
        [Required]
        [MaxLength(200)]
        public string Cover { get; set; }
        [Required]
        [MaxLength(200)]
        public string Source { get; set; }
        [Required]
        public int UserId { get; set; }
        
    }
}