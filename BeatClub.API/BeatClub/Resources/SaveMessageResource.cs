using System;
using System.ComponentModel.DataAnnotations;

namespace BeatClub.API.BeatClub.Resources
{
    public class SaveMessageResource
    {
        [Required]
        [MaxLength(120)]
        public string content { get; set; }
        
        [Required]
        public string userIdFrom { get; set; }
        
        [Required]
        public string userIdTo { get; set; }
        
        [Required]
        public DateTime messageDate { get; set; }
        
    }
}