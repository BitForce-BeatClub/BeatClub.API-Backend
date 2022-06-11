using System.Collections.Generic;
namespace BeatClub.API.Learning.Domain.Models
{
    public class Creator
    {
        public int Id { get; set; }
    
        public string Name { get; set; }

        public IList<Track> Tracks { get; set; } = new List<Track>();

    }
}

