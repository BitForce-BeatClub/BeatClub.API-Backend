using System.ComponentModel.DataAnnotations;

namespace BeatClub.API.Learning.Resources
{
    public class SaveUserResource
    {
        
        [Required]
        [MaxLength(50)]
        public string Nickname { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string Password { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string TypeUser { get; set; }
    }
}