namespace BeatClub.API.BeatClub.Domain.Models
{
    public class Membership
    {
        public int id { get; set; }
        
        public string title {get; set; }
        
        public int price { get; set; }
        
        public string feature { get; set; }
        
        public string description { get; set; }
        
        public string urlToImage { get; set; }
    }
}