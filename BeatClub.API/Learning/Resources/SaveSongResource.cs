using System;
using System.ComponentModel.DataAnnotations;

namespace BeatClub.API.Learning.Resources
{
    public class SaveSongResource
    {
        
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }
        [Required]
        [MaxLength(200)]
        public string UrlToImage { get; set; }
        [Required]
        [MaxLength(120)]
        public string Description { get; set; }
        [Required]
        public int UserId { get; set; }
    }
}