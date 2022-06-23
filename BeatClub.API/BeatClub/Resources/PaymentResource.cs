using BeatClub.API.BeatClub.Domain.Models;

namespace BeatClub.API.BeatClub.Resources
{
    public class PaymentResource
    {
        public int Id { get; set; }
        
        public string Description { get; set; }
        
        public string PayMethod { get; set; }
        
        public int Amount { get; set; }
        
        //public DateTime CreateAt { get; set; }
        
        public int UserId { get; set; }
       
    }
}