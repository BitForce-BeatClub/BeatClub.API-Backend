namespace BeatClub.API.Learning.Domain.Models
{
    public class Membership
    {
        public int Id { get; set; }
        
        public string Title {get; set; }
        
        public int Price { get; set; }
        
        public string Feature { get; set; }
        
        public string Description { get; set; }
        
        public string UrlToImage { get; set; }
    }
}