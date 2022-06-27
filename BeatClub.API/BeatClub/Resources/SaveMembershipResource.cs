using System.ComponentModel.DataAnnotations;

namespace BeatClub.API.BeatClub.Resources
{
    public class SaveMembershipResource
    {
        [Required]
        [MaxLength(50)]
        public string title { get; set; }
        [Required]
        public int price { get; set; }
        [Required]
        [MaxLength(120)]
        public string feature { get; set; }
        [Required]
        [MaxLength(120)]
        public string description { get; set; }
        [Required]
        [MaxLength(200)]
        public string urlToImage { get; set; }
    }
}