using System;

namespace BeatClub.API.Learning.Resources
{
    public class SongResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Gender { get; set; }
        //public DateTime CreateAt { get; set; }
        public SongListResource SongList { get; set; }
    }
}