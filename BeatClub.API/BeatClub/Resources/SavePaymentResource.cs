using System;
using System.ComponentModel.DataAnnotations;

namespace BeatClub.API.BeatClub.Resources
{
    public class SavePaymentResource
    {
        [Required]
        [MaxLength(120)]
        public string Description { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string PayMethod { get; set; }
        
        [Required]
        public int Amount { get; set; }
        
        [Required]
        public DateTime CreateAt { get; set; }
        
        [Required]
        public string UserId { get; set; }
    }
}