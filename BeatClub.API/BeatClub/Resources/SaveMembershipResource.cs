using System.ComponentModel.DataAnnotations;

namespace BeatClub.API.BeatClub.Resources
{
    public class SaveMembershipResource
    {
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        [MaxLength(120)]
        public string Feature { get; set; }
        [Required]
        [MaxLength(120)]
        public string Description { get; set; }
        [Required]
        [MaxLength(200)]
        public string UrlToImage { get; set; }
    }
}