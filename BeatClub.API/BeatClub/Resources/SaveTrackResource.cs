using System;
using System.ComponentModel.DataAnnotations;

namespace BeatClub.API.BeatClub.Resources
{
    public class SaveTrackResource
    {
        
        [Required]
        [MaxLength(50)]
        public string title { get; set; }
        [Required]
        [MaxLength(50)]
        public string privacy { get; set; }
        [Required]
        [MaxLength(50)]
        public string artist { get; set; }
        [Required]
        [MaxLength(50)]
        public string genre { get; set; }
        [Required]
        [MaxLength(200)]
        public string cover { get; set; }
        [Required]
        [MaxLength(200)]
        public string source { get; set; }
        [Required]
        public string userId { get; set; }
        [Required]
        public DateTime publishDate { get; set; }

    }
}