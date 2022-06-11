using System.ComponentModel.DataAnnotations;

namespace BeatClub.API.Learning.Resources
{
    public class SaveCreatorResource
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}

