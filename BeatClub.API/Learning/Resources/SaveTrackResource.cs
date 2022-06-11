using System.ComponentModel.DataAnnotations;

namespace BeatClub.API.Learning.Resources
{
    public class SaveTrackResource
    {
        
        [Required]
        public string Cover { get; set; }

        [Required]
        public string TrackUrl { get; set; }
        [Required]
        [MaxLength(30)]
        public string Title { get; set; }
    
        public string Genre { get; set; }
        
        [Required]
        [MaxLength(120)]
        public string Description { get; set; }

        [Required]
        public string Caption { get; set; }
    
        [Required]
        public string Privacy { get; set; }
        
        [Required]
        public int CreatorId { get; set; }
    }
}

