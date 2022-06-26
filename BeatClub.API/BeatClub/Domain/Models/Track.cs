using System;

namespace BeatClub.API.BeatClub.Domain.Models
{
    public class Track
    {
        public int id { get; set; }
        public string title { get; set; }
        public string privacy { get; set; }
        public string artist { get; set; }
        public string genre { get; set; }
        public string cover { get; set; }
        public string source { get; set; }
        public DateTime publishDate { get; set; }
        //Relationships
        public string userId { get; set; }
        public User User { get; set; }
    }
}