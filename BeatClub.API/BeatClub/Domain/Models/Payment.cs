namespace BeatClub.API.BeatClub.Domain.Models
{
    public class Payment
    {
        public int Id { get; set; }
        
        public string Description { get; set; }
        
        public string PayMethod { get; set; }
        
        public int Amount { get; set; }
        //public DateTime CreateAt { get; set; }
        
        public int UserId { get; set; }
        public User User { get; set; }
    }
}