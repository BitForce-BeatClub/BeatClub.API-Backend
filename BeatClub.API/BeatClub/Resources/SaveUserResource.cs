using System.ComponentModel.DataAnnotations;

namespace BeatClub.API.BeatClub.Resources
{
    public class SaveUserResource
    {
        
        [Required]
        [MaxLength(50)]
        public string Nickname { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string Firstname { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string Lastname { get; set; }
        
        [Required]
        [MaxLength(200)]
        public string UrlToImage { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string TypeUser { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string Trend { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string Result { get; set; }
        
        [Required]
        public int MembershipId { get; set; }
    }
}