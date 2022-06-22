using System.ComponentModel.DataAnnotations;

namespace BeatClub.API.Learning.Resources
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
        
        //public DateTime CreateAt { get; set; }
        
        [Required]
        public int UserId { get; set; }
    }
}