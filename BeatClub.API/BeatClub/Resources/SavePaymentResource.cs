using System;
using System.ComponentModel.DataAnnotations;

namespace BeatClub.API.BeatClub.Resources
{
    public class SavePaymentResource
    {
        [Required]
        [MaxLength(50)]
        public string plan { get; set; }
        
        [Required]
        public int price { get; set; }
        
        [Required]
        public DateTime date { get; set; }
        
        [Required]
        public string userId { get; set; }
        
    }
}