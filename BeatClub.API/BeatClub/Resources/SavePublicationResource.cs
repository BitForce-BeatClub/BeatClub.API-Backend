using System.ComponentModel.DataAnnotations;

namespace BeatClub.API.BeatClub.Resources
{
    public class SavePublicationResource
    {
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }
        [Required]
        [MaxLength(120)]
        public string Description { get; set; }
        /*[Required]
        public DateTime CreateAt { get; set; }*/
        [Required]
        public int UserId { get; set; }
        
    }
}