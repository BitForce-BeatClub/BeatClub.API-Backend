namespace BeatClub.API.Learning.Resources
{
    public class TrackResource
    {
        public int Id { get; set; }

        public string Cover { get; set; }

        public string TrackUrl { get; set; }
    
        public string Title { get; set; }
    
        public string Genre { get; set; }
        public string Description { get; set;}
    
        public string Caption { get; set; }
    
        public string Privacy { get; set; }
    
        //public DateTime CreatAt { get; set; }
    
        public CreatorResource Creator { get; set; }
    }
}

